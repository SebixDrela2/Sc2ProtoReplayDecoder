using System.Diagnostics;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes;
using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

internal class Sc2EnumGenerator(Dictionary<string, string> enumTags)
{
    public void Generator(IReadOnlyList<JsonNode> nodes)
    {
        var enumNodes = nodes.Where(x => x[TypeInfo][Type].ToString() is "EnumType");

        foreach(var node in enumNodes)
        {
            var variantArray = node[TypeInfo][Fields].AsArray();

            foreach(var variant in variantArray)
            {
                var variantName = variant[Name].ToString();
                var variantValueFullName = $"{node[FullName]}.{variantName}";
                var variantValue = variant[Value][Value].ToString();

                Debug.Assert(variant[Value][Type].ToString() is "IntLiteral");

                Console.WriteLine($"{variantValueFullName} = {variantValue}");
            }
        }
    }
}
