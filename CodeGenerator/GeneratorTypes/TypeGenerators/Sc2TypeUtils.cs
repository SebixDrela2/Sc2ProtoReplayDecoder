namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;

internal static class Sc2TypeUtils
{
    public static string GetTypeName(string fullName) => fullName
        .Replace(".", string.Empty)
        .Replace("NNet", "");
}
