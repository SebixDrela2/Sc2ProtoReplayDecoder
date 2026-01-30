using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators.Utils;

using static Sc2ReplayAnalyzer.Json.ProtocolJsonType;

public class ProtocolTypeConversionByteAligned : IProtocolTypeConversionAlignment
{
    public static ProtocolJsonTypeConversion FromNnetName(string nnetName) => nnetName switch
    {
        "NNet.uint8" or
        "NNet.Replay.EReplayType" or
        "NNet.uint6" or
        "NNet.Game.TPlayerId" or
        "NNet.Game.TControlId" or
        "NNet.Game.TTeamId" or
        "NNet.Replay.Tracker.TUIntMiniBits" => new ProtocolJsonTypeConversion
        {
            CSharpType = "u8",
            ShouldTryFrom = true,
            Parser = "tagged_vlq_int",
        },
        "NNet.uint32" or
        "NNet.uint14" or
        "NNet.uint22" or
        "NNet.Game.TDifficulty" or
        "NNet.Game.THandicap" => new ProtocolJsonTypeConversion
        {
            CSharpType = "u32",
            ShouldTryFrom = true,
            Parser = "tagged_vlq_int",
        },
        "NNet.int32" or "NNet.Game.TFixedBits" => new ProtocolJsonTypeConversion
        {
            CSharpType = "i32",
            ShouldTryFrom = true,
            Parser = "tagged_vlq_int",
        },
        "NNet.SVersion" => new ProtocolJsonTypeConversion
        {
            CSharpType = "SVersion",
            Parser = "Parse_SVersion"
        },
        "NNet.Game.TColorId" or "NNet.int64" => new ProtocolJsonTypeConversion
        {
            CSharpType = "i64",
            ShouldTryFrom = true,
            Parser = "tagged_vlq_int",
        },
        "NNet.uint64" => new ProtocolJsonTypeConversion
        {
            CSharpType = "u64",
            ShouldTryFrom = true,
            Parser = "tagged_vlq_int"
        },
        "FourCCType" => new ProtocolJsonTypeConversion
        {
            CSharpType = "uint",
            Parser = "tagged_fourcc"
        },
        "BlobType" or
        "NNet.Replay.CSignature" or
        "StringType" or
        "NNet.Replay.Tracker.CatalogName" or
        "NNet.Game.CCacheHandle" or
        "NNet.CFilePath" or
        "NNet.CUserName" => new ProtocolJsonTypeConversion
        {
            CSharpType = "List<byte>",
            Parser = "tagged_blob",
        },
        "BoolType" => new ProtocolJsonTypeConversion
        {
            CSharpType = "bool",
            Parser = "tagged_bool"
        },
        "OptionalType" => new ProtocolJsonTypeConversion
        {
            CSharpType = "Option<{}>",
            Parser = "{}",
            IsOptional = true,
        },
        "ArrayType" or
        "DynArrayType" or
        "NNet.CUserArchiveDataArray" or
        "NNet.CUserInitialDataArray" => new ProtocolJsonTypeConversion
        {
            CSharpType = "List<{}>",
            Parser = "{}",
            IsVector = true,
        },
        "NNet.SMD5" => new ProtocolJsonTypeConversion
        {
            CSharpType = "SMD5",
            Parser = "Parse_SMD5",
        },
        "NNet.EObserve" => new ProtocolJsonTypeConversion
        {
            CSharpType = "EObserve",
            Parser = "Parse_EObserve",
        },
        "NNet.Game.EResultDetails" => new ProtocolJsonTypeConversion
        {
            CSharpType = "GameEResultDetails",
            Parser = "Parse_GameEResultDetails"
        },
        "NNet.Game.CCacheHandles" => new ProtocolJsonTypeConversion
        {
            CSharpType = "List<List<byte>>",
            Parser = "tagged_blob",
            IsVector = true,
        },
        "NNet.Replay.Tracker.SPlayerStats" => new ProtocolJsonTypeConversion
        {
            CSharpType = "ReplayTrackerSPlayerStats",
            Parser = "Parse_ReplayTrackerSPlayerStats"
        },
        "NNet.Game.CPlayerDetailsArray" => new ProtocolJsonTypeConversion
        {
            CSharpType = "List<GameSPlayerDetails>",
            Parser = "Parse_GameSPlayerDetails",
            IsVector = true
        },
        "NNet.Game.SThumbnail" => new ProtocolJsonTypeConversion
        {
            CSharpType = "GameSThumbnail",
            Parser = "Parse_GameSThumbnail"
        },
        "NNet.Game.CModPaths" => new ProtocolJsonTypeConversion
        {
            CSharpType = "List<List<byte>>",
            Parser = "tagged_blob",
            IsVector = true,
        },
        "NNet.Game.EGameSpeed" => new ProtocolJsonTypeConversion
        {
            CSharpType = "GameEGameSpeed",
            Parser = "Parse_GameEGameSpeed"
        },
        "NNet.Game.SToonNameDetails" => new ProtocolJsonTypeConversion
        {
            CSharpType = "GameSToonNameDetails",
            Parser = "Parse_GameSToonNameDetails"
        },
        "NNet.Game.SColor" => new ProtocolJsonTypeConversion
        {
            CSharpType = "GameSColor",
            Parser = "Parse_GameSColor"
        },
        var x => throw new NotSupportedException($"WTF TYPE {x}")
    };

