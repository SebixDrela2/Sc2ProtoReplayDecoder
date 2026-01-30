using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators.Utils;
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

        _choiceGenerator.Generate<ProtocolConversionBitPacked>(bitPacked);
        _structGenerator.Generate<ProtocolConversionBitPacked>(bitPacked);
        _enumGenerator.Generate<ProtocolConversionBitPacked>(bitPacked);
        _intGenerator.Generate<ProtocolConversionBitPacked>(bitPacked);
        _bitArrayGenerator.Generate<ProtocolConversionBitPacked>(bitPacked);
        _userTypeGenerator.Generate<ProtocolConversionBitPacked>(bitPacked);
        _arrayDynGenerator.Generate<ProtocolConversionBitPacked>(bitPacked);
        _blobStringGenerator.Generate<ProtocolConversionBitPacked>(bitPacked);

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
