using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.MethodGenerators;
using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;

internal abstract class Sc2GeneratorBase
{
    private readonly StringBuilder _builder;

    private readonly HashSet<string> _classDefinitions = [];
    private readonly HashSet<string> _enumDefinitions = [];
    private readonly HashSet<string> _choiceDefinitions = [];

    private readonly Sc2BitMethodParser _bitMethodParser;
    private readonly Sc2ByteMethodParser _byteMethodParser;

    private readonly Dictionary<string, string> _choiceMap = [];


    public string Data => _builder.ToString();

    public Sc2GeneratorBase(StringBuilder builder, Sc2GeneratorData data)
    {
        _choiceMap = data.ChoiceMap;
        _builder = builder;

        var methodBuilder = new StringBuilder();

        _bitMethodParser = new Sc2BitMethodParser(methodBuilder, data);
        _byteMethodParser = new Sc2ByteMethodParser(methodBuilder, data);
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

    protected bool OpenClass(string className, string choiceType = null)
    {  
        if (_classDefinitions.Contains(className))
        {
            return false;
        }

        _classDefinitions.Add(className);

        var possibleInterfaceDef = choiceType is not null ? $" : I{Sc2TypeUtils.GetTypeName(choiceType)}" : string.Empty;

        _builder.AppendLine($"// {className}");
        _builder.AppendLine($$"""
            public class {{Sc2TypeUtils.GetTypeName(className)}}{{possibleInterfaceDef}}
            {
            """);

        return true;
    }

    protected bool OpenEnum(string enumName)
    {
        if (_enumDefinitions.Contains(enumName))
        {
            return false;
        }

        _enumDefinitions.Add(enumName);

        _builder.AppendLine($"// {enumName}");
        _builder.AppendLine($$"""
            public enum {{Sc2TypeUtils.GetTypeName(enumName)}}
            {
            """);

        return true;
    }

    protected bool OpenChoice(string choiceName)
    {
        if (_choiceDefinitions.Contains(choiceName))
        {
            return false;
        }

        _choiceDefinitions.Add(choiceName);

        var nonInterfaceChoiceType = Sc2TypeUtils.GetTypeName(choiceName);
        var interfaceChoiceType = $"I{nonInterfaceChoiceType}";

        _choiceMap.TryAdd(nonInterfaceChoiceType, interfaceChoiceType);

        _builder.AppendLine($"// {choiceName}");
        _builder.AppendLine($$"""
            public interface {{interfaceChoiceType}} { }
            """);
        _builder.AppendLine();

        return true;
    }

    protected void Close()
    {
        _builder.AppendLine("}");
        _builder.AppendLine();
    }

    protected void AddEnum(string enumName, string enumValue)
    {
        _builder.AppendLine($"""
                {enumName} = {enumValue},
            """);
    }

    protected void AddField(string fieldName, string fieldType)
    {
        var typeName = Sc2TypeUtils.GetTypeName(fieldType);

        if (_choiceMap.TryGetValue(typeName, out var choiceType))
        {
            _builder.AppendLine($"""
                public {choiceType} {fieldName};
            """);
        }
        else
        {
            _builder.AppendLine($"""
                public {typeName} {fieldName};
            """);
        }
    }
}
