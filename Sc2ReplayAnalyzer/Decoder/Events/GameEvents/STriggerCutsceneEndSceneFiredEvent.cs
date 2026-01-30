namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents;

internal class STriggerCutsceneEndSceneFiredEvent : GameEvent
{
    public STriggerCutsceneEndSceneFiredEvent(GameEvent gameEvent,
                        long cutsceneId) : base(gameEvent)
    {
        CutsceneId = cutsceneId;
    }

    public long CutsceneId { get; init; }
}
