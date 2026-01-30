namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents; 

internal class SGameUserLeaveEvent : GameEvent
{
    public SGameUserLeaveEvent(GameEvent gameEvent, string leaveReason) : base(gameEvent)
    {
        GameEvent = gameEvent;
        LeaveReason = leaveReason;
    }

    public GameEvent GameEvent { get; }
    public string LeaveReason { get; }
}