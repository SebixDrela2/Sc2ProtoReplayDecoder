namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes;

using System.Text;
using System.Text.Json.Nodes;
using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

internal class Sc2IntGenerator(StringBuilder builder, Dictionary<string, string> choiceMap)
    : Sc2GeneratorBase(builder, choiceMap)
{
    public void Generate(IReadOnlyList<JsonNode> nodes)
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
