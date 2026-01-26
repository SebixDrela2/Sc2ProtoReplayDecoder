using System.Text.RegularExpressions;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;

internal static class Sc2TypeUtils
{
    public static string GetTypeName(string fullName) => fullName
        .Replace(".", string.Empty)
        .Replace("NNet", "");

    public static string GetUnwrappedOptionTypeName(string unitTypeName)
    {
        var typeName = GetTypeName(unitTypeName);
        var match = Regex.Match(typeName, @"^Option<\s*(.+)\s*>$");

        if (!match.Success)
        {
            return typeName;
        }

        return match.Groups[1].Value;
    }

    public static string GetUnwrappedOptionListTypeName(string unitTypeName)
    {
        var typeName = GetTypeName(unitTypeName);
        var match = Regex.Match(typeName, @"^Option<List<\s*(.+)\s*>>$");

        if (!match.Success)
        {
            return typeName;
        }

        return match.Groups[1].Value;
    }
}
