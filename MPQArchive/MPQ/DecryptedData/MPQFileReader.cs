using ICSharpCode.SharpZipLib.BZip2;
using MPQArchive.MPQ.Constants;
using MPQArchive.MPQ.Utils;
using System.Buffers;
using System.Diagnostics;
using System.IO.Compression;

namespace MPQArchive.MPQ.DecryptedData;

public class MPQFileReader
{
    private readonly BinaryReader reader;
    private readonly MPQHashTableReader mpqHashTableReader;
    private readonly MPQHeader1 mpqHeader;
    private readonly CompositeTable compositeTable;
    private readonly long headerBaseOffset;

    public MPQFileReader(
        BinaryReader reader,
        MPQHashTableReader mpqHashTableReader,
        MPQHeader1 mpqHeader,
        CompositeTable compositeTable,
        long headerBaseOffset)
    {
        this.reader = reader;
        this.mpqHashTableReader = mpqHashTableReader;
        this.mpqHeader = mpqHeader;
        this.compositeTable = compositeTable;
        this.headerBaseOffset = headerBaseOffset;
    }

    public byte[] ReadFile(string fileName, bool forceDecompress = false)
    {
        var hashEntry = mpqHashTableReader.GetHashTableEntry(fileName)
            ?? throw new InvalidDataException("File not found.");

        var block = compositeTable.MPQBlockTableEntries[hashEntry.BlockIndex];

        if ((block.Flags & MPQFileConstant.MPQ_FILE_EXISTS) == 0)
            throw new InvalidDataException("File does not exist.");

        if ((block.Flags & MPQFileConstant.MPQ_FILE_ENCRYPTED) != 0)
            throw new NotSupportedException("Encryption not supported.");

        reader.GoTo(block.FilePosition + headerBaseOffset);
        byte[] fileData = reader.ReadBytes((int)block.CompressedSize);

        if ((block.Flags & MPQFileConstant.MPQ_FILE_SINGLE_UNIT) == 0 &&
            block.UncompressedSize != 0)
        {
            int sectorSize = 512 << mpqHeader.SectorSizeShift;
            int sectors = (int)(block.UncompressedSize / sectorSize) + 1;

            bool crc = (block.Flags & MPQFileConstant.MPQ_FILE_SECTOR_CRC) == 0;
            if (crc) sectors++;

            uint[] positions = UnpackPositions(fileData, sectors);
            fileData = ProcessSectors(fileData, block, positions, crc, forceDecompress);
        }
        else if ((block.Flags & MPQFileConstant.MPQ_FILE_COMPRESS) != 0 &&
                 (forceDecompress || block.UncompressedSize > block.CompressedSize))
        {
            fileData = Decompress(fileData);
        }

        return fileData;
    }

    public static unsafe byte[] ProcessSectors(
        byte[] fileData,
        MPQBlockTableEntry block,
        uint[] positions,
        bool crc,
        bool forceDecompress)
    {
        byte[] output = new byte[block.UncompressedSize];
        int writeOffset = 0;

        fixed (byte* filePtr = fileData)
        fixed (byte* outPtr = output)
        {
            int sectorCount = positions.Length - (crc ? 2 : 1);

            for (int i = 0; i < sectorCount; i++)
            {
                int start = (int)positions[i];
                int length = (int)(positions[i + 1] - positions[i]);
                byte* sectorPtr = filePtr + start;

                bool compressed =
                    (block.Flags & MPQFileConstant.MPQ_FILE_COMPRESS) != 0 &&
                    (forceDecompress || length < block.UncompressedSize);

                if (compressed)
                {
                    byte[] decompressed = Decompress(
                        new ReadOnlySpan<byte>(sectorPtr, length));

                    fixed (byte* src = decompressed)
                    {
                        Buffer.MemoryCopy(
                            src,
                            outPtr + writeOffset,
                            output.Length - writeOffset,
                            decompressed.Length);
                    }

                    writeOffset += decompressed.Length;
                }
                else
                {
                    Buffer.MemoryCopy(
                        sectorPtr,
                        outPtr + writeOffset,
                        output.Length - writeOffset,
                        length);

                    writeOffset += length;
                }
            }
        }

        return output;
    }

    private static byte[] Decompress(ReadOnlySpan<byte> data)
    {
        if (data.Length <= 1)
        {
            return Array.Empty<byte>();
        }

        var type = data[0];
        var payload = data.Slice(1);

        if (type == 0)
        {
            var result = new byte[payload.Length];
            payload.CopyTo(result);
            return result;
        }

        using var inputHandle = MemoryPool<byte>.Shared.Rent(payload.Length);
        var inputMemory = inputHandle.Memory.Slice(0, payload.Length);
        payload.CopyTo(inputMemory.Span);

        using var inputStream = new MemoryStream(inputMemory.ToArray());
        using Stream decompressor = type switch
        {
            2 => new DeflateStream(inputStream, CompressionLevel.Fastest),
            16 => new BZip2InputStream(inputStream),
            _ => throw new InvalidOperationException("Unsupported compression.")
        };

        using var outputStream = new MemoryStream();
        decompressor.CopyTo(outputStream);

        return outputStream.ToArray();
    }

    private static unsafe uint[] UnpackPositions(byte[] fileData, int sectors)
    {
        int count = sectors + 1;
        uint[] positions = new uint[count];

        fixed (byte* ptr = fileData)
        {
            uint* p = (uint*)ptr;
            for (int i = 0; i < count; i++)
            {
                positions[i] = p[i];
            }
        }

        return positions;
    }
}
