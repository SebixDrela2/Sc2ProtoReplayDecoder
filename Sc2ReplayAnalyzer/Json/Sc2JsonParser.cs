using Sc2ReplayAnalyzer.Json.Generator;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.Json;

using static Sc2JsonType;

public class Sc2JsonParser(Dictionary<string, string> jsonFiles)
{
    private const string NNetReplay = "NNet.Replay";
    private const string NNetGame = "NNet.Game";

    public IReadOnlyList<Sc2GeneratorData> Parse()
    {
        var result = new List<Sc2GeneratorData>();

        foreach(var json in jsonFiles)
        {
            result.Add(ParseJson(json.Key, json.Value));
        }

        return result;
    }

    private Sc2GeneratorData ParseJson(string protocolName, string json)
    {
        json = json.Replace(@"\x1b", @"\u001b");

        var jsonDocument = JsonNode.Parse(json);
        var rootModule = jsonDocument[Modules][0];

        return new Sc2GeneratorData
        {
            EnumTags = ParseRootModuleForEnumTags(rootModule),
            ByteAligned = ProcessByteAligned(rootModule),
            BitPacked = []
        };
    }

    private Dictionary<string, string> ParseRootModuleForEnumTags(JsonNode moduleDeclaration)
    {
        var enumTags = new Dictionary<string, string>();

        ProcessModuleDeclaration(moduleDeclaration, enumTags);

        return enumTags;
    }

    private IReadOnlyList<JsonNode> ProcessByteAligned(JsonNode rootModule)
    {
        var result = new List<JsonNode>();
        var moduleDeclarations = rootModule[Declaration].AsArray();

        foreach(var module in moduleDeclarations)
        {
            var fullName = module[FullName].ToString();

            switch(fullName)
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

        foreach(var replayDecl in replayDeclarations)
        {
            var fullName = replayDecl[FullName].ToString();

            switch(fullName)
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

        foreach(var trackerDeclaration in trackerDeclarations)
        {
            var fullName = trackerDeclaration[FullName].ToString();

            if (fullName.StartsWith("NNet.Replay.Tracker.S") || fullName is "NNet.Replay.Tracker.EEventId")
            {
                result.Add(trackerDeclaration);
            }
        }

        return result;
    }

    private Sc2StructDeclaration ProcessModuleDeclaration(JsonNode module, Dictionary<string, string> enumTags)
    {
        var typeDeclarations = module[Declaration].AsArray();

        foreach(var typeDeclaration in typeDeclarations)
        {
            var type = typeDeclaration[Type].ToString();

            switch(type)
            {
                case "Module":
                    ProcessModuleDeclaration(typeDeclaration, enumTags);
                    break;

                case "TypeDecl":
                    if (!IsReplayDeclaration(module[FullName].ToString()))
                    {
                        continue;
                    }

                    ProcessStructDeclaration(typeDeclaration, enumTags);
                    break;
            }
        }

        return default;
    }

    private Sc2StructDeclaration ProcessStructDeclaration(JsonNode typeDeclaration, Dictionary<string, string> enumTags)
    {
        if (typeDeclaration[TypeInfo][Type].ToString() != "StructType")
        {
            return default;
        }

        if (typeDeclaration[Declaration] is JsonArray typeDeclarationArray)
        {
            foreach(var typeDeclarationArrArg in typeDeclarationArray)
            {
                ProcessStructDeclaration(typeDeclarationArrArg, enumTags);
            }
        }

        var fieldArray = typeDeclaration[TypeInfo][Fields].AsArray();

        foreach(var field in fieldArray)
        {
            var nnetFieldType = field[Type];

            if (nnetFieldType.ToString() != "ConstDecl")
            {
                continue;
            }

            var typeFullName = field[TypeInfo][FullName].ToString();

            if (field[Value][Type].ToString() != "IdentifierExpr")
            {
                throw new Exception("Unknown value for ConstDecl.");
            }

            var typeKey = field[Value][FullName].ToString();
            var typeValue = typeDeclaration[FullName].ToString();

            enumTags.TryAdd(typeKey, typeValue);
        }

        return new Sc2StructDeclaration();
    }

    private static bool IsReplayDeclaration(string declaration) => declaration is NNetGame or NNetReplay;
}
