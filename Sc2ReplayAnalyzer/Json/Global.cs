using System.Buffers.Binary;
using System.Drawing;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

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


public sealed class BitReader
{
    private readonly BinaryReader _reader;
    private byte _currentByte;
    private int _bitOffset;

    public BitReader(BinaryReader reader)
    {
        _reader = reader;
        _bitOffset = 8;
    }

    public List<byte> TakeBitArray(int totalBits)
    {
        var result = new List<byte>();
        int remainingBits = totalBits;

        while (remainingBits > 0)
        {
            int count = remainingBits > 8 ? 8 : remainingBits;
            byte bits = ReadBits(count);

            result.Add(bits);

            remainingBits -= count;
        }

        return result;
    }

    public byte TakeUnalignedByte() => ReadBits(8);

    public List<byte> TakeFourCC()
    {
        var res = new List<byte>(4);

        for (int i = 0; i < 4; i++)
        {
            var value = ReadBits(8);

            res.Add(value);
        }

        return res;
    }

    public void TakeNull() { }

    public long ParsePackedInt(long offset, int numBits)
    {
        long num = ReadBitsI64(numBits);

        return offset + num;
    }

    public bool ParseBool()
    {
        return ReadBits(1) != 0;
    }

    public byte ReadBits(int count)
    {
        if (count < 0 || count > 8)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

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

    public long ReadBitsI64(int totalBits)
    {
        if (totalBits > 64)
        {
            throw new InvalidOperationException("More than 64 bits");
        }

        long result = 0;

        while (totalBits > 0)
        {
            int take = totalBits > 8
                ? (_bitOffset == 8 ? 8 : 8 - _bitOffset)
                : totalBits;

            byte bits = ReadBits(take);
            result = (result << take) | bits;

            totalBits -= take;
        }

        return result;
    }

    public void ByteAlign()
    {
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
}

public partial class ProtocolReader
{
    public void byte_align() => BitReader.ByteAlign();

    public List<byte> take_bit_array(long totalBits) => BitReader.TakeBitArray((int)totalBits);

    public long take_n_bits_into_i64(int totalBits) => BitReader.ReadBitsI64(totalBits);

    public byte take_unaligned_byte() => BitReader.TakeUnalignedByte();

    public void take_null() => BitReader.TakeNull();

    public List<byte> take_fourcc() => BitReader.TakeFourCC();

    public long parse_packed_int(long offset, int numBits) => BitReader.ParsePackedInt(offset, numBits);

    public bool parse_bool() => BitReader.ParseBool();
}

public partial class ProtocolReader : IDisposable
{
    private readonly BinaryReader _reader;
    public BitReader BitReader { get; }

    public ProtocolReader(BinaryReader reader)
    {
        _reader = reader;

        BitReader = new BitReader(reader);
    }

    public const byte ARRAY_TAG = 0x00;
    public const byte BIT_ARRAY_TAG = 0x01;
    public const byte BLOB_TAG = 0x02;
    public const byte CHOICE_TAG = 0x03;
    public const byte OPT_TAG = 0x04;
    public const byte STRUCT_TAG = 0x05;
    public const byte BOOL_TAG = 0x06;
    public const byte FOURCC_TAG = 0x07;
    public const byte INT_TAG = 0x09;

    public void ValidateTag(byte tag)
    {
        var value = ReadByte();

        if (value != tag)
        {
            throw new Exception($"Invalid tag: {value}, Expected: {tag}");
        }
    }

    public void ValidateArrayTag() => ValidateTag(ARRAY_TAG);
    public void ValidateBitArrayTag() => ValidateTag(BIT_ARRAY_TAG);
    public void ValidateBlobTag() => ValidateTag(BLOB_TAG);
    public void ValidateChoiceTag() => ValidateTag(CHOICE_TAG);
    public void ValidateOptTag() => ValidateTag(OPT_TAG);
    public void ValidateStructTag() => ValidateTag(STRUCT_TAG);
    public void ValidateBoolTag() => ValidateTag(BOOL_TAG);
    public void ValidateFourccTag() => ValidateTag(FOURCC_TAG);
    public void ValidateIntTag() => ValidateTag(INT_TAG);

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

    public void Dispose() => _reader.Dispose();

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

            bits += 7;
        }

        return isNegative ? -result : result;
    }

    public byte ReadByte()
    {
        BitReader.ByteAlign();
        return _reader.ReadByte();
    }

    public List<byte> ReadBytes(long length)
    {
        BitReader.ByteAlign();
        return _reader.ReadBytes((int)length).ToList();
    }

    public List<byte> ReadBytes(int length)
    {
        BitReader.ByteAlign();
        return _reader.ReadBytes(length).ToList();
    }

    public T[] ReadArray<T>(Func<T> parseMethod, long count) =>
        [.. Enumerable.Range(0, (int)count).Select(_ => parseMethod())];

    public List<T> ReadList<T>(Func<T> parseMethod, long count) =>
        [.. Enumerable.Range(0, (int)count).Select(_ => parseMethod())];
}

public static class ProtocolConversion<TResult>
{
    public static bool TryFrom<TFrom>(TFrom source, out TResult result)
    {
        throw new NotImplementedException();
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
