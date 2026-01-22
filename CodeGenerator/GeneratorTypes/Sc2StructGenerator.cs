using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes;

using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

internal class Sc2StructGenerator
{
    public void GenerateStructs<T>(IReadOnlyList<JsonNode> nodes)
        where T : ISc2JsonTypeConversionAlignment
    {
        var structNodes = nodes.Where(x => x[TypeInfo][Type].ToString() is "StructType");

        foreach (var node in structNodes)
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
        where T : ISc2JsonTypeConversionAlignment
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
        var fieldConverted = T.GetFieldConverted(field, fieldTypeInfo);

        var fieldType = fieldConverted.CSharpType;
        var fieldValueParser = fieldConverted.Parser;

        return fieldType;
    }
}
