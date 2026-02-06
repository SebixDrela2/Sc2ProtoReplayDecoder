namespace Sc2ReplayAnalyzer.Decoder.Events.Header;

public sealed record Header
{
    public Header(
        int protocol,
        int elapsedGameLoops,
        bool useScaledTime,
        Version version,
        string signature,
        string rootKey,
        string compatibilityHash,
        int type,
        int flags,
        int build,
        int baseBuild)
    {
        DataBuildNum = protocol;
        ElapsedGameLoops = elapsedGameLoops;
        UseScaledTime = useScaledTime;
        Version = version;
        Signature = signature;
        NgpdRootKey = rootKey;
        CompatibilityHash = compatibilityHash;
        Type = type;
        Flags = flags;
        Build = build;
        BaseBuild = baseBuild;
    }

    public int DataBuildNum { get; init; }

    public string NgpdRootKey { get; init; }

    public int ElapsedGameLoops { get; init; }

    public bool UseScaledTime { get; init; }

    public Version Version { get; init; }

    public string Signature { get; init; }

    public string CompatibilityHash { get; init; }

    public int Type { get; init; }

    public int Flags { get; init; }

    public int Build { get; init; }

    public int BaseBuild { get; init; }
}