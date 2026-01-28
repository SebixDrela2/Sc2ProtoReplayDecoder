using System.Text;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.MethodGenerators;

internal interface ISc2FinaliserParser
{
    void Finalise();
}

internal interface ISc2AgnosticParser : ISc2FinaliserParser
{
    void OpenUserType(string unitTypeName, string typeInfo);

    void OpenEnum<T>(string unitTypeName, int numFields, int? boundsLength)
        where T : ISc2JsonTypeConversionAlignment;

    void ContinueEnumVariant(string variantValue, string variantValueFullName, string fullName, string variantName);

    void CloseEnum();
}

internal interface ISc2MethodParser : ISc2FinaliserParser
{
    void OpenArray(JsonNode bounds, string unitTypeName, string internalType);
    void OpenInt(JsonNode bounds, string unitTypeName);
    void OpenChoice(string unitTypeName, int numFields, int? boundsLength);

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
