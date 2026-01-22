using Sc2ReplayAnalyzer.Parser;

namespace Sc2ReplayAnalyzer.Tokenizer;

public class Sc2JsonProvider
{
    private const string ResourcePrefix = "Sc2ReplayAnalyzer.Tokenizer.Protocols.";

    public Dictionary<string, string> Provide()
    {
        var assembly = typeof(Sc2ReplayDecoder).Assembly;
        var resourceNames = assembly.GetManifestResourceNames();
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
}
