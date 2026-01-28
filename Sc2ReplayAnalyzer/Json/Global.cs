global using u8 = byte;
global using i8 = sbyte;
global using u16 = ushort;
global using i16 = short;
global using u32 = uint;
global using i32 = int;
global using u64 = ulong;
global using i64 = long;
global using f16 = System.Half;
global using f32 = float;
global using f64 = double;
global using usize = nuint;
global using ssize = nint;

using System.Buffers.Binary;
using System.Numerics;

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

    public readonly T DefaultIfNone(T defaultValue) => HasValue ? Value : defaultValue;
    public readonly T DefaultIfNone() => default;

    public readonly void Deconstruct(out bool hasValue, out T value) => (hasValue, value) = (HasValue, Value);

    public static implicit operator Option<T>(NoneValue value) => None;
    public static readonly Option<T> None = default;
}

public static class Option
{
    public static T OkOrReturnMissingFieldErr<T>(Option<T> option)
    {
        if (!option.HasValue)
        {
            return default;
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

public sealed class BitReader(BinaryReader reader) : IDisposable
{
    private byte _currentByte;
    private int _available;

    public string DebugView => GetDebugView();
    public int BytePosition => (int)reader.BaseStream.Position;
    public int BitPosition => 8 - _available;
    public int RustSize => (int)reader.BaseStream.Length - BytePosition;

    private string GetDebugView()
    {
        var pos = reader.BaseStream.Position;

        var backing = (int)Math.Min(8, reader.BaseStream.Position);
        reader.BaseStream.Position -= backing;

        var value = reader.ReadBytes(16);

        reader.BaseStream.Position = pos;

        return $"Pos: {BytePosition}:{BitPosition} {string.Join(" ", value[..backing].Select(x => $"{x,3}"))} * {string.Join(" ", value[backing..].Select(x => $"{x,3}"))}";
    }

    public int AvailableBits => _available;

    public long TakeBitsI64(int totalBits)
    {
        long result = 0L;
        var remainingBits = totalBits;

        while (true)
        {
            var count = remainingBits > 8
                ? (_available != 0 ? _available : 8)
                : remainingBits;

            long bits = RTakeNBits(count);

            result |= bits << (remainingBits - count);                     

            remainingBits -= count;

            if (remainingBits is 0)
            {
                break;
            }
        }

        return result;
    }

    public List<byte> TakeBitArray(int totalBits)
    {
        var result = new List<byte>();
        var remainingBits = totalBits;

        while(true)
        {
            var count = remainingBits > 8 
                ? 8 
                : remainingBits;

            var bits = RTakeNBits(count);

            result.Add(bits);

            remainingBits -= count;

            if (remainingBits is 0)
            {
                break;
            }
        }

        return result;
    }

    public void ByteAlign()
    {
        if (_available is (0 or 8))
        {
            return;
        }

        _currentByte = reader.ReadByte();
        _available = 8;
    }

    public byte TakeUnalignedByte()
    {
        var result = TakeBitArray(8);

        return result[0];
    }

    public List<byte> TakeFourCC()
    {
        var bitArray = TakeBitArray(4 * 8);

        return bitArray;
    }

    public object TakeNull() => new();

    public long ParsePackedInt(long offset, int numBits)
    {
        var num = TakeBitsI64(numBits);
        var res = offset + num;

        return res;
    }

    public bool ParseBool()
    {
        var val = RTakeNBits(1);

        return val != 0;
    }

    public void Dispose() => reader.Dispose();

    private byte RTakeNBits(int count)
    {
        byte result;

        if (_available >= count)
        {
            var mask = (1 << count) - 1;
            result = (byte)(_currentByte & mask);
        }
        else
        {
            result = _currentByte;
            count -= _available;

            var mask = (1 << count) - 1;
            _currentByte = reader.ReadByte();

            var result2 = (byte)(_currentByte & mask);

            result <<= count;
            result |= result2;

            _available = 8;
        }

        _currentByte >>= count;
        _available -= count;

        return result;
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

    public int RustSize => _bitReader.RustSize;
    public int AvailableBits => _bitReader.AvailableBits;

    public void byte_align() => _bitReader.ByteAlign();

    protected List<byte> take_bit_array(long totalBits) => _bitReader.TakeBitArray((int)totalBits);

    protected long take_n_bits_into_i64(int totalBits) => _bitReader.TakeBitsI64(totalBits);

    protected byte take_unaligned_byte() => _bitReader.TakeUnalignedByte();

    protected object take_null() => _bitReader.TakeNull();

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

    protected List<T> ReadList<T>(Func<T> parseMethod, long count)
    {
        var result = new List<T>();

        for (var i = 0; i < count; ++i)
        {
            var methodResult = parseMethod();

            result.Add(methodResult);
        }

        return result;
    }

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

    //public static TResult From<TFrom>(TFrom source)
    //{
    //    if (!TryFrom(source, out var result))
    //    {
    //        throw new InvalidCastException($"Invalid cast");
    //    }

    //    return result;
    //}
}

public static class Extensions
{
    extension<TResult>(ProtocolConversion<TResult>)
        where TResult : unmanaged, IBinaryInteger<TResult>
    {
        public static TResult From<TFrom>(TFrom source)
            where TFrom : unmanaged, IBinaryInteger<TFrom> => TResult.CreateTruncating<TFrom>(source);
    }
}
