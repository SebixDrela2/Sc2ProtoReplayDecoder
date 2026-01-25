using Sc2ReplayAnalyzer.Json.Generator;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;
using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

internal class Sc2EnumGenerator(StringBuilder builder, Sc2GeneratorData data)
    : Sc2GeneratorBase(builder, data)
{
    public void Generate<T>(IReadOnlyList<JsonNode> nodes)
        where T : ISc2JsonTypeConversionAlignment
    {
        var enumNodes = nodes.Where(x => x[TypeInfo][Type].ToString() is "EnumType");

        foreach(var node in enumNodes)
        {
            var fullName = node[FullName].ToString();
            var methodParser = GetAgnosticMethodParser();

            if (AddInterfaceEnum(fullName))
            {           
                var variantArray = node[TypeInfo][Fields].AsArray();

                methodParser.OpenEnum<T>(fullName, variantArray.Count);
                foreach (var variant in variantArray)
                {
                    HandleVariant(node, variant);
                }

                methodParser.CloseEnum();
                methodParser.Finalise();

                AddLine();
            }
        }
    }

    private void HandleVariant(JsonNode node, JsonNode variant)
    {
        var fullName = node[FullName].ToString();
        var variantName = variant[Name].ToString();
        var variantValue = variant[Value][Value].ToString();

        var variantValueFullName = $"{Sc2TypeUtils.GetTypeName(fullName)}.{variantName}";

        Debug.Assert(variant[Value][Type].ToString() is "IntLiteral");

        AddRecordEnum(variantValueFullName, variantName, fullName);

        var methodParser = GetAgnosticMethodParser();
        methodParser.ContinueEnumVariant(variantValue, variantValueFullName, fullName, variantName);
    }
}
