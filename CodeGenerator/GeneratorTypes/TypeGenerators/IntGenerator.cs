namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;

using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;
using System.Text.Json.Nodes;
using static Sc2ReplayAnalyzer.Json.ProtocolJsonType;

internal class IntGenerator(StringBuilder builder, Sc2GeneratorData data)
    : CodeGeneratorBase(builder, data)
{
    public void Generate<T>(IReadOnlyList<JsonNode> nodes)
        where T : IProtocolTypeConversionAlignment
    {
        var intNodes = nodes.Where(x => x[TypeInfo][Type].ToString() is "IntType" or "InumType");
        var methodParser = GetMethodParser<T>();

        foreach(var node in intNodes)
        {
            var fullName = node[FullName].ToString();
            var bounds = node[TypeInfo][Bounds];

            if (bounds is null)
            {
                continue;
            }

            if (OpenClass(fullName))
            {
                AddField("Value", "long");
                Close();
            }

            methodParser.OpenInt(bounds, fullName);
            methodParser.Finalise();
        }
    }
}
