using Sc2ReplayAnalyzer.Json.Generator;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.Generators;

using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

public class Sc2CodeGenerator(IReadOnlyList<Sc2GeneratorData> dataList)
{
    public void Generate()
    {
        var byteAligned = dataList.Last().ByteAligned.Where(x => x[TypeInfo][Type].ToString() is "StructType");
        GenerateStructs<Sc2JsonTypeConversionByteAligned>(byteAligned);
    }

    private void GenerateStructs<T>(IEnumerable<JsonNode> nodes)
        where T : ISc2JsonTypeConversionAlignment
    {
        foreach (var node in nodes)
        {
            var unitTypeName = node[FullName].ToString();
            var unitType = node[TypeInfo][Type];
            var fields = node[TypeInfo][Fields].AsArray();
            var hasTags = fields.Count > 1 || fields[0]["tag"] is not null;

            Console.WriteLine();
            Console.WriteLine($"{unitTypeName} {unitType}");

            foreach (var field in fields)
            {
                HandleStructField<T>(field);
            }
        }
    }

    private void HandleStructField<T>(JsonNode field)
        where T: ISc2JsonTypeConversionAlignment
    {
        var nnetFieldType = field[Type].ToString();

        var typeInfoFullName = field[TypeInfo][FullName]?.ToString() ?? string.Empty;
        var fieldTypeInfo = !string.IsNullOrEmpty(typeInfoFullName)
            ? typeInfoFullName
            : field[TypeInfo][Type].ToString();

        if (nnetFieldType is "ConstDecl")
        {
            return;
        }

        if (nnetFieldType is not "MemberStructField")
        {
            throw new Exception("Not a struct field, expected.");
        }

        var fieldName = field[Name].ToString();
        var fieldType = GetStructFieldType<T>(field, fieldTypeInfo);

        Console.WriteLine($"\"{fieldName}\": \"{fieldType}\"");
    }

    private string GetStructFieldType<T>(JsonNode field, string fieldTypeInfo)
        where T : ISc2JsonTypeConversionAlignment
    {
        var fieldConverted = GetFieldConverted<T>(field, fieldTypeInfo);

        var fieldType = fieldConverted.CSharpType;
        var fieldValueParser = fieldConverted.Parser;

        return fieldType;
    }

    private Sc2JsonTypeConversion GetFieldConverted<T>(JsonNode field, string fieldTypeInfo)
        where T : ISc2JsonTypeConversionAlignment
    {
        var fieldConverted = T.FromNnetName(fieldTypeInfo);

        if (fieldTypeInfo is "OptionalType")
        {
            var enclosedFieldConverted = GetEnclosedFieldConverted<T>(field);

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
            var enclosedConvertedType = T.FromNnetName(elementType);

            fieldConverted.CSharpType = fieldConverted.CSharpType.Replace("{}", enclosedConvertedType.CSharpType);
            fieldConverted.Parser = fieldConverted.Parser.Replace("{}", enclosedConvertedType.Parser);
            fieldConverted.ShouldTryFrom = enclosedConvertedType.ShouldTryFrom;
            fieldConverted.IsVector = true;

            return fieldConverted;
        }

        return fieldConverted;
    }

    private Sc2JsonTypeConversion GetEnclosedFieldConverted<T>(JsonNode field)
        where T : ISc2JsonTypeConversionAlignment
    {
        if (field[TypeInfo][TypeInfo][Type].ToString() == "ArrayType")
        {
            var elementType = field[TypeInfo][TypeInfo][ElementType][FullName].ToString();

            var enclosedFieldConverted = T.FromNnetName(elementType);
            enclosedFieldConverted.CSharpType = $"List<{enclosedFieldConverted.CSharpType}>";
            enclosedFieldConverted.IsVector = true;
            enclosedFieldConverted.IsOptional = true;

            return enclosedFieldConverted;
        }

        var enclosedTypeFullName = field[TypeInfo][TypeInfo][FullName]?.ToString() ?? string.Empty;
        var enclosedType = !string.IsNullOrEmpty(enclosedTypeFullName)
            ? enclosedTypeFullName
            : field[TypeInfo][TypeInfo][Type].ToString();

        return T.FromNnetName(enclosedType);
    }
}
