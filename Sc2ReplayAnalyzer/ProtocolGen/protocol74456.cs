
namespace Sc2ReplayAnalyzer.Json.protocol74456;

// NNet.SVarUint32
public interface ISVarUint32 { }

// m_uint6
public class m_uint6 : ISVarUint32
{
    public byte Value;
}

// m_uint14
public class m_uint14 : ISVarUint32
{
    public int Value;
}

// m_uint22
public class m_uint22 : ISVarUint32
{
    public int Value;
}

// m_uint32
public class m_uint32 : ISVarUint32
{
    public int Value;
}

// NNet.Game.SCmdData
public interface IGameSCmdData { }

// TargetPoint
public class TargetPoint : IGameSCmdData
{
    public GameSMapCoord3D Value;
}

// TargetUnit
public class TargetUnit : IGameSCmdData
{
    public GameSCmdDataTargetUnit Value;
}

// Data
public class Data : IGameSCmdData
{
    public uint32 Value;
}

// m_eventData
public interface Im_eventData { }

// Checked
public class Checked : Im_eventData
{
    public bool Value;
}

// ValueChanged
public class ValueChanged : Im_eventData
{
    public uint32 Value;
}

// SelectionChanged
public class SelectionChanged : Im_eventData
{
    public int32 Value;
}

// TextChanged
public class TextChanged : Im_eventData
{
    public GameCChatString Value;
}

// MouseButton
public class MouseButton : Im_eventData
{
    public uint32 Value;
}

// NNet.Game.SLobbySlotChange
public interface IGameSLobbySlotChange { }

// m_control
public class m_control : IGameSLobbySlotChange
{
    public GameTControlId Value;
}

// m_userId
public class m_userId : IGameSLobbySlotChange
{
    public Option<TUserId> Value;
}

// m_teamId
public class m_teamId : IGameSLobbySlotChange
{
    public GameTTeamId Value;
}

// m_colorPref
public class m_colorPref : IGameSLobbySlotChange
{
    public GameTColorPreference Value;
}

// m_racePref
public class m_racePref : IGameSLobbySlotChange
{
    public TRacePreference Value;
}

// m_difficulty
public class m_difficulty : IGameSLobbySlotChange
{
    public GameTDifficulty Value;
}

// m_aiBuild
public class m_aiBuild : IGameSLobbySlotChange
{
    public GameTAIBuild Value;
}

// m_handicap
public class m_handicap : IGameSLobbySlotChange
{
    public GameTHandicap Value;
}

// m_observe
public class m_observe : IGameSLobbySlotChange
{
    public EObserve Value;
}

// m_logoIndex
public class m_logoIndex : IGameSLobbySlotChange
{
    public GameTPlayerLogoIndex Value;
}

// m_hero
public class m_hero : IGameSLobbySlotChange
{
    public CHeroHandle Value;
}

// m_skin
public class m_skin : IGameSLobbySlotChange
{
    public CSkinHandle Value;
}

// m_mount
public class m_mount : IGameSLobbySlotChange
{
    public CMountHandle Value;
}

// m_licenses
public class m_licenses : IGameSLobbySlotChange
{
    public GameCLicenseArray Value;
}

// m_tandemLeaderId
public class m_tandemLeaderId : IGameSLobbySlotChange
{
    public Option<TUserId> Value;
}

// m_commander
public class m_commander : IGameSLobbySlotChange
{
    public CCommanderHandle Value;
}

// m_commanderLevel
public class m_commanderLevel : IGameSLobbySlotChange
{
    public uint32 Value;
}

// m_hasSilencePenalty
public class m_hasSilencePenalty : IGameSLobbySlotChange
{
    public bool Value;
}

// m_tandemId
public class m_tandemId : IGameSLobbySlotChange
{
    public Option<TUserId> Value;
}

// m_commanderMasteryLevel
public class m_commanderMasteryLevel : IGameSLobbySlotChange
{
    public uint32 Value;
}

// NNet.Game.SSelectionMask
public interface IGameSSelectionMask { }

// Mask
public class Mask : IGameSSelectionMask
{
    public GameSelectionMaskType Value;
}

// OneIndices
public class OneIndices : IGameSSelectionMask
{
    public GameSelectionIndexArrayType Value;
}

// ZeroIndices
public class ZeroIndices : IGameSSelectionMask
{
    public GameSelectionIndexArrayType Value;
}

// NNet.SVersion
public class SVersion
{
    public byte m_flags;
    public byte m_major;
    public byte m_minor;
    public byte m_revision;
    public int m_build;
    public int m_baseBuild;
}

// NNet.SMD5
public class SMD5
{
    public Option<List<byte>> m_dataDeprecated;
    public List<byte> m_data;
}

// NNet.Game.SThumbnail
public class GameSThumbnail
{
    public List<byte> m_file;
}

// NNet.Game.SColor
public class GameSColor
{
    public byte m_a;
    public byte m_r;
    public byte m_g;
    public byte m_b;
}

// NNet.Game.SToonNameDetails
public class GameSToonNameDetails
{
    public byte m_region;
    public int m_programId;
    public int m_realm;
    public List<byte> m_name;
    public long m_id;
}

// NNet.Game.SPlayerDetails
public class GameSPlayerDetails
{
    public List<byte> m_name;
    public GameSToonNameDetails m_toon;
    public List<byte> m_race;
    public GameSColor m_color;
    public byte m_control;
    public byte m_teamId;
    public int m_handicap;
    public EObserve m_observe;
    public GameEResultDetails m_result;
    public Option<byte> m_workingSetSlotId;
    public List<byte> m_hero;
}

// NNet.Game.SDetails
public class GameSDetails
{
    public Option<List<GameSPlayerDetails>> m_playerList;
    public List<byte> m_title;
    public List<byte> m_difficulty;
    public GameSThumbnail m_thumbnail;
    public bool m_isBlizzardMap;
    public long m_timeUTC;
    public long m_timeLocalOffset;
    public Option<bool> m_restartAsTransitionMap;
    public bool m_disableRecoverGame;
    public List<byte> m_description;
    public List<byte> m_imageFilePath;
    public byte m_campaignIndex;
    public List<byte> m_mapFileName;
    public Option<List<List<byte>>> m_cacheHandles;
    public bool m_miniSave;
    public GameEGameSpeed m_gameSpeed;
    public int m_defaultDifficulty;
    public Option<List<List<byte>>> m_modPaths;
}

// NNet.Replay.SHeader
public class ReplaySHeader
{
    public List<byte> m_signature;
    public SVersion m_version;
    public byte m_type;
    public int m_elapsedGameLoops;
    public bool m_useScaledTime;
    public SMD5 m_ngdpRootKey;
    public int m_dataBuildNum;
    public SMD5 m_replayCompatibilityHash;
    public bool m_ngdpRootKeyIsDevData;
}

// NNet.Replay.Tracker.SPlayerStats
public class ReplayTrackerSPlayerStats
{
    public int m_scoreValueMineralsCurrent;
    public int m_scoreValueVespeneCurrent;
    public int m_scoreValueMineralsCollectionRate;
    public int m_scoreValueVespeneCollectionRate;
    public int m_scoreValueWorkersActiveCount;
    public int m_scoreValueMineralsUsedInProgressArmy;
    public int m_scoreValueMineralsUsedInProgressEconomy;
    public int m_scoreValueMineralsUsedInProgressTechnology;
    public int m_scoreValueVespeneUsedInProgressArmy;
    public int m_scoreValueVespeneUsedInProgressEconomy;
    public int m_scoreValueVespeneUsedInProgressTechnology;
    public int m_scoreValueMineralsUsedCurrentArmy;
    public int m_scoreValueMineralsUsedCurrentEconomy;
    public int m_scoreValueMineralsUsedCurrentTechnology;
    public int m_scoreValueVespeneUsedCurrentArmy;
    public int m_scoreValueVespeneUsedCurrentEconomy;
    public int m_scoreValueVespeneUsedCurrentTechnology;
    public int m_scoreValueMineralsLostArmy;
    public int m_scoreValueMineralsLostEconomy;
    public int m_scoreValueMineralsLostTechnology;
    public int m_scoreValueVespeneLostArmy;
    public int m_scoreValueVespeneLostEconomy;
    public int m_scoreValueVespeneLostTechnology;
    public int m_scoreValueMineralsKilledArmy;
    public int m_scoreValueMineralsKilledEconomy;
    public int m_scoreValueMineralsKilledTechnology;
    public int m_scoreValueVespeneKilledArmy;
    public int m_scoreValueVespeneKilledEconomy;
    public int m_scoreValueVespeneKilledTechnology;
    public int m_scoreValueFoodUsed;
    public int m_scoreValueFoodMade;
    public int m_scoreValueMineralsUsedActiveForces;
    public int m_scoreValueVespeneUsedActiveForces;
    public int m_scoreValueMineralsFriendlyFireArmy;
    public int m_scoreValueMineralsFriendlyFireEconomy;
    public int m_scoreValueMineralsFriendlyFireTechnology;
    public int m_scoreValueVespeneFriendlyFireArmy;
    public int m_scoreValueVespeneFriendlyFireEconomy;
    public int m_scoreValueVespeneFriendlyFireTechnology;
}

