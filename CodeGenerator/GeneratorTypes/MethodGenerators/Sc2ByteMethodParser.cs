using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;
using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.MethodGenerators;

using static Sc2ReplayAnalyzer.Json.Sc2JsonType;
internal class Sc2ByteMethodParser(StringBuilder methodBuilder, Sc2GeneratorData data) : ISc2MethodParser
{
    public string DebugView => GetDebugView();

    private readonly StringBuilder _parserBuilder = data.ParserGenerator;
    private readonly StringBuilder _methodInitializerBuilder = new StringBuilder();
    private readonly StringBuilder _fieldNameMethodBuilder = new StringBuilder();
    private readonly StringBuilder _methodStarter = new StringBuilder();
    private readonly StringBuilder _generalMethodBuilder = new StringBuilder();

    public void OpenArray(JsonNode bounds, string unitTypeName, string internalType)
    {
        var typeName = Sc2TypeUtils.GetTypeName(unitTypeName);
        internalType = Sc2TypeUtils.GetTypeName(internalType);

        _generalMethodBuilder.AppendLine($$"""
                public {{typeName}} Parse_{{typeName}}()
                {
                    ValidateArrayTag();

                    var arrayLength = ParseVlqInt();
                    var value = ReadList(Parse_{{internalType}}, arrayLength);

                    return new {{typeName}}
                    {
                        Value = value
                    };
                }
            """);
    }

    public void OpenInt(JsonNode bounds, string unitTypeName)
    {
        var typeName = Sc2TypeUtils.GetTypeName(unitTypeName);
        _generalMethodBuilder.AppendLine($$"""
                    public {{typeName}} Parse_{{typeName}}()
                    {
                        ValidateIntTag();
                        var value = ParseVlqInt();

                        return new {{typeName}}
                        {
                            Value = value
                        };
                    }
                """);
    }

    public void OpenChoice(string unitTypeName, int numBits, int? boundsLength)
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
                                ValidateOptTag();
                                var isProvided = ReadByte();

