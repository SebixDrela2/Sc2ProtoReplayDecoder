namespace Sc2ReplayAnalyzer.Decoder.Events.GameEvents;

public class STriggerTargetModeUpdateEvent : GameEvent
{
    public STriggerTargetModeUpdateEvent(GameEvent gameEvent,
                            int abilCmdIndex,
                            int abilLink,
                            int state) : base(gameEvent)
    {
        AbilCmdIndex = abilCmdIndex;
        AbilLink = abilLink;
        State = state;
    }

    public int AbilCmdIndex { get; init; }

    public int AbilLink { get; init; }

    public int State { get; init; }
}
