namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents; 

public class SBankFileEvent : GameEvent
{
    public SBankFileEvent(GameEvent gameEvent, string name) : base(gameEvent)
    {
        GameEvent = gameEvent;
        Name = name;
    }

    public GameEvent GameEvent { get; }
    public string Name { get; }
}