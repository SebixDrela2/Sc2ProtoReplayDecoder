using Sc2ReplayAnalyzer.Decoder.APIModel;
using Sc2ReplayAnalyzer.Decoder.Events.MessageEvents;
using Sc2ReplayAnalyzer.Json.BitPackedProtocolDefinitions;


namespace Sc2ReplayAnalyzer.Decoder.Parser;

internal static partial class Parse
{

    public static IReadOnlyList<ChatMessageEvent> ChatMessages(IEnumerable<MessageEventTriplet> chatMessages)
    {
        List<ChatMessageEvent> messages = [];

        foreach (var message in chatMessages)
        {
            var chatMessageEvent = message.EventID as GameEMessageId_e_chat;
            var chatMessage = chatMessageEvent.Value;

            var id = message.UserID;
            var loop = message.Delta;

            var recipient = chatMessage.m_recipient.GetKind();
            var msg = chatMessage.m_string.Value.ReadStringBytes();

            messages.Add(new ChatMessageEvent(recipient, (int)id, msg, loop));
        }

        return messages;
    }

    public static IReadOnlyList<PingMessageEvent> PingMessages(IEnumerable<MessageEventTriplet> pingMessages)
    {
        List<PingMessageEvent> messages = [];

        foreach (var message in pingMessages)
        {
            var pingMessageEvent = message.EventID as GameEMessageId_e_ping;
            var pingMessage = pingMessageEvent.Value;
            var point = pingMessage.m_point;

            var (x, y) = GetXYCoords(pingMessage);

            var id = message.UserID;
            var loop = message.Delta;

            var recipient = pingMessage.m_recipient.GetKind();


            messages.Add(new PingMessageEvent(recipient, (int)id, loop, x, y));
        }

        return messages;
    }

    private static (long, long) GetXYCoords(GameSPingMessage message)
    {
        if (message.m_point is { } point)
        {
            var x = point.x.Value.Value;
            var y = point.y.Value.Value;

            return (x, y);
        }

        return (0, 0);
    }
}
