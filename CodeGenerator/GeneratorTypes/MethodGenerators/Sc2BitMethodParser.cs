using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;
using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.MethodGenerators;

using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

internal class Sc2BitMethodParser(StringBuilder methodBuilder, Sc2GeneratorData data) : ISc2MethodParser
{
    private readonly StringBuilder _parserBuilder = data.ParserGenerator;
    private readonly StringBuilder _methodInitializerBuilder = new StringBuilder();
    private readonly StringBuilder _fieldNameMethodBuilder = new StringBuilder();
    private readonly StringBuilder _methodStarter = new StringBuilder();
    private readonly StringBuilder _generalMethodBuilder = new StringBuilder();

    public void OpenChoice(string unitTypeName)
    {
        var methodCtorBuilder = new StringBuilder();
        var typeName = Sc2TypeUtils.GetTypeName(unitTypeName);

        _parserBuilder.AppendLine();
        _parserBuilder.AppendLine($$"""
                    public {{typeName}} Parse_{{typeName}}() 
                    {
                """);

        _generalMethodBuilder.AppendLine($$"""
                        ValidateChoiceTag();
                        var variantTag = ParseVlqInt();
                        
                        switch (variantTag)
                        {
                """);
    }

    public void ContinueVariantChoice(Sc2JsonTypeConversion fieldConverted, string fieldTypeInfo, string fieldType, string variantName, string fieldTag)
    {
        var typeName = Sc2TypeUtils.GetTypeName(variantName);
        fieldType = Sc2TypeUtils.GetTypeName(fieldType);

        _generalMethodBuilder.AppendLine($$"""
                            case {{fieldTag}}:
                            {
                """);

        if (fieldConverted.IsOptional)
        {
            _generalMethodBuilder.AppendLine($$"""
                                var isProvided = parse_bool();
                                var res = {{fieldConverted.Parser}}();

                                if (isProvided)
                                {
                                    return new {{typeName}}
                                    {
                                        Value = Option.Some(res)
                                    };
                                }
                                else
                                {
                                    return new {{typeName}}
                                    {
                                        Value = Option.None
                                    };
                                }
                """);
        }
        else
        {
            _generalMethodBuilder.AppendLine($$"""
                                var res = {{fieldConverted.Parser}}();

                """);

            if (fieldConverted.ShouldTryFrom)
            {
                _generalMethodBuilder.AppendLine($$"""
                                return new {{typeName}}
                                {
                                    Value = ProtocolConversion<{{fieldType}}>.From(res)
                                };
                """);
            }
            else
            {
                _generalMethodBuilder.AppendLine($$"""
                                return new {{typeName}}
                                {
                                    Value = res
                                };
                """);
            }
        }


        _generalMethodBuilder.AppendLine("""
                            }
                """);
    }

    public void CloseChoice()
    {
        _generalMethodBuilder.AppendLine($$"""
                            default:
                            {
                                throw new Exception("WUT CHOICE");
                            }
                        }
                    }
                """);
    }

    public void CloseStruct(bool hasTags)
    {
        _methodInitializerBuilder.AppendLine($$"""
                        };
                    }
                """);
    }