// NNet.Replay.Tracker.SPlayerStatsEvent
public class ReplayTrackerSPlayerStatsEvent
{
    public byte m_playerId;
    public ReplayTrackerSPlayerStats m_stats;
}

// NNet.Replay.Tracker.SUnitBornEvent
public class ReplayTrackerSUnitBornEvent
{
    public int m_unitTagIndex;
    public int m_unitTagRecycle;
    public List<byte> m_unitTypeName;
    public byte m_controlPlayerId;
    public byte m_upkeepPlayerId;
    public byte m_x;
    public byte m_y;
    public Option<int> m_creatorUnitTagIndex;
    public Option<int> m_creatorUnitTagRecycle;
    public Option<List<byte>> m_creatorAbilityName;
}

// NNet.Replay.Tracker.SUnitDiedEvent
public class ReplayTrackerSUnitDiedEvent
{
    public int m_unitTagIndex;
    public int m_unitTagRecycle;
    public Option<byte> m_killerPlayerId;
    public byte m_x;
    public byte m_y;
    public Option<int> m_killerUnitTagIndex;
    public Option<int> m_killerUnitTagRecycle;
}

// NNet.Replay.Tracker.SUnitOwnerChangeEvent
public class ReplayTrackerSUnitOwnerChangeEvent
{
    public int m_unitTagIndex;
    public int m_unitTagRecycle;
    public byte m_controlPlayerId;
    public byte m_upkeepPlayerId;
}

// NNet.Replay.Tracker.SUnitTypeChangeEvent
public class ReplayTrackerSUnitTypeChangeEvent
{
    public int m_unitTagIndex;
    public int m_unitTagRecycle;
    public List<byte> m_unitTypeName;
}

// NNet.Replay.Tracker.SUpgradeEvent
public class ReplayTrackerSUpgradeEvent
{
    public byte m_playerId;
    public List<byte> m_upgradeTypeName;
    public int m_count;
}

// NNet.Replay.Tracker.SUnitInitEvent
public class ReplayTrackerSUnitInitEvent
{
    public int m_unitTagIndex;
    public int m_unitTagRecycle;
    public List<byte> m_unitTypeName;
    public byte m_controlPlayerId;
    public byte m_upkeepPlayerId;
    public byte m_x;
    public byte m_y;
}

// NNet.Replay.Tracker.SUnitDoneEvent
public class ReplayTrackerSUnitDoneEvent
{
    public int m_unitTagIndex;
    public int m_unitTagRecycle;
}

// NNet.Replay.Tracker.SUnitPositionsEvent
public class ReplayTrackerSUnitPositionsEvent
{
    public int m_firstUnitIndex;
    public List<int> m_items;
}

// NNet.Replay.Tracker.SPlayerSetupEvent
public class ReplayTrackerSPlayerSetupEvent
{
    public byte m_playerId;
    public int m_type;
    public Option<int> m_userId;
    public Option<int> m_slotId;
}

// NNet.TRacePreference
public class TRacePreference
{
    public Option<TRaceId> m_race;
}

// NNet.TTeamPreference
public class TTeamPreference
{
    public Option<uint8> m_team;
}

// NNet.SUserInitialData
public class SUserInitialData
{
    public CUserName m_name;
    public Option<CClanTag> m_clanTag;
    public Option<CCacheHandle> m_clanLogo;
    public Option<uint8> m_highestLeague;
    public Option<uint32> m_combinedRaceLevels;
    public uint32 m_randomSeed;
    public TRacePreference m_racePreference;
    public TTeamPreference m_teamPreference;
    public bool m_testMap;
    public bool m_testAuto;
    public bool m_examine;
    public bool m_customInterface;
    public uint32 m_testType;
    public EObserve m_observe;
    public CHeroHandle m_hero;
    public CSkinHandle m_skin;
    public CMountHandle m_mount;
    public CToonHandle m_toonHandle;
    public Option<int32> m_scaledRating;
}

// NNet.Game.TColorPreference
public class GameTColorPreference
{
    public Option<GameTColorId> m_color;
}

// NNet.Game.SCmdAbil
public class GameSCmdAbil
{
    public GameTAbilLink m_abilLink;
    public long m_abilCmdIndex;
    public Option<uint8> m_abilCmdData;
}

// NNet.Game.SCmdDataTargetUnit
public class GameSCmdDataTargetUnit
{
    public uint16 m_targetUnitFlags;
    public uint8 m_timer;
    public GameTUnitTag m_tag;
    public GameTUnitLink m_snapshotUnitLink;
    public Option<GameTPlayerId> m_snapshotControlPlayerId;
    public Option<GameTPlayerId> m_snapshotUpkeepPlayerId;
    public GameSMapCoord3D m_snapshotPoint;
}

// NNet.Game.SSetLobbySlotEvent
public class GameSSetLobbySlotEvent
{
    public GameTLobbySlotId m_slotId;
    public IGameSLobbySlotChange m_slotChange;
}

// NNet.Game.SDropUserEvent
public class GameSDropUserEvent
{
    public TUserId m_dropSessionUserId;
    public ELeaveReason m_reason;
}

// NNet.Game.SStartGameEvent
public class GameSStartGameEvent
{
}

// NNet.Game.SDropOurselvesEvent
public class GameSDropOurselvesEvent
{
}

// NNet.Game.SBankFileEvent
public class GameSBankFileEvent
{
    public List<byte> m_name;
}

// NNet.Game.SBankSectionEvent
public class GameSBankSectionEvent
{
    public List<byte> m_name;
}

// NNet.Game.SBankKeyEvent
public class GameSBankKeyEvent
{
    public List<byte> m_name;
    public uint32 m_type;
    public List<byte> m_data;
}

// NNet.Game.SBankValueEvent
public class GameSBankValueEvent
{
    public uint32 m_type;
    public List<byte> m_name;
    public List<byte> m_data;
}

// NNet.Game.SBankSignatureEvent
public class GameSBankSignatureEvent
{
    public List<uint8> m_signature;
    public CToonHandle m_toonHandle;
}

// NNet.Game.SUserOptionsEvent
public class GameSUserOptionsEvent
{
    public bool m_gameFullyDownloaded;
    public bool m_developmentCheatsEnabled;
    public bool m_testCheatsEnabled;
    public bool m_multiplayerCheatsEnabled;
    public bool m_syncChecksummingEnabled;
    public bool m_isMapToMapTransition;
    public bool m_debugPauseEnabled;
    public bool m_useGalaxyAsserts;
    public bool m_platformMac;
    public bool m_cameraFollow;
    public uint32 m_baseBuildNum;
    public uint32 m_buildNum;
    public uint32 m_versionFlags;
    public List<byte> m_hotkeyProfile;
}

// NNet.Game.SPickMapTagEvent
public class GameSPickMapTagEvent
{
    public uint8 m_pickedMapTag;
}

// NNet.Game.SUserFinishedLoadingEvent
public class GameSUserFinishedLoadingEvent
{
}

// NNet.Game.SUserFinishedLoadingSyncEvent
public class GameSUserFinishedLoadingSyncEvent
{
}

// NNet.Game.SSetGameDurationEvent
public class GameSSetGameDurationEvent
{
    public uint32 m_gameDuration;
}

// NNet.Game.STurnEvent
public class GameSTurnEvent
{
}

// NNet.Game.SCameraSaveEvent
public class GameSCameraSaveEvent
{
    public long m_which;
    public GameSPointMini m_target;
}

// NNet.Game.SPauseGameEvent
public class GameSPauseGameEvent
{
    public uint8 m_pauseTypeIndex;
}

// NNet.Game.SUnpauseGameEvent
public class GameSUnpauseGameEvent
{
    public uint8 m_pauseTypeIndex;
}

// NNet.Game.SSingleStepGameEvent
public class GameSSingleStepGameEvent
{
}

