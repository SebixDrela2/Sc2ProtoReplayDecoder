namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents; 

public class UnknownGameEvent : GameEvent
{
    public UnknownGameEvent(GameEvent gameEvent, string eventObj) : base(gameEvent)
    {
        GameEvent = gameEvent;
        Event = eventObj;
    }

    public GameEvent GameEvent { get; }
    public string Event { get; }
}