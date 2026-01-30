namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents;

public class STriggerTransmissionCompleteEvent : GameEvent
{
    public STriggerTransmissionCompleteEvent(GameEvent gameEvent,
                            long transmissionId) : base(gameEvent)
    {
        TransmissionId = transmissionId;
    }

    public long TransmissionId { get; init; }
}
