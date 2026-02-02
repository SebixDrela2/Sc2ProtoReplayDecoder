using Sc2ReplayAnalyzer.Json.VersionedProtocolDefinitions;

namespace Sc2ReplayAnalyzer.Decoder.Factory;

internal interface IVersionedProtocolParser
{
    SVarUint32 Parse_SVarUint32();

    GameSDetails Parse_GameSDetails();

    ReplayTrackerEEventId Parse_ReplayTrackerEEventId();

    int RustSize { get; }
}
