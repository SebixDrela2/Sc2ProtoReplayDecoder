namespace Sc2ReplayAnalyzer.Tests;

using Sc2ReplayAnalyzer.Json.Global;


[TestFixture]
public class BitReaderTests
{
    [Test]
    public void TestReadsGameEvents()
    {
        // Data: [0x00, 0xf0, 0x64, 0x2b, 0x4b, 0xa4, 0x0c, 0x00]
        byte[] data = { 0x00, 0xf0, 0x64, 0x2b, 0x4b, 0xa4, 0x0c, 0x00 };
        using var ms = new MemoryStream(data);
        using var reader = new BinaryReader(ms);
        var bitReader = new BitReader(reader);

        // Rust: SVarUint32::MUint6(0) -> 2 bits choice + 6 bits value
        long svarUintValue = bitReader.TakeBitsI64(8);
        Assert.That(svarUintValue, Is.EqualTo(0));

        // Rust: ReplaySGameUserId { m_user_id: 16 } -> 5 bits
        long userId = bitReader.ParsePackedInt(0, 5);
        Assert.That(userId, Is.EqualTo(16));

        // Rust: parse_packed_int(tail, 0, 7usize) -> 116
        long variantTag = bitReader.ParsePackedInt(0, 7);
        Assert.That(variantTag, Is.EqualTo(116));

        // Rust: rtake_n_bits(tail, 4usize) -> 0x06
        byte next4Bits = bitReader.ReadBits(4);
        Assert.That(next4Bits, Is.EqualTo(0x06));

        // Rust: Uint32::parse -> 1656011340
        long syncTime = bitReader.TakeBitsI64(32);
        Assert.That(syncTime, Is.EqualTo(1656011340));
    }

    [Test]
    public void TestReadsInitDataProperties()
    {
        byte[] data = {
            0x07, 0x75, 0x26, 0x7a, 0x50, 0xf8, 0xdf, 0x07, 0xbb, 0xf0,
            0xe0, 0x70, 0x00, 0xf0, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
            0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
            0xff, 0xff, 0x7d, 0x00, 0x00, 0xc0, 0x01, 0x7f, 0x3c, 0x00,
            0xc0, 0x03, 0x1f, 0x1c, 0x00, 0xc0, 0x07, 0x1f, 0x1c, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00
        };
        using var ms = new MemoryStream(data);
        using var reader = new BinaryReader(ms);
        var bitReader = new BitReader(reader);

        // Uint32 Checksum
        long checksum = bitReader.TakeBitsI64(32);
        Assert.That(checksum, Is.EqualTo(125118074));

        // Array length (5 bits) -> 16
        long arrayLength = bitReader.ParsePackedInt(0, 5);
        Assert.That(arrayLength, Is.EqualTo(16));

        // Bitarray length (6 bits) -> 16
        long bitArrayLength = bitReader.TakeBitsI64(6);
        Assert.That(bitArrayLength, Is.EqualTo(16));

        // GameCAllowedColors (16 bits) -> 65279
        long allowedColors = bitReader.TakeBitsI64(16);
        Assert.That(allowedColors, Is.EqualTo(65279));

        // Next length (8 bits) -> 3
        long nextLen = bitReader.TakeBitsI64(8);
        Assert.That(nextLen, Is.EqualTo(3));
    }
}