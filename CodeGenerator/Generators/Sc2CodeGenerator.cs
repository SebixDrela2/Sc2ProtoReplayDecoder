using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes;
using Sc2ReplayAnalyzer.Json.Generator;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.Generators;

using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

public class Sc2CodeGenerator(IReadOnlyList<Sc2GeneratorData> dataList)
{
    private readonly Sc2StructGenerator _structGenerator = new();
    private readonly Sc2ChoiceGenerator _choiceGenerator = new();
    private readonly Sc2EnumGenerator _enumGenerator = new(dataList.Last().EnumTags);

    public void Generate()
    {
        var byteAligned = dataList.Last().ByteAligned;
        var bitPacked = dataList.Last().BitPacked;

        //_structGenerator.GenerateStructs<Sc2JsonTypeConversionByteAligned>(byteAligned);
        //_structGenerator.GenerateStructs<Sc2TypeConversionBitPacked>(bitPacked);

        //_choiceGenerator.GenerateChoices<Sc2JsonTypeConversionByteAligned>(byteAligned);
        //_choiceGenerator.GenerateChoices<Sc2TypeConversionBitPacked>(bitPacked);

        //_enumGenerator.Generator(byteAligned);
        //_enumGenerator.Generator(bitPacked);
    } 
}
