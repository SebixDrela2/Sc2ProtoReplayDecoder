using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.MethodGenerators;
using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;

internal abstract class Sc2GeneratorBase
{
    private readonly StringBuilder _builder;

    private readonly HashSet<string> _interfaceEnumDefinitions = [];

    private readonly Sc2BitMethodParser _bitMethodParser;
    private readonly Sc2ByteMethodParser _byteMethodParser;
    private readonly Sc2AgnosticParser _agnosticParser;

    private readonly Dictionary<string, string> _enumTags = [];


    public string Data => _builder.ToString();

    public Sc2GeneratorBase(StringBuilder builder, Sc2GeneratorData data)
    {
        _enumTags = data.EnumTags;

        _builder = builder;

        var methodBuilder = new StringBuilder();

        _bitMethodParser = new Sc2BitMethodParser(methodBuilder, data);
        _byteMethodParser = new Sc2ByteMethodParser(methodBuilder, data);
        _agnosticParser = new Sc2AgnosticParser(methodBuilder, data);
    }

    protected ISc2MethodParser GetMethodParser<T>()
        where T : ISc2JsonTypeConversionAlignment
    {
        if (typeof(T) == typeof(Sc2TypeConversionBitPacked))
        {
            return _bitMethodParser;
        }
        if (typeof(T) == typeof(Sc2TypeConversionByteAligned))
        {
            return _byteMethodParser;
        }

        throw new Exception("Wrong parser type.");
    }

    protected Sc2BitMethodParser GetBitMethodParser() => _bitMethodParser;

    protected ISc2AgnosticParser GetAgnosticMethodParser() => _agnosticParser;

    protected bool OpenClass(string className, string choiceType = null)
    {
        var typeName = Sc2TypeUtils.GetTypeName(className);

        if (typeName is "None")
        {
            return false;
        }

        var possibleAbstractClass = choiceType is not null 
            ? $" : {Sc2TypeUtils.GetTypeName(choiceType)}" 
            : string.Empty;

        _builder.AppendLine($"// {className}");
        _builder.AppendLine($$"""
            public class {{typeName}}{{possibleAbstractClass}}
            {
            """);

        return true;
    }

    protected bool AddRecordEnum(string variantValueFullName, string variantName, string fullName)
    {
        var typeName = Sc2TypeUtils.GetTypeName(fullName);
        var uniqueVariantName = $"{typeName}_{variantName}";

        _builder.AppendLine($"// {variantName}");

        if (_enumTags.TryGetValue(variantValueFullName, out var field))
        {
            _builder.AppendLine($"""
            public record class {Sc2TypeUtils.GetTypeName(uniqueVariantName)}({Sc2TypeUtils.GetTypeName(field)} Value) : {typeName};
            """);
        }
        else
        {
            _builder.AppendLine($"""
            public record class {Sc2TypeUtils.GetTypeName(uniqueVariantName)}() : {typeName};
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
            public abstract record class {{Sc2TypeUtils.GetTypeName(enumName)}} { }
            """);

        return true;
    }

    protected bool OpenChoice(string choiceName)
    {
        var typeName = Sc2TypeUtils.GetTypeName(choiceName);

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
        var typeName = Sc2TypeUtils.GetTypeName(fieldType);

        _builder.AppendLine($"""
                public {typeName} {fieldName};
            """);
    }
}
