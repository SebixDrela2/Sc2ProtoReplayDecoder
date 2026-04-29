#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#define VECTORIZE_MEMORY_MOVE
#endif

using ICSharpCode.SharpZipLib.Checksum;
using System.Runtime.Intrinsics.X86;

namespace MPQArchive.Bzip;

/// <summary>
/// An input stream that decompresses files in the BZip2 format.
/// Optimized with SIMD vectorization support for:
/// - SSE2/SSE3 (128-bit operations)
/// - AVX/AVX2 (256-bit operations)
/// - SSE/AVX instruction sets for bulk memory operations and MTF shifting
/// Note: AVX512 support can be added via System.Runtime.Intrinsics.X86.Avx512 when available in future .NET versions
/// </summary>
/// 

public partial class FastBZip2InputStream
{
    public override int ReadByte()
    {
        Span<int> cftab = stackalloc int[257];

        if (streamEnd)
        {
            return -1;
        }

        int retChar = currentChar;
        switch (currentState)
        {
            case RAND_PART_B_STATE:
                goto SetupRandPartB;

            case RAND_PART_C_STATE:
                goto SetupRandPartC;

            case NO_RAND_PART_B_STATE:
                goto SetupNoRandPartB;

            case NO_RAND_PART_C_STATE:
                goto SetupNoRandPartC;

            case START_BLOCK_STATE:
            case NO_RAND_PART_A_STATE:
            case RAND_PART_A_STATE:
                break;
        }

    Exit:
        return retChar;

    SetupRandPartB:
        {
            if (ch2 != chPrev)
            {
                currentState = RAND_PART_A_STATE;
                count = 1;
                goto SetupRandPartA;
            }
            else
            {
                count++;
                if (count >= 4)
                {
                    z = ll8[tPos];
                    tPos = tt[tPos];
                    if (rNToGo == 0)
                    {
                        rNToGo = FastBZip2InputConstants.RandomNumbers[rTPos];
                        rTPos++;
                        if (rTPos == 512)
                        {
                            rTPos = 0;
                        }
                    }
                    rNToGo--;
                    z ^= (byte)((rNToGo == 1) ? 1 : 0);
                    j2 = 0;
                    currentState = RAND_PART_C_STATE;
                    goto SetupRandPartC;
                }
                else
                {
                    currentState = RAND_PART_A_STATE;
                    goto SetupRandPartA;
                }
            }
        }
        goto Exit;
        // SetupRandPartB

        SetupRandPartC:
        {
            if (j2 < (int)z)
            {
                currentChar = ch2;
                mCrc.Update(ch2);
                j2++;
            }
            else
            {
                currentState = RAND_PART_A_STATE;
                i2++;
                count = 0;
                goto SetupRandPartA;
            }
        }
        goto Exit;
        // SetupRandPartC

        SetupNoRandPartB:
        {
            if (ch2 != chPrev)
            {
                currentState = NO_RAND_PART_A_STATE;
                count = 1;
                goto SetupNoRandPartA;
            }
            else
            {
                count++;
                if (count >= 4)
                {
                    z = ll8[tPos];
                    tPos = tt[tPos];
                    currentState = NO_RAND_PART_C_STATE;
                    j2 = 0;
                    goto SetupNoRandPartC;
                }
                else
                {
                    currentState = NO_RAND_PART_A_STATE;
                    goto SetupNoRandPartA;
                }
            }
        }
        goto Exit;
        // SetupNoRandPartB

        SetupNoRandPartC:
        {
            if (j2 < (int)z)
            {
                currentChar = ch2;
                mCrc.Update(ch2);
                j2++;
            }
            else
            {
                currentState = NO_RAND_PART_A_STATE;
                i2++;
                count = 0;
                goto SetupNoRandPartA;
            }
        }
        goto Exit;
        // SetupNoRandPartC

        SetupRandPartA:
        {
            if (i2 <= last)
            {
                chPrev = ch2;
                ch2 = ll8[tPos];
                tPos = tt[tPos];
                if (rNToGo == 0)
                {
                    rNToGo = FastBZip2InputConstants.RandomNumbers[rTPos];
                    rTPos++;
                    if (rTPos == 512)
                    {
                        rTPos = 0;
                    }
                }
                rNToGo--;
                ch2 ^= (int)((rNToGo == 1) ? 1 : 0);
                i2++;

                currentChar = ch2;
                currentState = RAND_PART_B_STATE;
                mCrc.Update(ch2);
            }
            else
            {
                EndBlock();
                InitBlock();
                goto SetupBlock;
            }
        }
        goto Exit;

        SetupNoRandPartA:
        {
            if (i2 <= last)
            {
                chPrev = ch2;
                ch2 = ll8[tPos];
                tPos = tt[tPos];
                i2++;

                currentChar = ch2;
                currentState = NO_RAND_PART_B_STATE;
                mCrc.Update(ch2);
            }
            else
            {
                EndBlock();
                InitBlock();
                goto SetupBlock;
            }
        }
        goto Exit;

        SetupBlock:
        {

            int value = 0;
            for (int i = 0; i < 256; i++)
            {
                cftab[i] = value;
                value += unzftab[i];
            }

            cftab[256] = value;

            for (int i = 0; i <= last; i++)
            {
                byte ch = ll8[i];
                tt[cftab[ch]] = i;
                cftab[ch]++;
            }

            tPos = tt[origPtr];

            count = 0;
            i2 = 0;
            ch2 = 256;   /*-- not a char and not EOF --*/

            if (blockRandomised)
            {
                rNToGo = 0;
                rTPos = 0;
                goto SetupRandPartA;
            }
            else
            {
                goto SetupNoRandPartA;
            }
        }
        goto Exit;
    }
}

