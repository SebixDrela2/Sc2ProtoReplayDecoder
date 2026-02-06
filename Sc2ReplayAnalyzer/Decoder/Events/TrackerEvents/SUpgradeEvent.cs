namespace Sc2ReplayAnalyzer.Decoder.Events.TrackerEvents;

public class SUpgradeEvent : TrackerEvent
{
    public TrackerEvent TrackerEvent { get; }
    public int Count { get; }
    public string UpgradeTypeName { get; }
    public int PlayerId { get; }

    public SUpgradeEvent(TrackerEvent trackerEvent, int count, int playerId, string upgradeTypeName) : base(trackerEvent)
    {
        TrackerEvent = trackerEvent;
        Count = count;
        UpgradeTypeName = upgradeTypeName;
        PlayerId = playerId;
    }
}