namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents; 

public class STriggerChatMessageEvent : GameEvent
{
    public STriggerChatMessageEvent(GameEvent gameEvent, string chatMessage) : base(gameEvent)
    {
        GameEvent = gameEvent;
        ChatMessage = chatMessage;
    }

    public GameEvent GameEvent { get; }
    public string ChatMessage { get; }
}