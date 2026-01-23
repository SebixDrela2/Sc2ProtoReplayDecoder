using System.Diagnostics;
using System.Text;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes;
using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

internal class Sc2EnumGenerator(StringBuilder builder,
    Dictionary<string, string> enumTags,
    Dictionary<string, string> choiceMap)
    : Sc2GeneratorBase(builder, choiceMap)
{
    public void Generator(IReadOnlyList<JsonNode> nodes)
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

                Close();
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
