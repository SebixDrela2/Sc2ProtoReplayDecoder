using Sc2ReplayAnalyzer.Decoder.Events.TrackerEvents;
using Sc2ReplayAnalyzer.Json.VersionedProtocolDefinitions;

namespace Sc2ReplayAnalyzer.Decoder.Parser;

internal static partial class Parse
{
    public static TrackerEvents Tracker(IReadOnlyList<TrackerEventPair> trackerEventData)
    {
        List<TrackerEvent> trackerevents = new();

        foreach (var trackerData in trackerEventData)
        {
            TrackerEvent trackerEvent = GetTrackerEvent(trackerData);

            TrackerEvent detailEvent = trackerEvent.TrackerEventId switch
            {
                ReplayTrackerEEventId_e_playerSetup(var value) => GetSPlayerSetupEvent(value, trackerEvent),
                ReplayTrackerEEventId_e_playerStats(var value) => GetSPlayerStatsEvent(value, trackerEvent),
                ReplayTrackerEEventId_e_unitBorn(var value) => GetSUnitBornEvent(value, trackerEvent),
                ReplayTrackerEEventId_e_unitDied(var value) => GetSUnitDiedEvent(value, trackerEvent),
                ReplayTrackerEEventId_e_unitOwnerChange(var value) => GetSUnitOwnerChangeEvent(value, trackerEvent),
                ReplayTrackerEEventId_e_unitPosition(var value) => GetSUnitPositionsEvent(value, trackerEvent),
                ReplayTrackerEEventId_e_unitTypeChange(var value) => GetSUnitTypeChangeEvent(value, trackerEvent),
                ReplayTrackerEEventId_e_upgrade(var value) => GetSUpgradeEvent(value, trackerEvent),
                ReplayTrackerEEventId_e_unitInit(var value) => GetSUnitInitEvent(value, trackerEvent),
                ReplayTrackerEEventId_e_unitDone(var value) => GetSUnitDoneEvent(value, trackerEvent),
                var value => throw new NotSupportedException($"Unknown tracker: {value.GetType().FullName}")
            };
            trackerevents.Add(detailEvent);
        }

        var events = new TrackerEvents(
            trackerevents.OfType<SPlayerSetupEvent>().ToArray(),
            trackerevents.OfType<SPlayerStatsEvent>().ToArray(),
            trackerevents.OfType<SUnitBornEvent>().ToArray(),
            trackerevents.OfType<SUnitDiedEvent>().ToArray(),
            trackerevents.OfType<SUnitOwnerChangeEvent>().ToArray(),
            trackerevents.OfType<SUnitPositionsEvent>().ToArray(),
            trackerevents.OfType<SUnitTypeChangeEvent>().ToArray(),
            trackerevents.OfType<SUpgradeEvent>().ToArray(),
            trackerevents.OfType<SUnitInitEvent>().ToArray(),
            trackerevents.OfType<SUnitDoneEvent>().ToArray()
        );

        return events;
    }

    private static TrackerEvent GetTrackerEvent(TrackerEventPair eventPair)
    {
        var eventValue = eventPair.TrackerEventID;
        var type = eventValue.GetType().Name;

        return new TrackerEvent(eventPair.TrackerEventID, type, eventPair.Delta);
    }

    private static SUnitDoneEvent GetSUnitDoneEvent(ReplayTrackerSUnitDoneEvent replayTrackerSUnitDoneEvent, TrackerEvent trackerEvent)
    {
        int unitTagIndex = (int)replayTrackerSUnitDoneEvent.m_unitTagIndex;
        int unitTagRecycle = (int)replayTrackerSUnitDoneEvent.m_unitTagRecycle;

        return new SUnitDoneEvent(trackerEvent, unitTagIndex, unitTagRecycle);
    }

    private static SUnitInitEvent GetSUnitInitEvent(ReplayTrackerSUnitInitEvent replayTrackerSUnitInitEvent, TrackerEvent trackerEvent)
    {
        int unitTagIndex = (int)replayTrackerSUnitInitEvent.m_unitTagIndex;
        int unitTagRecycle = (int)replayTrackerSUnitInitEvent.m_unitTagRecycle;
        string unitTypeName = replayTrackerSUnitInitEvent.m_unitTypeName.ReadStringBytes();
        int controlPlayerId = replayTrackerSUnitInitEvent.m_controlPlayerId;
        int x = replayTrackerSUnitInitEvent.m_x;
        int y = replayTrackerSUnitInitEvent.m_y;
        int upkeepPlayerId = replayTrackerSUnitInitEvent.m_upkeepPlayerId;

        return new SUnitInitEvent(trackerEvent, unitTagIndex, unitTagRecycle, controlPlayerId, x, y, upkeepPlayerId, unitTypeName);
    }