// NNet.Game.SSetGameSpeedEvent
public class GameSSetGameSpeedEvent
{
    public GameEGameSpeed m_speed;
}

// NNet.Game.SAddGameSpeedEvent
public class GameSAddGameSpeedEvent
{
    public int8 m_delta;
}

// NNet.Game.SReplayJumpEvent
public class GameSReplayJumpEvent
{
    public Option<uint32> m_replayJumpGameLoop;
}

// NNet.Game.SSaveGameEvent
public class GameSSaveGameEvent
{
    public CFilePath m_fileName;
    public bool m_automatic;
    public bool m_overwrite;
    public List<byte> m_name;
    public List<byte> m_description;
}

// NNet.Game.SSaveGameDoneEvent
public class GameSSaveGameDoneEvent
{
}

// NNet.Game.SLoadGameDoneEvent
public class GameSLoadGameDoneEvent
{
}

// NNet.Game.SCheatEventData
public class GameSCheatEventData
{
    public GameSPoint m_point;
    public int32 m_time;
    public GameCCheatString m_verb;
    public GameCCheatString m_arguments;
}

// NNet.Game.SSessionCheatEvent
public class GameSSessionCheatEvent
{
    public GameSCheatEventData m_data;
}

// NNet.Game.SCommandManagerResetEvent
public class GameSCommandManagerResetEvent
{
    public uint32 m_sequence;
}

// NNet.Game.SGameCheatEvent
public class GameSGameCheatEvent
{
    public GameSCheatEventData m_data;
}

// NNet.Game.SCmdEvent
public class GameSCmdEvent
{
    public long m_cmdFlags;
    public Option<GameSCmdAbil> m_abil;
    public IGameSCmdData m_data;
    public long m_sequence;
    public Option<GameTUnitTag> m_otherUnit;
    public Option<uint32> m_unitGroup;
}

// NNet.Game.SSelectionDeltaEvent
public class GameSSelectionDeltaEvent
{
    public GameTControlGroupId m_controlGroupId;
    public GameSSelectionDelta m_delta;
}

// NNet.Game.SControlGroupUpdateEvent
public class GameSControlGroupUpdateEvent
{
    public GameTControlGroupIndex m_controlGroupIndex;
    public GameEControlGroupUpdate m_controlGroupUpdate;
    public IGameSSelectionMask m_mask;
}

// NNet.Game.SSelectionSyncCheckEvent
public class GameSSelectionSyncCheckEvent
{
    public GameTControlGroupId m_controlGroupId;
    public GameSSelectionSyncData m_selectionSyncData;
}

// NNet.Game.SResourceTradeEvent
public class GameSResourceTradeEvent
{
    public GameTPlayerId m_recipientId;
    public List<int32> m_resources;
}

// NNet.Game.STriggerChatMessageEvent
public class GameSTriggerChatMessageEvent
{
    public GameCTriggerChatMessageString m_chatMessage;
}

// NNet.Game.SAICommunicateEvent
public class GameSAICommunicateEvent
{
    public int8 m_beacon;
    public int8 m_ally;
    public int8 m_flags;
    public int8 m_build;
    public GameTUnitTag m_targetUnitTag;
    public GameTUnitLink m_targetUnitSnapshotUnitLink;
    public int8 m_targetUnitSnapshotUpkeepPlayerId;
    public int8 m_targetUnitSnapshotControlPlayerId;
    public GameSPoint3 m_targetPoint;
}

// NNet.Game.SSetAbsoluteGameSpeedEvent
public class GameSSetAbsoluteGameSpeedEvent
{
    public GameEGameSpeed m_speed;
}

// NNet.Game.SAddAbsoluteGameSpeedEvent
public class GameSAddAbsoluteGameSpeedEvent
{
    public int8 m_delta;
}

// NNet.Game.STriggerPingEvent
public class GameSTriggerPingEvent
{
    public GameSPoint m_point;
    public GameTUnitTag m_unit;
    public GameTUnitLink m_unitLink;
    public Option<GameTPlayerId> m_unitControlPlayerId;
    public Option<GameTPlayerId> m_unitUpkeepPlayerId;
    public GameSMapCoord3D m_unitPosition;
    public bool m_unitIsUnderConstruction;
    public bool m_pingedMinimap;
    public int32 m_option;
}

// NNet.Game.SBroadcastCheatEvent
public class GameSBroadcastCheatEvent
{
    public GameCCheatString m_verb;
    public GameCCheatString m_arguments;
}

// NNet.Game.SAllianceEvent
public class GameSAllianceEvent
{
    public uint32 m_alliance;
    public uint32 m_control;
}

// NNet.Game.SUnitClickEvent
public class GameSUnitClickEvent
{
    public GameTUnitTag m_unitTag;
}

// NNet.Game.SUnitHighlightEvent
public class GameSUnitHighlightEvent
{
    public GameTUnitTag m_unitTag;
    public uint8 m_flags;
}

// NNet.Game.STriggerReplySelectedEvent
public class GameSTriggerReplySelectedEvent
{
    public int32 m_conversationId;
    public int32 m_replyId;
}

// NNet.Game.SHijackReplaySessionUserInfo
public class GameSHijackReplaySessionUserInfo
{
    public TUserId m_sessionUserId;
    public bool m_addNewGameUser;
    public TUserId m_gameUserId;
}

// NNet.Game.SHijackReplaySessionEvent
public class GameSHijackReplaySessionEvent
{
    public List<GameSHijackReplaySessionUserInfo> m_userInfos;
    public GameEHijackMethod m_method;
}

// NNet.Game.SHijackReplayGameUserInfo
public class GameSHijackReplayGameUserInfo
{
    public TUserId m_gameUserId;
    public EObserve m_observe;
    public CUserName m_name;
    public Option<CToonHandle> m_toonHandle;
    public Option<CClanTag> m_clanTag;
    public Option<GameCCacheHandle> m_clanLogo;
}

// NNet.Game.SHijackReplayGameEvent
public class GameSHijackReplayGameEvent
{
    public List<GameSHijackReplayGameUserInfo> m_userInfos;
    public GameEHijackMethod m_method;
}

// NNet.Game.STriggerAbortMissionEvent
public class GameSTriggerAbortMissionEvent
{
}

// NNet.Game.STriggerPurchaseMadeEvent
public class GameSTriggerPurchaseMadeEvent
{
    public int32 m_purchaseItemId;
}

// NNet.Game.STriggerPurchaseExitEvent
public class GameSTriggerPurchaseExitEvent
{
}

// NNet.Game.STriggerPlanetMissionLaunchedEvent
public class GameSTriggerPlanetMissionLaunchedEvent
{
    public int32 m_difficultyLevel;
}

// NNet.Game.STriggerPlanetPanelCanceledEvent
public class GameSTriggerPlanetPanelCanceledEvent
{
}

// NNet.Game.STriggerDialogControlEvent
public class GameSTriggerDialogControlEvent
{
    public int32 m_controlId;
    public int32 m_eventType;
    public Im_eventData m_eventData;
}

// NNet.Game.STriggerSkippedEvent
public class GameSTriggerSkippedEvent
{
}

// NNet.Game.STriggerSoundLengthQueryEvent
public class GameSTriggerSoundLengthQueryEvent
{
    public uint32 m_soundHash;
    public uint32 m_length;
}

// NNet.Game.STriggerSoundLengthSyncEvent
public class GameSTriggerSoundLengthSyncEvent
{
    public GameSSyncSoundLength m_syncInfo;
}

// NNet.Game.STriggerAnimLengthQueryByNameEvent
public class GameSTriggerAnimLengthQueryByNameEvent
{
    public GameTQueryID m_queryId;
    public uint32 m_lengthMs;
    public uint32 m_finishGameLoop;
}

// NNet.Game.STriggerAnimLengthQueryByPropsEvent
public class GameSTriggerAnimLengthQueryByPropsEvent
{
    public GameTQueryID m_queryId;
    public uint32 m_lengthMs;
}

// NNet.Game.STriggerAnimOffsetEvent
public class GameSTriggerAnimOffsetEvent
{
    public GameTQueryID m_animWaitQueryId;
}

// NNet.Game.STriggerSoundOffsetEvent
public class GameSTriggerSoundOffsetEvent
{
    public GameTTriggerSoundTag m_sound;
}

// NNet.Game.STriggerTransmissionOffsetEvent
public class GameSTriggerTransmissionOffsetEvent
{
    public int32 m_transmissionId;
    public GameTTriggerThreadTag m_thread;
}

