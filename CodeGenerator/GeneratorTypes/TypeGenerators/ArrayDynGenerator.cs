namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;

using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;
using System.Text.Json.Nodes;
using static Sc2ReplayAnalyzer.Json.ProtocolJsonType;

internal class ArrayDynGenerator(StringBuilder builder, Sc2GeneratorData data)
    : CodeGeneratorBase(builder, data)
{
    public void Generate<T>(IReadOnlyList<JsonNode> nodes)
        where T : IProtocolTypeConversionAlignment
    {
        // bitpacked
        var arrayNodes = nodes.Where(x => x[TypeInfo][Type].ToString() is "ArrayType" or "DynArrayType");
        var methodParser = GetMethodParser<T>();

        foreach(var node in arrayNodes)
        {
            var fullName = node[FullName].ToString();
            var elementType = node[TypeInfo][ElementType][FullName].ToString();
            var bounds = node[TypeInfo][Bounds];
            var internalType = node[TypeInfo][ElementType][FullName].ToString();

            if (OpenClass(fullName))
            {
                AddField("Value", $"List<{elementType}>");
                Close();
            }

            methodParser.OpenArray(bounds, fullName, internalType);
            methodParser.Finalise();
        }
    }
}