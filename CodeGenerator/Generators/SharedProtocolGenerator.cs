using Sc2ReplayAnalyzer.Decoder.APIModel;
using Sc2ReplayAnalyzer.Json.Generator;
using System.Text;

namespace Sc2ReplayAnalyzer.CodeGenerator.Generators;

public class SharedProtocolGenerator(Sc2GeneratorData data)
{
    private readonly BitPackedGenerator _bitPackedGenerator = new(new StringBuilder(), data);
    private readonly VersionedGenerator _versionedGenerator = new(new StringBuilder(), data);

    private string ProtocolGenerationFolderPath => Path.GetFullPath(Path.Combine(
            AssemblyLocation,
           @"..\..\..\..\Sc2ReplayAnalyzer\ProtocolGen",
           data.ProtocolName));

    private string AssemblyLocation => Path.GetDirectoryName(typeof(Sc2Replay).Assembly.Location);

    public void Generate()
    {
        PrepareDirAndCleanUpPrevRun();

        _bitPackedGenerator.Generate();

        data.ParserGenerator.Clear();

        _versionedGenerator.Generate();
    }

    private void PrepareDirAndCleanUpPrevRun()
    {
        if (!Directory.Exists(ProtocolGenerationFolderPath))
        {
            Directory.CreateDirectory(ProtocolGenerationFolderPath);
        }

        var files = Directory.GetFiles(ProtocolGenerationFolderPath);

        foreach (var file in files)
        {
            File.Delete(file);
        }
    }
}
