using System.Text;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes;

internal abstract class Sc2GeneratorBase
{
    private readonly StringBuilder _builder;

    private readonly HashSet<string> _classDefinitions = [];
    private readonly HashSet<string> _enumDefinitions = [];
    private readonly HashSet<string> _choiceDefinitions = [];

    private readonly Dictionary<string, string> _choiceMap = [];

    public string Data => _builder.ToString();

    public Sc2GeneratorBase(StringBuilder builder, Dictionary<string, string> choiceMap)
    {
        _choiceMap = choiceMap;
        _builder = builder;
    }

    protected bool OpenClass(string className, string choiceType = null)
    {  
        if (_classDefinitions.Contains(className))
        {
            return false;
        }

        _classDefinitions.Add(className);

        var possibleInterfaceDef = choiceType is not null ? $" : I{GetTypeName(choiceType)}" : string.Empty;

        _builder.AppendLine($"// {className}");
        _builder.AppendLine($$"""
            public class {{GetTypeName(className)}}{{possibleInterfaceDef}}
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
            public enum {{GetTypeName(enumName)}}
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

        var nonInterfaceChoiceType = GetTypeName(choiceName);
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
        var typeName = GetTypeName(fieldType);

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

    private string GetTypeName(string fullName) => fullName
        .Replace(".", string.Empty)
        .Replace("NNet", "");
}
