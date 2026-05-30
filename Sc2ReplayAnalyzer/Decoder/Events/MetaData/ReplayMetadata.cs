namespace Sc2ReplayAnalyzer.Decoder.Events.MetaData;

public class ReplayMetadata
{
    public string BaseBuild { get; init; }
    
    public string DataBuild { get; init; }
    
    public string DataVersion { get; init; }
    
    public int Duration { get; init; }
    
    public Version GameVersion { get; init; }
    
    public bool IsNotAvailable { get; init; }
    
    public string Title { get; init; }
   
    public ICollection<MetadataPlayer> Players { get; init; }
}
