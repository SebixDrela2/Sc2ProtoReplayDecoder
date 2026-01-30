namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents; 

internal class SDecrementGameTimeRemainingEvent : GameEvent
{
    public SDecrementGameTimeRemainingEvent(GameEvent gameEvent, int decerementSeconds) : base(gameEvent)
    {
        GameEvent = gameEvent;
        DecerementSeconds = decerementSeconds;
    }

    public GameEvent GameEvent { get; }
    public int DecerementSeconds { get; }
}