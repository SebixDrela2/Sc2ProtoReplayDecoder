using Sc2ReplayAnalyzer.Json.Generator;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;
using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

internal class Sc2EnumGenerator(StringBuilder builder, Sc2GeneratorData data)
    : Sc2GeneratorBase(builder, data)
{
    public void Generator<T>(IReadOnlyList<JsonNode> nodes)
        where T : ISc2JsonTypeConversionAlignment
    {
        var enumNodes = nodes.Where(x => x[TypeInfo][Type].ToString() is "EnumType");

        foreach(var node in enumNodes)
        {
            var fullName = node[FullName].ToString();

            if (OpenEnum(fullName))
            {
                var variantArray = node[TypeInfo][Fields].AsArray();

                foreach (var variant in variantArray)
                {
                    HandleVariant(node, variant);
                }

                Close(GetMethodParser<T>().MethodBuilder);
            }
        }
    }

    private void HandleVariant(JsonNode node, JsonNode variant)
    {
        var variantName = variant[Name].ToString();
        var variantValue = variant[Value][Value].ToString();

        Debug.Assert(variant[Value][Type].ToString() is "IntLiteral");

        AddEnum(variantName, variantValue);
    }
}
