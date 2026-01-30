namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents;

internal class STriggerCutsceneBookmarkFiredEvent : GameEvent
{
    public STriggerCutsceneBookmarkFiredEvent(GameEvent gameEvent,
                            long cutsceneId,
                            string bookmarkName) : base(gameEvent)
    {
        CutsceneId = cutsceneId;
        BookmarkName = bookmarkName;
    }

    public long CutsceneId { get; init; }

    public string BookmarkName { get; init; }
}
