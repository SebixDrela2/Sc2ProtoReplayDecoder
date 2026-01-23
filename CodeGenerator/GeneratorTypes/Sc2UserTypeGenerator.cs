namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes;

using System.Text;
using System.Text.Json.Nodes;
using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

internal class Sc2UserTypeGenerator(StringBuilder builder) : Sc2GeneratorBase(builder)
{
    public void Generate(IReadOnlyList<JsonNode> nodes)
    {
        // bitpacked
        var userTypeNodes = nodes.Where(x => x[TypeInfo][Type].ToString() is "UserType");

        foreach(var node in userTypeNodes)
        {
            var fullName = node[FullName].ToString();
            var typeInfoFullName = node[TypeInfo][FullName].ToString();

            if (OpenClass(fullName))
            {
                AddField("Value", typeInfoFullName);
                Close();
            }
        }
    }
}