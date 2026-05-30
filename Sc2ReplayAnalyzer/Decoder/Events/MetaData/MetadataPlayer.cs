namespace Sc2ReplayAnalyzer.Decoder.Events.MetaData;

public class MetadataPlayer
{
    public int PlayerID { get; set; }
    public double APM { get; set; }
    public string Result { get; set; }
    public string SelectedRace { get; set; }
    public string AssignedRace { get; set; }
}