public partial class FastBZip2InputStream : Stream
{
    #region Constants

    private const int START_BLOCK_STATE = 1;
    private const int RAND_PART_A_STATE = 2;
    private const int RAND_PART_B_STATE = 3;
    private const int RAND_PART_C_STATE = 4;
    private const int NO_RAND_PART_A_STATE = 5;
    private const int NO_RAND_PART_B_STATE = 6;
    private const int NO_RAND_PART_C_STATE = 7;

#if VECTORIZE_MEMORY_MOVE
    private static readonly int VectorSize = System.Numerics.Vector<byte>.Count;
#endif // VECTORIZE_MEMORY_MOVE

    #endregion Constants

    #region Instance Fields

    /*--
		index of the last char in the block, so
		the block size == last + 1.
		--*/
    private int last;

    /*--
		index in zptr[] of original string after sorting.
		--*/
    private int origPtr;

    /*--
		always: in the range 0 .. 9.
		The current block size is 100000 * this number.
		--*/
    private int blockSize100k;

    private bool blockRandomised;

    private int bsBuff;
    private int bsLive;
    private BZip2Crc mCrc = new();

    private bool[] inUse = new bool[256];
    private int nInUse;

    private byte[] seqToUnseq = new byte[256];
    private byte[] unseqToSeq = new byte[256];

    private byte[] selector = new byte[FastBZip2InputConstants.MaximumSelectors];
    private byte[] selectorMtf = new byte[FastBZip2InputConstants.MaximumSelectors];

    private int[] tt;
    private byte[] ll8;

    /*--
		freq table collected to save a pass over the data
		during decompression.
		--*/
    private int[] unzftab = new int[256];

    private int[][] limit = new int[FastBZip2InputConstants.GroupCount][];
    private int[][] baseArray = new int[FastBZip2InputConstants.GroupCount][];
    private int[][] perm = new int[FastBZip2InputConstants.GroupCount][];
    private int[] minLens = new int[FastBZip2InputConstants.GroupCount];

    private readonly ArraySegment<byte> _baseInput;
    private long _position = 0;
    private ReadOnlySpan<byte> BaseSpan => _baseInput;


    private bool streamEnd;

    private int currentChar = -1;

    private int currentState = START_BLOCK_STATE;

    private int storedBlockCRC, storedCombinedCRC;
    private int computedBlockCRC;
    private uint computedCombinedCRC;

    private int count, chPrev, ch2;
    private int tPos;
    private int rNToGo;
    private int rTPos;
    private int i2, j2;
    private byte z;

    #endregion Instance Fields

    /// <summary>
    /// Construct instance for reading from stream
    /// </summary>
    /// <param name="stream">Data source</param>
    public FastBZip2InputStream(ArraySegment<byte> data)
    {
        // init arrays
        for (int i = 0; i < FastBZip2InputConstants.GroupCount; ++i)
        {
            limit[i] = new int[FastBZip2InputConstants.MaximumAlphaSize];
            baseArray[i] = new int[FastBZip2InputConstants.MaximumAlphaSize];
            perm[i] = new int[FastBZip2InputConstants.MaximumAlphaSize];
        }

        //baseStream = stream;
        bsLive = 0;
        bsBuff = 0;
        _baseInput = data;

        Initialize();
        InitBlock();
        SetupBlock();
    }