    public void ContinueFieldStruct(JsonNode field, Sc2JsonTypeConversion fieldConverted, string fieldName, string fieldType, string unitTypeName, bool hasTags)
    {
        var typeName = Sc2TypeUtils.GetTypeName(unitTypeName);
        fieldType = Sc2TypeUtils.GetTypeName(fieldType);

        fieldConverted.Parser = Sc2TypeUtils.GetTypeName(fieldConverted.Parser);

        if (fieldConverted.IsOptional)
        {
            _methodStarter.AppendLine($"""
                        var {fieldName} = Option.Some<{fieldType}>(Option.None);
                """);
        }
        else
        {
            _methodStarter.AppendLine($"""
                        Option<{fieldType}> {fieldName} = Option.None;
                """);
        }

        if (fieldConverted.IsOptional)
        {
            _generalMethodBuilder.AppendLine($$"""
                        if ({{fieldName}} is { HasValue: true, Value.HasValue: false })
                """);
        }
        else
        {
            _generalMethodBuilder.AppendLine($$"""
                        if ({{fieldName}} is { HasValue: false })                           
                """);
        }

        _generalMethodBuilder.AppendLine($$"""
                        {
                            var parsed_{{fieldName}} = Parse_{{typeName}}_{{fieldName}}();
                            {{fieldName}} = Option.Some(parsed_{{fieldName}});
                """);

        _methodInitializerBuilder.AppendLine($$"""
                            {{fieldName}} = Option.OkOrReturnMissingFieldErr({{fieldName}}),
                """);

        _fieldNameMethodBuilder.AppendLine($$"""

                    public {{fieldType}} Parse_{{typeName}}_{{fieldName}}()
                    {                             
                """);

        if (fieldConverted.IsOptional)
        {
            _fieldNameMethodBuilder.AppendLine($$"""
                            var isProvided = parse_bool();

                            if (isProvided)
                            {
                """);

            if (fieldConverted.IsVector)
            {
                var arrayLength = field[TypeInfo][TypeInfo][Bounds][Max][EValue].ToString();
                var arraySizeBits = int.Log2(int.Parse(arrayLength)) + 1;

                _fieldNameMethodBuilder.AppendLine($$"""
                                var arrayLength = take_n_bits_into_i64({{arraySizeBits}});

                """);

                if (fieldConverted.IsBitArray)
                {
                    _fieldNameMethodBuilder.AppendLine($$"""
                                var array = take_bit_array(arrayLength);
                """);
                }
                else
                {
                    _fieldNameMethodBuilder.AppendLine($$"""
                                var array = ReadArray({{fieldConverted.Parser}}, arrayLength);
                        
                """);
                }

                if (fieldConverted.ShouldTryFrom)
                {
                    _fieldNameMethodBuilder.AppendLine($$"""
                                array = array.Select(x => ProtocolConversion<{{fieldType}}>.From(x)).ToList();
                """);
                }

                _fieldNameMethodBuilder.AppendLine($"""

                                return Option.Some(array);
                """);
            }
            else
            {
                if (fieldConverted.Parser.Contains("input,"))
                {
                    _fieldNameMethodBuilder.AppendLine($$"""
                                var res = {{fieldConverted.Parser}};
                """);
                }
                else
                {
                    _fieldNameMethodBuilder.AppendLine($$"""
                                var res = {{fieldConverted.Parser}}();
                """);
                }

                if (fieldConverted.ShouldTryFrom)
                {
                    _fieldNameMethodBuilder.AppendLine($$"""

                                return Option.Some(ProtocolConversion<{{fieldType}}>.From(res);
                """);
                }
                else
                {
                    _fieldNameMethodBuilder.AppendLine($$"""

                                return Option.Some(res);
                """);
                }
            }

            _fieldNameMethodBuilder.AppendLine($$"""
                            }
                            else
                            {
                                return Option.None;
                            }
                """);
        }
        else if (fieldConverted.IsVector)
        {
            var eValueArrayLength = field[Bounds]?[Max]?[EValue].ToString() ?? string.Empty;
            var arrayLength = !string.IsNullOrEmpty(eValueArrayLength)
                ? eValueArrayLength
                : field[TypeInfo][Bounds][Max][EValue].ToString();
            var arraySizeBits = int.Log2(int.Parse(arrayLength)) + 1;

            _fieldNameMethodBuilder.AppendLine($$"""
                        var arrayLength = take_n_bits_into_i64({{arraySizeBits}});
                        var array = new {{fieldType}}();

                        for (var i = 0 ; i < arrayLength ; ++i)
                        {
                            var data = {{fieldConverted.Parser}}();
                            array.Add(data);
                        }
                """);

            if (fieldConverted.ShouldTryFrom)
            {
                _fieldNameMethodBuilder.AppendLine($$"""
                        array = array.Select(x => ProtocolConversion<{{fieldType}}>.From(x)).ToList();

                """);
            }

            _fieldNameMethodBuilder.AppendLine($"""
                        return array;
                """);
        }
        else
        {
            if (fieldConverted.Parser.Contains("input,"))
            {
                _fieldNameMethodBuilder.AppendLine($$"""
                        var {{fieldName}} = {{fieldConverted.Parser}}
                """);
            }
            else
            {
                _fieldNameMethodBuilder.AppendLine($$"""
                        var {{fieldName}} = {{fieldConverted.Parser}}();
                """);
            }

            if (fieldConverted.ShouldTryFrom)
            {
                _fieldNameMethodBuilder.AppendLine($$"""

                        return ProtocolConversion<{{fieldType}}>.From({{fieldName}});
                """);
            }
            else
            {
                _fieldNameMethodBuilder.AppendLine($$"""
                        return {{fieldName}};
                """);
            }
        }


        _generalMethodBuilder.AppendLine($$"""
                        }

                """);
        _fieldNameMethodBuilder.AppendLine($$"""
                    }
                """);
    }
   
    public void OpenStruct(string unitTypeName, bool hasTags)
    {
        var typeName = Sc2TypeUtils.GetTypeName(unitTypeName);

        _parserBuilder.AppendLine();
        _parserBuilder.AppendLine($$"""
                    public {{typeName}} Parse_{{typeName}}() 
                    {
                """);

        _methodInitializerBuilder.AppendLine($$"""
                        return new {{typeName}}
                        {   
                """);


    }

    public void Finalise()
    {
        _parserBuilder.Append(_methodStarter);
        _parserBuilder.Append(_generalMethodBuilder);
        _parserBuilder.Append(_methodInitializerBuilder);
        _parserBuilder.Append(_fieldNameMethodBuilder);

        _methodInitializerBuilder.Clear();
        _fieldNameMethodBuilder.Clear();
        _methodStarter.Clear();
        _generalMethodBuilder.Clear();
    }
}
