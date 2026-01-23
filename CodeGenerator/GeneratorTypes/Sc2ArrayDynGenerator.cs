namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes;

using System.Text;
using System.Text.Json.Nodes;
using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

internal class Sc2ArrayDynGenerator(StringBuilder builder, Dictionary<string, string> choiceMap) 
    : Sc2GeneratorBase(builder, choiceMap)
{
    public void Generate(IReadOnlyList<JsonNode> nodes)
    {
        // bitpacked
        var arrayNodes = nodes.Where(x => x[TypeInfo][Type].ToString() is "ArrayType" or "DynArrayType");

        foreach(var node in arrayNodes)
        {
            var fullName = node[FullName].ToString();
            var elementType = node[TypeInfo][ElementType][FullName].ToString();

            if (OpenClass(fullName))
            {
                AddField("Value", elementType);
                Close();
            }
        }
    }
}