    /// <summary>
    /// Get/set flag indicating ownership of underlying stream.
    /// When the flag is true <see cref="Stream.Dispose()" /> will close the underlying stream also.
    /// </summary>
    public bool IsStreamOwner { get; set; } = true;

    #region Stream Overrides

    /// <summary>
    /// Gets a value indicating if the stream supports reading
    /// </summary>
    public override bool CanRead => true;

    /// <summary>
    /// Gets a value indicating whether the current stream supports seeking.
    /// </summary>
    public override bool CanSeek => true;

    /// <summary>
    /// Gets a value indicating whether the current stream supports writing.
    /// This property always returns false
    /// </summary>
    public override bool CanWrite => false;

    /// <summary>
    /// Gets the length in bytes of the stream.
    /// </summary>
    public override long Length => BaseSpan.Length;

    /// <summary>
    /// Gets the current position of the stream.
    /// Setting the position is not supported and will throw a NotSupportException.
    /// </summary>
    /// <exception cref="NotSupportedException">Any attempt to set the position.</exception>
    public override long Position
    {
        get => _position;
        set => throw new NotSupportedException("BZip2InputStream position cannot be set");
    }

    /// <summary>
    /// Flushes the stream.
    /// </summary>
    public override void Flush() { }

    /// <summary>
    /// Set the streams position.  This operation is not supported and will throw a NotSupportedException
    /// </summary>
    /// <param name="offset">A byte offset relative to the <paramref name="origin"/> parameter.</param>
    /// <param name="origin">A value of type <see cref="SeekOrigin"/> indicating the reference point used to obtain the new position.</param>
    /// <returns>The new position of the stream.</returns>
    /// <exception cref="NotSupportedException">Any access</exception>
    public override long Seek(long offset, SeekOrigin origin)
    {
        throw new NotSupportedException("BZip2InputStream Seek not supported");
    }

    /// <summary>
    /// Sets the length of this stream to the given value.
    /// This operation is not supported and will throw a NotSupportedExceptionortedException
    /// </summary>
    /// <param name="value">The new length for the stream.</param>
    /// <exception cref="NotSupportedException">Any access</exception>
    public override void SetLength(long value)
    {
        throw new NotSupportedException("BZip2InputStream SetLength not supported");
    }

    /// <summary>
    /// Writes a block of bytes to this stream using data from a buffer.
    /// This operation is not supported and will throw a NotSupportedException
    /// </summary>
    /// <param name="buffer">The buffer to source data from.</param>
    /// <param name="offset">The offset to start obtaining data from.</param>
    /// <param name="count">The number of bytes of data to write.</param>
    /// <exception cref="NotSupportedException">Any access</exception>
    public override void Write(byte[] buffer, int offset, int count)
    {
        throw new NotSupportedException("BZip2InputStream Write not supported");
    }

    /// <summary>
    /// Writes a byte to the current position in the file stream.
    /// This operation is not supported and will throw a NotSupportedException
    /// </summary>
    /// <param name="value">The value to write.</param>
    /// <exception cref="NotSupportedException">Any access</exception>
    public override void WriteByte(byte value)
    {
        throw new NotSupportedException("BZip2InputStream WriteByte not supported");
    }

