using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator;

using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

public class Sc2JsonTypeConversion
{
    public string CSharpType = "unknown type";
    public bool IsVector = false;
    public bool IsSizedInt = false;
    public bool IsOptional = false;
    public bool ShouldTryFrom = false;
    public string Parser = "unknown type";
}

internal interface ISc2JsonTypeConversionAlignment
{
    static abstract Sc2JsonTypeConversion FromNnetName(string nnetName);
    static abstract Sc2JsonTypeConversion GetFieldConverted(JsonNode field, string fieldTypeInfo);
}

public class Sc2TypeConversionBitPacked : ISc2JsonTypeConversionAlignment
{
    public static Sc2JsonTypeConversion FromNnetName(string nnetName) 
    {
        if (nnetName.StartsWith("NNet"))
        {
            return new Sc2JsonTypeConversion
            {
                CSharpType = nnetName,
                Parser = $"{nnetName}.Parse"
            };
        }

        return nnetName switch
        {
            "BoolType" => new Sc2JsonTypeConversion
            {
                CSharpType = "bool",
                Parser = "parse_bool",
            },
            "OptionalType" => new Sc2JsonTypeConversion
            {
                CSharpType = "Option<{}>",
                Parser = "{}",
                IsOptional = true,
            },
            "ArrayType" or "DynArrayType" => new Sc2JsonTypeConversion
            {
                CSharpType = "List<{}>",
                Parser = "{}",
                IsVector = true,
            },
            "BlobType" or 
            "BitArrayType" or 
            "AsciiStringType" or 
            "StringType" => new Sc2JsonTypeConversion
            {
                CSharpType = $"List<byte>",
                Parser = "take_unaligned_byte",
                IsVector = true,
            },
            "IntType" => new Sc2JsonTypeConversion
            {
                CSharpType = "long",
                Parser = "parse_packed_int({})",
                IsSizedInt = true,
            },
            "FourCCType" => new Sc2JsonTypeConversion
            {
                CSharpType = "List<byte>",
                Parser = "take_fourcc",
            },
            "NullType" => new Sc2JsonTypeConversion
            {
                CSharpType = "()",
                Parser = "take_null",
            },
            var x => throw new NotSupportedException($"WTF TYPE {x}")
        };     
    }

    public static Sc2JsonTypeConversion GetFieldConverted(JsonNode field, string fieldTypeInfo)
    {
        var fieldConverted = field[Name].ToString() is "m_eventData" && fieldTypeInfo is "ChoiceType"
            ? new Sc2JsonTypeConversion
            {
                CSharpType = "m_eventData",
                Parser = "m_eventData.Parse",
            }
            : FromNnetName(fieldTypeInfo);

        if (fieldTypeInfo is "OptionalType")
        {
            var typeInfoType = field[TypeInfo][TypeInfo][Type].ToString();
            var enclosedFieldConverted = GetEnclosedFieldConverted(field, typeInfoType);

            fieldConverted.CSharpType = fieldConverted.CSharpType.Replace("{}", enclosedFieldConverted.CSharpType);
            fieldConverted.Parser = fieldConverted.Parser.Replace("{}", enclosedFieldConverted.Parser);
            fieldConverted.ShouldTryFrom = enclosedFieldConverted.ShouldTryFrom;
            fieldConverted.IsVector = enclosedFieldConverted.IsVector;
            fieldConverted.IsOptional = true;

            if (enclosedFieldConverted.IsSizedInt)
            {
                var offset = field[TypeInfo][TypeInfo][Bounds][Min][EValue].ToString();
                var bitsNum = BoundsMaxValueToBitSize(field[TypeInfo][TypeInfo][Bounds]);

                fieldConverted.Parser = fieldConverted.Parser.Replace("{}", $"input, {offset}, nuint {bitsNum}");
            }
        }
        else if (fieldTypeInfo is "ArrayType" or "BitArrayType" or "DynArrayType")
        {
            var elementType = fieldTypeInfo is "ArrayType" or "DynArrayType"
                ? field[TypeInfo][ElementType][FullName].ToString()
                : "byte";

            var enclosedFieldConverted = FromNnetName(elementType);
            fieldConverted.CSharpType = fieldConverted.CSharpType.Replace("{}", enclosedFieldConverted.CSharpType);
            fieldConverted.Parser = fieldConverted.Parser.Replace("{}", enclosedFieldConverted.Parser);
            fieldConverted.ShouldTryFrom = enclosedFieldConverted.ShouldTryFrom;
            fieldConverted.IsSizedInt = enclosedFieldConverted.IsSizedInt;
            fieldConverted.IsVector = true;
        }
        
        if (fieldConverted.IsSizedInt)
        {
            var offset = field[TypeInfo][Bounds][Min][EValue].ToString();
            var bitsNum = BoundsMaxValueToBitSize(field[TypeInfo][Bounds]);

            fieldConverted.Parser = fieldConverted.Parser.Replace("{}", $"input, {offset}, nuint {bitsNum}");
        }

        var fieldType = fieldConverted.CSharpType;
        var fieldValueParser = fieldConverted.Parser;


        return fieldConverted;
    }