    private static SUpgradeEvent GetSUpgradeEvent(ReplayTrackerSUpgradeEvent replayTrackerSUpgradeEvent, TrackerEvent trackerEvent)
    {
        int count = replayTrackerSUpgradeEvent.m_count;
        string upgradeTypeName = replayTrackerSUpgradeEvent.m_upgradeTypeName.ReadStringBytes();
        return new SUpgradeEvent(trackerEvent, count, upgradeTypeName);
    }

    private static SUnitTypeChangeEvent GetSUnitTypeChangeEvent(ReplayTrackerSUnitTypeChangeEvent replayTrackerSUnitTypeChangeEvent, TrackerEvent trackerEvent)
    {
        int unitTagIndex = (int)replayTrackerSUnitTypeChangeEvent.m_unitTagIndex;
        int unitTagRecycle = (int)replayTrackerSUnitTypeChangeEvent.m_unitTagRecycle;
        string unitTypeName = replayTrackerSUnitTypeChangeEvent.m_unitTypeName.ReadStringBytes();

        return new SUnitTypeChangeEvent(trackerEvent, unitTagIndex, unitTagRecycle, unitTypeName);
    }

    private static SUnitPositionsEvent GetSUnitPositionsEvent(ReplayTrackerSUnitPositionsEvent replayTrackerSUnitPositionsEvent, TrackerEvent trackerEvent)
    {
        int firstUnitIndex = (int)replayTrackerSUnitPositionsEvent.m_firstUnitIndex;

        List<int> items = new List<int>();

        if (replayTrackerSUnitPositionsEvent.m_items is { } itemsObj)
        {
            items.AddRange(itemsObj);
        }

        return new SUnitPositionsEvent(trackerEvent, firstUnitIndex, [.. items]);
    }

    private static SUnitOwnerChangeEvent GetSUnitOwnerChangeEvent(ReplayTrackerSUnitOwnerChangeEvent replayTrackerSUnitOwnerChangeEvent, TrackerEvent trackerEvent)
    {
        int unitTagIndex = (int)replayTrackerSUnitOwnerChangeEvent.m_unitTagIndex;
        int unitTagRecycle = (int)replayTrackerSUnitOwnerChangeEvent.m_unitTagRecycle;
        int controlPlayerId = replayTrackerSUnitOwnerChangeEvent.m_controlPlayerId;
        int upkeepPlayerId = replayTrackerSUnitOwnerChangeEvent.m_upkeepPlayerId;

        return new SUnitOwnerChangeEvent(trackerEvent, unitTagIndex, unitTagRecycle, controlPlayerId, upkeepPlayerId);
    }

    private static SUnitDiedEvent GetSUnitDiedEvent(ReplayTrackerSUnitDiedEvent replayTrackerSUnitDiedEvent, TrackerEvent trackerEvent)
    {
        int unitTagIndex = (int)replayTrackerSUnitDiedEvent.m_unitTagIndex;
        int unitTagRecycle = (int)replayTrackerSUnitDiedEvent.m_unitTagRecycle;
        int? killerPlayerId = replayTrackerSUnitDiedEvent.m_killerPlayerId.DefaultIfNone();

        int x = replayTrackerSUnitDiedEvent.m_x;
        int y = replayTrackerSUnitDiedEvent.m_y;
        int? killerUnitTagRecycle = (int?)replayTrackerSUnitDiedEvent.m_killerUnitTagRecycle.DefaultIfNone();
        int? killerUnitTagIndex = (int?)replayTrackerSUnitDiedEvent.m_killerUnitTagIndex.DefaultIfNone();

        return new SUnitDiedEvent(trackerEvent, unitTagIndex, unitTagRecycle, killerPlayerId, x, y, killerUnitTagRecycle, killerUnitTagIndex);
    }

