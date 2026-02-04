using Sc2ReplayAnalyzer.Decoder.Events.MetaData;
using Sc2ReplayAnalyzer.Json.BitPackedProtocolDefinitions;

using GameSDetails = Sc2ReplayAnalyzer.Json.VersionedProtocolDefinitions.GameSDetails;

namespace Sc2ReplayAnalyzer.Decoder.APIModel;

internal class Sc2ReplayData
{
    public string FileName { get; init; }       
    public required ReplayMetadata MetaData { get; init; }          
    public required ReplaySInitData InitData { get; init; }        
    public required IReadOnlyList<MessageEventTriplet> MessagesData { get; init; }         
    public required GameSDetails DetailsData { get; init; }         
    public required IReadOnlyList<TrackerEventPair> TrackerData { get; init; }
    public required IReadOnlyList<GameEventTriplet> GameData { get; init; }
}