    /// <summary>
    /// Read a sequence of bytes and advances the read position by one byte.
    /// </summary>
    /// <param name="buffer">Array of bytes to store values in</param>
    /// <param name="offset">Offset in array to begin storing data</param>
    /// <param name="count">The maximum number of bytes to read</param>
    /// <returns>The total number of bytes read into the buffer. This might be less
    /// than the number of bytes requested if that number of bytes are not
    /// currently available or zero if the end of the stream is reached.
    /// </returns>
    public override int Read(byte[] buffer, int offset, int count)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException(nameof(buffer));
        }

        Span<byte> targetSpan = new Span<byte>(buffer, offset, count);
        int i = 0;
        while (i < targetSpan.Length)
        {
            int rb = ReadByte();
            if (rb == -1)
            {
                return i;
            }
            targetSpan[i] = (byte)rb;
            i++;
        }
        return count;
    }

    /// <summary>
    /// Closes the stream, releasing any associated resources.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing && IsStreamOwner)
        {
            //baseStream.Dispose();
        }
    }

    /// <summary>
    /// Read a byte from stream advancing position
    /// </summary>
    /// <returns>byte read or -1 on end of stream</returns>
    //public override int ReadByte()
    //{
    //    if (streamEnd)
    //    {
    //        return -1;
    //    }

    //    int retChar = currentChar;
    //    switch (currentState)
    //    {
    //        case RAND_PART_B_STATE:
    //            SetupRandPartB();
    //            break;

    //        case RAND_PART_C_STATE:
    //            SetupRandPartC();
    //            break;

    //        case NO_RAND_PART_B_STATE:
    //            SetupNoRandPartB();
    //            break;

    //        case NO_RAND_PART_C_STATE:
    //            SetupNoRandPartC();
    //            break;

    //        case START_BLOCK_STATE:
    //        case NO_RAND_PART_A_STATE:
    //        case RAND_PART_A_STATE:
    //            break;
    //    }
    //    return retChar;
    //}

    #endregion Stream Overrides

    /// <summary>
    /// Optimized bulk copy for int arrays using SIMD when available.
    /// Copies count elements from src starting at srcOffset to dst at dstOffset.
    /// Supports AVX2 (8 ints at a time) and SSE2 (4 ints at a time), with fallback to managed copy.
    /// </summary>
    private static void OptimizedIntArrayCopy(ReadOnlySpan<int> src, int srcOffset, Span<int> dst, int dstOffset, int count)
    {
        if (count <= 0)
            return;

        if (Avx2.IsSupported && count >= 8)
        {
            unsafe
            {
                fixed (int* pSrc = src, pDst = dst)
                {
                    int* ps = pSrc + srcOffset;
                    int* pd = pDst + dstOffset;
                    int remaining = count;

                    // Process 8 ints (256 bits) at a time with AVX2
                    while (remaining >= 8)
                    {
                        var vec = Avx2.LoadVector256((int*)ps);
                        Avx2.Store((int*)pd, vec);
                        ps += 8;
                        pd += 8;
                        remaining -= 8;
                    }

                    // Fall through to SSE or scalar for remainder
                    if (Sse2.IsSupported && remaining >= 4)
                    {
                        while (remaining >= 4)
                        {
                            var vec128 = Sse2.LoadVector128((int*)ps);
                            Sse2.Store((int*)pd, vec128);
                            ps += 4;
                            pd += 4;
                            remaining -= 4;
                        }
                    }

                    // Handle remaining ints with scalar copy
                    while (remaining > 0)
                    {
                        *pd++ = *ps++;
                        remaining--;
                    }
                }
            }
        }
        else if (Sse2.IsSupported && count >= 4)
        {
            unsafe
            {
                fixed (int* pSrc = src, pDst = dst)
                {
                    int* ps = pSrc + srcOffset;
                    int* pd = pDst + dstOffset;
                    int remaining = count;

                    // Process 4 ints (128 bits) at a time with SSE2
                    while (remaining >= 4)
                    {
                        var vec = Sse2.LoadVector128(ps);
                        Sse2.Store(pd, vec);
                        ps += 4;
                        pd += 4;
                        remaining -= 4;
                    }

                    // Handle remaining ints
                    while (remaining > 0)
                    {
                        *pd++ = *ps++;
                        remaining--;
                    }
                }
            }
        }
        else
        {
            // Fallback: use Span.CopyTo for best compatibility
            src.Slice(srcOffset, count).CopyTo(dst.Slice(dstOffset, count));
        }
    }
    /// Shifts bytes in the yy array from index j down to 0, moving position j to the front.
    /// Supports AVX2 (256-bit), SSE (128-bit), and fallback to System.Numerics.Vector.
    /// </summary>
    private static void OptimizedMtfShift(Span<byte> yy, int j)
    {
        if (j == 0)
            return;

        byte tmp = yy[j];

#if VECTORIZE_MEMORY_MOVE
        // AVX2 support for 256-bit (32-byte) operations
        if (Avx2.IsSupported && j >= 32)
        {
            unsafe
            {
                fixed (byte* pYy = yy)
                {
                    byte* pStart = pYy;
                    byte* pEnd = pYy + j;

                    // Process 32-byte chunks backwards
                    while (pEnd - pStart >= 32)
                    {
                        var vec = Avx.LoadVector256(pEnd - 32);
                        Avx.Store(pEnd - 31, vec);
                        pEnd -= 32;
                    }
                }
            }
            j %= 32;
        }
        // SSE2 support for 128-bit (16-byte) operations
        else if (Sse2.IsSupported && j >= 16)
        {
            unsafe
            {
                fixed (byte* pYy = yy)
                {
                    byte* pStart = pYy;
                    byte* pEnd = pYy + j;

                    // Process 16-byte chunks backwards
                    while (pEnd - pStart >= 16)
                    {
                        var vec = Sse2.LoadVector128(pEnd - 16);
                        Sse2.Store(pEnd - 15, vec);
                        pEnd -= 16;
                    }
                }
            }
            j %= 16;
        }
#endif

        // Handle remaining bytes with a fast loop - this is still quick for small j
        while (j > 0)
        {
            yy[j] = yy[--j];
        }

        yy[0] = tmp;
    }

    private void MakeMaps()
    {
        nInUse = 0;
        for (int i = 0; i < 256; ++i)
        {
            if (inUse[i])
            {
                seqToUnseq[nInUse] = (byte)i;
                unseqToSeq[i] = (byte)nInUse;
                nInUse++;
            }
        }
    }

    private void Initialize()
    {
        char magic1 = BsGetUChar();
        char magic2 = BsGetUChar();

        char magic3 = BsGetUChar();
        char magic4 = BsGetUChar();

        if (magic1 != 'B' || magic2 != 'Z' || magic3 != 'h' || magic4 < '1' || magic4 > '9')
        {
            streamEnd = true;
            return;
        }

        SetDecompressStructureSizes(magic4 - '0');
        computedCombinedCRC = 0;
    }

    private void InitBlock()
    {
        char magic1 = BsGetUChar();
        char magic2 = BsGetUChar();
        char magic3 = BsGetUChar();
        char magic4 = BsGetUChar();
        char magic5 = BsGetUChar();
        char magic6 = BsGetUChar();

        if (magic1 == 0x17 && magic2 == 0x72 && magic3 == 0x45 && magic4 == 0x38 && magic5 == 0x50 && magic6 == 0x90)
        {
            Complete();
            return;
        }

        if (magic1 != 0x31 || magic2 != 0x41 || magic3 != 0x59 || magic4 != 0x26 || magic5 != 0x53 || magic6 != 0x59)
        {
            BadBlockHeader();
            streamEnd = true;
            return;
        }

        storedBlockCRC = BsGetInt32();

        blockRandomised = (BsR(1) == 1);

        GetAndMoveToFrontDecode();

        mCrc.Reset();
        currentState = START_BLOCK_STATE;
    }

    private void EndBlock()
    {
        computedBlockCRC = (int)mCrc.Value;

        // -- A bad CRC is considered a fatal error. --
        if (storedBlockCRC != computedBlockCRC)
        {
            CrcError();
        }

        // 1528150659
        computedCombinedCRC = ((computedCombinedCRC << 1) & 0xFFFFFFFF) | (computedCombinedCRC >> 31);
        computedCombinedCRC = computedCombinedCRC ^ (uint)computedBlockCRC;
    }

    private void Complete()
    {
        storedCombinedCRC = BsGetInt32();
        if (storedCombinedCRC != (int)computedCombinedCRC)
        {
            CrcError();
        }

        streamEnd = true;
    }

    private void FillBuffer()
    {
        int thech = 0;

        try
        {
            if (_position < BaseSpan.Length)
            {
                thech = BaseSpan[(int)_position++];
            }
            else
            {
                thech = -1;
            }
        }
        catch (Exception)
        {
            CompressedStreamEOF();
        }

        if (thech == -1)
        {
            CompressedStreamEOF();
        }

        bsBuff = (bsBuff << 8) | (thech & 0xFF);
        bsLive += 8;
    }

    private int BsR(int n)
    {
        while (bsLive < n)
        {
            FillBuffer();
        }

        int v = (bsBuff >> (bsLive - n)) & ((1 << n) - 1);
        bsLive -= n;
        return v;
    }

    private char BsGetUChar()
    {
        return (char)BsR(8);
    }

    private int BsGetIntVS(int numBits)
    {
        return BsR(numBits);
    }

    private int BsGetInt32()
    {
        int result = BsR(8);
        result = (result << 8) | BsR(8);
        result = (result << 8) | BsR(8);
        result = (result << 8) | BsR(8);
        return result;
    }

    private void RecvDecodingTables()
    {
        // Reuse a single buffer for lengths across groups instead of allocating separate arrays
        Span<char> lenBuffer = stackalloc char[FastBZip2InputConstants.GroupCount * FastBZip2InputConstants.MaximumAlphaSize];

        bool[] inUse16 = new bool[16];

        //--- Receive the mapping table ---
        for (int i = 0; i < 16; i++)
        {
            inUse16[i] = (BsR(1) == 1);
        }

        for (int i = 0; i < 16; i++)
        {
            if (inUse16[i])
            {
                for (int j = 0; j < 16; j++)
                {
                    inUse[i * 16 + j] = (BsR(1) == 1);
                }
            }
            else
            {
                for (int j = 0; j < 16; j++)
                {
                    inUse[i * 16 + j] = false;
                }
            }
        }

        MakeMaps();
        int alphaSize = nInUse + 2;

        //--- Now the selectors ---
        int nGroups = BsR(3);
        int nSelectors = BsR(15);

        for (int i = 0; i < nSelectors; i++)
        {
            int j = 0;
            while (BsR(1) == 1)
            {
                j++;
            }
            selectorMtf[i] = (byte)j;
        }

        //--- Undo the MTF values for the selectors. ---
        Span<byte> pos = stackalloc byte[FastBZip2InputConstants.GroupCount];
        for (int v = 0; v < nGroups; v++)
        {
            pos[v] = (byte)v;
        }

        for (int i = 0; i < nSelectors; i++)
        {
            int v = selectorMtf[i];
            byte tmp = pos[v];
            while (v > 0)
            {
                pos[v] = pos[v - 1];
                v--;
            }
            pos[0] = tmp;
            selector[i] = tmp;
        }

        //--- Now the coding tables ---
        for (int t = 0; t < nGroups; t++)
        {
            int curr = BsR(5);
            Span<char> tLen = lenBuffer.Slice(t * FastBZip2InputConstants.MaximumAlphaSize, FastBZip2InputConstants.MaximumAlphaSize);
            for (int i = 0; i < alphaSize; i++)
            {
                while (BsR(1) == 1)
                {
                    if (BsR(1) == 0)
                    {
                        curr++;
                    }
                    else
                    {
                        curr--;
                    }
                }
                tLen[i] = (char)curr;
            }
        }

        //--- Create the Huffman decoding tables ---
        for (int t = 0; t < nGroups; t++)
        {
            Span<char> tLen = lenBuffer.Slice(t * FastBZip2InputConstants.MaximumAlphaSize, alphaSize);
            int minLen = 32;
            int maxLen = 0;
            for (int i = 0; i < alphaSize; i++)
            {
                maxLen = Math.Max(maxLen, tLen[i]);
                minLen = Math.Min(minLen, tLen[i]);
            }
            HbCreateDecodeTables(limit[t], baseArray[t], perm[t], tLen, minLen, maxLen, alphaSize);
            minLens[t] = minLen;
        }
    }

    private void GetAndMoveToFrontDecode()
    {
        Span<byte> yy = stackalloc byte[256];
        int nextSym;

        int limitLast = FastBZip2InputConstants.BaseBlockSize * blockSize100k;
        origPtr = BsGetIntVS(24);

        RecvDecodingTables();
        int EOB = nInUse + 1;
        int groupNo = -1;
        int groupPos = 0;

        /*--
			Setting up the unzftab entries here is not strictly
			necessary, but it does save having to do it later
			in a separate pass, and so saves a block's worth of
			cache misses.
			--*/
        for (int i = 0; i <= 255; i++)
        {
            unzftab[i] = 0;
        }

        for (int i = 0; i <= 255; i++)
        {
            yy[i] = (byte)i;
        }

        last = -1;

        if (groupPos == 0)
        {
            groupNo++;
            groupPos = FastBZip2InputConstants.GroupSize;
        }

        groupPos--;
        int zt = selector[groupNo];
        int zn = minLens[zt];
        int zvec = BsR(zn);
        int zj;

        while (zvec > limit[zt][zn])
        {
            if (zn > 20)
            { // the longest code
                throw new Exception("Bzip data error");
            }
            zn++;
            while (bsLive < 1)
            {
                FillBuffer();
            }
            zj = (bsBuff >> (bsLive - 1)) & 1;
            bsLive--;
            zvec = (zvec << 1) | zj;
        }
        if (zvec - baseArray[zt][zn] < 0 || zvec - baseArray[zt][zn] >= FastBZip2InputConstants.MaximumAlphaSize)
        {
            throw new Exception("Bzip data error");
        }
        nextSym = perm[zt][zvec - baseArray[zt][zn]];

        while (true)
        {
            if (nextSym == EOB)
            {
                break;
            }

            if (nextSym == FastBZip2InputConstants.RunA || nextSym == FastBZip2InputConstants.RunB)
            {
                int s = -1;
                int n = 1;
                do
                {
                    if (nextSym == FastBZip2InputConstants.RunA)
                    {
                        s += (0 + 1) * n;
                    }
                    else if (nextSym == FastBZip2InputConstants.RunB)
                    {
                        s += (1 + 1) * n;
                    }

                    n <<= 1;

                    if (groupPos == 0)
                    {
                        groupNo++;
                        groupPos = FastBZip2InputConstants.GroupSize;
                    }

                    groupPos--;

                    zt = selector[groupNo];
                    zn = minLens[zt];
                    zvec = BsR(zn);

                    while (zvec > limit[zt][zn])
                    {
                        zn++;
                        while (bsLive < 1)
                        {
                            FillBuffer();
                        }
                        zj = (bsBuff >> (bsLive - 1)) & 1;
                        bsLive--;
                        zvec = (zvec << 1) | zj;
                    }
                    nextSym = perm[zt][zvec - baseArray[zt][zn]];
                } while (nextSym == FastBZip2InputConstants.RunA || nextSym == FastBZip2InputConstants.RunB);

                s++;
                byte ch = seqToUnseq[yy[0]];
                unzftab[ch] += s;

                while (s > 0)
                {
                    last++;
                    ll8[last] = ch;
                    s--;
                }

                if (last >= limitLast)
                {
                    BlockOverrun();
                }
                continue;
            }
            else
            {
                last++;
                if (last >= limitLast)
                {
                    BlockOverrun();
                }

                byte tmp = yy[nextSym - 1];
                unzftab[seqToUnseq[tmp]]++;
                ll8[last] = seqToUnseq[tmp];

                OptimizedMtfShift(yy, nextSym - 1);

                if (groupPos == 0)
                {
                    groupNo++;
                    groupPos = FastBZip2InputConstants.GroupSize;
                }

                groupPos--;
                zt = selector[groupNo];
                zn = minLens[zt];
                zvec = BsR(zn);
                while (zvec > limit[zt][zn])
                {
                    zn++;
                    while (bsLive < 1)
                    {
                        FillBuffer();
                    }
                    zj = (bsBuff >> (bsLive - 1)) & 1;
                    bsLive--;
                    zvec = (zvec << 1) | zj;
                }
                nextSym = perm[zt][zvec - baseArray[zt][zn]];
                continue;
            }
        }
    }

    private void SetupBlock()
    {
        int[] cftab = new int[257];

        cftab[0] = 0;
        new Span<int>(unzftab, 0, 256).CopyTo(new Span<int>(cftab, 1, 256));

        for (int i = 1; i <= 256; i++)
        {
            cftab[i] += cftab[i - 1];
        }

        for (int i = 0; i <= last; i++)
        {
            byte ch = ll8[i];
            tt[cftab[ch]] = i;
            cftab[ch]++;
        }

        cftab = null;

        tPos = tt[origPtr];

        count = 0;
        i2 = 0;
        ch2 = 256;   /*-- not a char and not EOF --*/

        if (blockRandomised)
        {
            rNToGo = 0;
            rTPos = 0;
            SetupRandPartA();
        }
        else
        {
            SetupNoRandPartA();
        }
    }

    private void SetupRandPartA()
    {
        if (i2 <= last)
        {
            chPrev = ch2;
            ch2 = ll8[tPos];
            tPos = tt[tPos];
            if (rNToGo == 0)
            {
                rNToGo = FastBZip2InputConstants.RandomNumbers[rTPos];
                rTPos++;
                if (rTPos == 512)
                {
                    rTPos = 0;
                }
            }
            rNToGo--;
            ch2 ^= (int)((rNToGo == 1) ? 1 : 0);
            i2++;

            currentChar = ch2;
            currentState = RAND_PART_B_STATE;
            mCrc.Update(ch2);
        }
        else
        {
            EndBlock();
            InitBlock();
            SetupBlock();
        }
    }

    private void SetupNoRandPartA()
    {
        if (i2 <= last)
        {
            chPrev = ch2;
            ch2 = ll8[tPos];
            tPos = tt[tPos];
            i2++;

            currentChar = ch2;
            currentState = NO_RAND_PART_B_STATE;
            mCrc.Update(ch2);
        }
        else
        {
            EndBlock();
            InitBlock();
            SetupBlock();
        }
    }

    private void SetupRandPartB()
    {
        if (ch2 != chPrev)
        {
            currentState = RAND_PART_A_STATE;
            count = 1;
            SetupRandPartA();
        }
        else
        {
            count++;
            if (count >= 4)
            {
                z = ll8[tPos];
                tPos = tt[tPos];
                if (rNToGo == 0)
                {
                    rNToGo = FastBZip2InputConstants.RandomNumbers[rTPos];
                    rTPos++;
                    if (rTPos == 512)
                    {
                        rTPos = 0;
                    }
                }
                rNToGo--;
                z ^= (byte)((rNToGo == 1) ? 1 : 0);
                j2 = 0;
                currentState = RAND_PART_C_STATE;
                SetupRandPartC();
            }
            else
            {
                currentState = RAND_PART_A_STATE;
                SetupRandPartA();
            }
        }
    }

    private void SetupRandPartC()
    {
        if (j2 < (int)z)
        {
            currentChar = ch2;
            mCrc.Update(ch2);
            j2++;
        }
        else
        {
            currentState = RAND_PART_A_STATE;
            i2++;
            count = 0;
            SetupRandPartA();
        }
    }

    private void SetupNoRandPartB()
    {
        if (ch2 != chPrev)
        {
            currentState = NO_RAND_PART_A_STATE;
            count = 1;
            SetupNoRandPartA();
        }
        else
        {
            count++;
            if (count >= 4)
            {
                z = ll8[tPos];
                tPos = tt[tPos];
                currentState = NO_RAND_PART_C_STATE;
                j2 = 0;
                SetupNoRandPartC();
            }
            else
            {
                currentState = NO_RAND_PART_A_STATE;
                SetupNoRandPartA();
            }
        }
    }

    private void SetupNoRandPartC()
    {
        if (j2 < (int)z)
        {
            currentChar = ch2;
            mCrc.Update(ch2);
            j2++;
        }
        else
        {
            currentState = NO_RAND_PART_A_STATE;
            i2++;
            count = 0;
            SetupNoRandPartA();
        }
    }

    private void SetDecompressStructureSizes(int newSize100k)
    {
        if (!(0 <= newSize100k && newSize100k <= 9 && 0 <= blockSize100k && blockSize100k <= 9))
        {
            throw new Exception("Invalid block size");
        }

        blockSize100k = newSize100k;

        if (newSize100k == 0)
        {
            return;
        }

        int n = FastBZip2InputConstants.BaseBlockSize * newSize100k;
        ll8 = new byte[n];
        tt = new int[n];
    }

    private static void CompressedStreamEOF()
    {
        throw new EndOfStreamException("BZip2 input stream end of compressed stream");
    }

    private static void BlockOverrun()
    {
        throw new Exception("BZip2 input stream block overrun");
    }

    private static void BadBlockHeader()
    {
        throw new Exception("BZip2 input stream bad block header");
    }

    private static void CrcError()
    {
        throw new Exception("BZip2 input stream crc error");
    }

    private static void HbCreateDecodeTables(int[] limit, int[] baseArray, int[] perm, ReadOnlySpan<char> length, int minLen, int maxLen, int alphaSize)
    {
        int pp = 0;

        for (int i = minLen; i <= maxLen; ++i)
        {
            for (int j = 0; j < alphaSize; ++j)
            {
                if (length[j] == i)
                {
                    perm[pp] = j;
                    ++pp;
                }
            }
        }

        for (int i = 0; i < FastBZip2InputConstants.MaximumCodeLength; i++)
        {
            baseArray[i] = 0;
        }

        for (int i = 0; i < alphaSize; i++)
        {
            ++baseArray[length[i] + 1];
        }

        for (int i = 1; i < FastBZip2InputConstants.MaximumCodeLength; i++)
        {
            baseArray[i] += baseArray[i - 1];
        }

        for (int i = 0; i < FastBZip2InputConstants.MaximumCodeLength; i++)
        {
            limit[i] = 0;
        }

        int vec = 0;

        for (int i = minLen; i <= maxLen; i++)
        {
            vec += (baseArray[i + 1] - baseArray[i]);
            limit[i] = vec - 1;
            vec <<= 1;
        }

        for (int i = minLen + 1; i <= maxLen; i++)
        {
            baseArray[i] = ((limit[i - 1] + 1) << 1) - baseArray[i];
        }
    }
}
