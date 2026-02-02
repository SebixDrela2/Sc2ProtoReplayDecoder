using Sc2ReplayAnalyzer.Json.BitPackedProtocolDefinitions;


namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents;

public class GameEvent
{
    public GameEvent(int userId, GameEEventId eventId, string eventType, long gameloop)
    {
        UserId = userId;
        EventId = eventId;
        Type = eventType;
        Gameloop = gameloop;       
    }

    public GameEvent(GameEvent gameEvent)
    {
        ArgumentNullException.ThrowIfNull(gameEvent);
        UserId = gameEvent.UserId;
        EventId = gameEvent.EventId;
        Gameloop = gameEvent.Gameloop;
    }

    public int UserId { get; }
    public GameEEventId EventId { get; }
    public string Type { get; }
    public long Gameloop { get; }
}