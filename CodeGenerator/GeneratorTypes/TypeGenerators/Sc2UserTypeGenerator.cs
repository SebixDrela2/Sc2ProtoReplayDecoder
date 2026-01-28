namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;

using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;
using System.Text.Json.Nodes;
using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

internal class Sc2UserTypeGenerator(StringBuilder builder, Sc2GeneratorData data)
    : Sc2GeneratorBase(builder, data)
{
    public void Generate<T>(IReadOnlyList<JsonNode> nodes)
        where T : ISc2JsonTypeConversionAlignment
    {
        var userTypeNodes = nodes.Where(x => x[TypeInfo][Type].ToString() is "UserType");
        var methodParser = GetAgnosticMethodParser();

        foreach(var node in userTypeNodes)
        {
            var fullName = node[FullName].ToString();
            var typeInfoFullName = node[TypeInfo][FullName].ToString();

            if (OpenClass(fullName))
            {
                AddField("Value", typeInfoFullName);
                Close();
            }

            methodParser.OpenUserType(fullName, typeInfoFullName);
            methodParser.Finalise();
        }
    }
}