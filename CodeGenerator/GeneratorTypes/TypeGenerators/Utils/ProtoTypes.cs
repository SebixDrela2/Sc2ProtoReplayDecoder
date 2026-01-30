using System.Collections;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.CodeGenerator.GeneratorTypes.TypeGenerators.Utils;

using static Sc2ReplayAnalyzer.Json.ProtocolJsonType;

public enum ProtoGenType
{
    ArrayDyn = 0,
    BitArray = 1,
    Blob = 2,
    String = 3,
    Choice = 4,
    Enum = 5,
    Int = 6,
    Struct = 7,
    UserType = 8
}
internal static class ProtoTypes
{
    public const string Array = "ArrayType";
    public const string DynArray = "DynArrayType";
    public const string BitArray = "BitArrayType";
    public const string String = "StringType";
    public const string Blob = "BlobType";
    public const string Choice = "ChoiceType";
    public const string Enum = "EnumType";
    public const string Int = "IntType";
    public const string Inum = "InumType";
    public const string Struct = "StructType";
    public const string User = "UserType";

    public static bool IsForGenerator(JsonNode node, ProtoGenType genType)
    {
        var typeInfoType = node[TypeInfo][Type].ToString();

        return genType switch
        {
            ProtoGenType.ArrayDyn => typeInfoType is Array or DynArray,
            ProtoGenType.BitArray => typeInfoType is ProtoTypes.BitArray,
            ProtoGenType.Blob => typeInfoType is ProtoTypes.Blob,
            ProtoGenType.String => typeInfoType is ProtoTypes.String,
            ProtoGenType.Choice => typeInfoType is Choice,
            ProtoGenType.Enum => typeInfoType is ProtoTypes.Enum,
            ProtoGenType.Int => typeInfoType is Int or Inum,
            ProtoGenType.Struct => typeInfoType is Struct,
            ProtoGenType.UserType => typeInfoType is User,
            var unknown => throw new InvalidDataException($"Unknown generator provided: {unknown}")
        };
    }
}
