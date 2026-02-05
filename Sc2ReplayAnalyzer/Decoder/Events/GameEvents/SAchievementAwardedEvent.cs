namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents;

public class SAchievementAwardedEvent : GameEvent
{
    public SAchievementAwardedEvent(GameEvent gameEvent, int achievementLink) : base(gameEvent)
    {
        AchievementLink = achievementLink;
    }

    public int AchievementLink { get; init; }    
}