    private static SUnitBornEvent GetSUnitBornEvent(ReplayTrackerSUnitBornEvent replayTrackerSUnitBornEvent, TrackerEvent trackerEvent)
    {
        int unitTagIndex = (int)replayTrackerSUnitBornEvent.m_unitTagIndex;
        int unitTagRecycle = (int)replayTrackerSUnitBornEvent.m_unitTagRecycle;
        string? creatorAbilityName = replayTrackerSUnitBornEvent.m_creatorAbilityName.DefaultIfNone()?.ReadStringBytes();
        int? creatorUnitTagRecycle = (int?)replayTrackerSUnitBornEvent.m_creatorUnitTagRecycle.DefaultIfNone();
        int controlPlayerId = replayTrackerSUnitBornEvent.m_controlPlayerId;
        int x = replayTrackerSUnitBornEvent.m_x;
        int y = replayTrackerSUnitBornEvent.m_y;
        int upkeepPlayerId = replayTrackerSUnitBornEvent.m_upkeepPlayerId;
        string unitTypeName = replayTrackerSUnitBornEvent.m_unitTypeName.ReadStringBytes();
        int? creatorUnitTagIndex = (int?)replayTrackerSUnitBornEvent.m_creatorUnitTagIndex.DefaultIfNone();
        return new SUnitBornEvent(trackerEvent, unitTagIndex, unitTagRecycle, creatorAbilityName, creatorUnitTagRecycle, controlPlayerId, x, y, upkeepPlayerId, unitTypeName, creatorUnitTagIndex);
    }

    private static SPlayerSetupEvent GetSPlayerSetupEvent(ReplayTrackerSPlayerSetupEvent replayTrackerSPlayerSetupEvent, TrackerEvent trackerEvent)
    {
        int type = (int)replayTrackerSPlayerSetupEvent.m_type;
        int? userId = (int?)replayTrackerSPlayerSetupEvent.m_userId.DefaultIfNone();
        int slotId = (int)replayTrackerSPlayerSetupEvent.m_slotId.DefaultIfNone();

        return new SPlayerSetupEvent(trackerEvent, type, userId, slotId);
    }
    
