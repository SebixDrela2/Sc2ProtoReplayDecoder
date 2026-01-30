namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents 
{
    public class GameEvents
    {
        public GameEvents(List<GameEvent> gameevents)
        {
            Gameevents = gameevents;
        }

        public List<GameEvent> Gameevents { get; }
    }
}