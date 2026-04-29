using MPQArchive.MPQ.DecryptedData;
using Sc2ReplayAnalyzer.CodeGenerator.Generators;
using Sc2ReplayAnalyzer.Decoder;
using Sc2ReplayAnalyzer.Json;
using Sc2ReplayAnalyzer.TestApp;
using Sc2ReplayAnalyzer.Tokenizer;

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
        var path = @"C:\Users\Sebastian\Documents\StarCraft II\Accounts\103757627\1-S2-1-10180166\Replays\Multiplayer";
        var path2 = @"C:\\Users\\Sebastian\\replays\\___ONIZA_REPLAYS\\Oh No It's Zombies 25812.SC2Replay";
        //var files = Directory.GetFiles(path);

        //foreach (var file in files.Where(x => x.Contains("Oh No It's Zombies")))
        //{
        //    var decoder = new ReplayDecoder();
        //    var replay = decoder.DecodeReplay(file);

        //    Console.WriteLine(replay.FileName);
        //}

        var decoder = new ReplayDecoder();
        var replay = decoder.DecodeReplay(path2);
    }    
}