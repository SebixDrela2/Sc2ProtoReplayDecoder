namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;

using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;
using System.Text.Json.Nodes;
using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

internal class Sc2IntGenerator(StringBuilder builder, Sc2GeneratorData data)
    : Sc2GeneratorBase(builder, data)
{
    public void Generate<T>(IReadOnlyList<JsonNode> nodes)
        where T : ISc2JsonTypeConversionAlignment
    {
        var intNodes = nodes.Where(x => x[TypeInfo][Type].ToString() is "IntType" or "InumType");

        foreach(var node in intNodes)
        {
            var fullName = node[FullName].ToString();

            if (OpenClass(fullName))
            {
                AddField("Value", "long");

                Close();
            }
        }
    }
}
