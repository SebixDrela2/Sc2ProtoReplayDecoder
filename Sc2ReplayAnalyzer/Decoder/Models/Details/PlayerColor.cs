namespace Sc2ReplayAnalyzer.Decoder.Models.Details;

public class PlayerColor
{
    public PlayerColor(long a, long b, long g, long r)
    {
        A = a;
        B = b;
        G = g;
        R = r;
    }

    public PlayerColor()
    {

    }

    public long A { get; set; }
    public long B { get; set; }
    public long G { get; set; }
    public long R { get; set; }
}