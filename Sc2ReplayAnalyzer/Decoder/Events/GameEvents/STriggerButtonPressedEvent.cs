namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents;

public class STriggerButtonPressedEvent : GameEvent
{
    public STriggerButtonPressedEvent(
        GameEvent gameEvent,
        int button) : base(gameEvent)
    {
        Button = button;
    }
    public int Button { get; init; }
}
