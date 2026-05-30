using Sc2ReplayAnalyzer.Decoder.Events.TrackerEvents;
using Sc2ReplayAnalyzer.Json.VersionedProtocolDefinitions;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Sc2ReplayAnalyzer.Decoder.Parser;

internal static partial class Parse
{
    public static TrackerEvents Tracker(IReadOnlyList<TrackerEventPair> trackerEventData)
    {
        List<TrackerEvent> trackerevents = [];
        List<SPlayerSetupEvent> sPlayerSetupEvent = [];
        List<SPlayerStatsEvent> sPlayerStatsEvent = [];
        List<SUnitBornEvent> sUnitBornEvent = [];
        List<SUnitDiedEvent> sUnitDiedEvent = [];
        List<SUnitOwnerChangeEvent> sUnitOwnerChangeEvent = [];
        List<SUnitPositionsEvent> sUnitPositionsEvent = [];
        List<SUnitTypeChangeEvent> sUnitTypeChangeEvent = [];
        List<SUpgradeEvent> sUpgradeEvent = [];
        List<SUnitInitEvent> sUnitInitEvent = [];
        List<SUnitDoneEvent> sUnitDoneEvent = [];

        foreach (var trackerData in trackerEventData)
        {
            TrackerEvent trackerEvent = GetTrackerEvent(trackerData);
            switch(trackerEvent.TrackerEventId)
            {
                case ReplayTrackerEEventId_e_playerSetup(var playerSetup):
                    sPlayerSetupEvent.Add(GetSPlayerSetupEvent(playerSetup, trackerEvent)); 
                        break;
                case ReplayTrackerEEventId_e_playerStats(var playerStats): 
                
                    sPlayerStatsEvent.Add(GetSPlayerStatsEvent(playerStats, trackerEvent)); 
                    break;
                case ReplayTrackerEEventId_e_unitBorn(var unitBorn): 
                
                    sUnitBornEvent.Add(GetSUnitBornEvent(unitBorn, trackerEvent)); 
                    break;
                case ReplayTrackerEEventId_e_unitDied(var unitDied): 
                
                    sUnitDiedEvent.Add(GetSUnitDiedEvent(unitDied, trackerEvent)); 
                    break;
                case ReplayTrackerEEventId_e_unitOwnerChange(var unitOwnerChange): 
                
                    sUnitOwnerChangeEvent.Add(GetSUnitOwnerChangeEvent(unitOwnerChange, trackerEvent)); 
                    break;
                case ReplayTrackerEEventId_e_unitPosition(var unitPosition): 
                
                    sUnitPositionsEvent.Add(GetSUnitPositionsEvent(unitPosition, trackerEvent)); 
                    break;
                case ReplayTrackerEEventId_e_unitTypeChange(var unitTypeChange): 
                
                    sUnitTypeChangeEvent.Add(GetSUnitTypeChangeEvent(unitTypeChange, trackerEvent)); 
                    break;
                case ReplayTrackerEEventId_e_upgrade(var upgrade): 
                
                    sUpgradeEvent.Add(GetSUpgradeEvent(upgrade, trackerEvent)); 
                    break;
                case ReplayTrackerEEventId_e_unitInit(var unitInit): 
                
                    sUnitInitEvent.Add(GetSUnitInitEvent(unitInit, trackerEvent)); 
                    break;
                case ReplayTrackerEEventId_e_unitDone(var unitDone): 
              
                    sUnitDoneEvent.Add(GetSUnitDoneEvent(unitDone, trackerEvent)); 
                    break;

                case var value:
                    throw new NotSupportedException($"Unknown tracker: {value.GetType().FullName}");
            };
        }

        var events = new TrackerEvents(
            sPlayerSetupEvent,
            sPlayerStatsEvent,
            sUnitBornEvent,
            sUnitDiedEvent,
            sUnitOwnerChangeEvent,
            sUnitPositionsEvent,
            sUnitTypeChangeEvent,
            sUpgradeEvent,
            sUnitInitEvent,
            sUnitDoneEvent);

        SetTrackerKillerUnitLink(events);

        return events;
    }

    private static void SetTrackerKillerUnitLink(TrackerEvents events)
    {
        var owo = Stopwatch.StartNew();

        var diedIndexMap = new SortedList<ulong, SUnitDiedEvent>();
        var initIndexMap = new SortedList<ulong, SUnitInitEvent>();
        var doneIndexMap = new SortedList<ulong, SUnitDoneEvent>();
        var bornIndexMap = new SortedList<ulong, SUnitBornEvent>();

        foreach (var element in events.SUnitDiedEvents) diedIndexMap.Add(GetUniqueIndex((element.UnitTagIndex, element.UnitTagRecycle)), element);
        foreach (var element in events.SUnitInitEvents) initIndexMap.Add(GetUniqueIndex((element.UnitTagIndex, element.UnitTagRecycle)), element);
        foreach (var element in events.SUnitDoneEvents) doneIndexMap.Add(GetUniqueIndex((element.UnitTagIndex, element.UnitTagRecycle)), element);
        foreach (var element in events.SUnitBornEvents) bornIndexMap.Add(GetUniqueIndex((element.UnitTagIndex, element.UnitTagRecycle)), element);

        foreach (var element in events.SUnitBornEvents) element.SUnitDiedEvent = diedIndexMap.GetValueOrDefault(GetUniqueIndex((element.UnitTagIndex, element.UnitTagRecycle)));
        foreach (var element in events.SUnitInitEvents) element.SUnitDiedEvent = diedIndexMap.GetValueOrDefault(GetUniqueIndex((element.UnitTagIndex, element.UnitTagRecycle)));
        foreach (var element in events.SUnitInitEvents) element.SUnitDoneEvent = doneIndexMap.GetValueOrDefault(GetUniqueIndex((element.UnitTagIndex, element.UnitTagRecycle)));

        foreach (var x in events.SUnitDiedEvents)
        {
            x.KillerUnitBornEvent = (x.KillerUnitTagIndex, x.KillerUnitTagRecycle) is ({ } a, { } b) ? bornIndexMap.GetValueOrDefault(GetUniqueIndex((a, b))) : default;
        }

        foreach (var x in events.SUnitDiedEvents)
        {
            x.KillerUnitInitEvent = (x.KillerUnitTagIndex, x.KillerUnitTagRecycle) is ({ } a, { } b) ? initIndexMap.GetValueOrDefault(GetUniqueIndex((a, b))) : default;
        }

        owo.Stop();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong GetUniqueIndex((int, int) pair) => Unsafe.BitCast<(int, int), ulong>(pair);

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
        int playerId = replayTrackerSUpgradeEvent.m_playerId;

        return new SUpgradeEvent(trackerEvent, count, playerId, upgradeTypeName);
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
                    replayTrackerSPlayerStatsEvent.m_playerId,
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
                0,
                0
            );
    }
}
