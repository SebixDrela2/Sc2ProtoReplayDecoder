namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents; 

internal class SCommandManagerStateEvent : GameEvent
{
    public SCommandManagerStateEvent(GameEvent gameEvent, string state, int? sequence) : base(gameEvent)
    {
        GameEvent = gameEvent;
        State = state;
        Sequence = sequence;
    }

    public GameEvent GameEvent { get; }
    public string State { get; }
    public int? Sequence { get; }
}