using Sc2ReplayAnalyzer.Decoder.Events.GameEvents;
using Sc2ReplayAnalyzer.Decoder.Events.InitEvents;
using Sc2ReplayAnalyzer.Decoder.Events.MessageEvents;
using Sc2ReplayAnalyzer.Decoder.Events.MetaData;
using Sc2ReplayAnalyzer.Decoder.Events.TrackerEvents;
using Sc2ReplayAnalyzer.Decoder.Models.Details;

namespace Sc2ReplayAnalyzer.Decoder.APIModel;

public class Sc2Replay(string replayPath)
{
    public string FileName = replayPath;

    public required InitData InitData { get; init; }
    public required Details Details { get; init; }
    public required GameEvents GameEvents { get; init; }
    public required TrackerEvents TrackerEvents { get; init; }
    public required ReplayMetadata MetaData { get; init; }
    public required List<ChatMessageEvent> ChatMessages { get; init; }
    public required List<PingMessageEvent> PingMessages { get; init; }
}
