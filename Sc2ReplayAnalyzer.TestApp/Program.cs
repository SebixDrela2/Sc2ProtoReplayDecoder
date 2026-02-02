using Sc2ReplayAnalyzer.CodeGenerator.Generators;
using Sc2ReplayAnalyzer.Decoder;
using Sc2ReplayAnalyzer.Json;
using Sc2ReplayAnalyzer.TestApp;
using Sc2ReplayAnalyzer.Tokenizer;
using System.Diagnostics;

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
        var unwork = @"C:\Users\Sebastian\replays\Oh No It's Zombies 10583.SC2Replay";
        var work = @"C:\Users\Sebastian\Documents\StarCraft II\Accounts\103757627\1-S2-1-10180166\Replays\Multiplayer\Oh No It's Zombies Arctic Map (45).SC2Replay";
        var choice = work;
        string[] files = Directory.GetFiles(ReplaysPath);

        var time = Stopwatch.StartNew();

        var decoder = new ReplayDecoder();
        var total = 0;

        foreach (var file in files)
        {
            Console.WriteLine($"Started decoding: {file}");
            decoder.DecodeReplay(file);

            Console.WriteLine($"Decoded: {file}");
            Console.WriteLine($"Total: {++total}");
        }

        time.Stop();
        Console.Write($"Total time: {time}");
    }
}