namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents;

public class STriggerTransmissionOffsetEvent : GameEvent
{
    public STriggerTransmissionOffsetEvent(GameEvent gameEvent, long transmissionId, long threadTag) : base(gameEvent)
    {
        TransmissionId = transmissionId;
        ThreadTag = threadTag;
    }

    public long TransmissionId { get; init; }
    public long ThreadTag { get; init; }
}