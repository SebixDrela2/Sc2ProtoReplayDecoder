using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;
using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;

namespace Sc2ReplayAnalyzer.CodeGenerator.Generators;

public class Sc2BitPackedGenerator(StringBuilder builder, Sc2GeneratorData data)
{
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
        var bitPacked = data.BitPacked;
        var protocolName = data.ProtocolName;

        Init(protocolName);

        _choiceGenerator.Generate<Sc2TypeConversionBitPacked>(bitPacked);
        _structGenerator.Generate<Sc2TypeConversionBitPacked>(bitPacked);
        _enumGenerator.Generate<Sc2TypeConversionBitPacked>(bitPacked);
        _intGenerator.Generate<Sc2TypeConversionBitPacked>(bitPacked);
        _bitArrayGenerator.Generate<Sc2TypeConversionBitPacked>(bitPacked);
        _userTypeGenerator.Generate<Sc2TypeConversionBitPacked>(bitPacked);
        _arrayDynGenerator.Generate<Sc2TypeConversionBitPacked>(bitPacked);
        _blobStringGenerator.Generate<Sc2TypeConversionBitPacked>(bitPacked);

        Finalise(protocolName);
    }

    private void Init(string protocolName)
    {
        builder.AppendLine();
        builder.AppendLine($"""
            using Sc2ReplayAnalyzer.Json.Global;

            namespace Sc2ReplayAnalyzer.Json.{protocolName}.BitPacked;
            """);
        builder.AppendLine();
    }

    private void Finalise(string protocolName)
    {
        builder.AppendLine($$"""
            public class BitPackedProtocolParser(BinaryReader reader) : BitPackedProtocolParserImpl(reader)
            {
            {{data.ParserGenerator}}
            }
            """);
        File.WriteAllText(@$"{data.GenFolderPath}\{protocolName}\BitPackedProtocolParser.cs", builder.ToString());
    }
}
