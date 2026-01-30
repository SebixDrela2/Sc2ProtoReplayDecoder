namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents;

public class STriggerGameMenuItemSelectedEvent : GameEvent
{
    public STriggerGameMenuItemSelectedEvent(
        GameEvent gameEvent,
        long gameMenuItemIndex) : base(gameEvent)
    {
        GameMenuItemIndex = gameMenuItemIndex;
    }

    public long GameMenuItemIndex { get; init; }
}
