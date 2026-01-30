using Sc2ReplayAnalyzer.Json.Generator;
using System.Reflection;
using System.Text;

namespace Sc2ReplayAnalyzer.CodeGenerator.Generators;

public class SharedProtocolGenerator(Sc2GeneratorData data)
{
    private readonly BitPackedGenerator _bitPackedGenerator = new(new StringBuilder(), data);
    private readonly VersionedGenerator _versionedGenerator = new(new StringBuilder(), data);

    private string GeneratedProtocolPath => @$"{ProtocolGenerationFolderPath}\{data.GenFolderPath}";

    private string ProtocolGenerationFolderPath => Path.GetFullPath(Path.Combine(
            AssemblyLocation,
           "..", "..", "..", "..",
           "ProtocolGen"));

    private string AssemblyLocation => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    public void Generate()
    {
        PrepareDirAndCleanUpPrevRun();

        _bitPackedGenerator.Generate();

        data.ParserGenerator.Clear();

        _versionedGenerator.Generate();
    }

    private void PrepareDirAndCleanUpPrevRun()
    {
        if (!Directory.Exists(GeneratedProtocolPath))
        {
            Directory.CreateDirectory(GeneratedProtocolPath);
        }

        var files = Directory.GetFiles(GeneratedProtocolPath);

        foreach (var file in files)
        {
            File.Delete(file);
        }
    }
}
