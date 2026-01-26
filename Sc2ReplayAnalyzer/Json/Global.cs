using System.Buffers.Binary;

namespace Sc2ReplayAnalyzer.Json.Global;

public struct Option<T>
{
    public bool HasValue;
    public T Value;

    public static Option<T> Some(T value) => new Option<T>
    {
        HasValue = true,
        Value = value
    };

    public readonly void Deconstruct(out bool hasValue, out T value) => (hasValue, value) = (HasValue, Value);

    public static implicit operator Option<T>(NoneValue value) => None;
    public static readonly Option<T> None = default;
}

public static class Option
{
    // // ok_or_return_missing_field_err!
    public static T OkOrReturnMissingFieldErr<T>(Option<T> option)
    {
        if (!option.HasValue)
        {
            throw new Exception("TO DO.");
        }

        return option.Value;
    }

    public static Option<T> Some<T>(T value) => new Option<T>
    {
        HasValue = true,
        Value = value
    };

    public static readonly NoneValue None = default;
}

public struct NoneValue;

public sealed class BitReader : IDisposable
{
    private readonly BinaryReader _reader;
    private byte _currentByte;
    private int _bitOffset;

    public BitReader(BinaryReader reader)
    {
        _reader = reader;
        _bitOffset = 8;
    }

    private void EnsureByte()
    {
        if (_bitOffset == 8)
        {
            _currentByte = _reader.ReadByte();
            _bitOffset = 0;
        }
    }

    private byte TakeBits(int count)
    {
        byte result = 0;

        while (count > 0)
        {
            EnsureByte();

            int available = 8 - _bitOffset;
            int take = Math.Min(count, available);

            int shift = available - take;
            byte bits = (byte)((_currentByte >> shift) & ((1 << take) - 1));

            result = (byte)((result << take) | bits);

            _bitOffset += take;
            count -= take;
        }

        return result;
    }

    private readonly struct ReaderState
    {
        public readonly long Position;
        public readonly byte CurrentByte;
        public readonly int BitOffset;

        public ReaderState(long pos, byte cur, int off)
        {
            Position = pos;
            CurrentByte = cur;
            BitOffset = off;
        }
    }

    private ReaderState SaveState() => new ReaderState(_reader.BaseStream.Position, _currentByte, _bitOffset);

    private void RestoreState(ReaderState s)
    {
        _reader.BaseStream.Position = s.Position;
        _currentByte = s.CurrentByte;
        _bitOffset = s.BitOffset;
    }

    private byte RTakeBits(int count)
    {
        var state = SaveState();
        byte res = TakeBits(count);
        RestoreState(state);
        return res;
    }

    public long TakeBitsI64(int totalBits)
    {
        if (totalBits > 64)
        {
            throw new InvalidOperationException("More than 64 bits");
        }

        long res = 0;
        int remainingBits = totalBits;

        while (remainingBits > 0)
        {
            int count = remainingBits > 8
                ? (_bitOffset != 0 ? 8 - _bitOffset : 8)
                : remainingBits;

            byte bits = RTakeBits(count);
            TakeBits(count);

            res |= (long)bits << (remainingBits - count);

            remainingBits -= count;
        }

        return res;
    }

    public List<byte> TakeBitArray(int totalBits)
    {
        var res = new List<byte>();
        int remainingBits = totalBits;

        while (remainingBits > 0)
        {
            int count = remainingBits > 8 ? 8 : remainingBits;

            byte bits = RTakeBits(count);
            TakeBits(count);

            res.Add(bits);
            remainingBits -= count;
        }

        return res;
    }

    /* ============================
     * byte_align
     * ============================ */

    public void ByteAlign()
    {
        if (_bitOffset != 0)
        {
            TakeBits(8 - _bitOffset);
        }
    }

    /* ============================
     * take_unaligned_byte
     * ============================ */

    public byte TakeUnalignedByte()
    {
        return TakeBitArray(8)[0];
    }

    /* ============================
     * take_fourcc
     * ============================ */

    public List<byte> TakeFourCC()
    {
        return TakeBitArray(4 * 8);
    }

    /* ============================
     * take_null
     * ============================ */

    public void TakeNull()
    {
        // intentionally does nothing
    }

    /* ============================
     * parse_packed_int
     * ============================ */

