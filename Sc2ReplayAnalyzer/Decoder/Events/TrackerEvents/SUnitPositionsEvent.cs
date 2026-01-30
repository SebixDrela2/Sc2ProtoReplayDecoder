namespace Sc2ReplayAnalyzer.Decoder.Events.TrackerEvents;

public class SUnitPositionsEvent : TrackerEvent
{
    // Public properties to replace private fields
    public TrackerEvent TrackerEvent { get; }
    public int FirstUnitIndex { get; }
    public int[] Ints { get; }

    // Constructor to initialize the properties
    public SUnitPositionsEvent(TrackerEvent trackerEvent, int firstUnitIndex, int[] ints) : base(trackerEvent)
    {
        TrackerEvent = trackerEvent;
        FirstUnitIndex = firstUnitIndex;
        Ints = ints;
    }
}