     public static nuint BoundsMaxValueToBitSize(JsonNode bounds)
     {       
        var res = double.Parse(bounds[Max][EValue].ToString());

        if (!bool.Parse(bounds[Min][Inclusive].ToString()))
        {
            res -= 1;
        }

        if (!bool.Parse(bounds[Max][Inclusive].ToString()))
        {
            res -= 1;
        }

        return (nuint)Math.Floor((Math.Log2(res)) + 1);
    }

    private static Sc2JsonTypeConversion GetEnclosedFieldConverted(JsonNode field, string typeInfoType)
    {
        if (typeInfoType is "ArrayType" or "BitArrayType")
        {
            var elementType = GetElementType(field, typeInfoType);
            var enclosedFieldConverted = FromNnetName(elementType);

            enclosedFieldConverted.CSharpType = $"List<{enclosedFieldConverted.CSharpType}>";
            enclosedFieldConverted.IsVector = true;
            enclosedFieldConverted.IsOptional = true;

            return enclosedFieldConverted;
        }

        var fullName = field[TypeInfo][TypeInfo][FullName]?.ToString() ?? string.Empty;
        var enclosedType = !string.IsNullOrEmpty(fullName)
            ? fullName
            : field[TypeInfo][TypeInfo][Type].ToString();

        return FromNnetName(enclosedType);
    }
    
    private static string GetElementType(JsonNode field, string typeInfoType)
    {
        if (typeInfoType is "ArrayType" or "DynArrayType")
        {
            return field[TypeInfo][TypeInfo][ElementType][FullName].ToString();
        }

        return "byte";
    }
}

