using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators.Utils;
using System.Text;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.MethodGenerators;

internal interface IProtocolMethodParser : IProtocolFinaliserParser
{
    void OpenArray(JsonNode bounds, string unitTypeName, string internalType);
    void OpenInt(JsonNode bounds, string unitTypeName);
    void OpenChoice(string unitTypeName, int numFields);

    void ContinueVariantChoice(
        ProtocolJsonTypeConversion fieldConverted, 
        string fieldTypeInfo, 
        string fieldType, 
        string variantName, 
        string fieldTag);

    void CloseChoice();

    void OpenStruct(string unitTypeName, bool hasTags);

    void ContinueFieldStruct(
        JsonNode field,
        ProtocolJsonTypeConversion fieldConverted,
        string fieldName,
        string fieldType,
        string unitTypeName,
        bool hasTags);

    void CloseStruct(bool hasTags);
}
