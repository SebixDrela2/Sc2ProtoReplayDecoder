using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators.Utils;

internal interface IProtocolTypeConversionAlignment
{
    static abstract ProtocolJsonTypeConversion FromNnetName(string nnetName);
    static abstract ProtocolJsonTypeConversion GetFieldConverted(JsonNode field, string fieldTypeInfo);
}
