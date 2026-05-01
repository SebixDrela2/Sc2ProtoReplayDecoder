using System.Buffers;
using System.Runtime.InteropServices;

namespace MPQArchive.Bzip.Native;

public static unsafe class BZip2FastDecompress
{
    private const string DllName = "libbz2-1.dll";

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    private static extern int BZ2_bzDecompressInit(ref bz_stream strm, int verbosity, int small);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    private static extern int BZ2_bzDecompress(ref bz_stream strm);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    private static extern int BZ2_bzDecompressEnd(ref bz_stream strm);

    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    private static extern int BZ2_bzBuffToBuffDecompress(
        byte* dest,
        ref uint destLen,
        byte* source,
        uint sourceLen,
        int small,
        int verbosity
    );

    [StructLayout(LayoutKind.Sequential)]
    private struct bz_stream
    {
        public byte* next_in;
        public UInt32 avail_in;
        public UInt32 total_in_lo32;
        public UInt32 total_in_hi32;

        public byte* next_out;
        public UInt32 avail_out;
        public UInt32 total_out_lo32;
        public UInt32 total_out_hi32;

        public IntPtr state;
        public IntPtr bzalloc;
        public IntPtr bzfree;
        public IntPtr opaque;
    }

    private const int BZ_OK = 0;
    private const int BZ_STREAM_END = 4;
    private const int BZ_MEM_ERROR = -3;
    private const int BZ_DATA_ERROR = -4;
    private const int BZ_OUTBUFF_FULL = -8;

    private const int Verbosity = 0;
    private const int Small = 0;
    private const int AvailableRead = 64 << 10;

    public static byte[] Decompress(ReadOnlySpan<byte> compressed)
    {
        if (compressed == null | compressed.Length is 0)
        {
            return [];
        }

        var stream = new bz_stream
        {
            bzalloc = IntPtr.Zero,
            bzfree = IntPtr.Zero,
            opaque = IntPtr.Zero,
        };

        var state = BZ2_bzDecompressInit(ref stream, Verbosity, Small);
        byte[] result;

        try
        {
            ulong totalIn = ((ulong)stream.total_in_hi32 << 32) | stream.total_in_lo32;
            ulong totalOut = ((ulong)stream.total_out_hi32 << 32) | stream.total_out_lo32;

            if (totalIn != 0 || totalOut != 0)
            {
                throw new InvalidOperationException($"Invalid BZip stream init.");
            }

            if (state != BZ_OK)
            {
                throw new InvalidOperationException("Invalid BZip state.");
            }

            result = DecompressInternal(ref stream, compressed);
        }
        finally
        {
            state = BZ2_bzDecompressEnd(ref stream);
        }

        if (state is not BZ_OK)
        {
            throw new InvalidOperationException($"Stream is not ok");
        }

        return result;
    }

    private static byte[] DecompressInternal(ref bz_stream stream, ReadOnlySpan<byte> input)
    {
        var result = new ArrayBufferWriter<byte>();

        fixed (byte* inputPtr = input)
        {
            stream.next_in = inputPtr;
            stream.avail_in = (uint)input.Length;

            var streamResult = BZ_OK;

            while (streamResult is BZ_OK)
            {
                var chunk = result.GetSpan(AvailableRead);

                fixed (byte* outputPtr = chunk)
                {
                    stream.next_out = outputPtr;
                    stream.avail_out = (uint)chunk.Length;

                    streamResult = BZ2_bzDecompress(ref stream);

                    int advanceAmount = (int)(chunk.Length - stream.avail_out);
                    result.Advance(advanceAmount);

                    if (streamResult is BZ_STREAM_END)
                    {
                        break;
                    }
                    else if (streamResult is not BZ_OK)
                    {
                        throw new InvalidOperationException($"Stream is not okay.");
                    }
                }
            }

            return result.WrittenSpan.ToArray();
        }
    }
}
