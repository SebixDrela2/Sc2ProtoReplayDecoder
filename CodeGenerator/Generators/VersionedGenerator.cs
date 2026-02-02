using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators.Utils;
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

        var methodBuilder = new StringBuilder();

        AddClasses();

        _choiceGenerator.Generate<ProtocolTypeConversionByteAligned>(byteAligned);
        _structGenerator.Generate<ProtocolTypeConversionByteAligned>(byteAligned);
        _enumGenerator.Generate<ProtocolTypeConversionByteAligned>(byteAligned);
        _intGenerator.Generate<ProtocolTypeConversionByteAligned>(byteAligned);
        _arrayDynGenerator.Generate<ProtocolTypeConversionByteAligned>(byteAligned);

        AddParser(methodBuilder, protocolName);

        if (data.IsLatestProtocol)
        {
            File.WriteAllText(@$"{ProtocolGenerationFolderPath}\VersionedProtocolDefinitions.cs", builder.ToString());
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

            namespace Sc2ReplayAnalyzer.Json.VersionedProtocolDefinitions;
            """);
        builder.AppendLine();
    }

    private void AddParser(StringBuilder methodBuilder, string protocolName)
    {
        methodBuilder.AppendLine($$"""
            using Sc2ReplayAnalyzer.Global;
            using Sc2ReplayAnalyzer.Json.VersionedProtocolDefinitions;
            using Sc2ReplayAnalyzer.Decoder.Factory;
            
            namespace Sc2ReplayAnalyzer.Json.{{protocolName}}.Versioned;

            public class VersionedProtocolParser(BinaryReader reader) : VersionedProtocolParserImpl(reader), IVersionedProtocolParser
            {
            {{data.ParserGenerator}}
            }
            """);
        File.WriteAllText(@$"{ProtocolGenerationFolderPathVersioned}\VersionedProtocolParser.cs", methodBuilder.ToString());
    }
}
