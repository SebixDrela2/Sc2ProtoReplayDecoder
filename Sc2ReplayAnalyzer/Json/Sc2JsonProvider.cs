namespace Sc2ReplayAnalyzer.Tokenizer;

public class Sc2JsonProvider
{
    private const string ResourcePrefix = "Sc2ReplayAnalyzer.Json.Protocols.";
    private const string ProtocolNumberPrefix = "Sc2ReplayAnalyzer.Json.Protocols.protocol";
    private const string ProtocolNumberSuffix = ".json";
    private const int MinimalProtocolSupported = 51702;
    public Dictionary<string, string> Provide()
    {
        var assembly = typeof(Sc2JsonProvider).Assembly;
        var resourceNames = assembly.GetManifestResourceNames()
            .Where(IsSupportedProtocol);
        var jsonDict = new Dictionary<string, string>();

        foreach(var resourceName in resourceNames)
        {
            using var reader = new StreamReader(assembly.GetManifestResourceStream(resourceName)!);
            var data = reader.ReadToEnd();
            var protocolName = Path.GetFileNameWithoutExtension(resourceName[ResourcePrefix.Length..]);

            jsonDict[protocolName] = data;
        }

        return jsonDict;
    }

    private bool IsSupportedProtocol(string resource) 
=> int.Parse(resource[ProtocolNumberPrefix.Length..^ProtocolNumberSuffix.Length]) >= MinimalProtocolSupported;
}
