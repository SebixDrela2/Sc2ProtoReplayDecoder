namespace Sc2ReplayAnalyzer.CodeGenerator;

public class Sc2JsonTypeConversion
{
    public string CSharpType = "unknown type";
    public bool IsVector = false;
    public bool IsSizedInt = false;
    public bool IsOptional = false;
    public bool ShouldTryFrom = false;
    public string Parser = "unknown type";
}

internal interface ISc2JsonTypeConversionAlignment
{
    static abstract Sc2JsonTypeConversion FromNnetName(string nnetName);
}

internal class Sc2JsonTypeConversionByteAligned : ISc2JsonTypeConversionAlignment
{
    public static Sc2JsonTypeConversion FromNnetName(string nnetName) => nnetName switch
    {
        "NNet.uint8" or
        "NNet.Replay.EReplayType" or
        "NNet.uint6" or
        "NNet.Game.TPlayerId" or
        "NNet.Game.TControlId" or
        "NNet.Game.TTeamId" or
        "NNet.Replay.Tracker.TUIntMiniBits" => new Sc2JsonTypeConversion
        {
            CSharpType = "byte",
            ShouldTryFrom = true,
            Parser = "tagged_vlq_int",
        },
        "NNet.uint32" or
        "NNet.uint14" or
        "NNet.uint22" or
        "NNet.Game.TDifficulty" or
        "NNet.Game.THandicap" => new Sc2JsonTypeConversion
        {
            CSharpType = "int",
            ShouldTryFrom = true,
            Parser = "tagged_vlq_int",
        },
        "NNet.int32" or "NNet.Game.TFixedBits" => new Sc2JsonTypeConversion
        {
            CSharpType = "int",
            ShouldTryFrom = true,
            Parser = "tagged_vlq_int",
        },
        "NNet.SVersion" => new Sc2JsonTypeConversion
        {
            CSharpType = "SVersion",
            Parser = "SVersion.Parse"
        },
        "NNet.Game.TColorId" or "NNet.int64" => new Sc2JsonTypeConversion
        {
            CSharpType = "long",
            ShouldTryFrom = true,
            Parser = "tagged_vlq_int",
        },
        "NNet.uint64" => new Sc2JsonTypeConversion
        {
            CSharpType = "long",
            ShouldTryFrom = true,
            Parser = "tagged_vlq_int"
        },
        "FourCCType" => new Sc2JsonTypeConversion
        {
            CSharpType = "int",
            Parser = "tagged_fourcc"
        },
        "BlobType" or
        "NNet.Replay.CSignature" or
        "StringType" or
        "NNet.Replay.Tracker.CatalogName" or
        "NNet.Game.CCacheHandle" or
        "NNet.CFilePath" or
        "NNet.CUserName" => new Sc2JsonTypeConversion
        {
            CSharpType = "List<byte>",
            Parser = "tagged_blob",
        },
        "BoolType" => new Sc2JsonTypeConversion
        {
            CSharpType = "bool",
            Parser = "tagged_bool"
        },
        "OptionalType" => new Sc2JsonTypeConversion
        {
            CSharpType = "Option<{}>",
            Parser = "{}",
            IsOptional = true,
        },
        "ArrayType" or
        "DynArrayType" or
        "NNet.CUserArchiveDataArray" or
        "NNet.CUserInitialDataArray" => new Sc2JsonTypeConversion
        {
            CSharpType = "List<{}>",
            Parser = "{}",
            IsVector = true,
        },
        "NNet.SMD5" => new Sc2JsonTypeConversion
        {
            CSharpType = "Smd5",
            Parser = "Smd5.Parse",
        },
        "NNet.EObserve" => new Sc2JsonTypeConversion
        {
            CSharpType = "EObserve",
            Parser = "EObserve.Parse",
        },
        "NNet.Game.EResultDetails" => new Sc2JsonTypeConversion
        {
            CSharpType = "GameEResultDetails",
            Parser = "GameEResultDetails.Parse"
        },
        "NNet.Game.CCacheHandles" => new Sc2JsonTypeConversion
        {
            CSharpType = "List<List<byte>>",
            Parser = "tagged_blob",
            IsVector = true,
        },
        "NNet.Replay.Tracker.SPlayerStats" => new Sc2JsonTypeConversion
        {
            CSharpType = "ReplayTrackerSPlayerStats",
            Parser = "ReplayTrackerSPlayerStats.Parse"
        },
        "NNet.Game.CPlayerDetailsArray" => new Sc2JsonTypeConversion
        {
            CSharpType = "List<GameSPlayerDetails>",
            Parser = "GameSPlayerDetails.Parse"
        },
        "NNet.Game.SThumbnail" => new Sc2JsonTypeConversion
        {
            CSharpType = "GameSThumbnail",
            Parser = "GameSThumbnail.Parse"
        },
        "NNet.Game.CModPaths" => new Sc2JsonTypeConversion
        {
            CSharpType = "List<List<byte>>",
            Parser = "tagged_blob",
            IsVector = true,
        },
        "NNet.Game.EGameSpeed" => new Sc2JsonTypeConversion
        {
            CSharpType = "GameEGameSpeed",
            Parser = "GameEGameSpeed.Parse"
        },
        "NNet.Game.SToonNameDetails" => new Sc2JsonTypeConversion
        {
            CSharpType = "GameSToonNameDetails",
            Parser = "GameSToonNameDetails.Parse"
        },
        "NNet.Game.SColor" => new Sc2JsonTypeConversion
        {
            CSharpType = "GameSColor",
            Parser = "GameSColor.Parse"
        },
        var x => throw new NotSupportedException($"WTF TYPE {x}")
    };
}