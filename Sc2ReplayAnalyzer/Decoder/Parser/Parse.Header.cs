using Sc2ReplayAnalyzer.Decoder.Events.Header;
using Sc2ReplayAnalyzer.Json.VersionedProtocolDefinitions;

namespace Sc2ReplayAnalyzer.Decoder.Parser;

internal static partial class Parse
{
    internal static Header Header(ReplaySHeader header)
    {
        var useScaledTime = header.m_useScaledTime;
        var signature = header.m_signature.ReadStringBytes();
        (var version, int flags, int build, int basebuild) = GetVersion(header);
        var elapsed = (int)header.m_elapsedGameLoops;
        var protocol = (int)header.m_dataBuildNum;
        var type = header.m_type;
        var rootKey = GetRootKey(header);

        return new Header(protocol, elapsed, useScaledTime, version, signature, rootKey, string.Empty, type, flags, build, basebuild);
    }

    private static (Version, int, int, int) GetVersion(ReplaySHeader header)
    {
        var version = new Version();
        int flags = 0;
        int build = 0;
        int basebuild = 0;

        if (header.m_version is { } headerVersion)
        {
            version = new Version(headerVersion.m_major, headerVersion.m_minor, headerVersion.m_revision);
            flags = headerVersion.m_flags;
            build = (int)headerVersion.m_build;
            basebuild = (int)headerVersion.m_baseBuild;
        }
        return (version, flags, build, basebuild);
    }

    private static string GetRootKey(ReplaySHeader header)
    {
        if (header.m_ngdpRootKey is { } rootKey)
        {
            return rootKey.m_data.ReadStringBytes();
        }

        return "";
    }
}