public class Sc2JsonTypeConversionByteAligned : ISc2JsonTypeConversionAlignment
{
    public static Sc2JsonTypeConversion FromNnetName(string nnetName) => nnetName switch
    {
        "NNet.uint8" or
        "NNet.Replay.EReplayType" or
        "NNet.uint6" or
        "NNet.Game.TPlayerId" or
        "NNet.Game.TControlId" or
        "NNet.Game.TTeamId" or
        "NNet.Replay.Tracker.TUIntMiniBits" => new Sc2JsonTypeConversion
        {
            CSharpType = "byte",
            ShouldTryFrom = true,
            Parser = "tagged_vlq_int",
        },
        "NNet.uint32" or
        "NNet.uint14" or
        "NNet.uint22" or
        "NNet.Game.TDifficulty" or
        "NNet.Game.THandicap" => new Sc2JsonTypeConversion
        {
            CSharpType = "int",
            ShouldTryFrom = true,
            Parser = "tagged_vlq_int",
        },
        "NNet.int32" or "NNet.Game.TFixedBits" => new Sc2JsonTypeConversion
        {
            CSharpType = "int",
            ShouldTryFrom = true,
            Parser = "tagged_vlq_int",
        },
        "NNet.SVersion" => new Sc2JsonTypeConversion
        {
            CSharpType = "SVersion",
            Parser = "SVersion.Parse"
        },
        "NNet.Game.TColorId" or "NNet.int64" => new Sc2JsonTypeConversion
        {
            CSharpType = "long",
            ShouldTryFrom = true,
            Parser = "tagged_vlq_int",
        },
        "NNet.uint64" => new Sc2JsonTypeConversion
        {
            CSharpType = "long",
            ShouldTryFrom = true,
            Parser = "tagged_vlq_int"
        },
        "FourCCType" => new Sc2JsonTypeConversion
        {
            CSharpType = "int",
            Parser = "tagged_fourcc"
        },
        "BlobType" or
        "NNet.Replay.CSignature" or
        "StringType" or
        "NNet.Replay.Tracker.CatalogName" or
        "NNet.Game.CCacheHandle" or
        "NNet.CFilePath" or
        "NNet.CUserName" => new Sc2JsonTypeConversion
        {
            CSharpType = "List<byte>",
            Parser = "tagged_blob",
        },
        "BoolType" => new Sc2JsonTypeConversion
        {
            CSharpType = "bool",
            Parser = "tagged_bool"
        },
        "OptionalType" => new Sc2JsonTypeConversion
        {
            CSharpType = "Option<{}>",
            Parser = "{}",
            IsOptional = true,
        },
        "ArrayType" or
        "DynArrayType" or
        "NNet.CUserArchiveDataArray" or
        "NNet.CUserInitialDataArray" => new Sc2JsonTypeConversion
        {
            CSharpType = "List<{}>",
            Parser = "{}",
            IsVector = true,
        },
        "NNet.SMD5" => new Sc2JsonTypeConversion
        {
            CSharpType = "SMD5",
            Parser = "SMD5.Parse",
        },
        "NNet.EObserve" => new Sc2JsonTypeConversion
        {
            CSharpType = "EObserve",
            Parser = "EObserve.Parse",
        },
        "NNet.Game.EResultDetails" => new Sc2JsonTypeConversion
        {
            CSharpType = "GameEResultDetails",
            Parser = "GameEResultDetails.Parse"
        },
        "NNet.Game.CCacheHandles" => new Sc2JsonTypeConversion
        {
            CSharpType = "List<List<byte>>",
            Parser = "tagged_blob",
            IsVector = true,
        },
        "NNet.Replay.Tracker.SPlayerStats" => new Sc2JsonTypeConversion
        {
            CSharpType = "ReplayTrackerSPlayerStats",
            Parser = "ReplayTrackerSPlayerStats.Parse"
        },
        "NNet.Game.CPlayerDetailsArray" => new Sc2JsonTypeConversion
        {
            CSharpType = "List<GameSPlayerDetails>",
            Parser = "GameSPlayerDetails.Parse"
        },
        "NNet.Game.SThumbnail" => new Sc2JsonTypeConversion
        {
            CSharpType = "GameSThumbnail",
            Parser = "GameSThumbnail.Parse"
        },
        "NNet.Game.CModPaths" => new Sc2JsonTypeConversion
        {
            CSharpType = "List<List<byte>>",
            Parser = "tagged_blob",
            IsVector = true,
        },
        "NNet.Game.EGameSpeed" => new Sc2JsonTypeConversion
        {
            CSharpType = "GameEGameSpeed",
            Parser = "GameEGameSpeed.Parse"
        },
        "NNet.Game.SToonNameDetails" => new Sc2JsonTypeConversion
        {
            CSharpType = "GameSToonNameDetails",
            Parser = "GameSToonNameDetails.Parse"
        },
        "NNet.Game.SColor" => new Sc2JsonTypeConversion
        {
            CSharpType = "GameSColor",
            Parser = "GameSColor.Parse"
        },
        var x => throw new NotSupportedException($"WTF TYPE {x}")
    };

    public static Sc2JsonTypeConversion GetFieldConverted(JsonNode field, string fieldTypeInfo)
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

    private static Sc2JsonTypeConversion GetEnclosedFieldConverted(JsonNode field)
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