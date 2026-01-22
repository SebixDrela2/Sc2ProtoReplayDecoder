using MPQArchive.MPQ;
using Sc2ReplayAnalyzer.Json;
using Sc2ReplayAnalyzer.Tokenizer;

namespace Sc2ReplayAnalyzer.Parser;

public class Sc2ReplayDecoder(string path)
{
    private readonly Sc2JsonProvider _provider = new Sc2JsonProvider();

    public void Decode()
    {
        using var fileStream = File.Open(path, FileMode.Open);
        var mpqArchive = new MPQReader(fileStream).Read();

        var jsonFiles = _provider.Provide();

        var jsonParser = new Sc2JsonParser(jsonFiles);
        var dataList = jsonParser.Parse();
    }
}
