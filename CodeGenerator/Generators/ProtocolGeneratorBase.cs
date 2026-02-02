using Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators;
using Sc2ReplayAnalyzer.Decoder.APIModel;
using Sc2ReplayAnalyzer.Json.Generator;
using System.Reflection;
using System.Text;

namespace Sc2ReplayAnalyzer.CodeGenerator.Generators;

internal abstract class ProtocolGeneratorBase(StringBuilder builder, Sc2GeneratorData data)
{
    protected readonly EnumGenerator _enumGenerator = new(builder, data);
    protected readonly StructGenerator _structGenerator = new(builder, data);
    protected readonly IntGenerator _intGenerator = new(builder, data);
    protected readonly ChoiceGenerator _choiceGenerator = new(builder, data);
    protected readonly ArrayGenerator _bitArrayGenerator = new(builder, data);
    protected readonly UserTypeGenerator _userTypeGenerator = new(builder, data);
    protected readonly ArrayDynGenerator _arrayDynGenerator = new(builder, data);
    protected readonly BlobTypeStringGenerator _blobStringGenerator = new(builder, data);

    protected string ProtocolGenerationFolderPathVersioned => Path.GetFullPath(Path.Combine(
        AssemblyLocation,
       @"..\..\..\..\Sc2ReplayAnalyzer\ProtocolGen",
       data.ProtocolName));

    protected string ProtocolGenerationFolderPath => Directory.GetParent(ProtocolGenerationFolderPathVersioned).FullName;

    private string AssemblyLocation => Path.GetDirectoryName(typeof(Sc2Replay).Assembly.Location);
}
