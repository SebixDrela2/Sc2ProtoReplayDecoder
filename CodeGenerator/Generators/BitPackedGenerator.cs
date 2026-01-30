using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;

namespace Sc2ReplayAnalyzer.CodeGenerator.Generators;

internal class BitPackedGenerator(StringBuilder builder, Sc2GeneratorData data) 
    : ProtocolGeneratorBase(builder, data)
{
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
