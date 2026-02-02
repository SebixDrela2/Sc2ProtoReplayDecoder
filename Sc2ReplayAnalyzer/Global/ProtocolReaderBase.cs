namespace Sc2ReplayAnalyzer.Global;

public abstract class ProtocolReaderBase(BinaryReader reader)
{
    private const byte ARRAY_TAG = 0x00;
    private const byte BIT_ARRAY_TAG = 0x01;
    private const byte BLOB_TAG = 0x02;
    protected const byte CHOICE_TAG = 0x03;
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

    protected List<byte> ReadBytes(int count)
    {
        return reader.ReadBytes(count).ToList();
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
