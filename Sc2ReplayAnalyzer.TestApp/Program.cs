using Sc2ReplayAnalyzer.CodeGenerator.Generators;
using Sc2ReplayAnalyzer.Decoder;
using Sc2ReplayAnalyzer.Json;
using Sc2ReplayAnalyzer.TestApp;
using Sc2ReplayAnalyzer.Tokenizer;

internal class Program
{
    private static readonly Sc2JsonProvider _provider = new Sc2JsonProvider();

    private const ProtoRunType RunChoice = ProtoRunType.Decode;

    private const string ProtocolName = "protocol90870";
    private const string ReplaysPath = @"C:\Users\Sebastian\Documents\StarCraft II\Accounts\103757627\1-S2-1-10180166\Replays\Multiplayer";

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
        var dataList = jsonParser.Parse().ToArray();

        var data = dataList.First(x => x.ProtocolName is ProtocolName);

        var generator = new SharedProtocolGenerator(data);
        generator.Generate();
    }

    private static void Decode()
    {
        var files = Directory.GetFiles(ReplaysPath);
        
        foreach (var file in files)
        {
            var decoder = new ReplayDecoder();
            decoder.Decode(file);

            Console.WriteLine($"Decoded: {file}");
        }
    }
}