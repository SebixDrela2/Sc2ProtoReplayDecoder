using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;

namespace Sc2ReplayAnalyzer.CodeGenerator.Generators;

internal class VersionedGenerator(StringBuilder builder, Sc2GeneratorData data) 
    : ProtocolGeneratorBase(builder, data)
{
    public void Generate()
    {
        var byteAligned = data.ByteAligned;
        var protocolName = data.ProtocolName;

        Init(protocolName);

        _choiceGenerator.Generate<Sc2TypeConversionByteAligned>(byteAligned);
        _structGenerator.Generate<Sc2TypeConversionByteAligned>(byteAligned);
        _enumGenerator.Generate<Sc2TypeConversionByteAligned>(byteAligned);
        _intGenerator.Generate<Sc2TypeConversionByteAligned>(byteAligned);
        _arrayDynGenerator.Generate<Sc2TypeConversionByteAligned>(byteAligned);

        Finalise(protocolName);

    }

    private void Init(string protocolName)
    {
        builder.AppendLine();
        builder.AppendLine($"""
            using Sc2ReplayAnalyzer.Json.Global;

            namespace Sc2ReplayAnalyzer.Json.{protocolName}.Versioned;
            """);
        builder.AppendLine();
    }

    private void Finalise(string protocolName)
    {
        builder.AppendLine($$"""
            public class VersionedProtocolParser(BinaryReader reader) : VersionedProtocolParserImpl(reader)
            {
            {{data.ParserGenerator}}
            }
            """);
        File.WriteAllText(@$"{data.GenFolderPath}\{protocolName}\VersionedProtocolParser.cs", builder.ToString());
    }
}
