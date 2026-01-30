using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators.Utils;
using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.MethodGenerators;

internal class AgnosticParser(StringBuilder methodBuilder, Sc2GeneratorData data) : IProtocolAgnosticParser
{
    public string DebugView => GetDebugView();

    private readonly StringBuilder _parserBuilder = data.ParserGenerator;
    private readonly StringBuilder _methodInitializerBuilder = new StringBuilder();
    private readonly StringBuilder _fieldNameMethodBuilder = new StringBuilder();
    private readonly StringBuilder _methodStarter = new StringBuilder();
    private readonly StringBuilder _generalMethodBuilder = new StringBuilder();


    public void OpenUserType(string unitTypeName, string typeInfo)
    {
        var typeName = ProtocolTypeUtils.GetTypeName(unitTypeName);
        typeInfo = ProtocolTypeUtils.GetTypeName(typeInfo);

        _generalMethodBuilder.AppendLine($$"""
                    public {{typeName}} Parse_{{typeName}}()
                    {
                        var value = Parse_{{typeInfo}}();

                        return new {{typeName}}
                        {
                            Value = value,
                        };
                    }
                """);
    }

    public void OpenEnum<T>(string unitTypeName, int numFields)
        where T : IProtocolTypeConversionAlignment
    {
        var typeName = ProtocolTypeUtils.GetTypeName(unitTypeName);
        var numBits = (int)Math.Ceiling(Math.Log2(numFields)); 

        if (typeof(T) == typeof(ProtocolTypeConversionByteAligned))
        {
            _generalMethodBuilder.AppendLine($$"""
                    public {{typeName}} Parse_{{typeName}}()
                    {
                        ValidateIntTag();
                        var variantTag = ParseVlqInt();

                        switch (variantTag)
                        {
                        
                """);
        }
        else if (typeof(T) == typeof(ProtocolConversionBitPacked))
        {
            numBits = typeName is "GameEMessageId" ? ++numBits : numBits;

            _generalMethodBuilder.AppendLine($$"""
                    public {{typeName}} Parse_{{typeName}}()
                    {
                        var numBits = {{numBits}};
                        var variantTag = parse_packed_int(0, numBits);

                        switch (variantTag)
                        {
                        
                """);
        }
        else
        {
            throw new NotSupportedException("Type of Conversion alignment not supported.");
        }
    }

    public void ContinueEnumVariant(string variantValue, string variantValueFullName, string fullName, string variantName)
    {
        var typeName = ProtocolTypeUtils.GetTypeName(fullName);
        var uniqueVariantName = $"{typeName}_{variantName}";
        var tags = data.EnumTags;

        _generalMethodBuilder.AppendLine($$"""
                            case {{variantValue}}:
                            {                        
                """);

        if (tags.TryGetValue(variantValueFullName, out var structName))
        {
            _generalMethodBuilder.AppendLine($$"""
                                var res = Parse_{{structName}}();

                                return new {{uniqueVariantName}}(res);
                """);
        }
        else
        {
            _generalMethodBuilder.AppendLine($$"""
                                return new {{uniqueVariantName}}();
                """);
        }

        _generalMethodBuilder.AppendLine($$"""
                            }
                            break;                  
                """);
    }

    public void CloseEnum()
    {
        _generalMethodBuilder.AppendLine($$"""
                            default:
                            {
                                throw new Exception("INVALID TAG");
                            }
                        }
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


