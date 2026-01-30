namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.MethodGenerators;

internal interface IProtocolAgnosticParser : IProtocolFinaliserParser
{
    void OpenUserType(string unitTypeName, string typeInfo);

    void OpenEnum<T>(string unitTypeName, int numFields)
        where T : IProtocolTypeConversionAlignment;

    void ContinueEnumVariant(string variantValue, string variantValueFullName, string fullName, string variantName);

    void CloseEnum();
}
