namespace Sc2ReplayAnalyzer.Decoder.Models.Details;

public class DetailsPlayer
{
    public DetailsPlayer(PlayerColor color, byte control, uint handicap, string hero, string name, string observe, string race, string result, int team, Toon toon, byte slot)
    {
        Color = color;
        Control = control;
        Handicap = handicap;
        Hero = hero;
        Name = name;
        Observe = observe;
        Race = race;
        Result = result;
        Team = team;
        Toon = toon;
        Slot = slot;

        if (name != null && name.Contains("<sp/>", StringComparison.Ordinal))
        {
            var ents = name.Split("<sp/>");
            Name = ents[1];
            ClanName = ents[0].Length > 8 ? ents[0][4..^4] : null;
        }
        else
        {
            Name = name ?? "";
        }
    }

    public PlayerColor Color { get; }
    public long Control { get; }
    public long Handicap { get; }
    public string Hero { get; }
    public string Name { get; }
    public string Observe { get; }
    public string Race { get; }
    public string Result { get; }
    public long Team { get; }
    public Toon Toon { get; }
    public long Slot { get; }
    public string ClanName { get; init; }
}