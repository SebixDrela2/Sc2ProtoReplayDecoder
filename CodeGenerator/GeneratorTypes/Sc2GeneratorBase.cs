using System.Text;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes;

internal abstract class Sc2GeneratorBase
{
    private readonly StringBuilder _builder;

    private readonly HashSet<string> _classDefinitions = [];
    private readonly HashSet<string> _enumDefinitions = [];
    private readonly HashSet<string> _choiceDefinitions = [];

    public string Data => _builder.ToString();

    public Sc2GeneratorBase(StringBuilder builder)
    {
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

        _builder.AppendLine($"// {choiceName}");
        _builder.AppendLine($$"""
            public interface I{{GetTypeName(choiceName)}} { }
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
        _builder.AppendLine($"""
                public {GetTypeName(fieldType)} {fieldName};
            """);
    }

    private string GetTypeName(string fullName) => fullName
        .Replace(".", string.Empty)
        .Replace("NNet", "");
}
