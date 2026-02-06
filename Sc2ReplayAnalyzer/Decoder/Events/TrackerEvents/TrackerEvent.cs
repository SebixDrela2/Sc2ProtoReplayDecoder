using Sc2ReplayAnalyzer.Json.VersionedProtocolDefinitions;

namespace Sc2ReplayAnalyzer.Decoder.Events.TrackerEvents;

public class TrackerEvent
{
    public ReplayTrackerEEventId TrackerEventId { get; init; }
    public string Type { get; init; }
    public long Gameloop { get; init; }

    public TrackerEvent(ReplayTrackerEEventId eventID, string type, long gameloop)
    {
        TrackerEventId = eventID;
        Type = type;
        Gameloop = gameloop;
    }

    public TrackerEvent(TrackerEvent trackerEvent)
    {
        ArgumentNullException.ThrowIfNull(trackerEvent);

        TrackerEventId = trackerEvent.TrackerEventId;
        Type = trackerEvent.Type;
        Gameloop = trackerEvent.Gameloop;
    }
}