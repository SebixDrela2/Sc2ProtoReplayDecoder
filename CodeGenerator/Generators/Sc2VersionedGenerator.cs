using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;
using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sc2ReplayAnalyzer.CodeGenerator.Generators;

internal class Sc2VersionedGenerator(StringBuilder builder, Sc2GeneratorData data)
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
