using System.Text;

namespace Sc2ReplayAnalyzer.Decoder.Attributes;


internal class TruncatedError : Exception
{
    public TruncatedError(BitPackedLittleEndianBuffer buffer) : base($"Buffer truncated: {buffer}") { }
}

internal class BitPackedLittleEndianBuffer
{
    private byte[] _data;
    private int _used;
    private int _next;
    private int _nextbits;

    public BitPackedLittleEndianBuffer(byte[] contents)
    {
        _data = contents ?? [];
        _used = 0;
        _next = 0;
        _nextbits = 0;
    }

    public override string ToString()
    {
        string s = (_used < _data.Length) ? $"{_data[_used]:x2}" : "--";
        return $"buffer({(_nextbits > 0 ? _next : 0):x2}/{_nextbits},[{_used}]={s})";
    }

    public bool Done()
    {
        return _nextbits == 0 && _used >= _data.Length;
    }

    public int UsedBits()
    {
        return _used * 8 - _nextbits;
    }

    public void ByteAlign()
    {
        _nextbits = 0;
    }

    public byte[] ReadAlignedBytes(int bytes)
    {
        ByteAlign();

        if (_used + bytes > _data.Length)
        {
            throw new TruncatedError(this);
        }

        byte[] result = new byte[bytes];
        Array.Copy(_data, _used, result, 0, bytes);
        _used += bytes;
        return result;
    }

    public int ReadBits(int bits)
    {
        int result = 0;
        int resultBits = 0;

        while (resultBits != bits)
        {
            if (_nextbits == 0)
            {
                if (Done())
                    throw new TruncatedError(this);

                _next = _data[_used];
                _used++;
                _nextbits = 8;
            }

            int copyBits = Math.Min(bits - resultBits, _nextbits);
            int copy = _next & ((1 << copyBits) - 1);

            result |= copy << resultBits;

            _next >>= copyBits;
            _nextbits -= copyBits;
            resultBits += copyBits;
        }

        return result;
    }

    public string ReadUnalignedBytes(int bytes)
    {
        StringBuilder sb = new StringBuilder(bytes);
        for (int i = 0; i < bytes; i++)
        {
            sb.Append((char)ReadBits(8));
        }
        return sb.ToString();
    }
}
