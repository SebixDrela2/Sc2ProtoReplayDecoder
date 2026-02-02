using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.MethodGenerators;
using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators.Utils;
using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;

internal abstract class CodeGeneratorBase
{
    private readonly StringBuilder _builder;

    private readonly HashSet<string> _interfaceEnumDefinitions = [];

    private readonly BitMethodParser _bitMethodParser;
    private readonly ByteMethodParser _byteMethodParser;
    private readonly AgnosticParser _agnosticParser;

    private readonly Dictionary<string, string> _enumTags = [];


    public string Data => _builder.ToString();

    public CodeGeneratorBase(StringBuilder builder, Sc2GeneratorData data)
    {
        _enumTags = data.EnumTags;

        _builder = builder;

        var methodBuilder = new StringBuilder();

        _bitMethodParser = new BitMethodParser(methodBuilder, data);
        _byteMethodParser = new ByteMethodParser(methodBuilder, data);
        _agnosticParser = new AgnosticParser(methodBuilder, data);
    }

    protected IProtocolMethodParser GetMethodParser<T>()
        where T : IProtocolTypeConversionAlignment
    {
        if (typeof(T) == typeof(ProtocolConversionBitPacked))
        {
            return _bitMethodParser;
        }
        if (typeof(T) == typeof(ProtocolTypeConversionByteAligned))
        {
            return _byteMethodParser;
        }

        throw new Exception("Wrong parser type.");
    }

    protected BitMethodParser GetBitMethodParser() => _bitMethodParser;

    protected IProtocolAgnosticParser GetAgnosticMethodParser() => _agnosticParser;

    protected bool OpenClass(string className, string choiceType = null, bool isPartial = false)
    {
        var typeName = ProtocolTypeUtils.GetTypeName(className);

        if (typeName is "None")
        {
            return false;
        }

        var possibleAbstractClass = choiceType is not null 
            ? $" : {ProtocolTypeUtils.GetTypeName(choiceType)}" 
            : string.Empty;

        var possiblePartial = isPartial ? "partial" : string.Empty;

        _builder.AppendLine($"// {className}");
        _builder.AppendLine($$"""
            public {{possiblePartial}} class {{typeName}}{{possibleAbstractClass}}
            {
            """);

        return true;
    }

    protected bool AddRecordEnum(string variantValueFullName, string variantName, string fullName)
    {
        var typeName = ProtocolTypeUtils.GetTypeName(fullName);
        var uniqueVariantName = $"{typeName}_{variantName}";

        _builder.AppendLine($"// {variantName}");

        if (_enumTags.TryGetValue(variantValueFullName, out var field))
        {
            _builder.AppendLine($"""
            public record class {ProtocolTypeUtils.GetTypeName(uniqueVariantName)}({ProtocolTypeUtils.GetTypeName(field)} Value) : {typeName};
            """);
        }
        else
        {
            _builder.AppendLine($"""
            public record class {ProtocolTypeUtils.GetTypeName(uniqueVariantName)}() : {typeName};
            """);
        }

        return true;
    }

    protected bool AddInterfaceEnum(string enumName)
    {
        if (_interfaceEnumDefinitions.Contains(enumName))
        {
            return false;
        }

        _interfaceEnumDefinitions.Add(enumName);

        _builder.AppendLine($"// {enumName}");
        _builder.AppendLine($$"""
            public abstract record class {{ProtocolTypeUtils.GetTypeName(enumName)}} { }
            """);

        return true;
    }

    protected bool OpenChoice(string choiceName)
    {
        var typeName = ProtocolTypeUtils.GetTypeName(choiceName);

        _builder.AppendLine($"// {choiceName}");
        _builder.AppendLine($$"""
            public abstract class {{typeName}} { }
            """);
        _builder.AppendLine();

        return true;
    }

    protected void Close()
    {
        _builder.AppendLine("}");
        AddLine();
    }

    protected void AddLine() => _builder.AppendLine();

    protected void AddField(string fieldName, string fieldType)
    {
        var typeName = ProtocolTypeUtils.GetTypeName(fieldType);

        _builder.AppendLine($"""
                public {typeName} {fieldName};
            """);
    }
}
