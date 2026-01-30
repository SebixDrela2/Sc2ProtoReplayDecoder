using MPQArchive.MPQ.ReceivedData;
using Sc2ReplayAnalyzer.Decoder.Events.MetaData;
using Sc2ReplayAnalyzer.Decoder.Parser;
using Sc2ReplayAnalyzer.Json.protocol90870.BitPacked;
using Sc2ReplayAnalyzer.Json.protocol90870.Versioned;

namespace Sc2ReplayAnalyzer.Decoder.APIModel;

internal class Sc2ReplayData
{
    public required ReplaySHeader HeaderData { get; init; }         
    public required ReplayMetadata MetaData { get; init; }          
    public required ReplaySInitData InitData { get; init; }        
    public required IReadOnlyList<MessageEventTriplet> MessagesData { get; init; }         
    public required GameSDetails DetailsData { get; init; }         
    public required IReadOnlyList<TrackerEventPair> TrackerData { get; init; }
    public required IReadOnlyList<GameEventTriplet> GameData { get; init; }

    public static Sc2Replay FromData(Sc2ReplayData replayData)
    {
        return new Sc2Replay
        {         
            MetaData = Parse.Details(replayData.DetailsData),
            InitData = Parse.in(),
            ChatMessages = ParseMessageEvents(),
            Details = ParseReplayDetails(),
            TrackerEvents = ParseTrackerEvents(),
            GameEvents = ParseGameEvents(),
        };
    }
}
