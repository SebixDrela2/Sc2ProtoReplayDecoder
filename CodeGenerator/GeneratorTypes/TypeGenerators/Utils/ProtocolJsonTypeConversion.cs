namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators.Utils;

public class ProtocolJsonTypeConversion
{
    public string CSharpType = "unknown type";
    public bool IsVector = false;
    public bool IsSizedInt = false;
    public bool IsOptional = false;
    public bool ShouldTryFrom = false;
    public bool IsBitArray = false;
    public string Parser = "unknown type";
}
