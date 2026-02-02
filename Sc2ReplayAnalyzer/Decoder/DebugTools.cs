

using Sc2ReplayAnalyzer.Decoder.Factory;
using System.Diagnostics;

namespace Sc2ReplayAnalyzer.Decoder;

internal static class DebugTools
{
    private static int _operation = 0;

    public static List<string> Info = [];


    public static void LogVersionedLines(IVersionedProtocolParser versionedParser, string additionalContent = "")
    {
        var debug = $"Op:{_operation}: (RS:{versionedParser.RustSize}) {additionalContent}";

        AddLineIncrementOp(debug);
    }

    public static void LogBitPackedLines(IBitPackedProtocolParser bitPacked)
    {
        var rustSize = bitPacked.RustSize;
        var available = bitPacked.AvailableBits;
        var offset = 8 - available;

        var debug = $"Op:{_operation}: (RS:{rustSize}, OS:{offset})";

        AddLineIncrementOp(debug);
    }

    private static void AddLineIncrementOp(string debug)
    {
        Info.Add(debug);

        _operation++;

        if (_operation == 12547)
        {

        }
    }
}
