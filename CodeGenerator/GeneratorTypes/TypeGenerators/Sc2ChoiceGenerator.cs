using Sc2ReplayAnalyzer.Json.Generator;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;

using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

internal class Sc2ChoiceGenerator(StringBuilder builder, Sc2GeneratorData data)
    : Sc2GeneratorBase(builder, data)
{
    public void GenerateChoices<T>(IReadOnlyList<JsonNode> nodes)
        where T : ISc2JsonTypeConversionAlignment
    {
        var choiceNodes = nodes.Where(x => x[TypeInfo][Type].ToString() is "ChoiceType");

        foreach (var node in choiceNodes)
        {
            var variantArray = node[TypeInfo][Fields].AsArray();
            var fullName = node[FullName]?.ToString() ?? node[Name].ToString();

            if (OpenChoice(fullName))
            {
                foreach (var variant in variantArray)
                {
                    HandleVariant<T>(variant, fullName);
                }            
            }
        }    
    }

    private void HandleVariant<T>(JsonNode variant, string fullName)
        where T : ISc2JsonTypeConversionAlignment
    {
        if (variant[TypeInfo][Type].ToString() is "NullType")
        {
            return;
        }

        var fieldTypeInfoFullName = variant[TypeInfo][FullName]?.ToString();
        var variantName = variant[Name].ToString();
        var fieldTypeInfo = fieldTypeInfoFullName is not null
            ? fieldTypeInfoFullName
            : variant[TypeInfo][Type].ToString();

        var fieldConverted = T.FromNnetName(fieldTypeInfo);

        if (fieldTypeInfo is "OptionalType")
        {
            var enclosedType = variant[TypeInfo][TypeInfo][Type].ToString();

            if (typeof(T) == typeof(Sc2TypeConversionBitPacked) && enclosedType is "UserType")
            {
                enclosedType = variant[TypeInfo][TypeInfo][FullName].ToString();
            }

            fieldConverted.Parser = fieldConverted.Parser.Replace("{}", enclosedType);
            fieldConverted.CSharpType = fieldConverted.CSharpType.Replace("{}", enclosedType);
        }

        Debug.Assert(variant[Tag][Type].ToString() == "IntLiteral");

        var fieldType = fieldConverted.CSharpType;

        if (OpenClass(variantName, fullName))
        {
            AddField("Value", fieldType);
            Close(GetMethodParser<T>().MethodBuilder);
        }       
    }
}
