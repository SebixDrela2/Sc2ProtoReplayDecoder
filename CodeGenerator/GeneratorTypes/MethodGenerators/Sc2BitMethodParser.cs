using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.MethodGenerators;

internal class Sc2BitMethodParser(StringBuilder methodBuilder, Sc2GeneratorData data) : ISc2MethodParser
{
    public StringBuilder MethodBuilder => methodBuilder;

    public void CloseStruct(bool hasTags)
    {
       // no op;
    }

    public void ContinueFieldStruct(JsonNode field, Sc2JsonTypeConversion fieldConverted, string fieldName, string fieldType, string unitTypeName, bool hasTags)
    {
        // no op;
    }

    public void Finalise()
    {
        // no op;
    }

    public void OpenStruct(string unitTypeName, bool hasTags)
    {
        methodBuilder.AppendLine();
        methodBuilder.AppendLine("""
                    public void Parse(BinaryReader reader) 
                    {
                        ValidateStructTag(reader);
                        var structFieldCount = ParseVlqInt(reader);
                    } // TO DO
                """);
    }
}
