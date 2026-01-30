namespace Sc2ReplayAnalyzer.Global;

public abstract class BitPackedProtocolParserImpl : ProtocolReaderBase
{
    public BitReader _bitReader { get; }

    public BitPackedProtocolParserImpl(BinaryReader reader)
        : base(reader)
    {
        _bitReader = new BitReader(reader);
    }

    public void Dispose()
    {
        _bitReader.Dispose();
    }

    public int RustSize => _bitReader.RustSize;
    public int AvailableBits => _bitReader.AvailableBits;

    public void byte_align() => _bitReader.ByteAlign();

    protected List<byte> take_bit_array(long totalBits) => _bitReader.TakeBitArray((int)totalBits);

    protected long take_n_bits_into_i64(int totalBits) => _bitReader.TakeBitsI64(totalBits);

    protected byte take_aligned_byte() => _bitReader.TakeAlignedByte();

    protected object take_null() => _bitReader.TakeNull();

    protected List<byte> take_fourcc() => _bitReader.TakeFourCC();

    protected long parse_packed_int(long offset, int numBits) => _bitReader.ParsePackedInt(offset, numBits);

    protected bool parse_bool() => _bitReader.ParseBool();
}