// NNet.Game.STriggerTransmissionCompleteEvent
public class GameSTriggerTransmissionCompleteEvent
{
    public int32 m_transmissionId;
}

// NNet.Game.SCameraUpdateEvent
public class GameSCameraUpdateEvent
{
    public Option<GameSPointMini> m_target;
    public Option<GameTFixedMiniBitsUnsigned> m_distance;
    public Option<GameTFixedMiniBitsUnsigned> m_pitch;
    public Option<GameTFixedMiniBitsUnsigned> m_yaw;
    public Option<int8> m_reason;
    public bool m_follow;
}

// NNet.Game.STriggerConversationSkippedEvent
public class GameSTriggerConversationSkippedEvent
{
    public GameEConversationSkip m_skipType;
}

// NNet.Game.STriggerMouseClickedEvent
public class GameSTriggerMouseClickedEvent
{
    public uint32 m_button;
    public bool m_down;
    public GameSUICoord m_posUI;
    public GameSMapCoord3D m_posWorld;
    public int8 m_flags;
}

// NNet.Game.STriggerMouseMovedEvent
public class GameSTriggerMouseMovedEvent
{
    public GameSUICoord m_posUI;
    public GameSMapCoord3D m_posWorld;
    public int8 m_flags;
}

// NNet.Game.SAchievementAwardedEvent
public class GameSAchievementAwardedEvent
{
    public GameTAchievementLink m_achievementLink;
}

// NNet.Game.STriggerHotkeyPressedEvent
public class GameSTriggerHotkeyPressedEvent
{
    public uint32 m_hotkey;
    public bool m_down;
}

// NNet.Game.STriggerTargetModeUpdateEvent
public class GameSTriggerTargetModeUpdateEvent
{
    public GameTAbilLink m_abilLink;
    public long m_abilCmdIndex;
    public int8 m_state;
}

// NNet.Game.STriggerPlanetPanelReplayEvent
public class GameSTriggerPlanetPanelReplayEvent
{
}

// NNet.Game.STriggerSoundtrackDoneEvent
public class GameSTriggerSoundtrackDoneEvent
{
    public uint32 m_soundtrack;
}

// NNet.Game.STriggerPlanetMissionSelectedEvent
public class GameSTriggerPlanetMissionSelectedEvent
{
    public int32 m_planetId;
}

// NNet.Game.STriggerKeyPressedEvent
public class GameSTriggerKeyPressedEvent
{
    public int8 m_key;
    public int8 m_flags;
}

// NNet.Game.STriggerPlanetPanelBirthCompleteEvent
public class GameSTriggerPlanetPanelBirthCompleteEvent
{
}

// NNet.Game.STriggerPlanetPanelDeathCompleteEvent
public class GameSTriggerPlanetPanelDeathCompleteEvent
{
}

// NNet.Game.SResourceRequestEvent
public class GameSResourceRequestEvent
{
    public List<int32> m_resources;
}

// NNet.Game.SResourceRequestFulfillEvent
public class GameSResourceRequestFulfillEvent
{
    public int32 m_fulfillRequestId;
}

// NNet.Game.SResourceRequestCancelEvent
public class GameSResourceRequestCancelEvent
{
    public int32 m_cancelRequestId;
}

// NNet.Game.STriggerResearchPanelExitEvent
public class GameSTriggerResearchPanelExitEvent
{
}

// NNet.Game.STriggerResearchPanelPurchaseEvent
public class GameSTriggerResearchPanelPurchaseEvent
{
}

// NNet.Game.STriggerCommandErrorEvent
public class GameSTriggerCommandErrorEvent
{
    public int32 m_error;
    public Option<GameSCmdAbil> m_abil;
}

// NNet.Game.STriggerResearchPanelSelectionChangedEvent
public class GameSTriggerResearchPanelSelectionChangedEvent
{
    public int32 m_researchItemId;
}

// NNet.Game.STriggerMercenaryPanelExitEvent
public class GameSTriggerMercenaryPanelExitEvent
{
}

// NNet.Game.STriggerMercenaryPanelPurchaseEvent
public class GameSTriggerMercenaryPanelPurchaseEvent
{
}

// NNet.Game.STriggerMercenaryPanelSelectionChangedEvent
public class GameSTriggerMercenaryPanelSelectionChangedEvent
{
    public int32 m_mercenaryId;
}

// NNet.Game.STriggerVictoryPanelExitEvent
public class GameSTriggerVictoryPanelExitEvent
{
}

// NNet.Game.STriggerBattleReportPanelExitEvent
public class GameSTriggerBattleReportPanelExitEvent
{
}

// NNet.Game.STriggerBattleReportPanelPlayMissionEvent
public class GameSTriggerBattleReportPanelPlayMissionEvent
{
    public int32 m_battleReportId;
    public int32 m_difficultyLevel;
}

// NNet.Game.STriggerBattleReportPanelPlaySceneEvent
public class GameSTriggerBattleReportPanelPlaySceneEvent
{
    public int32 m_battleReportId;
}

// NNet.Game.STriggerBattleReportPanelSelectionChangedEvent
public class GameSTriggerBattleReportPanelSelectionChangedEvent
{
    public int32 m_battleReportId;
}

// NNet.Game.STriggerVictoryPanelPlayMissionAgainEvent
public class GameSTriggerVictoryPanelPlayMissionAgainEvent
{
    public int32 m_difficultyLevel;
}

// NNet.Game.STriggerMovieStartedEvent
public class GameSTriggerMovieStartedEvent
{
}

// NNet.Game.STriggerMovieFinishedEvent
public class GameSTriggerMovieFinishedEvent
{
}

// NNet.Game.SDecrementGameTimeRemainingEvent
public class GameSDecrementGameTimeRemainingEvent
{
    public int32 m_decrementSeconds;
}

// NNet.Game.STriggerPortraitLoadedEvent
public class GameSTriggerPortraitLoadedEvent
{
    public int32 m_portraitId;
}

// NNet.Game.STriggerMovieFunctionEvent
public class GameSTriggerMovieFunctionEvent
{
    public List<byte> m_functionName;
}

// NNet.Game.STriggerCustomDialogDismissedEvent
public class GameSTriggerCustomDialogDismissedEvent
{
    public int32 m_result;
}

// NNet.Game.STriggerGameMenuItemSelectedEvent
public class GameSTriggerGameMenuItemSelectedEvent
{
    public int32 m_gameMenuItemIndex;
}

// NNet.Game.STriggerMouseWheelEvent
public class GameSTriggerMouseWheelEvent
{
    public GameTFixedMiniBitsSigned m_wheelSpin;
    public int8 m_flags;
}

// NNet.Game.STriggerPurchasePanelSelectedPurchaseItemChangedEvent
public class GameSTriggerPurchasePanelSelectedPurchaseItemChangedEvent
{
    public int32 m_purchaseItemId;
}

// NNet.Game.STriggerPurchasePanelSelectedPurchaseCategoryChangedEvent
public class GameSTriggerPurchasePanelSelectedPurchaseCategoryChangedEvent
{
    public int32 m_purchaseCategoryId;
}

// NNet.Game.STriggerButtonPressedEvent
public class GameSTriggerButtonPressedEvent
{
    public GameTButtonLink m_button;
}

// NNet.Game.STriggerGameCreditsFinishedEvent
public class GameSTriggerGameCreditsFinishedEvent
{
}

// NNet.Game.STriggerCutsceneBookmarkFiredEvent
public class GameSTriggerCutsceneBookmarkFiredEvent
{
    public int32 m_cutsceneId;
    public List<byte> m_bookmarkName;
}

// NNet.Game.STriggerCutsceneEndSceneFiredEvent
public class GameSTriggerCutsceneEndSceneFiredEvent
{
    public int32 m_cutsceneId;
}

// NNet.Game.STriggerCutsceneConversationLineEvent
public class GameSTriggerCutsceneConversationLineEvent
{
    public int32 m_cutsceneId;
    public List<byte> m_conversationLine;
    public List<byte> m_altConversationLine;
}

// NNet.Game.STriggerCutsceneConversationLineMissingEvent
public class GameSTriggerCutsceneConversationLineMissingEvent
{
    public int32 m_cutsceneId;
    public List<byte> m_conversationLine;
}

// NNet.Game.SGameUserLeaveEvent
public class GameSGameUserLeaveEvent
{
    public ELeaveReason m_leaveReason;
}

