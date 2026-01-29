namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;

using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;
using System.Text.Json.Nodes;
using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

internal class Sc2BlobTypeStringGenerator(StringBuilder builder, Sc2GeneratorData data)
    : Sc2GeneratorBase(builder, data)
{
    public void Generate<T>(IReadOnlyList<JsonNode> nodes)
        where T : ISc2JsonTypeConversionAlignment
    {
        // bitpacked
        var blobNodes = nodes.Where(x => x[TypeInfo][Type].ToString() is "BlobType");
        var stringNodes = nodes.Where(x => x[TypeInfo][Type].ToString() is "StringType");

        var methodParser = GetBitMethodParser();

        foreach (var node in stringNodes)
        {
            var fullName = node[FullName].ToString();
            var bounds = node[TypeInfo][Bounds];

            if (OpenClass(fullName))
            {
                Console.WriteLine(fullName);

                AddField("Value", "List<byte>");
                Close();
            }

            methodParser.OpenString(bounds, fullName);
            methodParser.Finalise();
        }

        Console.WriteLine();

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
                Console.WriteLine(fullName);

                AddField("Value", "List<byte>");
                Close();
            }

            methodParser.OpenBlob(bounds, fullName);
            methodParser.Finalise();
        }
    }
}