using MPQArchive.MPQ.DecryptedData;
using Sc2ReplayAnalyzer.CodeGenerator.Generators;
using Sc2ReplayAnalyzer.Decoder;
using Sc2ReplayAnalyzer.Json;
using Sc2ReplayAnalyzer.TestApp;
using Sc2ReplayAnalyzer.Tokenizer;
using System.Diagnostics;
using System.Text;

internal class Program
{
    private static readonly Sc2JsonProvider _provider = new Sc2JsonProvider();

    private const ProtoRunType RunChoice = ProtoRunType.Decode;

    private const string ReplaysPath = @"C:\Users\Sebastian\replays";

    internal static void Main(string[] args)
    {
        Action action = RunChoice switch
        {
            ProtoRunType.Decode => Decode,
            ProtoRunType.Generate => Generate,
            var runChoice => throw new InvalidOperationException()
        };

        action();
    }

    private static void Generate()
    {
        var jsonFiles = _provider.Provide();
        var jsonParser = new ProtocolJsonParser(jsonFiles);
        var dataList = jsonParser.Parse();

        foreach(var data in dataList)
        {
            var generator = new SharedProtocolGenerator(data);
            generator.Generate();
        }
    }


    private static void Decode()
    {
        var decoder = new ReplayDecoder();

        var path =  @"C:\Users\Sebastian\source\repos\Sc2ReplayAnalyzer\Sc2ReplayAnalyzer.TestApp\Oh No It's Zombies Arctic Map (79).SC2Replay";
        var stopWatch = Stopwatch.StartNew();
        var result = decoder.DecodeReplay(path);
        stopWatch.Stop();
    }    
}