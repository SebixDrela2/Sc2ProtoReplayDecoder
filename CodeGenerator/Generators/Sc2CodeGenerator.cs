using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes;
using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.Generators;

using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

public class Sc2CodeGenerator(StringBuilder builder, IReadOnlyList<Sc2GeneratorData> dataList)
{
    private const string GenPath = @"C:\Users\Sebastian\source\repos\Sc2ReplayAnalyzer\Sc2ReplayAnalyzer\ProtocolGen";

    private readonly Sc2EnumGenerator _enumGenerator = new(builder, dataList.Last().EnumTags);
    private readonly Sc2StructGenerator _structGenerator = new(builder);
    private readonly Sc2IntGenerator _intGenerator = new(builder);
    private readonly Sc2ChoiceGenerator _choiceGenerator = new(builder);
    private readonly Sc2BitArrayGenerator _bitArrayGenerator = new(builder);
    private readonly Sc2UserTypeGenerator _userTypeGenerator = new(builder);
    private readonly Sc2ArrayDynGenerator _arrayDynGenerator = new(builder);
    private readonly Sc2BlobTypeStringGenerator _blobStringGenerator = new(builder);

    public void Generate()
    {
        var byteAligned = dataList.Last().ByteAligned;
        var bitPacked = dataList.Last().BitPacked;
        var protocolName = dataList.Last().ProtocolName;

        Init(protocolName);

        _structGenerator.GenerateStructs<Sc2JsonTypeConversionByteAligned>(byteAligned);
        _structGenerator.GenerateStructs<Sc2TypeConversionBitPacked>(bitPacked);

        _choiceGenerator.GenerateChoices<Sc2JsonTypeConversionByteAligned>(byteAligned);
        _choiceGenerator.GenerateChoices<Sc2TypeConversionBitPacked>(bitPacked);

        _enumGenerator.Generator(byteAligned);
        _enumGenerator.Generator(bitPacked);

        _intGenerator.Generate(byteAligned);
        _intGenerator.Generate(bitPacked);

        _bitArrayGenerator.Generate(bitPacked);

        _userTypeGenerator.Generate(bitPacked);

        _arrayDynGenerator.Generate(byteAligned);
        _arrayDynGenerator.Generate(bitPacked);

        _blobStringGenerator.Generate(bitPacked);


        Finalise(protocolName);
    }

    private void Init(string protocolName)
    {
        builder.AppendLine();
        builder.AppendLine($"""
            namespace Sc2ReplayAnalyzer.Json.{protocolName};
            """);
        builder.AppendLine();
    }

    private void Finalise(string protocolName)
    {
        File.WriteAllText(@$"{GenPath}\{protocolName}.cs", builder.ToString());
    }
}