    private static SPlayerStatsEvent GetSPlayerStatsEvent(ReplayTrackerSPlayerStatsEvent replayTrackerSPlayerStatsEvent, TrackerEvent trackerEvent)
    {
        if (replayTrackerSPlayerStatsEvent.m_stats is { } stats)
        {
            int scoreValueVespeneUsedCurrentTechnology = stats.m_scoreValueVespeneUsedCurrentTechnology;
            int scoreValueVespeneFriendlyFireArmy = stats.m_scoreValueVespeneFriendlyFireArmy;
            int scoreValueMineralsFriendlyFireTechnology = stats.m_scoreValueMineralsFriendlyFireTechnology;
            int scoreValueMineralsUsedCurrentEconomy = stats.m_scoreValueMineralsUsedCurrentEconomy;
            int scoreValueVespeneLostEconomy = stats.m_scoreValueVespeneLostEconomy;
            int scoreValueMineralsUsedCurrentArmy = stats.m_scoreValueMineralsUsedCurrentArmy;
            int scoreValueVespeneUsedInProgressArmy = stats.m_scoreValueVespeneUsedInProgressArmy;
            int scoreValueVespeneCollectionRate = stats.m_scoreValueVespeneCollectionRate;
            int scoreValueMineralsUsedInProgressTechnology = stats.m_scoreValueMineralsUsedInProgressTechnology;
            int scoreValueMineralsCollectionRate = stats.m_scoreValueMineralsCollectionRate;
            int scoreValueWorkersActiveCount = stats.m_scoreValueWorkersActiveCount;
            int scoreValueMineralsUsedInProgressArmy = stats.m_scoreValueMineralsUsedInProgressArmy;
            int scoreValueVespeneLostArmy = stats.m_scoreValueVespeneLostArmy;
            int scoreValueMineralsKilledEconomy = stats.m_scoreValueMineralsKilledEconomy;
            int scoreValueMineralsUsedCurrentTechnology = stats.m_scoreValueMineralsUsedCurrentTechnology;
            int scoreValueMineralsKilledArmy = stats.m_scoreValueMineralsKilledArmy;
            int scoreValueMineralsLostEconomy = stats.m_scoreValueMineralsLostEconomy;
            int scoreValueMineralsCurrent = stats.m_scoreValueMineralsCurrent;
            int scoreValueMineralsLostArmy = stats.m_scoreValueMineralsLostArmy;
            int scoreValueVespeneKilledArmy = stats.m_scoreValueVespeneKilledArmy;
            int scoreValueVespeneKilledTechnology = stats.m_scoreValueVespeneKilledTechnology;
            int scoreValueVespeneKilledEconomy = stats.m_scoreValueVespeneKilledEconomy;
            int scoreValueMineralsUsedActiveForces = stats.m_scoreValueMineralsUsedActiveForces;
            int scoreValueVespeneUsedCurrentArmy = stats.m_scoreValueVespeneUsedCurrentArmy;
            int scoreValueMineralsFriendlyFireArmy = stats.m_scoreValueMineralsFriendlyFireArmy;
            int scoreValueVespeneUsedActiveForces = stats.m_scoreValueVespeneUsedActiveForces;
            int scoreValueVespeneCurrent = stats.m_scoreValueVespeneCurrent;
            int scoreValueMineralsLostTechnology = stats.m_scoreValueMineralsLostTechnology;
            int scoreValueMineralsUsedInProgressEconomy = stats.m_scoreValueMineralsUsedInProgressEconomy;
            int scoreValueMineralsFriendlyFireEconomy = stats.m_scoreValueMineralsFriendlyFireEconomy;
            int scoreValueVespeneUsedInProgressTechnology = stats.m_scoreValueVespeneUsedInProgressTechnology;
            int scoreValueFoodMade = stats.m_scoreValueFoodMade;
            int scoreValueMineralsKilledTechnology = stats.m_scoreValueMineralsKilledTechnology;
            int scoreValueVespeneLostTechnology = stats.m_scoreValueVespeneLostTechnology;
            int scoreValueVespeneFriendlyFireEconomy = stats.m_scoreValueVespeneFriendlyFireEconomy;
            int scoreValueVespeneUsedInProgressEconomy = stats.m_scoreValueVespeneUsedInProgressEconomy;
            int scoreValueVespeneUsedCurrentEconomy = stats.m_scoreValueVespeneUsedCurrentEconomy;
            int scoreValueVespeneFriendlyFireTechnology = stats.m_scoreValueVespeneFriendlyFireTechnology;
            int scoreValueFoodUsed = stats.m_scoreValueFoodUsed;

            return new SPlayerStatsEvent
                (
                    trackerEvent,
                    scoreValueVespeneUsedCurrentTechnology,
                    scoreValueVespeneFriendlyFireArmy,
                    scoreValueMineralsFriendlyFireTechnology,
                    scoreValueMineralsUsedCurrentEconomy,
                    scoreValueVespeneLostEconomy,
                    scoreValueMineralsUsedCurrentArmy,
                    scoreValueVespeneUsedInProgressArmy,
                    scoreValueVespeneCollectionRate,
                    scoreValueMineralsUsedInProgressTechnology,
                    scoreValueMineralsCollectionRate,
                    scoreValueWorkersActiveCount,
                    scoreValueMineralsUsedInProgressArmy,
                    scoreValueVespeneLostArmy,
                    scoreValueMineralsKilledEconomy,
                    scoreValueMineralsUsedCurrentTechnology,
                    scoreValueMineralsKilledArmy,
                    scoreValueMineralsLostEconomy,
                    scoreValueMineralsCurrent,
                    scoreValueMineralsLostArmy,
                    scoreValueVespeneKilledArmy,
                    scoreValueVespeneKilledTechnology,
                    scoreValueVespeneKilledEconomy,
                    scoreValueMineralsUsedActiveForces,
                    scoreValueVespeneUsedCurrentArmy,
                    scoreValueMineralsFriendlyFireArmy,
                    scoreValueVespeneUsedActiveForces,
                    scoreValueVespeneCurrent,
                    scoreValueMineralsLostTechnology,
                    scoreValueMineralsUsedInProgressEconomy,
                    scoreValueMineralsFriendlyFireEconomy,
                    scoreValueVespeneUsedInProgressTechnology,
                    scoreValueFoodMade,
                    scoreValueMineralsKilledTechnology,
                    scoreValueVespeneLostTechnology,
                    scoreValueVespeneFriendlyFireEconomy,
                    scoreValueVespeneUsedInProgressEconomy,
                    scoreValueVespeneUsedCurrentEconomy,
                    scoreValueVespeneFriendlyFireTechnology,
                    scoreValueFoodUsed
                );
        }

        return new SPlayerStatsEvent
            (
                trackerEvent,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0
            );
    }
}
