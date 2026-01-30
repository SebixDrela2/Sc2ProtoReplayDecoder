namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents;

internal class SAchievementAwardedEvent : GameEvent
{
    public SAchievementAwardedEvent(GameEvent gameEvent, int achievementLink) : base(gameEvent)
    {
        AchievementLink = achievementLink;
    }

    public int AchievementLink { get; init; }    
}