// NNet.Game.SGameUserJoinEvent
public class GameSGameUserJoinEvent
{
    public EObserve m_observe;
    public CUserName m_name;
    public Option<CToonHandle> m_toonHandle;
    public Option<CClanTag> m_clanTag;
    public Option<GameCCacheHandle> m_clanLogo;
    public bool m_hijack;
    public Option<TUserId> m_hijackCloneGameUserId;
}

// NNet.Game.SCommandManagerStateEvent
public class GameSCommandManagerStateEvent
{
    public GameECommandManagerState m_state;
    public Option<long> m_sequence;
}

// NNet.Game.SCmdUpdateTargetPointEvent
public class GameSCmdUpdateTargetPointEvent
{
    public GameSMapCoord3D m_target;
}

// NNet.Game.SCmdUpdateTargetUnitEvent
public class GameSCmdUpdateTargetUnitEvent
{
    public GameSCmdDataTargetUnit m_target;
}

// NNet.Game.SCatalogModifyEvent
public class GameSCatalogModifyEvent
{
    public uint8 m_catalog;
    public uint16 m_entry;
    public List<byte> m_field;
    public List<byte> m_value;
}

// NNet.Game.SHeroTalentTreeSelectedEvent
public class GameSHeroTalentTreeSelectedEvent
{
    public uint32 m_index;
}

// NNet.Game.STriggerProfilerLoggingFinishedEvent
public class GameSTriggerProfilerLoggingFinishedEvent
{
}

// NNet.Game.SHeroTalentTreeSelectionPanelToggledEvent
public class GameSHeroTalentTreeSelectionPanelToggledEvent
{
    public bool m_shown;
}

// NNet.Game.SMuteChatEvent
public class GameSMuteChatEvent
{
    public TUserId m_targetUserId;
    public bool m_muted;
}

// NNet.Game.SConvertToReplaySessionEvent
public class GameSConvertToReplaySessionEvent
{
    public Option<int32> m_replayJumpGameLoop;
}

// NNet.Game.SSetSyncLoadingTimeEvent
public class GameSSetSyncLoadingTimeEvent
{
    public uint32 m_syncTime;
}

// NNet.Game.SSetSyncPlayingTimeEvent
public class GameSSetSyncPlayingTimeEvent
{
    public uint32 m_syncTime;
}

// NNet.Game.SPeerSetSyncLoadingTimeEvent
public class GameSPeerSetSyncLoadingTimeEvent
{
    public uint32 m_syncTime;
}

// NNet.Game.SPeerSetSyncPlayingTimeEvent
public class GameSPeerSetSyncPlayingTimeEvent
{
    public uint32 m_syncTime;
}

// NNet.Game.SPoint
public class GameSPoint
{
    public GameTFixedBits x;
    public GameTFixedBits y;
}

// NNet.Game.SPoint3
public class GameSPoint3
{
    public GameTFixedBits x;
    public GameTFixedBits y;
    public GameTFixedBits z;
}

// NNet.Game.SPointMini
public class GameSPointMini
{
    public GameTFixedMiniBitsUnsigned x;
    public GameTFixedMiniBitsUnsigned y;
}

// NNet.Game.SMapCoord
public class GameSMapCoord
{
    public GameTMapCoordFixedBits x;
    public GameTMapCoordFixedBits y;
}

// NNet.Game.SMapCoord3D
public class GameSMapCoord3D
{
    public GameTMapCoordFixedBits x;
    public GameTMapCoordFixedBits y;
    public GameTFixedBits z;
}

// NNet.Game.SUICoord
public class GameSUICoord
{
    public GameTUICoordX x;
    public GameTUICoordY y;
}

// NNet.Game.SSyncSoundLength
public class GameSSyncSoundLength
{
    public List<uint32> m_soundHash;
    public List<uint32> m_length;
}

// NNet.Game.SGameOptions
public class GameSGameOptions
{
    public bool m_lockTeams;
    public bool m_teamsTogether;
    public bool m_advancedSharedControl;
    public bool m_randomRaces;
    public bool m_battleNet;
    public bool m_amm;
    public bool m_competitive;
    public bool m_practice;
    public bool m_cooperative;
    public bool m_noVictoryOrDefeat;
    public bool m_heroDuplicatesAllowed;
    public GameEOptionFog m_fog;
    public GameEOptionObservers m_observers;
    public GameEOptionUserDifficulty m_userDifficulty;
    public GameEClientDebugFlags m_clientDebugFlags;
    public bool m_buildCoachEnabled;
}

// NNet.Game.SSlotDescription
public class GameSSlotDescription
{
    public GameCAllowedColors m_allowedColors;
    public CAllowedRaces m_allowedRaces;
    public GameCAllowedDifficulty m_allowedDifficulty;
    public GameCAllowedControls m_allowedControls;
    public CAllowedObserveTypes m_allowedObserveTypes;
    public GameCAllowedAIBuild m_allowedAIBuilds;
}

// NNet.Game.SGameDescription
public class GameSGameDescription
{
    public uint32 m_randomValue;
    public GameCGameCacheName m_gameCacheName;
    public GameSGameOptions m_gameOptions;
    public GameEGameSpeed m_gameSpeed;
    public GameEGameType m_gameType;
    public TUserCount m_maxUsers;
    public TUserCount m_maxObservers;
    public GameTPlayerCount m_maxPlayers;
    public GameTTeamCount m_maxTeams;
    public GameTColorCount m_maxColors;
    public TRaceCount m_maxRaces;
    public GameTControlCount m_maxControls;
    public uint8 m_mapSizeX;
    public uint8 m_mapSizeY;
    public GameTSyncChecksum m_mapFileSyncChecksum;
    public CFilePath m_mapFileName;
    public GameCAuthorName m_mapAuthorName;
    public GameTSyncChecksum m_modFileSyncChecksum;
    public GameSSlotDescriptions m_slotDescriptions;
    public GameTDifficulty m_defaultDifficulty;
    public GameTAIBuild m_defaultAIBuild;
    public GameCCacheHandles m_cacheHandles;
    public bool m_hasExtensionMod;
    public bool m_hasNonBlizzardExtensionMod;
    public bool m_isBlizzardMap;
    public bool m_isPremadeFFA;
    public bool m_isCoopMode;
    public bool m_isRealtimeMode;
}

// NNet.Game.CRewardOverride
public class GameCRewardOverride
{
    public uint32 m_key;
    public GameCRewardArray m_rewards;
}

// NNet.Game.SLobbySlot
public class GameSLobbySlot
{
    public GameTControlId m_control;
    public Option<TUserId> m_userId;
    public GameTTeamId m_teamId;
    public GameTColorPreference m_colorPref;
    public TRacePreference m_racePref;
    public GameTDifficulty m_difficulty;
    public GameTAIBuild m_aiBuild;
    public GameTHandicap m_handicap;
    public EObserve m_observe;
    public GameTPlayerLogoIndex m_logoIndex;
    public CHeroHandle m_hero;
    public CSkinHandle m_skin;
    public CMountHandle m_mount;
    public GameCArtifactArray m_artifacts;
    public Option<uint8> m_workingSetSlotId;
    public GameCRewardArray m_rewards;
    public CToonHandle m_toonHandle;
    public GameCLicenseArray m_licenses;
    public Option<TUserId> m_tandemLeaderId;
    public CCommanderHandle m_commander;
    public uint32 m_commanderLevel;
    public bool m_hasSilencePenalty;
    public Option<TUserId> m_tandemId;
    public uint32 m_commanderMasteryLevel;
    public GameCCommanderMasteryTalentArray m_commanderMasteryTalents;
    public GameCRewardOverrideArray m_rewardOverrides;
}

// NNet.Game.SLobbyState
public class GameSLobbyState
{
    public GameEPhase m_phase;
    public TUserCount m_maxUsers;
    public TUserCount m_maxObservers;
    public GameCLobbySlotArray m_slots;
    public uint32 m_randomSeed;
    public Option<TUserId> m_hostUserId;
    public bool m_isSinglePlayer;
    public uint8 m_pickedMapTag;
    public uint32 m_gameDuration;
    public GameTDifficulty m_defaultDifficulty;
    public GameTAIBuild m_defaultAIBuild;
}

// NNet.Game.SLobbySyncState
public class GameSLobbySyncState
{
    public CUserInitialDataArray m_userInitialData;
    public GameSGameDescription m_gameDescription;
    public GameSLobbyState m_lobbyState;
}

// NNet.Game.SChatMessage
public class GameSChatMessage
{
    public GameEMessageRecipient m_recipient;
    public GameCChatString m_string;
}

