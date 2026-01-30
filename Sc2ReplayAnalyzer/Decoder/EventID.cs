using Sc2ReplayAnalyzer.Json.protocol90870.BitPacked;
using Sc2ReplayAnalyzer.Json.protocol90870.Versioned;

namespace Sc2ReplayAnalyzer.Decoder;

internal record class EventPair
{
    public uint Delta;
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
