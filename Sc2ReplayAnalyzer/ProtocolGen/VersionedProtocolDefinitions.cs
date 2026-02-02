
using Sc2ReplayAnalyzer.Global;

namespace Sc2ReplayAnalyzer.Json.VersionedProtocolDefinitions;

// NNet.SVarUint32
public abstract class SVarUint32 { }

// m_uint6
public  class m_uint6 : SVarUint32
{
    public u8 Value;
}

// m_uint14
public  class m_uint14 : SVarUint32
{
    public u32 Value;
}

// m_uint22
public  class m_uint22 : SVarUint32
{
    public u32 Value;
}

// m_uint32
public  class m_uint32 : SVarUint32
{
    public u32 Value;
}

// NNet.SVersion
public  class SVersion
{
    public u8 m_flags;
    public u8 m_major;
    public u8 m_minor;
    public u8 m_revision;
    public u32 m_build;
    public u32 m_baseBuild;
}

// NNet.SMD5
public  class SMD5
{
    public Option<List<u8>> m_dataDeprecated;
    public List<byte> m_data;
}

// NNet.Game.SThumbnail
public  class GameSThumbnail
{
    public List<byte> m_file;
}

// NNet.Game.SColor
public  class GameSColor
{
    public u8 m_a;
    public u8 m_r;
    public u8 m_g;
    public u8 m_b;
}

// NNet.Game.SToonNameDetails
public  class GameSToonNameDetails
{
    public u8 m_region;
    public uint m_programId;
    public u32 m_realm;
    public List<byte> m_name;
    public u64 m_id;
}

// NNet.Game.SPlayerDetails
public  class GameSPlayerDetails
{
    public List<byte> m_name;
    public GameSToonNameDetails m_toon;
    public List<byte> m_race;
    public GameSColor m_color;
    public u8 m_control;
    public u8 m_teamId;
    public u32 m_handicap;
    public EObserve m_observe;
    public GameEResultDetails m_result;
    public Option<u8> m_workingSetSlotId;
    public List<byte> m_hero;
}

// NNet.Game.SDetails
public  class GameSDetails
{
    public Option<List<GameSPlayerDetails>> m_playerList;
    public List<byte> m_title;
    public List<byte> m_difficulty;
    public GameSThumbnail m_thumbnail;
    public bool m_isBlizzardMap;
    public i64 m_timeUTC;
    public i64 m_timeLocalOffset;
    public Option<bool> m_restartAsTransitionMap;
    public bool m_disableRecoverGame;
    public List<byte> m_description;
    public List<byte> m_imageFilePath;
    public u8 m_campaignIndex;
    public List<byte> m_mapFileName;
    public Option<List<List<byte>>> m_cacheHandles;
    public bool m_miniSave;
    public GameEGameSpeed m_gameSpeed;
    public u32 m_defaultDifficulty;
    public Option<List<List<byte>>> m_modPaths;
}

// NNet.Replay.SHeader
public  class ReplaySHeader
{
    public List<byte> m_signature;
    public SVersion m_version;
    public u8 m_type;
    public u32 m_elapsedGameLoops;
    public bool m_useScaledTime;
    public SMD5 m_ngdpRootKey;
    public u32 m_dataBuildNum;
    public SMD5 m_replayCompatibilityHash;
    public bool m_ngdpRootKeyIsDevData;
}

