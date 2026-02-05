namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents; 

public class SControlGroupUpdateEvent : GameEvent
{
    public SControlGroupUpdateEvent(GameEvent gameEvent, string controlGroupUpdate) : base(gameEvent)
    {
        GameEvent = gameEvent;
        ControlGroupUpdate = controlGroupUpdate;
    }

    public GameEvent GameEvent { get; }
    public string ControlGroupUpdate { get; }
}