// NNet.Game.SPingMessage
public class GameSPingMessage
{
    public GameEMessageRecipient m_recipient;
    public GameSPoint m_point;
}

// NNet.Game.SLoadingProgressMessage
public class GameSLoadingProgressMessage
{
    public int32 m_progress;
}

// NNet.Game.SServerPingMessage
public class GameSServerPingMessage
{
}

// NNet.Game.SReconnectNotifyMessage
public class GameSReconnectNotifyMessage
{
    public EReconnectStatus m_status;
}

// NNet.Game.SSelectionDeltaSubgroup
public class GameSSelectionDeltaSubgroup
{
    public GameTUnitLink m_unitLink;
    public GameTSubgroupPriority m_subgroupPriority;
    public GameTSubgroupPriority m_intraSubgroupPriority;
    public GameTSelectionCount m_count;
}

// NNet.Game.SSelectionDelta
public class GameSSelectionDelta
{
    public GameTSubgroupIndex m_subgroupIndex;
    public IGameSSelectionMask m_removeMask;
    public List<GameSSelectionDeltaSubgroup> m_addSubgroups;
    public List<GameTUnitTag> m_addUnitTags;
}

// NNet.Game.SSelectionSyncData
public class GameSSelectionSyncData
{
    public GameTSelectionCount m_count;
    public GameTSubgroupCount m_subgroupCount;
    public GameTSubgroupIndex m_activeSubgroupIndex;
    public GameTSyncChecksum m_unitTagsChecksum;
    public GameTSyncChecksum m_subgroupIndicesChecksum;
    public GameTSyncChecksum m_subgroupsChecksum;
}

// NNet.Game.SSessionSyncInfo
public class GameSSessionSyncInfo
{
    public List<GameTSyncChecksum> m_checksums;
}

// NNet.Game.SGameSyncInfo
public class GameSGameSyncInfo
{
    public List<GameTSyncChecksum> m_checksums;
}

// NNet.Replay.SInitData
public class ReplaySInitData
{
    public GameSLobbySyncState m_syncLobbyState;
}

// NNet.Replay.SGameUserId
public class ReplaySGameUserId
{
    public long m_userId;
}

// NNet.EObserve
public enum EObserve
{
    e_none = 0,
    e_spectator = 1,
    e_referee = 2,
}

// NNet.Game.EGameSpeed
public enum GameEGameSpeed
{
    e_slower = 0,
    e_slow = 1,
    e_normal = 2,
    e_fast = 3,
    e_faster = 4,
}

// NNet.Game.EResultDetails
public enum GameEResultDetails
{
    e_undecided = 0,
    e_win = 1,
    e_loss = 2,
    e_tie = 3,
}

// NNet.Replay.Tracker.EEventId
public enum ReplayTrackerEEventId
{
    e_playerStats = 0,
    e_unitBorn = 1,
    e_unitDied = 2,
    e_unitOwnerChange = 3,
    e_unitTypeChange = 4,
    e_upgrade = 5,
    e_unitInit = 6,
    e_unitDone = 7,
    e_unitPosition = 8,
    e_playerSetup = 9,
}

// NNet.ELeaveReason
public enum ELeaveReason
{
    e_userLeft = 0,
    e_userDropped = 1,
    e_userBanned = 2,
    e_userVictory = 3,
    e_userDefeat = 4,
    e_userTied = 5,
    e_userDesynced = 6,
    e_userOutOfTime = 7,
    e_weWereUnresponsive = 8,
    e_weContinuedAlone = 9,
    e_replayDesynced = 10,
    e_userTimeout = 11,
    e_userDisconnected = 12,
    e_unrecoverable = 13,
    e_userCatchupDesynced = 14,
    e_takeCommandDropped = 15,
}

// NNet.EReconnectStatus
public enum EReconnectStatus
{
    e_connected = 0,
    e_reconnected = 1,
    e_disconnected = 2,
    e_unrecoverable = 3,
}

// NNet.Game.ESynchronous
public enum GameESynchronous
{
    e_local = 0,
    e_session = 1,
    e_game = 2,
}

// NNet.Game.ESynthesized
public enum GameESynthesized
{
    e_synthesized = 0,
    e_notSynthesized = 1,
}

// NNet.Game.EDebug
public enum GameEDebug
{
    e_debug = 0,
    e_notDebug = 1,
}

// NNet.Game.EHijackMethod
public enum GameEHijackMethod
{
    e_recover = 0,
    e_takeCommand = 1,
}

// NNet.Game.EEventId
public enum GameEEventId
{
    e_setLobbySlot = 0,
    e_dropUser = 1,
    e_startGame = 2,
    e_dropOurselves = 3,
    e_userFinishedLoading = 4,
    e_userFinishedLoadingSync = 5,
    e_setGameDuration = 6,
    e_userOptions = 7,
    e_pickMapTag = 114,
    e_turn = 8,
    e_bankFile = 9,
    e_bankSection = 10,
    e_bankKey = 11,
    e_bankValue = 12,
    e_bankSignature = 13,
    e_cameraSave = 14,
    e_pauseGame = 15,
    e_unpauseGame = 16,
    e_singleStepGame = 17,
    e_setGameSpeed = 18,
    e_addGameSpeed = 19,
    e_replayJump = 20,
    e_saveGame = 21,
    e_saveGameDone = 22,
    e_loadGameDone = 23,
    e_sessionCheat = 24,
    e_commandManagerReset = 25,
    e_gameCheat = 26,
    e_cmd = 27,
    e_selectionDelta = 28,
    e_controlGroupUpdate = 29,
    e_selectionSyncCheck = 30,
    e_resourceTrade = 31,
    e_triggerChatMessage = 32,
    e_aiCommunicate = 33,
    e_setAbsoluteGameSpeed = 34,
    e_addAbsoluteGameSpeed = 35,
    e_triggerPing = 36,
    e_broadcastCheat = 37,
    e_alliance = 38,
    e_unitClick = 39,
    e_unitHighlight = 40,
    e_triggerReplySelected = 41,
    e_hijackReplaySession = 42,
    e_hijackReplayGame = 43,
    e_triggerSkipped = 44,
    e_triggerSoundLengthQuery = 45,
    e_triggerSoundOffset = 46,
    e_triggerTransmissionOffset = 47,
    e_triggerTransmissionComplete = 48,
    e_cameraUpdate = 49,
    e_triggerAbortMission = 50,
    e_triggerPurchaseMade = 51,
    e_triggerPurchaseExit = 52,
    e_triggerPlanetMissionLaunched = 53,
    e_triggerPlanetPanelCanceled = 54,
    e_triggerDialogControl = 55,
    e_triggerSoundLengthSync = 56,
    e_triggerConversationSkipped = 57,
    e_triggerMouseClicked = 58,
    e_triggerMouseMoved = 59,
    e_achievementAwarded = 60,
    e_triggerHotkeyPressed = 61,
    e_triggerTargetModeUpdate = 62,
    e_triggerPlanetPanelPanelReplay = 63,
    e_triggerSoundtrackDone = 64,
    e_triggerPlanetMissionSelected = 65,
    e_triggerKeyPressed = 66,
    e_triggerMovieFunction = 67,
    e_triggerPlanetPanelPanelBirthComplete = 68,
    e_triggerPlanetPanelPanelDeathComplete = 69,
    e_resourceRequest = 70,
    e_resourceRequestFulfill = 71,
    e_resourceRequestCancel = 72,
    e_triggerResearchPanelExit = 73,
    e_triggerResearchPanelPurchase = 74,
    e_triggerResearchPanelSelectionChanged = 75,
    e_triggerCommandError = 76,
    e_triggerMercenaryPanelExit = 77,
    e_triggerMercenaryPanelPurchase = 78,
    e_triggerMercenaryPanelSelectionChanged = 79,
    e_triggerVictoryPanelExit = 80,
    e_triggerBattleReportPanelExit = 81,
    e_triggerBattleReportPanelPlayMission = 82,
    e_triggerBattleReportPanelPlayScene = 83,
    e_triggerBattleReportSelectionChanged = 84,
    e_triggerVictoryPanelPlayMissionAgain = 85,
    e_triggerMovieStarted = 86,
    e_triggerMovieFinished = 87,
    e_decrementGameTimeRemaining = 88,
    e_triggerPortraitLoaded = 89,
    e_triggerQueryDialogDismissed = 90,
    e_triggerGameMenuItemSelected = 91,
    e_triggerMouseWheel = 92,
    e_triggerPurchasePanelSelectedPurchaseItemChanged = 93,
    e_triggerPurchasePanelSelectedPurchaseCategoryChanged = 94,
    e_triggerButtonPressed = 95,
    e_triggerGameCreditsFinished = 96,
    e_triggerCutsceneBookmarkFired = 97,
    e_triggerCutsceneEndSceneFired = 98,
    e_triggerCutsceneConversationLine = 99,
    e_triggerCutsceneConversationLineMissing = 100,
    e_gameUserLeave = 101,
    e_gameUserJoin = 102,
    e_commandManagerState = 103,
    e_cmdUpdateTargetPoint = 104,
    e_cmdUpdateTargetUnit = 105,
    e_triggerAnimLengthQueryByName = 106,
    e_triggerAnimLengthQueryByProps = 107,
    e_triggerAnimOffset = 108,
    e_catalogModify = 109,
    e_heroTalentTreeSelected = 110,
    e_triggerProfilerLoggingFinished = 111,
    e_heroTalentTreeSelectionPanelToggled = 112,
    e_muteUserChanged = 113,
    e_convertToReplaySession = 115,
    e_setSyncLoadingTime = 116,
    e_setSyncPlayingTime = 117,
    e_peerSetSyncLoadingTime = 118,
    e_peerSetSyncPlayingTime = 119,
}

