using Sc2ReplayAnalyzer.Json.Generator;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;

using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

internal class Sc2ChoiceGenerator(StringBuilder builder, Sc2GeneratorData data)
    : Sc2GeneratorBase(builder, data)
{
    public void Generate<T>(IReadOnlyList<JsonNode> nodes)
        where T : ISc2JsonTypeConversionAlignment
    {
        var choiceNodes = nodes.Where(x => x[TypeInfo][Type].ToString() is "ChoiceType");
        var methodParser = GetMethodParser<T>();

        foreach (var node in choiceNodes)
        {
            var variantArray = node[TypeInfo][Fields].AsArray();
            var unitTypeFullName = node[FullName]?.ToString() ?? node[Name].ToString();

            if (OpenChoice(unitTypeFullName))
            {
                methodParser.OpenChoice(unitTypeFullName, variantArray.Count);

                foreach (var variant in variantArray)
                {
                    HandleVariant<T>(variant, unitTypeFullName);
                }

                methodParser.CloseChoice();
                methodParser.Finalise();
            }
        }    
    }

    private void HandleVariant<T>(JsonNode variant, string unitTypeFullName)
        where T : ISc2JsonTypeConversionAlignment
    {
        var variantTypeInfoType = variant[TypeInfo][Type].ToString();
        
        if (typeof(T) == typeof(Sc2TypeConversionByteAligned) && variantTypeInfoType is "NullType")
        {
            return;
        }

        var fieldTypeInfoFullName = variant[TypeInfo][FullName]?.ToString();
        var variantName = variant[Name].ToString();
        var fieldTypeInfo = fieldTypeInfoFullName is not null
            ? fieldTypeInfoFullName
            : variantTypeInfoType.ToString();

        var fieldConverted = T.FromNnetName(fieldTypeInfo);

        if (fieldTypeInfo is "OptionalType")
        {
            var enclosedType = variant[TypeInfo][TypeInfo][Type].ToString();

            if (typeof(T) == typeof(Sc2TypeConversionBitPacked) && enclosedType is "UserType")
            {
                enclosedType = Sc2TypeUtils.GetTypeName(variant[TypeInfo][TypeInfo][FullName].ToString());
            }

            fieldConverted.Parser = fieldConverted.Parser.Replace("{}", enclosedType);
            fieldConverted.CSharpType = fieldConverted.CSharpType.Replace("{}", enclosedType);
            fieldConverted.IsOptional = true;
        }

        Debug.Assert(variant[Tag][Type].ToString() == "IntLiteral");

        var fieldType = fieldConverted.CSharpType;

        if (OpenClass(variantName, unitTypeFullName))
        {
            AddField("Value", fieldType);
            Close();
        }

        var methodParser = GetMethodParser<T>();

        var fieldTag = variant[Tag][Value].ToString();
        methodParser.ContinueVariantChoice(fieldConverted, fieldTypeInfo, fieldType, variantName, fieldTag);
    }
}
