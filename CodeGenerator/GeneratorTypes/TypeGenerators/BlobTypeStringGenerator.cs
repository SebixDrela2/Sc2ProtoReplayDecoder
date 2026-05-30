namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;

using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators.Utils;
using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;
using System.Text.Json.Nodes;
using static Sc2ReplayAnalyzer.Json.ProtocolJsonType;

internal class BlobTypeStringGenerator(StringBuilder builder, Sc2GeneratorData data)
    : CodeGeneratorBase(builder, data)
{
    public void Generate<T>(IReadOnlyList<JsonNode> nodes)
        where T : IProtocolTypeConversionAlignment
    {
        // bitpacked
        var blobNodes = nodes.Where(node => ProtoTypes.IsForGenerator(node, ProtoGenType.Blob));
        var stringNodes = nodes.Where(node => ProtoTypes.IsForGenerator(node, ProtoGenType.String));

        var methodParser = GetBitMethodParser();

        foreach (var node in stringNodes)
        {
            var fullName = node[FullName].ToString();
            var bounds = node[TypeInfo][Bounds];

            var unitTypeName = ProtocolTypeUtils.GetTypeName(fullName);

            if (ProtocolTypeUtils.IsUnusedUnitTypeName(unitTypeName))
            {
                continue;
            }

            if (OpenClass(fullName))
            {
                AddField("Value", "byte[]");
                Close();
            }

            methodParser.OpenString(bounds, fullName);
            methodParser.Finalise();
        }

        foreach (var node in blobNodes)
        {
            var fullName = node[FullName].ToString();
            var bounds = node[TypeInfo][Bounds];

            if (bounds is null)
            {
                throw new Exception("OOGA");
            }

            if (OpenClass(fullName))
            {   
                AddField("Value", "byte[]");
                Close();
            }

            methodParser.OpenBlob(bounds, fullName);
            methodParser.Finalise();
        }
    }
}