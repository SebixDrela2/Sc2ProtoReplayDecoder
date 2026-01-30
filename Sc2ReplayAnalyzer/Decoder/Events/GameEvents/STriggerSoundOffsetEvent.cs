namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents;

public class STriggerSoundOffsetEvent : GameEvent
{
    public STriggerSoundOffsetEvent(GameEvent gameEvent,
                            int sound) : base(gameEvent)
    {
        Sound = sound;
    }

    public int Sound { get; init; }
}