                                if (isProvided != 0)
                                {
                                    var res = {{fieldConverted.Parser}}();

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

        _generalMethodBuilder.AppendLine($$"""
                            }
                            break;
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

    public void OpenStruct(string unitTypeName, bool hasTags)
    {
        var methodCtorBuilder = new StringBuilder();
        var typeName = Sc2TypeUtils.GetTypeName(unitTypeName);

        _methodInitializerBuilder.AppendLine($$"""
                        return new {{typeName}}
                        {   
                """);

        _parserBuilder.AppendLine();
        _parserBuilder.AppendLine($$"""
                    public {{typeName}} Parse_{{typeName}}() 
                    {
                """);

        _generalMethodBuilder.AppendLine($$"""
                        ValidateStructTag();
                        var structFieldCount = ParseVlqInt();           
                """);

        if (hasTags)
        {
            _generalMethodBuilder.AppendLine($$"""
                        for (var i = 0; i < structFieldCount; i++)
                        {
                            var fieldTag = ParseVlqInt();
                    
                            switch (fieldTag)
                            {
                """);
        }
    }

    public void ContinueFieldStruct(JsonNode field, Sc2JsonTypeConversion fieldConverted, string fieldName, string fieldType, string unitTypeName, bool hasTags)
    {
        var typeName = Sc2TypeUtils.GetTypeName(unitTypeName);

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

        var tabs = hasTags ? "            " : string.Empty;

        if (hasTags)
        {

            var fieldTag = field[Tag][Value].ToString();
            _generalMethodBuilder.AppendLine($$"""
                                case {{fieldTag}}:
                                {
                """);
        }
        if (fieldConverted.IsOptional)
        {
            _generalMethodBuilder.AppendLine($$"""
                {{tabs}}        if ({{fieldName}} is { HasValue: true, Value.HasValue: false })
                """);
        }
        else
        {
            _generalMethodBuilder.AppendLine($$"""
                {{tabs}}        if ({{fieldName}} is { HasValue: false })                           
                """);
        }

        if (hasTags)
        {
            _generalMethodBuilder.AppendLine($$"""
                                    {
                                        var parsed_{{fieldName}} = Parse_{{typeName}}_{{fieldName}}();
                                        {{fieldName}} = Option.Some(parsed_{{fieldName}});
                                        continue;
                                    }
                                    else
                                    {
                                        throw new Exception("Duplicate tag!");
                                    }
                                }
                                break;
                """);
        }
        else
        {
            _generalMethodBuilder.AppendLine($$"""
                {{tabs}}        {
                {{tabs}}            var parsed_{{fieldName}} = Parse_{{typeName}}_{{fieldName}}();
                {{tabs}}            {{fieldName}} = Option.Some(parsed_{{fieldName}});
                {{tabs}}        }
                """);
        }

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
                        ValidateOptTag();
                        var isProvided = ReadByte();

                        {{fieldType}} {{fieldName}} = default;
                        if (isProvided != 0)
                        {                                   
                """);

            if (fieldConverted.IsVector)
            {
                _fieldNameMethodBuilder.AppendLine($$"""
                            ValidateArrayTag();
                            var arrayLength = ParseVlqInt();
                            var array = ReadList({{fieldConverted.Parser}}, arrayLength);
                """);

                if (fieldConverted.ShouldTryFrom)
                {
                    _fieldNameMethodBuilder.AppendLine($$"""
                            {{fieldName}} = Option.Some(array.Select(x => ProtocolConversion<{{Sc2TypeUtils.GetUnwrappedOptionListTypeName(fieldConverted.CSharpType)}}>.From(x)).ToList());                                 
                """);
                }
                else
                {
                    _fieldNameMethodBuilder.AppendLine($$"""
                            {{fieldName}} = Option.Some(array);
                """);
                }
            } 
            else
            {
                _fieldNameMethodBuilder.AppendLine($$"""
                            var res = {{fieldConverted.Parser}}();

                """);

                if (fieldConverted.ShouldTryFrom)
                {
                    _fieldNameMethodBuilder.AppendLine($$"""
                            {{fieldName}} = Option.Some(ProtocolConversion<{{Sc2TypeUtils.GetUnwrappedOptionTypeName(fieldConverted.CSharpType)}}>.From(res));
                """);
                }
                else
                {
                    _fieldNameMethodBuilder.AppendLine($$"""
                            {{fieldName}} = Option.Some(res);          
                """);
                }
            }

            _fieldNameMethodBuilder.AppendLine($$"""
                        }
                        else
                        {
                            {{fieldName}} = Option.None;
                        }

                        return {{fieldName}};
                """);
        }
        else if (fieldConverted.IsVector)
        {
            _fieldNameMethodBuilder.AppendLine($$"""
                        ValidateArrayTag();
                        var arrayLength = ParseVlqInt();
                        var array = ReadList({{fieldConverted.Parser}}, arrayLength);

                """);

            if (fieldConverted.ShouldTryFrom)
            {
                _fieldNameMethodBuilder.AppendLine($$"""
                        return array.Select(x => ProtocolConversion<i32>.From(x)).ToList();
                """);
            }
            else
            {

                _fieldNameMethodBuilder.AppendLine($$"""
                        return array;
                """);
            }
        }
        else if (fieldConverted.IsSizedInt)
        {
            _fieldNameMethodBuilder.AppendLine($$"""
                        var {{fieldName}} = {{fieldConverted.Parser}}();

                        return {{fieldName}};
                """);
        }
        else
        {
            _fieldNameMethodBuilder.AppendLine($$"""
                        var {{fieldName}} = {{fieldConverted.Parser}}();
                """);

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

        _fieldNameMethodBuilder.AppendLine($$"""
                    }
                """);     
    }

    public void CloseStruct(bool hasTags)
    {
        if (hasTags)
        {
            _generalMethodBuilder.AppendLine($$"""
                            }
                        }
                """);
        }

        _methodInitializerBuilder.AppendLine($$"""
                        };
                    }
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

    private string GetDebugView()
    {
        var result = $"{_methodStarter}{_generalMethodBuilder}{_methodInitializerBuilder}{_fieldNameMethodBuilder}";

        return result;
    }
}
