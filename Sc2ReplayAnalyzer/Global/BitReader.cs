using System.Diagnostics;
using System.Runtime.CompilerServices;

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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public long TakeBitsI64(int totalBits)
    {
        long result = 0L;
        int remainingBits = totalBits;

        // Fast path for small reads (most common case)
        if (totalBits <= 8 && _available >= totalBits)
        {
            int mask = (1 << totalBits) - 1;
            result = (long)(_currentByte & mask);
            _currentByte >>= totalBits;
            _available -= totalBits;
            return result;
        }

        // General path for larger reads
        while (remainingBits > 0)
        {
            int count = remainingBits > 8
                ? (_available != 0 ? _available : 8)
                : remainingBits;

            long bits = RTakeNBits(count);
            result |= bits << (remainingBits - count);
            remainingBits -= count;
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

        // Optimized path: if we're byte-aligned and reading a whole number of bytes
        if (_available is 0 && (leftBits & 0b111) is 0)
        {
            int bytesToRead = leftBits >> 3; // Equivalent to leftBits / 8
            return reader.ReadBytes(bytesToRead).ToList();
        }

        // Path for partial bytes at current position
        if (_available is 0)
        {
            int bytesToRead = (leftBits + 7) >> 3;
            byte[] readBytes = reader.ReadBytes(bytesToRead);

            int leftOverBits = leftBits & 0b111;
            if (leftOverBits is not 0)
            {
                _available = 8 - leftOverBits;
                ref byte lastByte = ref readBytes[^1];
                int mask = (1 << leftOverBits) - 1;
                _currentByte = (byte)(lastByte >> leftOverBits);
                lastByte &= (byte)mask;
            }

            return readBytes.ToList();
        }

        // General path: read bits incrementally
        int capacityHint = (leftBits + 7) >> 3;
        result.Capacity = capacityHint;

        while (leftBits > 0)
        {
            int count = leftBits > 8 ? 8 : leftBits;
            byte bits = (byte)RTakeNBits(count);
            result.Add(bits);
            leftBits -= count;
        }

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public long ParsePackedInt(long offset, int numBits)
    {
        var num = TakeBitsI64(numBits);
        var res = offset + num;

        return res;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
