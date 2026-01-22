using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes;
using Sc2ReplayAnalyzer.Json.Generator;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.Generators;

using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

public class Sc2CodeGenerator(IReadOnlyList<Sc2GeneratorData> dataList)
{
    private readonly Sc2StructGenerator _structGenerator = new();

    public void Generate()
    {
        var byteAligned = dataList.Last().ByteAligned;
        var bitPacked = dataList.Last().BitPacked;

        _structGenerator.GenerateStructs<Sc2JsonTypeConversionByteAligned>(byteAligned);
        _structGenerator.GenerateStructs<Sc2TypeConversionBitPacked>(bitPacked);
    } 
}