    public static ProtocolJsonTypeConversion GetFieldConverted(JsonNode field, string fieldTypeInfo)
    {
        var fieldConverted = FromNnetName(fieldTypeInfo);

        if (fieldTypeInfo is "OptionalType")
        {
            var enclosedFieldConverted = GetEnclosedFieldConverted(field);

            fieldConverted.CSharpType = fieldConverted.CSharpType.Replace("{}", enclosedFieldConverted.CSharpType);
            fieldConverted.Parser = fieldConverted.Parser.Replace("{}", enclosedFieldConverted.Parser);
            fieldConverted.ShouldTryFrom = enclosedFieldConverted.ShouldTryFrom;
            fieldConverted.IsVector = enclosedFieldConverted.IsVector;
            fieldConverted.IsOptional = true;

            return fieldConverted;
        }

        if (fieldTypeInfo is "ArrayType")
        {
            var elementType = field[TypeInfo][ElementType][FullName].ToString();
            var enclosedConvertedType = FromNnetName(elementType);

            fieldConverted.CSharpType = fieldConverted.CSharpType.Replace("{}", enclosedConvertedType.CSharpType);
            fieldConverted.Parser = fieldConverted.Parser.Replace("{}", enclosedConvertedType.Parser);
            fieldConverted.ShouldTryFrom = enclosedConvertedType.ShouldTryFrom;
            fieldConverted.IsVector = true;

            return fieldConverted;
        }

        return fieldConverted;
    }

    private static ProtocolJsonTypeConversion GetEnclosedFieldConverted(JsonNode field)
    {
        if (field[TypeInfo][TypeInfo][Type].ToString() == "ArrayType")
        {
            var elementType = field[TypeInfo][TypeInfo][ElementType][FullName].ToString();

            var enclosedFieldConverted = FromNnetName(elementType);
            enclosedFieldConverted.CSharpType = $"List<{enclosedFieldConverted.CSharpType}>";
            enclosedFieldConverted.IsVector = true;
            enclosedFieldConverted.IsOptional = true;

            return enclosedFieldConverted;
        }

        var enclosedTypeFullName = field[TypeInfo][TypeInfo][FullName]?.ToString() ?? string.Empty;
        var enclosedType = !string.IsNullOrEmpty(enclosedTypeFullName)
            ? enclosedTypeFullName
            : field[TypeInfo][TypeInfo][Type].ToString();

        return FromNnetName(enclosedType);
    }
}