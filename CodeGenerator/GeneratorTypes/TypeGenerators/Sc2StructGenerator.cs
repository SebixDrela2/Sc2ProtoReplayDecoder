using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;

using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

internal class Sc2StructGenerator(StringBuilder builder, Sc2GeneratorData data)
    : Sc2GeneratorBase(builder, data)
{
    public void Generate<T>(IReadOnlyList<JsonNode> nodes)
        where T : ISc2JsonTypeConversionAlignment
    {
        var structNodes = nodes.Where(x => x[TypeInfo][Type].ToString() is "StructType");

        foreach (var node in structNodes)
        {
            var unitTypeName = node[FullName].ToString();
            var unitType = node[TypeInfo][Type].ToString();
            var fields = node[TypeInfo][Fields].AsArray();
            var hasTags = fields.Count > 1 && fields[0][Tag] is not null;
            var methodParser = GetMethodParser<T>();

            if (OpenClass(unitTypeName))
            {
                methodParser.OpenStruct(unitTypeName, hasTags);

                foreach (var field in fields)
                {
                    HandleStructField<T>(field, unitTypeName, hasTags);
                }

                methodParser.CloseStruct(hasTags);
                methodParser.Finalise();

                Close();
            }
        }
    }

    private void HandleStructField<T>(JsonNode field, string unitTypeName, bool hasTags)
        where T : ISc2JsonTypeConversionAlignment
    {
        var methodParser = GetMethodParser<T>();
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
        var fieldConverted = GetStructFieldCoverted<T>(field, fieldTypeInfo);
        var fieldType = fieldConverted.CSharpType;

        AddField(fieldName, fieldConverted.CSharpType);
        methodParser.ContinueFieldStruct(field, fieldConverted, fieldName, fieldType, unitTypeName, hasTags);
        
    }

    private Sc2JsonTypeConversion GetStructFieldCoverted<T>(JsonNode field, string fieldTypeInfo)
        where T : ISc2JsonTypeConversionAlignment
    {
        var fieldConverted = T.GetFieldConverted(field, fieldTypeInfo);

        return fieldConverted;
    }
}
