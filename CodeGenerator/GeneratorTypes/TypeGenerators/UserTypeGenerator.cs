namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;

using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators.Utils;
using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;
using System.Text.Json.Nodes;
using static Sc2ReplayAnalyzer.Json.ProtocolJsonType;

internal class UserTypeGenerator(StringBuilder builder, Sc2GeneratorData data)
    : CodeGeneratorBase(builder, data)
{
    public void Generate<T>(IReadOnlyList<JsonNode> nodes)
        where T : IProtocolTypeConversionAlignment
    {
        var userTypeNodes = nodes.Where(node => ProtoTypes.IsForGenerator(node, ProtoGenType.UserType));
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