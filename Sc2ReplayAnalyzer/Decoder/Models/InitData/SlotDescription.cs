using System.Numerics;

namespace Sc2ReplayAnalyzer.Decoder.Models.InitData
{
    public class SlotDescription
    {
        public SlotDescription(string allowedRaces, string allowedColors, string allowedAIBuilds, string allowedDifficulty, string allowedObserveTypes, string allowedControls)
        {
            AllowedRaces = allowedRaces;
            AllowedColors = allowedColors;
            AllowedAIBuilds = allowedAIBuilds;
            AllowedDifficulty = allowedDifficulty;
            AllowedObserveTypes = allowedObserveTypes;
            AllowedControls = allowedControls;
        }

        public string AllowedRaces { get; }
        public string AllowedColors { get; }
        public string AllowedAIBuilds { get; }
        public string AllowedDifficulty { get; }
        public string AllowedObserveTypes { get; }
        public string AllowedControls { get; }
    }
}