namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents;

public class STriggerSoundLengthQueryEvent : GameEvent
{
    /// <summary>Record <c>STriggerSoundLengthQueryEvent</c> constructor</summary>
    ///
    public STriggerSoundLengthQueryEvent(GameEvent gameEvent,
                            long soundHash,
                            int length) : base(gameEvent)
    {
        SoundHash = soundHash;
        Length = length;
    }

    public long SoundHash { get; init; }

    public int Length { get; init; }
}
