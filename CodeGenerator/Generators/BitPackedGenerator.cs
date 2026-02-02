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

        var methodBuilder = new StringBuilder();

        if (data.IsLatestProtocol)
        {
            AddClasses();
        }

        _choiceGenerator.Generate<ProtocolConversionBitPacked>(bitPacked);
        _structGenerator.Generate<ProtocolConversionBitPacked>(bitPacked);
        _enumGenerator.Generate<ProtocolConversionBitPacked>(bitPacked);
        _intGenerator.Generate<ProtocolConversionBitPacked>(bitPacked);
        _bitArrayGenerator.Generate<ProtocolConversionBitPacked>(bitPacked);
        _userTypeGenerator.Generate<ProtocolConversionBitPacked>(bitPacked);
        _arrayDynGenerator.Generate<ProtocolConversionBitPacked>(bitPacked);
        _blobStringGenerator.Generate<ProtocolConversionBitPacked>(bitPacked);

        AddParser(methodBuilder, protocolName);

        if (data.IsLatestProtocol)
        {
            File.WriteAllText(@$"{ProtocolGenerationFolderPath}\BitPackedProtocolDefinitions.cs", builder.ToString());
        }
    }

    private void AddClasses()
    {
        if (!data.IsLatestProtocol)
        {
            return;
        }

        builder.AppendLine();
        builder.AppendLine($"""
            using Sc2ReplayAnalyzer.Global;

            namespace Sc2ReplayAnalyzer.Json.BitPackedProtocolDefinitions;
            """);
        builder.AppendLine();   
    }

    private void AddParser(StringBuilder methodBuilder, string protocolName)
    {
        methodBuilder.AppendLine($$"""
            using Sc2ReplayAnalyzer.Global;
            using Sc2ReplayAnalyzer.Json.BitPackedProtocolDefinitions;
            using Sc2ReplayAnalyzer.Decoder.Factory;

            namespace Sc2ReplayAnalyzer.Json.{{protocolName}}.BitPacked;

            public class BitPackedProtocolParser(BinaryReader reader) : BitPackedProtocolParserImpl(reader), IBitPackedProtocolParser
            {
            {{data.ParserGenerator}}
            }
            """);
        File.WriteAllText(@$"{ProtocolGenerationFolderPathVersioned}\BitPackedProtocolParser.cs", methodBuilder.ToString());
    }
}
