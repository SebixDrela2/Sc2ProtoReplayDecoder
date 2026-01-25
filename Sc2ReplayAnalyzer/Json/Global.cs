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

public class ProtocolReader(BinaryReader reader) : IDisposable
{
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
        var value = reader.ReadByte();

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

    public void Dispose() => reader.Dispose();

}