// NNet.Game.ECommandManagerState
public enum GameECommandManagerState
{
    e_fireDone = 0,
    e_fireOnce = 1,
    e_fireMany = 2,
}

// NNet.Game.EPhase
public enum GameEPhase
{
    e_initializing = 0,
    e_lobby = 1,
    e_closed = 2,
    e_loading = 3,
    e_playing = 4,
    e_gameover = 5,
}

// NNet.Game.EConversationSkip
public enum GameEConversationSkip
{
    e_skipOneLine = 0,
    e_skipAllLines = 1,
}

// NNet.Game.EOptionFog
public enum GameEOptionFog
{
    e_default = 0,
    e_hideTerrain = 1,
    e_mapExplored = 2,
    e_alwaysVisible = 3,
}

// NNet.Game.EOptionObservers
public enum GameEOptionObservers
{
    e_none = 0,
    e_onJoin = 1,
    e_onJoinAndDefeat = 2,
    e_refereesOnJoin = 3,
}

// NNet.Game.EOptionUserDifficulty
public enum GameEOptionUserDifficulty
{
    e_none = 0,
    e_global = 1,
    e_individual = 2,
}

// NNet.Game.EGameLaunch
public enum GameEGameLaunch
{
    e_invalid = 0,
    e_map = 1,
    e_replay = 2,
    e_save = 3,
    e_transition = 4,
    e_serverReplay = 5,
}

// NNet.Game.EGameType
public enum GameEGameType
{
    e_melee = 0,
    e_freeForAll = 1,
    e_useSettings = 2,
    e_oneOnOne = 3,
    e_twoTeamPlay = 4,
    e_threeTeamPlay = 5,
    e_fourTeamPlay = 6,
}

// NNet.Game.EControl
public enum GameEControl
{
    e_open = 0,
    e_closed = 1,
    e_user = 2,
    e_computer = 3,
}

// NNet.Game.EMessageRecipient
public enum GameEMessageRecipient
{
    e_all = 0,
    e_allies = 1,
    e_individual = 2,
    e_battlenet = 3,
    e_observers = 4,
}

// NNet.Game.EMessageId
public enum GameEMessageId
{
    e_chat = 0,
    e_ping = 1,
    e_loadingProgress = 2,
    e_serverPing = 3,
    e_reconnectNotify = 4,
}

// NNet.Game.EResultCode
public enum GameEResultCode
{
    e_undecided = 0,
    e_loss = 1,
    e_tie = 2,
    e_win = 3,
}

// NNet.Game.EControlGroupUpdate
public enum GameEControlGroupUpdate
{
    e_set = 0,
    e_append = 1,
    e_recall = 2,
    e_clear = 3,
    e_setAndSteal = 4,
    e_appendAndSteal = 5,
}

// NNet.TRaceId
public class TRaceId
{
    public long Value;
}

// NNet.TRaceCount
public class TRaceCount
{
    public long Value;
}

// NNet.int8
public class int8
{
    public long Value;
}

// NNet.int16
public class int16
{
    public long Value;
}

// NNet.int32
public class int32
{
    public long Value;
}

// NNet.int64
public class int64
{
    public long Value;
}

// NNet.uint8
public class uint8
{
    public long Value;
}

// NNet.uint16
public class uint16
{
    public long Value;
}

// NNet.uint32
public class uint32
{
    public long Value;
}

// NNet.uint64
public class uint64
{
    public long Value;
}

// NNet.uint6
public class uint6
{
    public long Value;
}

// NNet.uint14
public class uint14
{
    public long Value;
}

// NNet.uint22
public class uint22
{
    public long Value;
}

// NNet.TUserId
public class TUserId
{
    public long Value;
}

// NNet.TUserCount
public class TUserCount
{
    public long Value;
}

// NNet.Game.c_maxColors
public class Gamec_maxColors
{
    public long Value;
}

// NNet.Game.c_defaultColors
public class Gamec_defaultColors
{
    public long Value;
}

// NNet.Game.TColorId
public class GameTColorId
{
    public long Value;
}

// NNet.Game.TColorCount
public class GameTColorCount
{
    public long Value;
}

// NNet.Game.c_maxCameraSaveValue
public class Gamec_maxCameraSaveValue
{
    public long Value;
}

// NNet.Game.c_maxCmdFlagValue
public class Gamec_maxCmdFlagValue
{
    public long Value;
}

// NNet.Game.c_maxCmdSequenceValue
public class Gamec_maxCmdSequenceValue
{
    public long Value;
}

// NNet.Game.TFixedInt
public class GameTFixedInt
{
    public long Value;
}

// NNet.Game.TFixedUInt
public class GameTFixedUInt
{
    public long Value;
}

// NNet.Game.TMapCoordFixedBits
public class GameTMapCoordFixedBits
{
    public long Value;
}

// NNet.Game.TUICoordX
public class GameTUICoordX
{
    public long Value;
}

// NNet.Game.TUICoordY
public class GameTUICoordY
{
    public long Value;
}

// NNet.Game.c_maxAbilCmds
public class Gamec_maxAbilCmds
{
    public long Value;
}

// NNet.Game.c_maxHandicap
public class Gamec_maxHandicap
{
    public long Value;
}

// NNet.Game.THandicap
public class GameTHandicap
{
    public long Value;
}

// NNet.Game.c_maxDifficulties
public class Gamec_maxDifficulties
{
    public long Value;
}

// NNet.Game.TDifficulty
public class GameTDifficulty
{
    public long Value;
}

// NNet.Game.c_maxAIBuilds
public class Gamec_maxAIBuilds
{
    public long Value;
}

// NNet.Game.TAIBuild
public class GameTAIBuild
{
    public long Value;
}

// NNet.Game.c_maxResources
public class Gamec_maxResources
{
    public long Value;
}

// NNet.Game.c_syncSoundLengthMax
public class Gamec_syncSoundLengthMax
{
    public long Value;
}

// NNet.Game.EClientDebugFlags
public class GameEClientDebugFlags
{
    public long Value;
}

// NNet.Game.c_maxControls
public class Gamec_maxControls
{
    public long Value;
}

// NNet.Game.TControlId
public class GameTControlId
{
    public long Value;
}

// NNet.Game.TControlCount
public class GameTControlCount
{
    public long Value;
}

// NNet.Game.c_maxLobbySlots
public class Gamec_maxLobbySlots
{
    public long Value;
}

// NNet.Game.TLobbySlotCount
public class GameTLobbySlotCount
{
    public long Value;
}

// NNet.Game.TLobbySlotId
public class GameTLobbySlotId
{
    public long Value;
}

// NNet.Game.c_maxArtifacts
public class Gamec_maxArtifacts
{
    public long Value;
}

// NNet.Game.c_maxCommanderMasteryTalents
public class Gamec_maxCommanderMasteryTalents
{
    public long Value;
}

// NNet.Game.c_maxRewards
public class Gamec_maxRewards
{
    public long Value;
}

// NNet.Game.c_maxLicenses
public class Gamec_maxLicenses
{
    public long Value;
}

// NNet.Game.c_maxPlayers
public class Gamec_maxPlayers
{
    public long Value;
}

// NNet.Game.TPlayerId
public class GameTPlayerId
{
    public long Value;
}

// NNet.Game.TPlayerCount
public class GameTPlayerCount
{
    public long Value;
}

