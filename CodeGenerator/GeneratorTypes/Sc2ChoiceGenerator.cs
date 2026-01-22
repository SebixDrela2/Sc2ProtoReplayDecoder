using System.Diagnostics;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes;

using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

internal class Sc2ChoiceGenerator
{
    public void GenerateChoices<T>(IReadOnlyList<JsonNode> nodes)
        where T : ISc2JsonTypeConversionAlignment
    {
        var choiceNodes = nodes.Where(x => x[TypeInfo][Type].ToString() is "ChoiceType");

        foreach (var node in choiceNodes)
        {
            var variantArray = node[TypeInfo][Fields].AsArray();

            foreach (var variant in variantArray)
            {
                HandleVariant<T>(variant);
            }
        }    
    }

    private void HandleVariant<T>(JsonNode variant)
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

        Console.WriteLine($"\"{variantName}\": {fieldType}");
    }
}
