using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;
using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.MethodGenerators;

using static Sc2ReplayAnalyzer.Json.Sc2JsonType;
internal class Sc2ByteMethodParser(StringBuilder methodBuilder, Sc2GeneratorData data) : ISc2MethodParser
{
    private readonly string ClassUnderTest = "TRacePreference";
    public string DebugView => GetDebugView();

    public StringBuilder MethodBuilder => methodBuilder;
   

    private readonly StringBuilder _methodInitializerBuilder = new StringBuilder();
    private readonly StringBuilder _fieldNameMethodBuilder = new StringBuilder();
    private readonly StringBuilder _methodStarter = new StringBuilder();
    private readonly StringBuilder _generalMethodBuilder = new StringBuilder();

    public void OpenStruct(string unitTypeName, bool hasTags)
    {
        var methodCtorBuilder = new StringBuilder();
        var typeName = Sc2TypeUtils.GetTypeName(unitTypeName);

        if (typeName == ClassUnderTest)
        {

        }

        _methodInitializerBuilder.AppendLine($$"""
                        return new {{typeName}}
                        {   
                """);

        methodBuilder.AppendLine();
        methodBuilder.AppendLine($$"""
                    public {{typeName}} static Parse(ProtocolReader reader) 
                    {
                """);

        _generalMethodBuilder.AppendLine($$"""
                        reader.ValidateStructTag();
                        var structFieldCount = reader.ParseVlqInt();           
                """);

        if (hasTags)
        {
            _generalMethodBuilder.AppendLine($$"""
                        for (var i = 0; i < structFieldCount; i++)
                        {
                            var fieldTag = reader.ParseVlqInt();
                    
                            switch (fieldTag)
                            {
                """);
        }
    }

    public void ContinueFieldStruct(
        JsonNode field,
        Sc2JsonTypeConversion fieldConverted, 
        string fieldName, 
        string fieldType,
        string unitTypeName,
        bool hasTags)
    {
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
                                        var parsed_{{fieldName}} = Parse_{{fieldName}}(reader);
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
                {{tabs}}            var parsed_{{fieldName}} = Parse_{{fieldName}}(reader);
                {{tabs}}            {{fieldName}} = Option.Some(parsed_{{fieldName}});
                {{tabs}}        }
                """);
        }

        _methodInitializerBuilder.AppendLine($$"""
                            {{fieldName}} = Option.OkOrReturnMissingFieldErr({{fieldName}}),
                """);


        _fieldNameMethodBuilder.AppendLine($$"""
                    public static {{fieldType}} Parse_{{fieldName}}(ProtocolReader reader)
                    {
                                
                """);

        if (fieldConverted.IsOptional)
        {
            _fieldNameMethodBuilder.AppendLine($$"""
                        reader.ValidateOptTag();
                        var isProvided = reader.ReadByte(); // nom::number::complete::u8(tail)
                        var {{fieldName}} = null;

                        if (isProvided != 0)
                        {                                   
                """);

            if (fieldConverted.IsVector)
            {
                _fieldNameMethodBuilder.AppendLine($$"""
                            reader.ValidateArrayTag();
                            var arrayLength = reader.ParseVlqInt();

                            var array = Enumerable.Range(0, arrayLength).Select(_ => {{fieldConverted.Parser}}(reader)).ToArray();

                """);

                if (fieldConverted.ShouldTryFrom)
                {
                    _fieldNameMethodBuilder.AppendLine($$"""
                            throw new Exception("WUT ELEMENT"); // "let array = array.iter().map(|val| <_>::try_from(*val)?).collect();\n",                                  
                """);
                }

                _fieldNameMethodBuilder.AppendLine($$"""
                            {{fieldName}} = Option.Some(array);
                """);
            } 
            else
            {
                _fieldNameMethodBuilder.AppendLine($$"""
                            var res = {{fieldConverted.Parser}}(reader);

                """);

                if (fieldConverted.ShouldTryFrom)
                {
                    _fieldNameMethodBuilder.AppendLine($$"""
                        // "{{fieldName}} = Option.Some(res.TryFrom()); // RUSTIFICATION (tail, Some(<_>::try_from(res)?))\n"
                """);
                }
                else
                {
                    _fieldNameMethodBuilder.AppendLine($$"""
                        //"  {{fieldName}} = Option.Some(res);          
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
                        reader.ValidateArrayTag();
                        var arrayLength = reader.ParseVlqInt();
                        var array = Enumerable.Range(0, arrayLength).Select(_ => {{fieldConverted.Parser}}(reader)).ToArray();

                """);

            if (fieldConverted.ShouldTryFrom)
            {
                _fieldNameMethodBuilder.AppendLine($$"""
                         // let array = array.iter().map(|val| <_>::try_from(*val)?).collect();
                """);
            }
        }
        else if (fieldConverted.IsSizedInt)
        {
            _fieldNameMethodBuilder.AppendLine($$"""
                        var {{fieldName}} = {{fieldConverted.Parser}};

                        return {{fieldName}};
                """);
        }
        else
        {
            _fieldNameMethodBuilder.AppendLine($$"""
                        return {{fieldName}};
                """);
        }

        _fieldNameMethodBuilder.AppendLine($$"""
                    }//1
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
        methodBuilder.Append(_methodStarter);
        methodBuilder.Append(_generalMethodBuilder);
        methodBuilder.Append(_methodInitializerBuilder);
        methodBuilder.Append(_fieldNameMethodBuilder);

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
