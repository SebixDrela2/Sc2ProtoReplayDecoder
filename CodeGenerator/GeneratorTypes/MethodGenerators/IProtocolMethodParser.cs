using System.Text;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.MethodGenerators;

internal interface IProtocolMethodParser : IProtocolFinaliserParser
{
    void OpenArray(JsonNode bounds, string unitTypeName, string internalType);
    void OpenInt(JsonNode bounds, string unitTypeName);
    void OpenChoice(string unitTypeName, int numFields);

    void ContinueVariantChoice(
        Sc2JsonTypeConversion fieldConverted, 
        string fieldTypeInfo, 
        string fieldType, 
        string variantName, 
        string fieldTag);

    void CloseChoice();

    void OpenStruct(string unitTypeName, bool hasTags);

    void ContinueFieldStruct(
        JsonNode field,
        Sc2JsonTypeConversion fieldConverted,
        string fieldName,
        string fieldType,
        string unitTypeName,
        bool hasTags);

    void CloseStruct(bool hasTags);
}
