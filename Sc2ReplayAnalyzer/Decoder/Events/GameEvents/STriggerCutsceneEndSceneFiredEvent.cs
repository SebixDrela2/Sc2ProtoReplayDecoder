namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents;

public class STriggerCutsceneEndSceneFiredEvent : GameEvent
{
    public STriggerCutsceneEndSceneFiredEvent(GameEvent gameEvent,
                        long cutsceneId) : base(gameEvent)
    {
        CutsceneId = cutsceneId;
    }

    public long CutsceneId { get; init; }
}
