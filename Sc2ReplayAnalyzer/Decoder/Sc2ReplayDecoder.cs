using MPQArchive.MPQ;
using Sc2ReplayAnalyzer.Tokenizer;
using Sc2ReplayAnalyzer.Json.protocol95299;
namespace Sc2ReplayAnalyzer.Decoder;

public class Sc2ReplayDecoder(string path)
{
    private readonly Sc2JsonProvider _provider = new Sc2JsonProvider();

    public void Decode()
    {
        using var fileStream = File.Open(path, FileMode.Open);
        var mpqArchive = new MPQReader(fileStream).Read();
        var userData = mpqArchive.MPQUserData;

        var binaryReader = new BinaryReader(new MemoryStream(mpqArchive.MPQUserData.Content));

        var parser = new ProtocolParser(binaryReader);
        var header = parser.Parse_ReplaySHeader();       
    }
}
