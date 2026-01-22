namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes;

using System.Text.Json.Nodes;
using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

internal class Sc2IntGenerator
{
    public void Generate<T>(IReadOnlyList<JsonNode> nodes)
        where T : ISc2JsonTypeConversionAlignment
    {
        var intNodes = nodes.Where(x => x[TypeInfo][Type].ToString() is "IntType" or "InumType");


    }
}
