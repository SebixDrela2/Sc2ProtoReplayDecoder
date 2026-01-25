using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;
using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.Generators;

using static Sc2ReplayAnalyzer.Json.Sc2JsonType;

public class Sc2CodeGenerator(StringBuilder builder, Sc2GeneratorData data)
{
    private const string GenPath = @"C:\Users\Sebastian\source\repos\Sc2ReplayAnalyzer\Sc2ReplayAnalyzer\ProtocolGen";

    private readonly Sc2EnumGenerator _enumGenerator = new(builder, data);
    private readonly Sc2StructGenerator _structGenerator = new(builder, data);
    private readonly Sc2IntGenerator _intGenerator = new(builder, data);
    private readonly Sc2ChoiceGenerator _choiceGenerator = new(builder, data);
    private readonly Sc2BitArrayGenerator _bitArrayGenerator = new(builder, data);
    private readonly Sc2UserTypeGenerator _userTypeGenerator = new(builder, data);
    private readonly Sc2ArrayDynGenerator _arrayDynGenerator = new(builder, data);
    private readonly Sc2BlobTypeStringGenerator _blobStringGenerator = new(builder, data);

    public void Generate()
    {
        var byteAligned = data.ByteAligned;
        var bitPacked = data.BitPacked;
        var protocolName = data.ProtocolName;

        Init(protocolName);

        _choiceGenerator.GenerateChoices<Sc2TypeConversionByteAligned>(byteAligned);
        _choiceGenerator.GenerateChoices<Sc2TypeConversionBitPacked>(bitPacked);

        _structGenerator.GenerateStructs<Sc2TypeConversionByteAligned>(byteAligned);
        _structGenerator.GenerateStructs<Sc2TypeConversionBitPacked>(bitPacked);

        _enumGenerator.Generator<Sc2TypeConversionByteAligned>(byteAligned);
        _enumGenerator.Generator<Sc2TypeConversionBitPacked>(bitPacked);

        _intGenerator.Generate<Sc2TypeConversionByteAligned>(byteAligned);
        _intGenerator.Generate<Sc2TypeConversionBitPacked>(bitPacked);

        _bitArrayGenerator.Generate<Sc2TypeConversionBitPacked>(bitPacked);

        _userTypeGenerator.Generate<Sc2TypeConversionBitPacked>(bitPacked);

        _arrayDynGenerator.Generate<Sc2TypeConversionByteAligned>(byteAligned);
        _arrayDynGenerator.Generate<Sc2TypeConversionBitPacked>(bitPacked);

        _blobStringGenerator.Generate<Sc2TypeConversionBitPacked>(bitPacked);


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
