using System.Buffers.Binary;

namespace Sc2ReplayAnalyzer.Global;

public abstract class VersionedProtocolParserImpl(BinaryReader reader) : ProtocolReaderBase(reader)
{
    public List<byte> tagged_bitarray()
    {
        ValidateBitArrayTag();

        var arrayLength = ParseVlqInt();
        arrayLength = (arrayLength + 7) / 8;

        return ReadBytes(arrayLength);
    }

    public List<byte> tagged_blob()
    {
        ValidateBlobTag();

        var blobLength = ParseVlqInt();

        return ReadBytes(blobLength);
    }

    public long tagged_vlq_int()
    {
        ValidateIntTag();

        return ParseVlqInt();
    }

    public bool tagged_bool()
    {
        ValidateBoolTag();

        return ReadByte() != 0;
    }

    public uint tagged_fourcc()
    {
        ValidateFourccTag();

        return BinaryPrimitives.ReadUInt32BigEndian(ReadBytes(4).ToArray());
    }

    public void Dispose() => reader.Dispose();

    public long ParseVlqInt()
    {
        long v_int_value = ReadByte();
        bool isNegative = (v_int_value & 1) != 0;

        long result = (v_int_value >> 1) & 0x3f;

        for (int bits = 6; (v_int_value & 0x80) != 0; bits += 7)
        {
            long new_v_int_value = ReadByte();

            result |= (new_v_int_value & 0x7f) << bits;
            v_int_value = new_v_int_value;
        }

        return isNegative ? -result : result;
    }

    public List<byte> ReadBytes(long length)
    {
        return reader.ReadBytes((int)length).ToList();
    }

    public List<byte> ReadBytes(int length)
    {
        return reader.ReadBytes(length).ToList();
    }

    public string DebugView => GetDebugView();
    public int BytePosition => (int)reader.BaseStream.Position;
    public int RustSize => (int)reader.BaseStream.Length - BytePosition;

    private string GetDebugView()
    {
        var pos = reader.BaseStream.Position;

        var backing = (int)Math.Min(8, reader.BaseStream.Position);
        reader.BaseStream.Position -= backing;

        var value = reader.ReadBytes(16);

        reader.BaseStream.Position = pos;

        return $"BytePos: {BytePosition} {string.Join(" ", value[..backing].Select(x => $"{x,3}"))} * {string.Join(" ", value[backing..].Select(x => $"{x,3}"))}";
    }
}
