using System.Diagnostics;

namespace Sc2ReplayAnalyzer.Global;

public sealed class BitReader(BinaryReader reader) : IDisposable
{
    private byte _currentByte;
    private int _available;

    public string DebugView => GetDebugView();
    public int BytePosition => (int)reader.BaseStream.Position;
    public int BitPosition => 8 - _available;
    public int RustSize => (int)reader.BaseStream.Length - BytePosition;

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

    public List<byte> TakeBitArray(int leftBits)
    {      
        var result = new List<byte>();

        if (leftBits is 0)
        {
            return result;
        }

        if (_available is 0)
        {
            var bytesToRead = (leftBits + 7) / 8;
            var leftOverBits = leftBits % 8;
            var readBytes = reader.ReadBytes(bytesToRead);

            if (leftOverBits is not 0)
            {
                _available = 8 - leftOverBits;

                ref var lastByte = ref readBytes[^1];
                var mask = (byte)((1 << leftOverBits) - 1);

                _currentByte = (byte)(lastByte >> leftOverBits);

                lastByte &= mask;
            }

            return readBytes.ToList();
        }
        //else
        //{
        //    var bitsToRead = leftBits - _available;
        //    var bytesToRead = (bitsToRead + 7) >> 3;

        //    var bitsRead1 = leftBits & 0b111;
        //    var bitsRead2 = bitsToRead & 0b111;

        //    var readBytes = reader.ReadBytes(bytesToRead);

        //    GetShiftedArrayBits(readBytes, _currentByte, 8 - bitsRead2);

        //    //if (bitsRead is not 0)
        //    //{
        //    //    _available = 8 - bitsRead;

        //    //    ref var lastByte = ref readBytes[^1];
        //    //    var mask = (byte)((1 << bitsRead) - 1);

        //    //    _currentByte = (byte)(lastByte >> bitsRead);

        //    //    lastByte &= mask;
        //    //}

        //    return readBytes.ToList();
        //}

        while(true)
        {
            var count = leftBits > 8 
                ? 8 
                : leftBits;

            var bits = RTakeNBits(count);

            result.Add(bits);

            leftBits -= count;

            if (leftBits is 0)
            {
                break;
            }
        }

        return result;
    }

    public void ByteAlign()
    {
        if (_available is 8)
        {
            throw new Exception();
        }
        
        _available = 0;
    }

    public byte TakeAlignedByte()
    {
        ByteAlign();
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

    private IReadOnlyList<byte> GetShiftedArrayBits(byte[] bytes, byte prefixByte, int shiftCount)
    {
        var result = new byte[bytes.Length + 1];

        for (var i = 0; i < bytes.Length; ++i)
        {
            uint tmp = bytes[^i];
            result[^i] = prefixByte;

            tmp <<= 8;
            tmp >>= shiftCount;

            result[^i] |= (byte)tmp;

            prefixByte = (byte)(tmp >> 8);
        }

        return result;
    }

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

    private string GetDebugView()
    {
        var pos = reader.BaseStream.Position;

        var backing = (int)Math.Min(8, reader.BaseStream.Position);
        reader.BaseStream.Position -= backing;

        var value = reader.ReadBytes(16);

        reader.BaseStream.Position = pos;

        return $"Pos: {BytePosition}:{BitPosition} {string.Join(" ", value[..backing].Select(x => $"{x,3}"))} * {string.Join(" ", value[backing..].Select(x => $"{x,3}"))}";
    }
}
