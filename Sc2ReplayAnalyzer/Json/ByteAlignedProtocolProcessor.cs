using System.Text.Json.Nodes;
using System.Xml.Linq;

namespace Sc2ReplayAnalyzer.Json;

using static ProtocolJsonType;

internal class ByteAlignedProtocolProcessor
{
    public IReadOnlyList<JsonNode> ProcessByteAligned(JsonNode rootModule)
    {
        var result = new List<JsonNode>();
        var moduleDeclarations = rootModule[Declaration].AsArray();

        foreach (var module in moduleDeclarations)
        {
            var fullName = module[FullName].ToString();

            switch (fullName)
            {
                case "NNet.SVersion":
                case "NNet.SVarUint32":
                case "NNet.SMD5":
                case "NNet.EObserve":
                    result.Add(module);
                    break;

                case "NNet.Replay":
                case "NNet.Game":
                    result.AddRange(ProcessReplayEvent(module));
                    break;
            }
        }

        return result;
    }

    private IReadOnlyList<JsonNode> ProcessReplayEvent(JsonNode typeDeclaration)
    {
        var result = new List<JsonNode>();
        var replayDeclarations = typeDeclaration[Declaration].AsArray();

        foreach (var replayDecl in replayDeclarations)
        {
            var fullName = replayDecl[FullName].ToString();

            switch (fullName)
            {
                case "NNet.Replay.SHeader":
                    result.Add(replayDecl);
                    break;

                case "NNet.Replay.Tracker":
                    result.AddRange(ProcessReplayTracker(replayDecl));
                    break;

                case "NNet.Game.CPlayerDetailsArray":
                case "NNet.Game.SDetails":
                case "NNet.Game.SPlayerDetails":
                case "NNet.Game.SThumbnail":
                case "NNet.Game.EGameSpeed":
                case "NNet.Game.EResultDetails":
                case "NNet.Game.SToonNameDetails":
                case "NNet.Game.SColor":
                    result.Add(replayDecl);
                    break;
            }
        }

        return result;
    }

    private IReadOnlyList<JsonNode> ProcessReplayTracker(JsonNode typeDeclaration)
    {
        var result = new List<JsonNode>();
        var trackerDeclarations = typeDeclaration[Declaration].AsArray();

        foreach (var trackerDeclaration in trackerDeclarations)
        {
            var fullName = trackerDeclaration[FullName].ToString();

            if (fullName.StartsWith("NNet.Replay.Tracker.S") || fullName is "NNet.Replay.Tracker.EEventId")
            {
                result.Add(trackerDeclaration);
            }
        }

        return result;
    }
}
