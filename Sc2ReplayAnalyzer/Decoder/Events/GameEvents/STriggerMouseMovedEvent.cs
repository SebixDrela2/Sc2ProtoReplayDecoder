namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents;

public class STriggerMouseMovedEvent : GameEvent
{
    public STriggerMouseMovedEvent(
        GameEvent gameEvent,
        int flags,
        long posX,
        long posY) : base(gameEvent)
    {
        Flags = flags;
        PosUIX = posX;
        PosUIY = posY;
    }
    public int Flags { get; init; }

    public long PosUIX { get; init; }

    public long PosUIY { get; init; }
}
