using Sc2ReplayAnalyzer.Json.BitPackedProtocolDefinitions;
using Sc2ReplayAnalyzer.Json.VersionedProtocolDefinitions;

namespace Sc2ReplayAnalyzer.Decoder;

internal record class TrackerEventPair
{
    public long Delta;
    public ReplayTrackerEEventId TrackerEventID;
}

internal record class GameEventTriplet
{
    public long Delta;
    public long UserID;
    public GameEEventId EventID;
}

internal record class MessageEventTriplet
{
    public long Delta;
    public long UserID;
    public GameEMessageId EventID;
}
