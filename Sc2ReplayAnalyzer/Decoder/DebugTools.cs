using Sc2ReplayAnalyzer.Json.protocol90870.BitPacked;

namespace Sc2ReplayAnalyzer.Decoder;

internal class DebugTools
{
    private void LogBitPackedLines(BitPackedProtocolParser bitPacked, ref int operation, List<string> info)
    {
        var rustSize = bitPacked.RustSize;
        var available = bitPacked.AvailableBits;
        var offset = 8 - available;

        var debug = $"Op:{operation}: (RS:{rustSize}, OS:{offset})";

        info.Add(debug);

        operation++;
    }
}