// NNet.Game.c_maxSelection
public class Gamec_maxSelection
{
    public long Value;
}

// NNet.Game.c_maxSelectionSubgroups
public class Gamec_maxSelectionSubgroups
{
    public long Value;
}

// NNet.Game.c_maxControlGroups
public class Gamec_maxControlGroups
{
    public long Value;
}

// NNet.Game.c_maxSentAddSubgroups
public class Gamec_maxSentAddSubgroups
{
    public long Value;
}

// NNet.Game.c_maxSentAddUnitTags
public class Gamec_maxSentAddUnitTags
{
    public long Value;
}

// NNet.Game.TSelectionCount
public class GameTSelectionCount
{
    public long Value;
}

// NNet.Game.TSelectionIndex
public class GameTSelectionIndex
{
    public long Value;
}

// NNet.Game.TSubgroupPriority
public class GameTSubgroupPriority
{
    public long Value;
}

// NNet.Game.TSubgroupCount
public class GameTSubgroupCount
{
    public long Value;
}

// NNet.Game.TSubgroupIndex
public class GameTSubgroupIndex
{
    public long Value;
}

// NNet.Game.TControlGroupCount
public class GameTControlGroupCount
{
    public long Value;
}

// NNet.Game.TControlGroupIndex
public class GameTControlGroupIndex
{
    public long Value;
}

// NNet.Game.TControlGroupId
public class GameTControlGroupId
{
    public long Value;
}

// NNet.Game.c_sessionSyncChecksumsMax
public class Gamec_sessionSyncChecksumsMax
{
    public long Value;
}

// NNet.Game.c_gameSyncChecksumsMax
public class Gamec_gameSyncChecksumsMax
{
    public long Value;
}

// NNet.Game.c_maxTeams
public class Gamec_maxTeams
{
    public long Value;
}

// NNet.Game.TTeamId
public class GameTTeamId
{
    public long Value;
}

// NNet.Game.TTeamCount
public class GameTTeamCount
{
    public long Value;
}

// NNet.CAllowedRaces
public class CAllowedRaces
{
    public List<byte> Value;
}

// NNet.CAllowedObserveTypes
public class CAllowedObserveTypes
{
    public List<byte> Value;
}

// NNet.Game.CAllowedColors
public class GameCAllowedColors
{
    public List<byte> Value;
}

// NNet.Game.CAllowedDifficulty
public class GameCAllowedDifficulty
{
    public List<byte> Value;
}

// NNet.Game.CAllowedAIBuild
public class GameCAllowedAIBuild
{
    public List<byte> Value;
}

// NNet.Game.CAllowedControls
public class GameCAllowedControls
{
    public List<byte> Value;
}

// NNet.Game.SelectionMaskType
public class GameSelectionMaskType
{
    public List<byte> Value;
}

// NNet.Game.TQueryID
public class GameTQueryID
{
    public uint16 Value;
}

// NNet.Game.c_invalidQueryId
public class Gamec_invalidQueryId
{
    public uint16 Value;
}

// NNet.Game.TAchievementLink
public class GameTAchievementLink
{
    public uint16 Value;
}

// NNet.Game.TAchievementTermLink
public class GameTAchievementTermLink
{
    public uint16 Value;
}

// NNet.Game.TButtonLink
public class GameTButtonLink
{
    public uint16 Value;
}

// NNet.Game.TUnitLink
public class GameTUnitLink
{
    public uint16 Value;
}

// NNet.Game.TUnitTag
public class GameTUnitTag
{
    public uint32 Value;
}

// NNet.Game.TTriggerThreadTag
public class GameTTriggerThreadTag
{
    public uint32 Value;
}

// NNet.Game.TTriggerSoundTag
public class GameTTriggerSoundTag
{
    public uint32 Value;
}

// NNet.Game.TAbilLink
public class GameTAbilLink
{
    public uint16 Value;
}

// NNet.Game.TFixedBits
public class GameTFixedBits
{
    public int32 Value;
}

// NNet.Game.TFixedMiniBitsUnsigned
public class GameTFixedMiniBitsUnsigned
{
    public uint16 Value;
}

// NNet.Game.TFixedMiniBitsSigned
public class GameTFixedMiniBitsSigned
{
    public int16 Value;
}

// NNet.Game.TPlayerLogoIndex
public class GameTPlayerLogoIndex
{
    public uint32 Value;
}

// NNet.Game.c_maxPlayerLogoIndex
public class Gamec_maxPlayerLogoIndex
{
    public GameTPlayerLogoIndex Value;
}

// NNet.Game.THeroLink
public class GameTHeroLink
{
    public uint16 Value;
}

// NNet.Game.TReward
public class GameTReward
{
    public uint32 Value;
}

// NNet.Game.TLicense
public class GameTLicense
{
    public uint32 Value;
}

// NNet.Game.TSyncChecksum
public class GameTSyncChecksum
{
    public uint32 Value;
}

// NNet.Game.TSyncValue
public class GameTSyncValue
{
    public uint16 Value;
}

// NNet.Game.c_ignoreSyncValue
public class Gamec_ignoreSyncValue
{
    public GameTSyncValue Value;
}

// NNet.Game.CPlayerDetailsArray
public class GameCPlayerDetailsArray
{
    public GameSPlayerDetails Value;
}

// NNet.CUserInitialDataArray
public class CUserInitialDataArray
{
    public SUserInitialData Value;
}

// NNet.Game.CModPaths
public class GameCModPaths
{
    public CFilePath Value;
}

// NNet.Game.CCacheHandles
public class GameCCacheHandles
{
    public GameCCacheHandle Value;
}

// NNet.Game.SSlotDescriptions
public class GameSSlotDescriptions
{
    public GameSSlotDescription Value;
}

// NNet.Game.CArtifactArray
public class GameCArtifactArray
{
    public CArtifactHandle Value;
}

// NNet.Game.CCommanderMasteryTalentArray
public class GameCCommanderMasteryTalentArray
{
    public uint32 Value;
}

// NNet.Game.CRewardArray
public class GameCRewardArray
{
    public GameTReward Value;
}

// NNet.Game.CRewardOverrideArray
public class GameCRewardOverrideArray
{
    public GameCRewardOverride Value;
}

// NNet.Game.CLicenseArray
public class GameCLicenseArray
{
    public GameTLicense Value;
}

// NNet.Game.CLobbySlotArray
public class GameCLobbySlotArray
{
    public GameSLobbySlot Value;
}

// NNet.Game.SelectionIndexArrayType
public class GameSelectionIndexArrayType
{
    public GameTSelectionIndex Value;
}

// NNet.CFilePath
public class CFilePath
{
    public List<byte> Value;
}

// NNet.CUserName
public class CUserName
{
    public List<byte> Value;
}

// NNet.CClanTag
public class CClanTag
{
    public List<byte> Value;
}

// NNet.CHeroHandle
public class CHeroHandle
{
    public List<byte> Value;
}

// NNet.CSkinHandle
public class CSkinHandle
{
    public List<byte> Value;
}

// NNet.CMountHandle
public class CMountHandle
{
    public List<byte> Value;
}

// NNet.CArtifactHandle
public class CArtifactHandle
{
    public List<byte> Value;
}

// NNet.CToonHandle
public class CToonHandle
{
    public List<byte> Value;
}

// NNet.CCommanderHandle
public class CCommanderHandle
{
    public List<byte> Value;
}

// NNet.Game.CCheatString
public class GameCCheatString
{
    public List<byte> Value;
}

// NNet.Game.CTriggerChatMessageString
public class GameCTriggerChatMessageString
{
    public List<byte> Value;
}

// NNet.Game.CGameCacheName
public class GameCGameCacheName
{
    public List<byte> Value;
}

// NNet.Game.CAuthorName
public class GameCAuthorName
{
    public List<byte> Value;
}

// NNet.Game.TFlexLicenseName
public class GameTFlexLicenseName
{
    public List<byte> Value;
}

// NNet.Game.TFlexLicenseAttributeName
public class GameTFlexLicenseAttributeName
{
    public List<byte> Value;
}

// NNet.Game.TFlexLicenseAttributeValue
public class GameTFlexLicenseAttributeValue
{
    public List<byte> Value;
}

// NNet.Game.CChatString
public class GameCChatString
{
    public List<byte> Value;
}

// NNet.CCacheHandle
public class CCacheHandle
{
    public List<byte> Value;
}

// NNet.Game.CCacheHandle
public class GameCCacheHandle
{
    public List<byte> Value;
}

