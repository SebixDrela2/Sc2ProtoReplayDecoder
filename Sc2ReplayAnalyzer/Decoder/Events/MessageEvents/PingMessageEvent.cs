namespace Sc2ReplayAnalyzer.Decoder.Events.MessageEvents;

public class PingMessageEvent
{
    public PingMessageEvent(string recipient, int id, long loop, long x, long y)
    {
        Recipient = recipient;
        Id = id;
        Loop = loop;
        X = x;
        Y = y;
    }

    public string Recipient { get; }
    public int Id { get; }
    public long Loop { get; }
    public long X { get; }
    public long Y { get; }
}