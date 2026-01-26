using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sc2ReplayAnalyzer.CodeGenerator.Generators;

public class Sc2SharedCodeGenerator(Sc2GeneratorData data)
{
    private readonly Sc2BitPackedGenerator _bitPackedGenerator = new Sc2BitPackedGenerator(new StringBuilder(), data);
    private readonly Sc2VersionedGenerator _versionedGenerator = new Sc2VersionedGenerator(new StringBuilder(), data);
    public void Generate()
    {
        var protocolName = data.ProtocolName;
        var destinationDirectory = @$"{data.GenFolderPath}\{protocolName}";

        if (!Directory.Exists(destinationDirectory))
        {
            Directory.CreateDirectory(destinationDirectory);
        }

        _bitPackedGenerator.Generate();

        data.ParserGenerator.Clear();

        _versionedGenerator.Generate();
    }
}
