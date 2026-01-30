using System.Text.RegularExpressions;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators.Utils;

internal static class ProtocolTypeUtils
{
    private static readonly string[] UnusedUnitTypeNames = 
        ["GameTFlexLicenseName",
         "GameTFlexLicenseAttributeName",
         "GameTFlexLicenseAttributeValue"];

    public static string GetTypeName(string fullName) => fullName
        .Replace(".", string.Empty)
        .Replace("NNet", "");

    public static bool IsUnusedUnitTypeName(string unitTypeName) => UnusedUnitTypeNames.Contains(unitTypeName);

    public static int GetStrSizeBoundMax(string typeName) => typeName switch
    {
        "CFilePath" or "GameCChatString" => 11,
        "CUserName" or "CClanTag" or "GameCAuthorName" => 8,
        "CSkinHandle" or "CMountHandle" or "CArtifactHandle" or "CCommanderHandle" or "CHeroHandle" => 9,
        "CToonHandle" => 7,
        "GameCCheatString" or "GameCTriggerChatMessageString" or "GameCGameCacheName" => 10,
        var x => throw new NotSupportedException($"Invalid type: {x} for string bit parser.")
    };

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
