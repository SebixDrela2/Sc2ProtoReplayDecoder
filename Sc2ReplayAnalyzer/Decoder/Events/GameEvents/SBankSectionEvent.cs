namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents; 

internal class SBankSectionEvent : GameEvent
{
    public SBankSectionEvent(GameEvent gameEvent, string name) : base(gameEvent)
    {
        GameEvent = gameEvent;
        Name = name;
    }

    public GameEvent GameEvent { get; }
    public string Name { get; }
}