using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators.Utils;

using static Sc2ReplayAnalyzer.Json.ProtocolJsonType;

public class ProtocolConversionBitPacked : IProtocolTypeConversionAlignment
{
    public static ProtocolJsonTypeConversion FromNnetName(string nnetName)
    {
        if (nnetName.StartsWith("NNet"))
        {
            return new ProtocolJsonTypeConversion
            {
                CSharpType = nnetName,
                Parser = $"Parse_{ProtocolTypeUtils.GetTypeName(nnetName)}"
            };
        }

        return nnetName switch
        {
            "BoolType" => new ProtocolJsonTypeConversion
            {
                CSharpType = "bool",
                Parser = "parse_bool",
            },
            "OptionalType" => new ProtocolJsonTypeConversion
            {
                CSharpType = "Option<{}>",
                Parser = "{}",
                IsOptional = true,
            },
            "ArrayType" or "DynArrayType" => new ProtocolJsonTypeConversion
            {
                CSharpType = "List<{}>",
                Parser = "{}",
                IsVector = true,
            },
            "BlobType" or
            "BitArrayType" or
            "AsciiStringType" or
            "StringType" => new ProtocolJsonTypeConversion
            {
                CSharpType = $"List<u8>",
                Parser = "take_aligned_byte",
                IsVector = true,
            },
            "IntType" => new ProtocolJsonTypeConversion
            {
                CSharpType = "i64",
                Parser = "parse_packed_int({})",
                IsSizedInt = true,
            },
            "FourCCType" => new ProtocolJsonTypeConversion
            {
                CSharpType = "List<u8>",
                Parser = "take_fourcc",
            },
            "NullType" => new ProtocolJsonTypeConversion
            {
                CSharpType = "object",
                Parser = "take_null",
            },
            var x => throw new NotSupportedException($"WTF TYPE {x}")
        };
    }

    public static ProtocolJsonTypeConversion GetFieldConverted(JsonNode field, string fieldTypeInfo)
    {
        var fieldConverted = field[Name].ToString() is "m_eventData" && fieldTypeInfo is "ChoiceType"
            ? new ProtocolJsonTypeConversion
            {
                CSharpType = "m_eventData",
                Parser = "Parse_m_eventData",
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

                fieldConverted.Parser = fieldConverted.Parser.Replace("{}", $"{offset}, {bitsNum}");
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

            if (elementType is "byte")
            {
                fieldConverted.IsBitArray = true;
            }
        }

        if (fieldConverted.IsSizedInt)
        {
            var offset = field[TypeInfo][Bounds][Min][EValue].ToString();
            var bitsNum = BoundsMaxValueToBitSize(field[TypeInfo][Bounds]);

            fieldConverted.Parser = fieldConverted.Parser.Replace("{}", $"{offset}, {bitsNum}");
        }

        var fieldType = fieldConverted.CSharpType;
        var fieldValueParser = fieldConverted.Parser;


        return fieldConverted;
    }

    public static int GetBoundsCCacheHandle(JsonNode bounds)
    {
        var boundType = bounds[Type].ToString();

        if (boundType is "ExactConstraint")
        {
            if (bounds[Max][Inclusive].GetValue<bool>())
            {
                return int.Parse(bounds[Max][EValue].ToString());
            }
        }

        throw new InvalidOperationException("OOGA BOOGA WUT");
    }

    public static long BoundsMaxValueToBitSize(JsonNode bounds)
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

        return (long)Math.Floor(Math.Log(res, 2) + 1);
    }

    private static ProtocolJsonTypeConversion GetEnclosedFieldConverted(JsonNode field, string typeInfoType)
    {
        if (typeInfoType is "ArrayType" or "BitArrayType")
        {
            var elementType = GetElementType(field, typeInfoType);
            var enclosedFieldConverted = FromNnetName(elementType);

            enclosedFieldConverted.CSharpType = $"List<{enclosedFieldConverted.CSharpType}>";
            enclosedFieldConverted.IsVector = true;
            enclosedFieldConverted.IsOptional = true;

            if (elementType is "byte")
            {
                enclosedFieldConverted.IsBitArray = true;
            }

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