// NNet.Replay.Tracker.SPlayerStats
public  class ReplayTrackerSPlayerStats
{
    public i32 m_scoreValueMineralsCurrent;
    public i32 m_scoreValueVespeneCurrent;
    public i32 m_scoreValueMineralsCollectionRate;
    public i32 m_scoreValueVespeneCollectionRate;
    public i32 m_scoreValueWorkersActiveCount;
    public i32 m_scoreValueMineralsUsedInProgressArmy;
    public i32 m_scoreValueMineralsUsedInProgressEconomy;
    public i32 m_scoreValueMineralsUsedInProgressTechnology;
    public i32 m_scoreValueVespeneUsedInProgressArmy;
    public i32 m_scoreValueVespeneUsedInProgressEconomy;
    public i32 m_scoreValueVespeneUsedInProgressTechnology;
    public i32 m_scoreValueMineralsUsedCurrentArmy;
    public i32 m_scoreValueMineralsUsedCurrentEconomy;
    public i32 m_scoreValueMineralsUsedCurrentTechnology;
    public i32 m_scoreValueVespeneUsedCurrentArmy;
    public i32 m_scoreValueVespeneUsedCurrentEconomy;
    public i32 m_scoreValueVespeneUsedCurrentTechnology;
    public i32 m_scoreValueMineralsLostArmy;
    public i32 m_scoreValueMineralsLostEconomy;
    public i32 m_scoreValueMineralsLostTechnology;
    public i32 m_scoreValueVespeneLostArmy;
    public i32 m_scoreValueVespeneLostEconomy;
    public i32 m_scoreValueVespeneLostTechnology;
    public i32 m_scoreValueMineralsKilledArmy;
    public i32 m_scoreValueMineralsKilledEconomy;
    public i32 m_scoreValueMineralsKilledTechnology;
    public i32 m_scoreValueVespeneKilledArmy;
    public i32 m_scoreValueVespeneKilledEconomy;
    public i32 m_scoreValueVespeneKilledTechnology;
    public i32 m_scoreValueFoodUsed;
    public i32 m_scoreValueFoodMade;
    public i32 m_scoreValueMineralsUsedActiveForces;
    public i32 m_scoreValueVespeneUsedActiveForces;
    public i32 m_scoreValueMineralsFriendlyFireArmy;
    public i32 m_scoreValueMineralsFriendlyFireEconomy;
    public i32 m_scoreValueMineralsFriendlyFireTechnology;
    public i32 m_scoreValueVespeneFriendlyFireArmy;
    public i32 m_scoreValueVespeneFriendlyFireEconomy;
    public i32 m_scoreValueVespeneFriendlyFireTechnology;
}

// NNet.Replay.Tracker.SPlayerStatsEvent
public  class ReplayTrackerSPlayerStatsEvent
{
    public u8 m_playerId;
    public ReplayTrackerSPlayerStats m_stats;
}

// NNet.Replay.Tracker.SUnitBornEvent
public  class ReplayTrackerSUnitBornEvent
{
    public u32 m_unitTagIndex;
    public u32 m_unitTagRecycle;
    public List<byte> m_unitTypeName;
    public u8 m_controlPlayerId;
    public u8 m_upkeepPlayerId;
    public u8 m_x;
    public u8 m_y;
    public Option<u32> m_creatorUnitTagIndex;
    public Option<u32> m_creatorUnitTagRecycle;
    public Option<List<byte>> m_creatorAbilityName;
}

// NNet.Replay.Tracker.SUnitDiedEvent
public  class ReplayTrackerSUnitDiedEvent
{
    public u32 m_unitTagIndex;
    public u32 m_unitTagRecycle;
    public Option<u8> m_killerPlayerId;
    public u8 m_x;
    public u8 m_y;
    public Option<u32> m_killerUnitTagIndex;
    public Option<u32> m_killerUnitTagRecycle;
}

// NNet.Replay.Tracker.SUnitOwnerChangeEvent
public  class ReplayTrackerSUnitOwnerChangeEvent
{
    public u32 m_unitTagIndex;
    public u32 m_unitTagRecycle;
    public u8 m_controlPlayerId;
    public u8 m_upkeepPlayerId;
}

// NNet.Replay.Tracker.SUnitTypeChangeEvent
public  class ReplayTrackerSUnitTypeChangeEvent
{
    public u32 m_unitTagIndex;
    public u32 m_unitTagRecycle;
    public List<byte> m_unitTypeName;
}

// NNet.Replay.Tracker.SUpgradeEvent
public  class ReplayTrackerSUpgradeEvent
{
    public u8 m_playerId;
    public List<byte> m_upgradeTypeName;
    public i32 m_count;
}

