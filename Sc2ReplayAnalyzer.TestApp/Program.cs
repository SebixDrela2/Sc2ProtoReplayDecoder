using Sc2ReplayAnalyzer.CodeGenerator.Generators;
using Sc2ReplayAnalyzer.Decoder;
using Sc2ReplayAnalyzer.Json;
using Sc2ReplayAnalyzer.Tokenizer;
using System.Diagnostics;

internal class Program
{
    private static readonly Sc2JsonProvider _provider = new Sc2JsonProvider();
    private const string GenPath = @"C:\Users\Sebastian\source\repos\Sc2ReplayAnalyzer\Sc2ReplayAnalyzer\ProtocolGen";
    internal static void Main(string[] args)
    {
        //Generate();
        Decode();
    }

    private static void Generate()
    {
        var jsonFiles = _provider.Provide();

        var jsonParser = new Sc2JsonParser(jsonFiles);
        var dataList = jsonParser.Parse().ToArray();

        var data = dataList.First(x => x.ProtocolName is "protocol90870");
        data.GenFolderPath = GenPath;

        var generator = new Sc2SharedCodeGenerator(data);
        generator.Generate();
    }

    private static void Decode()
    {
        var count = 0;
        var files = Directory.GetFiles(@"C:\Users\Sebastian\Documents\StarCraft II\Accounts\103757627\1-S2-1-10180166\Replays\Multiplayer").ToArray();
        var length = files.Count();

        var totalTime = Stopwatch.StartNew();

        foreach (var file in files)
        {
            var decoder = new Sc2ReplayDecoder(file);
            decoder.Decode();
        }

        totalTime.Stop();

        Console.WriteLine($"Total Time: {totalTime}");
    }
}