    public long ParsePackedInt(long offset, int numBits)
    {
        return offset + TakeBitsI64(numBits);
    }

    /* ============================
     * parse_bool
     * ============================ */

    public bool ParseBool()
    {
        byte bit = RTakeBits(1);
        TakeBits(1);
        return bit != 0;
    }

    public void Dispose()
    {
        _reader.Dispose();
    }
}

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

    public void byte_align() => _bitReader.ByteAlign();

    protected List<byte> take_bit_array(long totalBits) => _bitReader.TakeBitArray((int)totalBits);

    protected long take_n_bits_into_i64(int totalBits) => _bitReader.TakeBitsI64(totalBits);

    protected byte take_unaligned_byte() => _bitReader.TakeUnalignedByte();

    protected void take_null() => _bitReader.TakeNull();

    protected List<byte> take_fourcc() => _bitReader.TakeFourCC();

    protected long parse_packed_int(long offset, int numBits) => _bitReader.ParsePackedInt(offset, numBits);

    protected bool parse_bool() => _bitReader.ParseBool();
}

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

    public int tagged_vlq_int()
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

    public int ParseVlqInt()
    {
        var v_int_value = ReadByte();
        var isNegative = (v_int_value & 1) != 0;

        int result = (v_int_value >> 1) & 0x3f;

        for (int bits = 6; (v_int_value & 0x80) != 0; bits += 7)
        {
            var new_v_int_value = ReadByte();

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
}

public abstract class ProtocolReaderBase(BinaryReader reader)
{
    private const byte ARRAY_TAG = 0x00;
    private const byte BIT_ARRAY_TAG = 0x01;
    private const byte BLOB_TAG = 0x02;
    private const byte CHOICE_TAG = 0x03;
    private const byte OPT_TAG = 0x04;
    private const byte STRUCT_TAG = 0x05;
    private const byte BOOL_TAG = 0x06;
    private const byte FOURCC_TAG = 0x07;
    private const byte INT_TAG = 0x09;

    protected void ValidateArrayTag() => ValidateTag(ARRAY_TAG);
    protected void ValidateBitArrayTag() => ValidateTag(BIT_ARRAY_TAG);
    protected void ValidateBlobTag() => ValidateTag(BLOB_TAG);
    protected void ValidateChoiceTag() => ValidateTag(CHOICE_TAG);
    protected void ValidateOptTag() => ValidateTag(OPT_TAG);
    protected void ValidateStructTag() => ValidateTag(STRUCT_TAG);
    protected void ValidateBoolTag() => ValidateTag(BOOL_TAG);
    protected void ValidateFourccTag() => ValidateTag(FOURCC_TAG);
    protected void ValidateIntTag() => ValidateTag(INT_TAG);

    protected byte ReadByte()
    {
        return reader.ReadByte();
    }

    protected T[] ReadArray<T>(Func<T> parseMethod, long count) =>
        [.. Enumerable.Range(0, (int)count).Select(_ => parseMethod())];

    protected List<T> ReadList<T>(Func<T> parseMethod, long count) =>
        [.. Enumerable.Range(0, (int)count).Select(_ => parseMethod())];

    private void ValidateTag(byte tag)
    {
        var value = ReadByte();

        if (value != tag)
        {
            throw new Exception($"Invalid tag: {value}, Expected: {tag}");
        }
    }  
}

public static class ProtocolConversion<TResult>
{
    public static bool TryFrom<TFrom>(TFrom source, out TResult result)
    {
        result = default;

        if (source == null)
        {
            return false;
        }

        if (source is TResult)
        {
            result = (TResult)(object)source;
            return true;
        }

        try
        {
            var underlyingType = Nullable.GetUnderlyingType(typeof(TResult));
            var targetType = underlyingType ?? typeof(TResult);

            if (targetType == typeof(string))
            {
                result = (TResult)(object)source.ToString();
                return true;
            }

            if (source is IConvertible)
            {
                result = (TResult)Convert.ChangeType(source, targetType);
                return true;
            }
        }
        catch
        {
            return false;
        }

        return false;
    }

    public static TResult From<TFrom>(TFrom source)
    {
        if (!TryFrom(source, out var result))
        {
            throw new InvalidCastException($"Invalid cast");
        }

        return result;
    }
}
