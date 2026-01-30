namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;

using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators.Utils;
using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;
using System.Text.Json.Nodes;
using static Sc2ReplayAnalyzer.Json.ProtocolJsonType;

internal class ArrayGenerator(StringBuilder builder, Sc2GeneratorData data)
    : CodeGeneratorBase(builder, data)
{
    public void Generate<T>(IReadOnlyList<JsonNode> nodes)
        where T : IProtocolTypeConversionAlignment
    {
        // bitpacked
        var arrayNodes = nodes.Where(node => ProtoTypes.IsForGenerator(node, ProtoGenType.BitArray));

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