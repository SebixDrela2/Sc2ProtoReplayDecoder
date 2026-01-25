using Sc2ReplayAnalyzer.CodeGenerator;
using Sc2ReplayAnalyzer.CodeGenerator.Generators;
using Sc2ReplayAnalyzer.Json;
using Sc2ReplayAnalyzer.Tokenizer;
using System.Text;

internal class Program
{
    private static readonly Sc2JsonProvider _provider = new Sc2JsonProvider();
    private static void Main(string[] args)
    {
        //var decoder = new Sc2ReplayDecoder("Oh No It's Zombies Arctic Map (37).SC2Replay");
        //decoder.Decode();

        var jsonFiles = _provider.Provide();

        var jsonParser = new Sc2JsonParser(jsonFiles);
        var dataList = jsonParser.Parse().ToArray();

        foreach (var data in dataList[0..1])
        {
            var generator = new Sc2CodeGenerator(new StringBuilder(), data);
            generator.Generate();

            Enumerable.Range(0, 5).Select(x => x).ToArray();


        }
    }
}