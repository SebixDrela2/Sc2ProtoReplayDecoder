using System.Runtime.InteropServices;

namespace Sc2ReplayAnalyzer.Decoder.Attributes;

[StructLayout(LayoutKind.Auto)]
public class ReplayAttributes
{
    public string PrivacyOption { get; init; }
    public string PartiesPrivate { get; init; }
    public string GameSpeed { get; init; }
    public int LobbyDelay { get; init; }
    public bool IsPremadeGame { get; init; }
    public string GameMode { get; init; }
    public int GameDuration { get; init; }
    public string Rules { get; init; }
    public bool LockedAlliances { get; init; }
    public string PartiesPremade { get; init; }

    public bool IsPublic => GameMode?.Equals("Public", StringComparison.OrdinalIgnoreCase) == true;
    public bool IsPrivate => GameMode?.Equals("Private", StringComparison.OrdinalIgnoreCase) == true;
    public bool IsCustomGame => PartiesPrivate?.Equals("Cust", StringComparison.OrdinalIgnoreCase) == true;

    public override string ToString() => $"GameMode: {GameMode}, Speed: {GameSpeed}, Privacy: {PrivacyOption}, IsPublic: {IsPublic}";
}
