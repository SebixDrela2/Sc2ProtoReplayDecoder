using Sc2ReplayAnalyzer.Json.Generator;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.Json;

using static Sc2JsonType;

public class Sc2JsonParser(Dictionary<string, string> jsonFiles)
{
    private const string NNetReplay = "NNet.Replay";
    private const string NNetGame = "NNet.Game";

    private readonly Sc2ByteAlignedProcessor _byteAlignedProcessor = new Sc2ByteAlignedProcessor();
    private readonly Sc2BitPackedProcessor _bitPackedProcessor = new Sc2BitPackedProcessor();

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
            ProtocolName = protocolName,
            EnumTags = ParseRootModuleForEnumTags(rootModule),
            ByteAligned = _byteAlignedProcessor.ProcessByteAligned(rootModule),
            BitPacked = _bitPackedProcessor.ProcessBitPacked(rootModule)
        };
    }

    private Dictionary<string, string> ParseRootModuleForEnumTags(JsonNode moduleDeclaration)
    {
        var enumTags = new Dictionary<string, string>();
        var typeDeclarations = moduleDeclaration[Declaration] as JsonArray;
        
        foreach (var typeDeclaration in typeDeclarations)
        {
            var fullName = typeDeclaration[FullName].ToString();

            if (!IsReplayDeclaration(fullName))
            {
                continue;
            }

            var subDeclarations = typeDeclaration[Declaration] as JsonArray;

            foreach(var subDeclaration in subDeclarations)
            {
                if (subDeclaration[Declaration] is JsonArray thirdLevelDeclarations)
                {
                    foreach(var thirdLevelDeclaration in thirdLevelDeclarations)
                    {
                        ProcessStructDeclaration(thirdLevelDeclaration, enumTags);
                    }
                }
                else
                {
                    ProcessStructDeclaration(subDeclaration, enumTags);
                }
            }
        } 
        
        return enumTags;
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

            var typeVariantValue = GetTypeName(field[Value][FullName].ToString().Replace(typeFullName, string.Empty));
            var typeVariant = GetTypeName(typeFullName);

            var value = GetTypeName(typeDeclaration[FullName].ToString());
            var key = $"{typeVariant}.{typeVariantValue}";

            enumTags.TryAdd(key, value);
        }

        return new Sc2StructDeclaration();
    }

    private static bool IsReplayDeclaration(string declaration) => declaration is NNetGame or NNetReplay;

    private static string GetTypeName(string fullName) => fullName
        .Replace(".", string.Empty)
        .Replace("NNet", "");
}
