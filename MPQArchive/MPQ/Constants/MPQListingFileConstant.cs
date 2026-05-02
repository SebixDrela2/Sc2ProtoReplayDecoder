namespace MPQArchive.MPQ.Constants;

public static class MPQListingFileConstant
{
    public static readonly string[] UsedListingFiles = [
        GameMetaData,
        InitData,
        MessageEvents,
        Details,
        GameEvents,
        TrackerEvents,
        AttributeEvents
    ];

    public const string GameMetaData = "replay.gamemetadata.json";
    public const string InitData = "replay.initData";
    public const string MessageEvents = "replay.message.events";
    public const string Details = "replay.details";
    public const string GameEvents = "replay.game.events";
    public const string TrackerEvents = "replay.tracker.events";
    public const string AttributeEvents = "replay.attributes.events";
}
