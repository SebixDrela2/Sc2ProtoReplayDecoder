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
        var files = Directory.GetFiles(ReplaysPath);
        var decoder = new ReplayDecoder();

        foreach (var file in files)
        {
            decoder.DecodeReplay(file);
        }
    }
}