// NNet.Replay.Tracker.SUnitInitEvent
public  class ReplayTrackerSUnitInitEvent
{
    public u32 m_unitTagIndex;
    public u32 m_unitTagRecycle;
    public List<byte> m_unitTypeName;
    public u8 m_controlPlayerId;
    public u8 m_upkeepPlayerId;
    public u8 m_x;
    public u8 m_y;
}

// NNet.Replay.Tracker.SUnitDoneEvent
public  class ReplayTrackerSUnitDoneEvent
{
    public u32 m_unitTagIndex;
    public u32 m_unitTagRecycle;
}

// NNet.Replay.Tracker.SUnitPositionsEvent
public  class ReplayTrackerSUnitPositionsEvent
{
    public u32 m_firstUnitIndex;
    public List<i32> m_items;
}

// NNet.Replay.Tracker.SPlayerSetupEvent
public  class ReplayTrackerSPlayerSetupEvent
{
    public u8 m_playerId;
    public u32 m_type;
    public Option<u32> m_userId;
    public Option<u32> m_slotId;
}

// NNet.EObserve
public abstract record class EObserve { }
// e_none
public record class EObserve_e_none() : EObserve;
// e_spectator
public record class EObserve_e_spectator() : EObserve;
// e_referee
public record class EObserve_e_referee() : EObserve;

// NNet.Game.EGameSpeed
public abstract record class GameEGameSpeed { }
// e_slower
public record class GameEGameSpeed_e_slower() : GameEGameSpeed;
// e_slow
public record class GameEGameSpeed_e_slow() : GameEGameSpeed;
// e_normal
public record class GameEGameSpeed_e_normal() : GameEGameSpeed;
// e_fast
public record class GameEGameSpeed_e_fast() : GameEGameSpeed;
// e_faster
public record class GameEGameSpeed_e_faster() : GameEGameSpeed;

// NNet.Game.EResultDetails
public abstract record class GameEResultDetails { }
// e_undecided
public record class GameEResultDetails_e_undecided() : GameEResultDetails;
// e_win
public record class GameEResultDetails_e_win() : GameEResultDetails;
// e_loss
public record class GameEResultDetails_e_loss() : GameEResultDetails;
// e_tie
public record class GameEResultDetails_e_tie() : GameEResultDetails;

// NNet.Replay.Tracker.EEventId
public abstract record class ReplayTrackerEEventId { }
// e_playerStats
public record class ReplayTrackerEEventId_e_playerStats(ReplayTrackerSPlayerStatsEvent Value) : ReplayTrackerEEventId;
// e_unitBorn
public record class ReplayTrackerEEventId_e_unitBorn(ReplayTrackerSUnitBornEvent Value) : ReplayTrackerEEventId;
// e_unitDied
public record class ReplayTrackerEEventId_e_unitDied(ReplayTrackerSUnitDiedEvent Value) : ReplayTrackerEEventId;
// e_unitOwnerChange
public record class ReplayTrackerEEventId_e_unitOwnerChange(ReplayTrackerSUnitOwnerChangeEvent Value) : ReplayTrackerEEventId;
// e_unitTypeChange
public record class ReplayTrackerEEventId_e_unitTypeChange(ReplayTrackerSUnitTypeChangeEvent Value) : ReplayTrackerEEventId;
// e_upgrade
public record class ReplayTrackerEEventId_e_upgrade(ReplayTrackerSUpgradeEvent Value) : ReplayTrackerEEventId;
// e_unitInit
public record class ReplayTrackerEEventId_e_unitInit(ReplayTrackerSUnitInitEvent Value) : ReplayTrackerEEventId;
// e_unitDone
public record class ReplayTrackerEEventId_e_unitDone(ReplayTrackerSUnitDoneEvent Value) : ReplayTrackerEEventId;
// e_unitPosition
public record class ReplayTrackerEEventId_e_unitPosition(ReplayTrackerSUnitPositionsEvent Value) : ReplayTrackerEEventId;
// e_playerSetup
public record class ReplayTrackerEEventId_e_playerSetup(ReplayTrackerSPlayerSetupEvent Value) : ReplayTrackerEEventId;

// NNet.Game.CPlayerDetailsArray
public  class GameCPlayerDetailsArray
{
    public List<GameSPlayerDetails> Value;
}

