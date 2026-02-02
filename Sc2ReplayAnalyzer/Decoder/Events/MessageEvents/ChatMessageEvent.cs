namespace Sc2ReplayAnalyzer.Decoder.Events.MessageEvents;

public class ChatMessageEvent
{
    public ChatMessageEvent(string recipient, int id, string msg, long loop)
    {
        Recipient = recipient;
        Id = id;
        Msg = msg;
        Loop = loop;
    }

    public string Recipient { get; }
    public int Id { get; }
    public string Msg { get; }
    public long Loop { get; }
}