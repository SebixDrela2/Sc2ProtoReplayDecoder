using System.Text;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.MethodGenerators;

internal interface ISc2MethodParser
{
    void OpenStruct(string unitTypeName, bool hasTags);

    void ContinueFieldStruct(
        JsonNode field,
        Sc2JsonTypeConversion fieldConverted,
        string fieldName,
        string fieldType,
        string unitTypeName,
        bool hasTags);

    void CloseStruct(bool hasTags);
    void Finalise();
}
