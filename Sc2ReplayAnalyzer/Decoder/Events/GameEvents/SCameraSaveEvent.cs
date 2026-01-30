namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents;

public class SCameraSaveEvent : GameEvent
{
    public SCameraSaveEvent(GameEvent gameEvent,
                            int which,
                            long targetX,
                            long targetY) : base(gameEvent)
    {
        Which = which;
        TargetX = targetX;
        TargetY = targetY;
    }

    public int Which { get; init; }

    public long TargetX { get; init; }

    public long TargetY { get; init; }
}
