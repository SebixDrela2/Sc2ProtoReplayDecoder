using Sc2ReplayAnalyzer.Decoder.Attributes;
using Sc2ReplayAnalyzer.Decoder.Events.GameEvents;
using Sc2ReplayAnalyzer.Decoder.Events.Header;
using Sc2ReplayAnalyzer.Decoder.Events.InitEvents;
using Sc2ReplayAnalyzer.Decoder.Events.MessageEvents;
using Sc2ReplayAnalyzer.Decoder.Events.MetaData;
using Sc2ReplayAnalyzer.Decoder.Events.TrackerEvents;
using Sc2ReplayAnalyzer.Decoder.Models.Details;
using Sc2ReplayAnalyzer.Decoder.Parser;
using Sc2ReplayAnalyzer.Json.BitPackedProtocolDefinitions;


namespace Sc2ReplayAnalyzer.Decoder.APIModel;

public class Sc2Replay
{
    public required string FileName { get; set; }

    public required Header Header { get; init; }
    public required InitData InitData { get; init; }
    public required Details Details { get; init; }
    public required GameEvents GameEvents { get; init; }
    public required TrackerEvents TrackerEvents { get; init; }
    public required ReplayMetadata MetaData { get; init; }

    public required ReplayAttributes Attributes { get; init; }
    public required IReadOnlyList<ChatMessageEvent> ChatMessages { get; init; }
    public required IReadOnlyList<PingMessageEvent> PingMessages { get; init; }

    internal static Sc2Replay FromData(Sc2ReplayData replayData)
    {
        var chatMessages = replayData.MessagesData.Where(message => message.EventID is GameEMessageId_e_chat);
        var pingMessages = replayData.MessagesData.Where(message => message.EventID is GameEMessageId_e_ping);

        return new Sc2Replay
        {
            FileName = replayData.FileName,
            MetaData = replayData.MetaData,
            Attributes = replayData.Attributes,
            Header = Parse.Header(replayData.Header),
            InitData = Parse.InitData(replayData.InitData),
            ChatMessages = Parse.ChatMessages(chatMessages),
            PingMessages = Parse.PingMessages(pingMessages),
            Details = Parse.Details(replayData.DetailsData),
            TrackerEvents = Parse.Tracker(replayData.TrackerData),
            GameEvents = Parse.GameEvents(replayData.GameData),
        };
    }
}
