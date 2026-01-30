namespace Sc2ReplayAnalyzer.Decoder.Models.Details;

public class Toon
{
    public Toon(int id, string programId, int realm, byte region)
    {
        Id = id;
        ProgramId = programId;
        Realm = realm;
        Region = region;
    }

    public int Id { get; }
    public string ProgramId { get; }
    public int Realm { get; }
    public byte Region { get; }
}