namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents;

public class STriggerSoundtrackDoneEvent : GameEvent
{
    public STriggerSoundtrackDoneEvent(GameEvent gameEvent,int soundtrack) : base(gameEvent)
    {
        Soundtrack = soundtrack;
    }

    public int Soundtrack { get; init; }
}
