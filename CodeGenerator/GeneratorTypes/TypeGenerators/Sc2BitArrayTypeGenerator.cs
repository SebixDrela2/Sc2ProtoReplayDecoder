namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;

using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;
using System.Text.Json.Nodes;
using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

internal class Sc2BitArrayGenerator(StringBuilder builder, Sc2GeneratorData data)
    : Sc2GeneratorBase(builder, data)
{
    public void Generate<T>(IReadOnlyList<JsonNode> nodes)
        where T : ISc2JsonTypeConversionAlignment
    {
        // bitpacked
        var arrayNodes = nodes.Where(x => x[TypeInfo][Type].ToString() is "BitArrayType");

        foreach(var node in arrayNodes)
        {
            var fullName = node[FullName].ToString();
            var methodParser = GetBitMethodParser();
            var bounds = node[TypeInfo][Bounds];

            if (OpenClass(fullName))
            {
                AddField("Value", "List<byte>");
                Close();
            }

            methodParser.OpenBitArray(bounds, fullName);
            methodParser.Finalise();
        }
    }
}