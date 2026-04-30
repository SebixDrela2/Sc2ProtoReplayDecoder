namespace Sc2ReplayAnalyzer.Decoder.Events.TrackerEvents;

public class TrackerEvents
{
    public TrackerEvents(List<SPlayerSetupEvent> sPlayerSetupEvents, List<SPlayerStatsEvent> sPlayerStatsEvents, List<SUnitBornEvent> sUnitBornEvents, List<SUnitDiedEvent> sUnitDiedEvents, List<SUnitOwnerChangeEvent> sUnitOwnerChangeEvents, List<SUnitPositionsEvent> sUnitPositionsEvents, List<SUnitTypeChangeEvent> sUnitTypeChangeEvents, List<SUpgradeEvent> sUpgradeEvents, List<SUnitInitEvent> sUnitInitEvents, List<SUnitDoneEvent> sUnitDoneEvents)
    {
        SPlayerSetupEvents = sPlayerSetupEvents;
        SPlayerStatsEvents = sPlayerStatsEvents;
        SUnitBornEvents = sUnitBornEvents;
        SUnitDiedEvents = sUnitDiedEvents;
        SUnitOwnerChangeEvents = sUnitOwnerChangeEvents;
        SUnitPositionsEvents = sUnitPositionsEvents;
        SUnitTypeChangeEvents = sUnitTypeChangeEvents;
        SUpgradeEvents = sUpgradeEvents;
        SUnitInitEvents = sUnitInitEvents;
        SUnitDoneEvents = sUnitDoneEvents;
    }

    public List<SPlayerSetupEvent> SPlayerSetupEvents { get; }
    public List<SPlayerStatsEvent> SPlayerStatsEvents { get; }
    public List<SUnitBornEvent> SUnitBornEvents { get; }
    public List<SUnitDiedEvent> SUnitDiedEvents { get; }
    public List<SUnitOwnerChangeEvent> SUnitOwnerChangeEvents { get; }
    public List<SUnitPositionsEvent> SUnitPositionsEvents { get; }
    public List<SUnitTypeChangeEvent> SUnitTypeChangeEvents { get; }
    public List<SUpgradeEvent> SUpgradeEvents { get; }
    public List<SUnitInitEvent> SUnitInitEvents { get; }
    public List<SUnitDoneEvent> SUnitDoneEvents { get; }
}
