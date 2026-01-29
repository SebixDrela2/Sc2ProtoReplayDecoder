using Sc2ReplayAnalyzer.CodeGenerator.Generators;
using Sc2ReplayAnalyzer.Decoder;
using Sc2ReplayAnalyzer.Json;
using Sc2ReplayAnalyzer.Tokenizer;

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
        var decoder = new Sc2ReplayDecoder(@"C:\Users\Sebastian\Desktop\Blizurd\225.SC2Replay");
        decoder.Decode();
    }
}