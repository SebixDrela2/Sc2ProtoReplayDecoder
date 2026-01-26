
namespace Sc2ReplayAnalyzer.Json.protocol16939;

// NNet.SVarUint32
public abstract class SVarUint32 { }

// m_uint6
public class m_uint6 : SVarUint32
{
    public byte Value;
}

// m_uint14
public class m_uint14 : SVarUint32
{
    public uint Value;
}

// m_uint22
public class m_uint22 : SVarUint32
{
    public uint Value;
}

// m_uint32
public class m_uint32 : SVarUint32
{
    public uint Value;
}

// NNet.Game.SCmdData
public abstract class GameSCmdData { }

// TargetPoint
public class TargetPoint : GameSCmdData
{
    public GameSMapCoord3D Value;
}

// TargetUnit
public class TargetUnit : GameSCmdData
{
    public GameSCmdDataTargetUnit Value;
}

// Data
public class Data : GameSCmdData
{
    public uint32 Value;
}

// m_eventData
public abstract class m_eventData { }

// Checked
public class Checked : m_eventData
{
    public bool Value;
}

// ValueChanged
public class ValueChanged : m_eventData
{
    public uint32 Value;
}

// SelectionChanged
public class SelectionChanged : m_eventData
{
    public int32 Value;
}

// TextChanged
public class TextChanged : m_eventData
{
    public GameCChatString Value;
}

// NNet.Game.SLobbySlotChange
public abstract class GameSLobbySlotChange { }

// m_control
public class m_control : GameSLobbySlotChange
{
    public GameTControlId Value;
}

// m_userId
public class m_userId : GameSLobbySlotChange
{
    public Option<TUserId> Value;
}

// m_teamId
public class m_teamId : GameSLobbySlotChange
{
    public GameTTeamId Value;
}

// m_colorPref
public class m_colorPref : GameSLobbySlotChange
{
    public GameTColorPreference Value;
}

// m_racePref
public class m_racePref : GameSLobbySlotChange
{
    public TRacePreference Value;
}

// m_difficulty
public class m_difficulty : GameSLobbySlotChange
{
    public GameTDifficulty Value;
}

// m_handicap
public class m_handicap : GameSLobbySlotChange
{
    public GameTHandicap Value;
}

// m_observe
public class m_observe : GameSLobbySlotChange
{
    public EObserve Value;
}

// NNet.Game.SSelectionMask
public abstract class GameSSelectionMask { }

// Mask
public class Mask : GameSSelectionMask
{
    public GameSelectionMaskType Value;
}

// OneIndices
public class OneIndices : GameSSelectionMask
{
    public GameSelectionIndexArrayType Value;
}

// ZeroIndices
public class ZeroIndices : GameSSelectionMask
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
    public uint m_build;
    public uint m_baseBuild;
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
    public uint m_programId;
    public uint m_realm;
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
    public uint m_handicap;
    public EObserve m_observe;
    public GameEResultDetails m_result;
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
    public List<byte> m_description;
    public List<byte> m_imageFilePath;
    public List<byte> m_mapFileName;
    public Option<List<List<byte>>> m_cacheHandles;
    public bool m_miniSave;
    public GameEGameSpeed m_gameSpeed;
    public uint m_defaultDifficulty;
}

// NNet.Replay.SHeader
public class ReplaySHeader
{
    public List<byte> m_signature;
    public SVersion m_version;
    public byte m_type;
    public uint m_elapsedGameLoops;
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
    public uint32 m_randomSeed;
    public TRacePreference m_racePreference;
    public TTeamPreference m_teamPreference;
    public bool m_testMap;
    public bool m_testAuto;
    public EObserve m_observe;
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
    public uint8 m_targetUnitFlags;
    public uint8 m_timer;
    public GameTUnitTag m_tag;
    public GameTUnitLink m_snapshotUnitLink;
    public Option<GameTPlayerId> m_snapshotPlayerId;
    public GameSMapCoord3D m_snapshotPoint;
}

// NNet.Game.SSetLobbySlotEvent
public class GameSSetLobbySlotEvent
{
    public GameTLobbySlotId m_slotId;
    public GameSLobbySlotChange m_slotChange;
}

// NNet.Game.SDropUserEvent
public class GameSDropUserEvent
{
    public TUserId m_userId;
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

// NNet.Game.SUserOptionsEvent
public class GameSUserOptionsEvent
{
    public bool m_developmentCheatsEnabled;
    public bool m_multiplayerCheatsEnabled;
    public bool m_syncChecksummingEnabled;
    public bool m_isMapToMapTransition;
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

// NNet.Game.SRestartGameEvent
public class GameSRestartGameEvent
{
    public uint32 m_reloadGameLoop;
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

// NNet.Game.SPlayerLeaveEvent
public class GameSPlayerLeaveEvent
{
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
    public GameSCmdData m_data;
    public Option<GameTUnitTag> m_otherUnit;
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
    public GameSSelectionMask m_mask;
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
    public int8 m_autocast;
    public GameTUnitTag m_targetUnitTag;
    public GameTUnitLink m_targetUnitSnapshotUnitLink;
    public Option<GameTPlayerId> m_targetUnitSnapshotPlayerId;
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
    public m_eventData m_eventData;
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

// NNet.Game.STriggerSoundOffsetEvent
public class GameSTriggerSoundOffsetEvent
{
    public GameTTriggerSoundTag m_sound;
}

// NNet.Game.STriggerTransmissionOffsetEvent
public class GameSTriggerTransmissionOffsetEvent
{
    public int32 m_transmissionId;
}

// NNet.Game.STriggerTransmissionCompleteEvent
public class GameSTriggerTransmissionCompleteEvent
{
    public int32 m_transmissionId;
}

// NNet.Game.SCameraUpdateEvent
public class GameSCameraUpdateEvent
{
    public GameSPointMini m_target;
    public Option<GameTFixedMiniBits> m_distance;
    public Option<GameTFixedMiniBits> m_pitch;
    public Option<GameTFixedMiniBits> m_yaw;
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
    public uint32 m_posXUI;
    public uint32 m_posYUI;
    public GameTFixedBits m_posXWorld;
    public GameTFixedBits m_posYWorld;
    public GameTFixedBits m_posZWorld;
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

// NNet.Game.STriggerResearchPanelSelectionChangedEvent
public class GameSTriggerResearchPanelSelectionChangedEvent
{
    public int32 m_researchItemId;
}

// NNet.Game.SLagMessageEvent
public class GameSLagMessageEvent
{
    public GameTPlayerId m_laggingPlayerId;
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
    public GameTFixedUInt m_decrementMs;
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

// NNet.Game.STriggerCameraMoveEvent
public class GameSTriggerCameraMoveEvent
{
    public int8 m_reason;
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
    public GameTFixedMiniBits x;
    public GameTFixedMiniBits y;
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
    public bool m_ranked;
    public bool m_noVictoryOrDefeat;
    public GameEOptionFog m_fog;
    public GameEOptionObservers m_observers;
    public GameEOptionUserDifficulty m_userDifficulty;
}

// NNet.Game.SSlotDescription
public class GameSSlotDescription
{
    public GameCAllowedColors m_allowedColors;
    public CAllowedRaces m_allowedRaces;
    public GameCAllowedDifficulty m_allowedDifficulty;
    public GameCAllowedControls m_allowedControls;
    public CAllowedObserveTypes m_allowedObserveTypes;
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
    public GameCCacheHandles m_cacheHandles;
    public bool m_isBlizzardMap;
    public bool m_isPremadeFFA;
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
    public GameTHandicap m_handicap;
    public EObserve m_observe;
    public GameCRewardArray m_rewards;
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
    public uint32 m_gameDuration;
    public GameTDifficulty m_defaultDifficulty;
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

// NNet.Game.SSelectionDeltaSubgroup
public class GameSSelectionDeltaSubgroup
{
    public GameTUnitLink m_unitLink;
    public GameTSubgroupPriority m_intraSubgroupPriority;
    public GameTSelectionCount m_count;
}

// NNet.Game.SSelectionDelta
public class GameSSelectionDelta
{
    public GameTSubgroupIndex m_subgroupIndex;
    public GameSSelectionMask m_removeMask;
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
    public uint32 m_gameLoop;
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

// NNet.ELeaveReason
public abstract record class ELeaveReason { }
// e_userLeft
public record class ELeaveReason_e_userLeft() : ELeaveReason;
// e_userDropped
public record class ELeaveReason_e_userDropped() : ELeaveReason;
// e_userBanned
public record class ELeaveReason_e_userBanned() : ELeaveReason;
// e_userVictory
public record class ELeaveReason_e_userVictory() : ELeaveReason;
// e_userDefeat
public record class ELeaveReason_e_userDefeat() : ELeaveReason;
// e_userTied
public record class ELeaveReason_e_userTied() : ELeaveReason;
// e_userDesynced
public record class ELeaveReason_e_userDesynced() : ELeaveReason;
// e_userOutOfTime
public record class ELeaveReason_e_userOutOfTime() : ELeaveReason;
// e_weWereUnresponsive
public record class ELeaveReason_e_weWereUnresponsive() : ELeaveReason;
// e_weContinuedAlone
public record class ELeaveReason_e_weContinuedAlone() : ELeaveReason;
// e_replayDesynced
public record class ELeaveReason_e_replayDesynced() : ELeaveReason;

// NNet.Game.ESynchronous
public abstract record class GameESynchronous { }
// e_local
public record class GameESynchronous_e_local() : GameESynchronous;
// e_session
public record class GameESynchronous_e_session(GameSSetLobbySlotEvent Value) : GameESynchronous;
// e_game
public record class GameESynchronous_e_game(GameSBankFileEvent Value) : GameESynchronous;

// NNet.Game.ESynthesized
public abstract record class GameESynthesized { }
// e_synthesized
public record class GameESynthesized_e_synthesized(GameSDropOurselvesEvent Value) : GameESynthesized;
// e_notSynthesized
public record class GameESynthesized_e_notSynthesized(GameSSetLobbySlotEvent Value) : GameESynthesized;

// NNet.Game.EDebug
public abstract record class GameEDebug { }
// e_debug
public record class GameEDebug_e_debug(GameSSingleStepGameEvent Value) : GameEDebug;
// e_notDebug
public record class GameEDebug_e_notDebug(GameSSetLobbySlotEvent Value) : GameEDebug;

// NNet.Game.EEventId
public abstract record class GameEEventId { }
// e_setLobbySlot
public record class GameEEventId_e_setLobbySlot(GameSSetLobbySlotEvent Value) : GameEEventId;
// e_dropUser
public record class GameEEventId_e_dropUser(GameSDropUserEvent Value) : GameEEventId;
// e_startGame
public record class GameEEventId_e_startGame(GameSStartGameEvent Value) : GameEEventId;
// e_dropOurselves
public record class GameEEventId_e_dropOurselves(GameSDropOurselvesEvent Value) : GameEEventId;
// e_userFinishedLoading
public record class GameEEventId_e_userFinishedLoading(GameSUserFinishedLoadingEvent Value) : GameEEventId;
// e_userFinishedLoadingSync
public record class GameEEventId_e_userFinishedLoadingSync(GameSUserFinishedLoadingSyncEvent Value) : GameEEventId;
// e_setGameDuration
public record class GameEEventId_e_setGameDuration(GameSSetGameDurationEvent Value) : GameEEventId;
// e_bankFile
public record class GameEEventId_e_bankFile(GameSBankFileEvent Value) : GameEEventId;
// e_bankSection
public record class GameEEventId_e_bankSection(GameSBankSectionEvent Value) : GameEEventId;
// e_bankKey
public record class GameEEventId_e_bankKey(GameSBankKeyEvent Value) : GameEEventId;
// e_bankValue
public record class GameEEventId_e_bankValue(GameSBankValueEvent Value) : GameEEventId;
// e_userOptions
public record class GameEEventId_e_userOptions(GameSUserOptionsEvent Value) : GameEEventId;
// e_turn
public record class GameEEventId_e_turn(GameSTurnEvent Value) : GameEEventId;
// e_pauseGame
public record class GameEEventId_e_pauseGame(GameSPauseGameEvent Value) : GameEEventId;
// e_unpauseGame
public record class GameEEventId_e_unpauseGame(GameSUnpauseGameEvent Value) : GameEEventId;
// e_singleStepGame
public record class GameEEventId_e_singleStepGame(GameSSingleStepGameEvent Value) : GameEEventId;
// e_setGameSpeed
public record class GameEEventId_e_setGameSpeed(GameSSetGameSpeedEvent Value) : GameEEventId;
// e_addGameSpeed
public record class GameEEventId_e_addGameSpeed(GameSAddGameSpeedEvent Value) : GameEEventId;
// e_restartGame
public record class GameEEventId_e_restartGame(GameSRestartGameEvent Value) : GameEEventId;
// e_saveGame
public record class GameEEventId_e_saveGame(GameSSaveGameEvent Value) : GameEEventId;
// e_saveGameDone
public record class GameEEventId_e_saveGameDone(GameSSaveGameDoneEvent Value) : GameEEventId;
// e_sessionCheat
public record class GameEEventId_e_sessionCheat(GameSSessionCheatEvent Value) : GameEEventId;
// e_playerLeave
public record class GameEEventId_e_playerLeave(GameSPlayerLeaveEvent Value) : GameEEventId;
// e_gameCheat
public record class GameEEventId_e_gameCheat(GameSGameCheatEvent Value) : GameEEventId;
// e_cmd
public record class GameEEventId_e_cmd(GameSCmdEvent Value) : GameEEventId;
// e_selectionDelta
public record class GameEEventId_e_selectionDelta(GameSSelectionDeltaEvent Value) : GameEEventId;
// e_controlGroupUpdate
public record class GameEEventId_e_controlGroupUpdate(GameSControlGroupUpdateEvent Value) : GameEEventId;
// e_selectionSyncCheck
public record class GameEEventId_e_selectionSyncCheck(GameSSelectionSyncCheckEvent Value) : GameEEventId;
// e_resourceTrade
public record class GameEEventId_e_resourceTrade(GameSResourceTradeEvent Value) : GameEEventId;
// e_triggerChatMessage
public record class GameEEventId_e_triggerChatMessage(GameSTriggerChatMessageEvent Value) : GameEEventId;
// e_aiCommunicate
public record class GameEEventId_e_aiCommunicate(GameSAICommunicateEvent Value) : GameEEventId;
// e_setAbsoluteGameSpeed
public record class GameEEventId_e_setAbsoluteGameSpeed(GameSSetAbsoluteGameSpeedEvent Value) : GameEEventId;
// e_addAbsoluteGameSpeed
public record class GameEEventId_e_addAbsoluteGameSpeed(GameSAddAbsoluteGameSpeedEvent Value) : GameEEventId;
// e_broadcastCheat
public record class GameEEventId_e_broadcastCheat(GameSBroadcastCheatEvent Value) : GameEEventId;
// e_alliance
public record class GameEEventId_e_alliance(GameSAllianceEvent Value) : GameEEventId;
// e_unitClick
public record class GameEEventId_e_unitClick(GameSUnitClickEvent Value) : GameEEventId;
// e_unitHighlight
public record class GameEEventId_e_unitHighlight(GameSUnitHighlightEvent Value) : GameEEventId;
// e_triggerReplySelected
public record class GameEEventId_e_triggerReplySelected(GameSTriggerReplySelectedEvent Value) : GameEEventId;
// e_triggerSkipped
public record class GameEEventId_e_triggerSkipped(GameSTriggerSkippedEvent Value) : GameEEventId;
// e_triggerSoundLengthQuery
public record class GameEEventId_e_triggerSoundLengthQuery(GameSTriggerSoundLengthQueryEvent Value) : GameEEventId;
// e_triggerSoundOffset
public record class GameEEventId_e_triggerSoundOffset(GameSTriggerSoundOffsetEvent Value) : GameEEventId;
// e_triggerTransmissionOffset
public record class GameEEventId_e_triggerTransmissionOffset(GameSTriggerTransmissionOffsetEvent Value) : GameEEventId;
// e_triggerTransmissionComplete
public record class GameEEventId_e_triggerTransmissionComplete(GameSTriggerTransmissionCompleteEvent Value) : GameEEventId;
// e_cameraUpdate
public record class GameEEventId_e_cameraUpdate(GameSCameraUpdateEvent Value) : GameEEventId;
// e_triggerAbortMission
public record class GameEEventId_e_triggerAbortMission(GameSTriggerAbortMissionEvent Value) : GameEEventId;
// e_triggerPurchaseMade
public record class GameEEventId_e_triggerPurchaseMade(GameSTriggerPurchaseMadeEvent Value) : GameEEventId;
// e_triggerPurchaseExit
public record class GameEEventId_e_triggerPurchaseExit(GameSTriggerPurchaseExitEvent Value) : GameEEventId;
// e_triggerPlanetMissionLaunched
public record class GameEEventId_e_triggerPlanetMissionLaunched(GameSTriggerPlanetMissionLaunchedEvent Value) : GameEEventId;
// e_triggerPlanetPanelCanceled
public record class GameEEventId_e_triggerPlanetPanelCanceled(GameSTriggerPlanetPanelCanceledEvent Value) : GameEEventId;
// e_triggerDialogControl
public record class GameEEventId_e_triggerDialogControl(GameSTriggerDialogControlEvent Value) : GameEEventId;
// e_triggerSoundLengthSync
public record class GameEEventId_e_triggerSoundLengthSync(GameSTriggerSoundLengthSyncEvent Value) : GameEEventId;
// e_triggerConversationSkipped
public record class GameEEventId_e_triggerConversationSkipped(GameSTriggerConversationSkippedEvent Value) : GameEEventId;
// e_triggerMouseClicked
public record class GameEEventId_e_triggerMouseClicked(GameSTriggerMouseClickedEvent Value) : GameEEventId;
// e_triggerPlanetPanelPanelReplay
public record class GameEEventId_e_triggerPlanetPanelPanelReplay(GameSTriggerPlanetPanelReplayEvent Value) : GameEEventId;
// e_triggerSoundtrackDone
public record class GameEEventId_e_triggerSoundtrackDone(GameSTriggerSoundtrackDoneEvent Value) : GameEEventId;
// e_triggerPlanetMissionSelected
public record class GameEEventId_e_triggerPlanetMissionSelected(GameSTriggerPlanetMissionSelectedEvent Value) : GameEEventId;
// e_triggerKeyPressed
public record class GameEEventId_e_triggerKeyPressed(GameSTriggerKeyPressedEvent Value) : GameEEventId;
// e_triggerMovieFunction
public record class GameEEventId_e_triggerMovieFunction(GameSTriggerMovieFunctionEvent Value) : GameEEventId;
// e_triggerPlanetPanelPanelBirthComplete
public record class GameEEventId_e_triggerPlanetPanelPanelBirthComplete(GameSTriggerPlanetPanelBirthCompleteEvent Value) : GameEEventId;
// e_triggerPlanetPanelPanelDeathComplete
public record class GameEEventId_e_triggerPlanetPanelPanelDeathComplete(GameSTriggerPlanetPanelDeathCompleteEvent Value) : GameEEventId;
// e_resourceRequest
public record class GameEEventId_e_resourceRequest(GameSResourceRequestEvent Value) : GameEEventId;
// e_resourceRequestFulfill
public record class GameEEventId_e_resourceRequestFulfill(GameSResourceRequestFulfillEvent Value) : GameEEventId;
// e_resourceRequestCancel
public record class GameEEventId_e_resourceRequestCancel(GameSResourceRequestCancelEvent Value) : GameEEventId;
// e_triggerResearchPanelExit
public record class GameEEventId_e_triggerResearchPanelExit(GameSTriggerResearchPanelExitEvent Value) : GameEEventId;
// e_triggerResearchPanelPurchase
public record class GameEEventId_e_triggerResearchPanelPurchase(GameSTriggerResearchPanelPurchaseEvent Value) : GameEEventId;
// e_triggerResearchPanelSelectionChanged
public record class GameEEventId_e_triggerResearchPanelSelectionChanged(GameSTriggerResearchPanelSelectionChangedEvent Value) : GameEEventId;
// e_lagMessage
public record class GameEEventId_e_lagMessage(GameSLagMessageEvent Value) : GameEEventId;
// e_triggerMercenaryPanelExit
public record class GameEEventId_e_triggerMercenaryPanelExit(GameSTriggerMercenaryPanelExitEvent Value) : GameEEventId;
// e_triggerMercenaryPanelPurchase
public record class GameEEventId_e_triggerMercenaryPanelPurchase(GameSTriggerMercenaryPanelPurchaseEvent Value) : GameEEventId;
// e_triggerMercenaryPanelSelectionChanged
public record class GameEEventId_e_triggerMercenaryPanelSelectionChanged(GameSTriggerMercenaryPanelSelectionChangedEvent Value) : GameEEventId;
// e_triggerVictoryPanelExit
public record class GameEEventId_e_triggerVictoryPanelExit(GameSTriggerVictoryPanelExitEvent Value) : GameEEventId;
// e_triggerBattleReportPanelExit
public record class GameEEventId_e_triggerBattleReportPanelExit(GameSTriggerBattleReportPanelExitEvent Value) : GameEEventId;
// e_triggerBattleReportPanelPlayMission
public record class GameEEventId_e_triggerBattleReportPanelPlayMission(GameSTriggerBattleReportPanelPlayMissionEvent Value) : GameEEventId;
// e_triggerBattleReportPanelPlayScene
public record class GameEEventId_e_triggerBattleReportPanelPlayScene(GameSTriggerBattleReportPanelPlaySceneEvent Value) : GameEEventId;
// e_triggerBattleReportSelectionChanged
public record class GameEEventId_e_triggerBattleReportSelectionChanged(GameSTriggerBattleReportPanelSelectionChangedEvent Value) : GameEEventId;
// e_triggerVictoryPanelPlayMissionAgain
public record class GameEEventId_e_triggerVictoryPanelPlayMissionAgain(GameSTriggerVictoryPanelPlayMissionAgainEvent Value) : GameEEventId;
// e_triggerMovieStarted
public record class GameEEventId_e_triggerMovieStarted(GameSTriggerMovieStartedEvent Value) : GameEEventId;
// e_triggerMovieFinished
public record class GameEEventId_e_triggerMovieFinished(GameSTriggerMovieFinishedEvent Value) : GameEEventId;
// e_decrementGameTimeRemaining
public record class GameEEventId_e_decrementGameTimeRemaining(GameSDecrementGameTimeRemainingEvent Value) : GameEEventId;
// e_triggerPortraitLoaded
public record class GameEEventId_e_triggerPortraitLoaded(GameSTriggerPortraitLoadedEvent Value) : GameEEventId;
// e_triggerQueryDialogDismissed
public record class GameEEventId_e_triggerQueryDialogDismissed(GameSTriggerCustomDialogDismissedEvent Value) : GameEEventId;
// e_triggerGameMenuItemSelected
public record class GameEEventId_e_triggerGameMenuItemSelected(GameSTriggerGameMenuItemSelectedEvent Value) : GameEEventId;
// e_triggerCameraMove
public record class GameEEventId_e_triggerCameraMove(GameSTriggerCameraMoveEvent Value) : GameEEventId;
// e_triggerPurchasePanelSelectedPurchaseItemChanged
public record class GameEEventId_e_triggerPurchasePanelSelectedPurchaseItemChanged(GameSTriggerPurchasePanelSelectedPurchaseItemChangedEvent Value) : GameEEventId;
// e_triggerPurchasePanelSelectedPurchaseCategoryChanged
public record class GameEEventId_e_triggerPurchasePanelSelectedPurchaseCategoryChanged(GameSTriggerPurchasePanelSelectedPurchaseCategoryChangedEvent Value) : GameEEventId;
// e_triggerButtonPressed
public record class GameEEventId_e_triggerButtonPressed(GameSTriggerButtonPressedEvent Value) : GameEEventId;
// e_triggerGameCreditsFinished
public record class GameEEventId_e_triggerGameCreditsFinished(GameSTriggerGameCreditsFinishedEvent Value) : GameEEventId;

// NNet.Game.EPhase
public abstract record class GameEPhase { }
// e_initializing
public record class GameEPhase_e_initializing() : GameEPhase;
// e_lobby
public record class GameEPhase_e_lobby() : GameEPhase;
// e_closed
public record class GameEPhase_e_closed() : GameEPhase;
// e_loading
public record class GameEPhase_e_loading() : GameEPhase;
// e_playing
public record class GameEPhase_e_playing() : GameEPhase;
// e_gameover
public record class GameEPhase_e_gameover() : GameEPhase;

// NNet.Game.EConversationSkip
public abstract record class GameEConversationSkip { }
// e_skipOneLine
public record class GameEConversationSkip_e_skipOneLine() : GameEConversationSkip;
// e_skipAllLines
public record class GameEConversationSkip_e_skipAllLines() : GameEConversationSkip;

// NNet.Game.EOptionFog
public abstract record class GameEOptionFog { }
// e_default
public record class GameEOptionFog_e_default() : GameEOptionFog;
// e_hideTerrain
public record class GameEOptionFog_e_hideTerrain() : GameEOptionFog;
// e_mapExplored
public record class GameEOptionFog_e_mapExplored() : GameEOptionFog;
// e_alwaysVisible
public record class GameEOptionFog_e_alwaysVisible() : GameEOptionFog;

// NNet.Game.EOptionObservers
public abstract record class GameEOptionObservers { }
// e_none
public record class GameEOptionObservers_e_none() : GameEOptionObservers;
// e_onJoin
public record class GameEOptionObservers_e_onJoin() : GameEOptionObservers;
// e_onJoinAndDefeat
public record class GameEOptionObservers_e_onJoinAndDefeat() : GameEOptionObservers;
// e_refereesOnJoin
public record class GameEOptionObservers_e_refereesOnJoin() : GameEOptionObservers;

// NNet.Game.EOptionUserDifficulty
public abstract record class GameEOptionUserDifficulty { }
// e_none
public record class GameEOptionUserDifficulty_e_none() : GameEOptionUserDifficulty;
// e_global
public record class GameEOptionUserDifficulty_e_global() : GameEOptionUserDifficulty;
// e_individual
public record class GameEOptionUserDifficulty_e_individual() : GameEOptionUserDifficulty;

// NNet.Game.EGameLaunch
public abstract record class GameEGameLaunch { }
// e_invalid
public record class GameEGameLaunch_e_invalid() : GameEGameLaunch;
// e_normal
public record class GameEGameLaunch_e_normal() : GameEGameLaunch;
// e_replay
public record class GameEGameLaunch_e_replay() : GameEGameLaunch;
// e_save
public record class GameEGameLaunch_e_save() : GameEGameLaunch;
// e_transition
public record class GameEGameLaunch_e_transition() : GameEGameLaunch;

// NNet.Game.EGameType
public abstract record class GameEGameType { }
// e_melee
public record class GameEGameType_e_melee() : GameEGameType;
// e_freeForAll
public record class GameEGameType_e_freeForAll() : GameEGameType;
// e_useSettings
public record class GameEGameType_e_useSettings() : GameEGameType;
// e_oneOnOne
public record class GameEGameType_e_oneOnOne() : GameEGameType;
// e_twoTeamPlay
public record class GameEGameType_e_twoTeamPlay() : GameEGameType;
// e_threeTeamPlay
public record class GameEGameType_e_threeTeamPlay() : GameEGameType;
// e_fourTeamPlay
public record class GameEGameType_e_fourTeamPlay() : GameEGameType;

// NNet.Game.EControl
public abstract record class GameEControl { }
// e_open
public record class GameEControl_e_open() : GameEControl;
// e_closed
public record class GameEControl_e_closed() : GameEControl;
// e_user
public record class GameEControl_e_user() : GameEControl;
// e_computer
public record class GameEControl_e_computer() : GameEControl;

// NNet.Game.EMessageRecipient
public abstract record class GameEMessageRecipient { }
// e_all
public record class GameEMessageRecipient_e_all() : GameEMessageRecipient;
// e_allies
public record class GameEMessageRecipient_e_allies() : GameEMessageRecipient;
// e_individual
public record class GameEMessageRecipient_e_individual() : GameEMessageRecipient;
// e_battlenet
public record class GameEMessageRecipient_e_battlenet() : GameEMessageRecipient;

// NNet.Game.EMessageId
public abstract record class GameEMessageId { }
// e_chat
public record class GameEMessageId_e_chat(GameSChatMessage Value) : GameEMessageId;
// e_ping
public record class GameEMessageId_e_ping(GameSPingMessage Value) : GameEMessageId;
// e_loadingProgress
public record class GameEMessageId_e_loadingProgress(GameSLoadingProgressMessage Value) : GameEMessageId;
// e_serverPing
public record class GameEMessageId_e_serverPing(GameSServerPingMessage Value) : GameEMessageId;

// NNet.Game.EResultCode
public abstract record class GameEResultCode { }
// e_undecided
public record class GameEResultCode_e_undecided() : GameEResultCode;
// e_loss
public record class GameEResultCode_e_loss() : GameEResultCode;
// e_tie
public record class GameEResultCode_e_tie() : GameEResultCode;
// e_win
public record class GameEResultCode_e_win() : GameEResultCode;

// NNet.Game.EControlGroupUpdate
public abstract record class GameEControlGroupUpdate { }
// e_set
public record class GameEControlGroupUpdate_e_set() : GameEControlGroupUpdate;
// e_append
public record class GameEControlGroupUpdate_e_append() : GameEControlGroupUpdate;
// e_recall
public record class GameEControlGroupUpdate_e_recall() : GameEControlGroupUpdate;
// e_clear
public record class GameEControlGroupUpdate_e_clear() : GameEControlGroupUpdate;

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

// NNet.Game.THandicap
public class GameTHandicap
{
    public long Value;
}

// NNet.Game.TDifficulty
public class GameTDifficulty
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

// NNet.Game.TFixedMiniBits
public class GameTFixedMiniBits
{
    public uint16 Value;
}

// NNet.Game.TReward
public class GameTReward
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
    public List<GameSPlayerDetails> Value;
}

// NNet.CUserInitialDataArray
public class CUserInitialDataArray
{
    public List<SUserInitialData> Value;
}

// NNet.Game.CCacheHandles
public class GameCCacheHandles
{
    public List<GameCCacheHandle> Value;
}

// NNet.Game.SSlotDescriptions
public class GameSSlotDescriptions
{
    public List<GameSSlotDescription> Value;
}

// NNet.Game.CRewardArray
public class GameCRewardArray
{
    public List<GameTReward> Value;
}

// NNet.Game.CLobbySlotArray
public class GameCLobbySlotArray
{
    public List<GameSLobbySlot> Value;
}

// NNet.Game.SelectionIndexArrayType
public class GameSelectionIndexArrayType
{
    public List<GameTSelectionIndex> Value;
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

// NNet.Game.CChatString
public class GameCChatString
{
    public List<byte> Value;
}

// NNet.Game.CCacheHandle
public class GameCCacheHandle
{
    public List<byte> Value;
}

public class ProtocolParser(BinaryReader reader) : ProtocolReader(reader)
{

    public SVarUint32 Parse_SVarUint32() 
    {
        ValidateChoiceTag();
        var variantTag = ParseVlqInt();
        
        switch (variantTag)
        {
            case 0:
            {
                var res = tagged_vlq_int();
                return new m_uint6
                {
                    Value = ProtocolConversion<byte>.From(res)
                };
            }
            break;
            case 1:
            {
                var res = tagged_vlq_int();
                return new m_uint14
                {
                    Value = ProtocolConversion<uint>.From(res)
                };
            }
            break;
            case 2:
            {
                var res = tagged_vlq_int();
                return new m_uint22
                {
                    Value = ProtocolConversion<uint>.From(res)
                };
            }
            break;
            case 3:
            {
                var res = tagged_vlq_int();
                return new m_uint32
                {
                    Value = ProtocolConversion<uint>.From(res)
                };
            }
            break;
            default:
            {
                throw new Exception("WUT CHOICE");
            }
        }
    }

    public GameSCmdData Parse_GameSCmdData() 
    {
        ValidateChoiceTag();
        var variantTag = ParseVlqInt();
        
        switch (variantTag)
        {
            case 1:
            {
                var res = Parse_GameSMapCoord3D();

                return new TargetPoint
                {
                    Value = res
                };
            }
            case 2:
            {
                var res = Parse_GameSCmdDataTargetUnit();

                return new TargetUnit
                {
                    Value = res
                };
            }
            case 3:
            {
                var res = Parse_uint32();

                return new Data
                {
                    Value = res
                };
            }
            default:
            {
                throw new Exception("WUT CHOICE");
            }
        }
    }

    public m_eventData Parse_m_eventData() 
    {
        ValidateChoiceTag();
        var variantTag = ParseVlqInt();
        
        switch (variantTag)
        {
            case 1:
            {
                var res = parse_bool();

                return new Checked
                {
                    Value = res
                };
            }
            case 2:
            {
                var res = Parse_uint32();

                return new ValueChanged
                {
                    Value = res
                };
            }
            case 3:
            {
                var res = Parse_int32();

                return new SelectionChanged
                {
                    Value = res
                };
            }
            case 4:
            {
                var res = Parse_GameCChatString();

                return new TextChanged
                {
                    Value = res
                };
            }
            default:
            {
                throw new Exception("WUT CHOICE");
            }
        }
    }

    public GameSLobbySlotChange Parse_GameSLobbySlotChange() 
    {
        ValidateChoiceTag();
        var variantTag = ParseVlqInt();
        
        switch (variantTag)
        {
            case 0:
            {
                var res = Parse_GameTControlId();

                return new m_control
                {
                    Value = res
                };
            }
            case 1:
            {
                var isProvided = parse_bool();
                var res = Parse_TUserId();

                if (isProvided)
                {
                    return new m_userId
                    {
                        Value = Option.Some(res)
                    };
                }
                else
                {
                    return new m_userId
                    {
                        Value = Option.None
                    };
                }
            }
            case 2:
            {
                var res = Parse_GameTTeamId();

                return new m_teamId
                {
                    Value = res
                };
            }
            case 3:
            {
                var res = Parse_GameTColorPreference();

                return new m_colorPref
                {
                    Value = res
                };
            }
            case 4:
            {
                var res = Parse_TRacePreference();

                return new m_racePref
                {
                    Value = res
                };
            }
            case 5:
            {
                var res = Parse_GameTDifficulty();

                return new m_difficulty
                {
                    Value = res
                };
            }
            case 6:
            {
                var res = Parse_GameTHandicap();

                return new m_handicap
                {
                    Value = res
                };
            }
            case 7:
            {
                var res = Parse_EObserve();

                return new m_observe
                {
                    Value = res
                };
            }
            default:
            {
                throw new Exception("WUT CHOICE");
            }
        }
    }

    public GameSSelectionMask Parse_GameSSelectionMask() 
    {
        ValidateChoiceTag();
        var variantTag = ParseVlqInt();
        
        switch (variantTag)
        {
            case 1:
            {
                var res = Parse_GameSelectionMaskType();

                return new Mask
                {
                    Value = res
                };
            }
            case 2:
            {
                var res = Parse_GameSelectionIndexArrayType();

                return new OneIndices
                {
                    Value = res
                };
            }
            case 3:
            {
                var res = Parse_GameSelectionIndexArrayType();

                return new ZeroIndices
                {
                    Value = res
                };
            }
            default:
            {
                throw new Exception("WUT CHOICE");
            }
        }
    }

    public SVersion Parse_SVersion() 
    {
        Option<byte> m_flags = Option.None;
        Option<byte> m_major = Option.None;
        Option<byte> m_minor = Option.None;
        Option<byte> m_revision = Option.None;
        Option<uint> m_build = Option.None;
        Option<uint> m_baseBuild = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_flags is { HasValue: false })                           
                    {
                        var parsed_m_flags = Parse_SVersion_m_flags();
                        m_flags = Option.Some(parsed_m_flags);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 1:
                {
                    if (m_major is { HasValue: false })                           
                    {
                        var parsed_m_major = Parse_SVersion_m_major();
                        m_major = Option.Some(parsed_m_major);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 2:
                {
                    if (m_minor is { HasValue: false })                           
                    {
                        var parsed_m_minor = Parse_SVersion_m_minor();
                        m_minor = Option.Some(parsed_m_minor);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 3:
                {
                    if (m_revision is { HasValue: false })                           
                    {
                        var parsed_m_revision = Parse_SVersion_m_revision();
                        m_revision = Option.Some(parsed_m_revision);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 4:
                {
                    if (m_build is { HasValue: false })                           
                    {
                        var parsed_m_build = Parse_SVersion_m_build();
                        m_build = Option.Some(parsed_m_build);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 5:
                {
                    if (m_baseBuild is { HasValue: false })                           
                    {
                        var parsed_m_baseBuild = Parse_SVersion_m_baseBuild();
                        m_baseBuild = Option.Some(parsed_m_baseBuild);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
            }
        }
        return new SVersion
        {   
            m_flags = Option.OkOrReturnMissingFieldErr(m_flags),
            m_major = Option.OkOrReturnMissingFieldErr(m_major),
            m_minor = Option.OkOrReturnMissingFieldErr(m_minor),
            m_revision = Option.OkOrReturnMissingFieldErr(m_revision),
            m_build = Option.OkOrReturnMissingFieldErr(m_build),
            m_baseBuild = Option.OkOrReturnMissingFieldErr(m_baseBuild),
        };
    }
    public byte Parse_SVersion_m_flags()
    {                             
        var m_flags = tagged_vlq_int();
        return ProtocolConversion<byte>.From(m_flags);
    }
    public byte Parse_SVersion_m_major()
    {                             
        var m_major = tagged_vlq_int();
        return ProtocolConversion<byte>.From(m_major);
    }
    public byte Parse_SVersion_m_minor()
    {                             
        var m_minor = tagged_vlq_int();
        return ProtocolConversion<byte>.From(m_minor);
    }
    public byte Parse_SVersion_m_revision()
    {                             
        var m_revision = tagged_vlq_int();
        return ProtocolConversion<byte>.From(m_revision);
    }
    public uint Parse_SVersion_m_build()
    {                             
        var m_build = tagged_vlq_int();
        return ProtocolConversion<uint>.From(m_build);
    }
    public uint Parse_SVersion_m_baseBuild()
    {                             
        var m_baseBuild = tagged_vlq_int();
        return ProtocolConversion<uint>.From(m_baseBuild);
    }

    public GameSThumbnail Parse_GameSThumbnail() 
    {
        Option<List<byte>> m_file = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        if (m_file is { HasValue: false })                           
        {
            var parsed_m_file = Parse_GameSThumbnail_m_file();
            m_file = Option.Some(parsed_m_file);
        }
        return new GameSThumbnail
        {   
            m_file = Option.OkOrReturnMissingFieldErr(m_file),
        };
    }
    public List<byte> Parse_GameSThumbnail_m_file()
    {                             
        var m_file = tagged_blob();
        return m_file;
    }

    public GameSColor Parse_GameSColor() 
    {
        Option<byte> m_a = Option.None;
        Option<byte> m_r = Option.None;
        Option<byte> m_g = Option.None;
        Option<byte> m_b = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_a is { HasValue: false })                           
                    {
                        var parsed_m_a = Parse_GameSColor_m_a();
                        m_a = Option.Some(parsed_m_a);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 1:
                {
                    if (m_r is { HasValue: false })                           
                    {
                        var parsed_m_r = Parse_GameSColor_m_r();
                        m_r = Option.Some(parsed_m_r);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 2:
                {
                    if (m_g is { HasValue: false })                           
                    {
                        var parsed_m_g = Parse_GameSColor_m_g();
                        m_g = Option.Some(parsed_m_g);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 3:
                {
                    if (m_b is { HasValue: false })                           
                    {
                        var parsed_m_b = Parse_GameSColor_m_b();
                        m_b = Option.Some(parsed_m_b);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
            }
        }
        return new GameSColor
        {   
            m_a = Option.OkOrReturnMissingFieldErr(m_a),
            m_r = Option.OkOrReturnMissingFieldErr(m_r),
            m_g = Option.OkOrReturnMissingFieldErr(m_g),
            m_b = Option.OkOrReturnMissingFieldErr(m_b),
        };
    }
    public byte Parse_GameSColor_m_a()
    {                             
        var m_a = tagged_vlq_int();
        return ProtocolConversion<byte>.From(m_a);
    }
    public byte Parse_GameSColor_m_r()
    {                             
        var m_r = tagged_vlq_int();
        return ProtocolConversion<byte>.From(m_r);
    }
    public byte Parse_GameSColor_m_g()
    {                             
        var m_g = tagged_vlq_int();
        return ProtocolConversion<byte>.From(m_g);
    }
    public byte Parse_GameSColor_m_b()
    {                             
        var m_b = tagged_vlq_int();
        return ProtocolConversion<byte>.From(m_b);
    }

    public GameSToonNameDetails Parse_GameSToonNameDetails() 
    {
        Option<byte> m_region = Option.None;
        Option<uint> m_programId = Option.None;
        Option<uint> m_realm = Option.None;
        Option<List<byte>> m_name = Option.None;
        Option<long> m_id = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_region is { HasValue: false })                           
                    {
                        var parsed_m_region = Parse_GameSToonNameDetails_m_region();
                        m_region = Option.Some(parsed_m_region);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 1:
                {
                    if (m_programId is { HasValue: false })                           
                    {
                        var parsed_m_programId = Parse_GameSToonNameDetails_m_programId();
                        m_programId = Option.Some(parsed_m_programId);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 2:
                {
                    if (m_realm is { HasValue: false })                           
                    {
                        var parsed_m_realm = Parse_GameSToonNameDetails_m_realm();
                        m_realm = Option.Some(parsed_m_realm);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 3:
                {
                    if (m_name is { HasValue: false })                           
                    {
                        var parsed_m_name = Parse_GameSToonNameDetails_m_name();
                        m_name = Option.Some(parsed_m_name);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 4:
                {
                    if (m_id is { HasValue: false })                           
                    {
                        var parsed_m_id = Parse_GameSToonNameDetails_m_id();
                        m_id = Option.Some(parsed_m_id);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
            }
        }
        return new GameSToonNameDetails
        {   
            m_region = Option.OkOrReturnMissingFieldErr(m_region),
            m_programId = Option.OkOrReturnMissingFieldErr(m_programId),
            m_realm = Option.OkOrReturnMissingFieldErr(m_realm),
            m_name = Option.OkOrReturnMissingFieldErr(m_name),
            m_id = Option.OkOrReturnMissingFieldErr(m_id),
        };
    }
    public byte Parse_GameSToonNameDetails_m_region()
    {                             
        var m_region = tagged_vlq_int();
        return ProtocolConversion<byte>.From(m_region);
    }
    public uint Parse_GameSToonNameDetails_m_programId()
    {                             
        var m_programId = tagged_fourcc();
        return m_programId;
    }
    public uint Parse_GameSToonNameDetails_m_realm()
    {                             
        var m_realm = tagged_vlq_int();
        return ProtocolConversion<uint>.From(m_realm);
    }
    public List<byte> Parse_GameSToonNameDetails_m_name()
    {                             
        var m_name = tagged_blob();
        return m_name;
    }
    public long Parse_GameSToonNameDetails_m_id()
    {                             
        var m_id = tagged_vlq_int();
        return ProtocolConversion<long>.From(m_id);
    }

    public GameSPlayerDetails Parse_GameSPlayerDetails() 
    {
        Option<List<byte>> m_name = Option.None;
        Option<GameSToonNameDetails> m_toon = Option.None;
        Option<List<byte>> m_race = Option.None;
        Option<GameSColor> m_color = Option.None;
        Option<byte> m_control = Option.None;
        Option<byte> m_teamId = Option.None;
        Option<uint> m_handicap = Option.None;
        Option<EObserve> m_observe = Option.None;
        Option<GameEResultDetails> m_result = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_name is { HasValue: false })                           
                    {
                        var parsed_m_name = Parse_GameSPlayerDetails_m_name();
                        m_name = Option.Some(parsed_m_name);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 1:
                {
                    if (m_toon is { HasValue: false })                           
                    {
                        var parsed_m_toon = Parse_GameSPlayerDetails_m_toon();
                        m_toon = Option.Some(parsed_m_toon);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 2:
                {
                    if (m_race is { HasValue: false })                           
                    {
                        var parsed_m_race = Parse_GameSPlayerDetails_m_race();
                        m_race = Option.Some(parsed_m_race);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 3:
                {
                    if (m_color is { HasValue: false })                           
                    {
                        var parsed_m_color = Parse_GameSPlayerDetails_m_color();
                        m_color = Option.Some(parsed_m_color);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 4:
                {
                    if (m_control is { HasValue: false })                           
                    {
                        var parsed_m_control = Parse_GameSPlayerDetails_m_control();
                        m_control = Option.Some(parsed_m_control);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 5:
                {
                    if (m_teamId is { HasValue: false })                           
                    {
                        var parsed_m_teamId = Parse_GameSPlayerDetails_m_teamId();
                        m_teamId = Option.Some(parsed_m_teamId);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 6:
                {
                    if (m_handicap is { HasValue: false })                           
                    {
                        var parsed_m_handicap = Parse_GameSPlayerDetails_m_handicap();
                        m_handicap = Option.Some(parsed_m_handicap);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 7:
                {
                    if (m_observe is { HasValue: false })                           
                    {
                        var parsed_m_observe = Parse_GameSPlayerDetails_m_observe();
                        m_observe = Option.Some(parsed_m_observe);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 8:
                {
                    if (m_result is { HasValue: false })                           
                    {
                        var parsed_m_result = Parse_GameSPlayerDetails_m_result();
                        m_result = Option.Some(parsed_m_result);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
            }
        }
        return new GameSPlayerDetails
        {   
            m_name = Option.OkOrReturnMissingFieldErr(m_name),
            m_toon = Option.OkOrReturnMissingFieldErr(m_toon),
            m_race = Option.OkOrReturnMissingFieldErr(m_race),
            m_color = Option.OkOrReturnMissingFieldErr(m_color),
            m_control = Option.OkOrReturnMissingFieldErr(m_control),
            m_teamId = Option.OkOrReturnMissingFieldErr(m_teamId),
            m_handicap = Option.OkOrReturnMissingFieldErr(m_handicap),
            m_observe = Option.OkOrReturnMissingFieldErr(m_observe),
            m_result = Option.OkOrReturnMissingFieldErr(m_result),
        };
    }
    public List<byte> Parse_GameSPlayerDetails_m_name()
    {                             
        var m_name = tagged_blob();
        return m_name;
    }
    public GameSToonNameDetails Parse_GameSPlayerDetails_m_toon()
    {                             
        var m_toon = Parse_GameSToonNameDetails();
        return m_toon;
    }
    public List<byte> Parse_GameSPlayerDetails_m_race()
    {                             
        var m_race = tagged_blob();
        return m_race;
    }
    public GameSColor Parse_GameSPlayerDetails_m_color()
    {                             
        var m_color = Parse_GameSColor();
        return m_color;
    }
    public byte Parse_GameSPlayerDetails_m_control()
    {                             
        var m_control = tagged_vlq_int();
        return ProtocolConversion<byte>.From(m_control);
    }
    public byte Parse_GameSPlayerDetails_m_teamId()
    {                             
        var m_teamId = tagged_vlq_int();
        return ProtocolConversion<byte>.From(m_teamId);
    }
    public uint Parse_GameSPlayerDetails_m_handicap()
    {                             
        var m_handicap = tagged_vlq_int();
        return ProtocolConversion<uint>.From(m_handicap);
    }
    public EObserve Parse_GameSPlayerDetails_m_observe()
    {                             
        var m_observe = Parse_EObserve();
        return m_observe;
    }
    public GameEResultDetails Parse_GameSPlayerDetails_m_result()
    {                             
        var m_result = Parse_GameEResultDetails();
        return m_result;
    }

    public GameSDetails Parse_GameSDetails() 
    {
        var m_playerList = Option.Some<Option<List<GameSPlayerDetails>>>(Option.None);
        Option<List<byte>> m_title = Option.None;
        Option<List<byte>> m_difficulty = Option.None;
        Option<GameSThumbnail> m_thumbnail = Option.None;
        Option<bool> m_isBlizzardMap = Option.None;
        Option<long> m_timeUTC = Option.None;
        Option<long> m_timeLocalOffset = Option.None;
        Option<List<byte>> m_description = Option.None;
        Option<List<byte>> m_imageFilePath = Option.None;
        Option<List<byte>> m_mapFileName = Option.None;
        var m_cacheHandles = Option.Some<Option<List<List<byte>>>>(Option.None);
        Option<bool> m_miniSave = Option.None;
        Option<GameEGameSpeed> m_gameSpeed = Option.None;
        Option<uint> m_defaultDifficulty = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_playerList is { HasValue: true, Value.HasValue: false })
                    {
                        var parsed_m_playerList = Parse_GameSDetails_m_playerList();
                        m_playerList = Option.Some(parsed_m_playerList);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 1:
                {
                    if (m_title is { HasValue: false })                           
                    {
                        var parsed_m_title = Parse_GameSDetails_m_title();
                        m_title = Option.Some(parsed_m_title);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 2:
                {
                    if (m_difficulty is { HasValue: false })                           
                    {
                        var parsed_m_difficulty = Parse_GameSDetails_m_difficulty();
                        m_difficulty = Option.Some(parsed_m_difficulty);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 3:
                {
                    if (m_thumbnail is { HasValue: false })                           
                    {
                        var parsed_m_thumbnail = Parse_GameSDetails_m_thumbnail();
                        m_thumbnail = Option.Some(parsed_m_thumbnail);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 4:
                {
                    if (m_isBlizzardMap is { HasValue: false })                           
                    {
                        var parsed_m_isBlizzardMap = Parse_GameSDetails_m_isBlizzardMap();
                        m_isBlizzardMap = Option.Some(parsed_m_isBlizzardMap);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 5:
                {
                    if (m_timeUTC is { HasValue: false })                           
                    {
                        var parsed_m_timeUTC = Parse_GameSDetails_m_timeUTC();
                        m_timeUTC = Option.Some(parsed_m_timeUTC);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 6:
                {
                    if (m_timeLocalOffset is { HasValue: false })                           
                    {
                        var parsed_m_timeLocalOffset = Parse_GameSDetails_m_timeLocalOffset();
                        m_timeLocalOffset = Option.Some(parsed_m_timeLocalOffset);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 7:
                {
                    if (m_description is { HasValue: false })                           
                    {
                        var parsed_m_description = Parse_GameSDetails_m_description();
                        m_description = Option.Some(parsed_m_description);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 8:
                {
                    if (m_imageFilePath is { HasValue: false })                           
                    {
                        var parsed_m_imageFilePath = Parse_GameSDetails_m_imageFilePath();
                        m_imageFilePath = Option.Some(parsed_m_imageFilePath);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 9:
                {
                    if (m_mapFileName is { HasValue: false })                           
                    {
                        var parsed_m_mapFileName = Parse_GameSDetails_m_mapFileName();
                        m_mapFileName = Option.Some(parsed_m_mapFileName);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 10:
                {
                    if (m_cacheHandles is { HasValue: true, Value.HasValue: false })
                    {
                        var parsed_m_cacheHandles = Parse_GameSDetails_m_cacheHandles();
                        m_cacheHandles = Option.Some(parsed_m_cacheHandles);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 11:
                {
                    if (m_miniSave is { HasValue: false })                           
                    {
                        var parsed_m_miniSave = Parse_GameSDetails_m_miniSave();
                        m_miniSave = Option.Some(parsed_m_miniSave);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 12:
                {
                    if (m_gameSpeed is { HasValue: false })                           
                    {
                        var parsed_m_gameSpeed = Parse_GameSDetails_m_gameSpeed();
                        m_gameSpeed = Option.Some(parsed_m_gameSpeed);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 13:
                {
                    if (m_defaultDifficulty is { HasValue: false })                           
                    {
                        var parsed_m_defaultDifficulty = Parse_GameSDetails_m_defaultDifficulty();
                        m_defaultDifficulty = Option.Some(parsed_m_defaultDifficulty);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
            }
        }
        return new GameSDetails
        {   
            m_playerList = Option.OkOrReturnMissingFieldErr(m_playerList),
            m_title = Option.OkOrReturnMissingFieldErr(m_title),
            m_difficulty = Option.OkOrReturnMissingFieldErr(m_difficulty),
            m_thumbnail = Option.OkOrReturnMissingFieldErr(m_thumbnail),
            m_isBlizzardMap = Option.OkOrReturnMissingFieldErr(m_isBlizzardMap),
            m_timeUTC = Option.OkOrReturnMissingFieldErr(m_timeUTC),
            m_timeLocalOffset = Option.OkOrReturnMissingFieldErr(m_timeLocalOffset),
            m_description = Option.OkOrReturnMissingFieldErr(m_description),
            m_imageFilePath = Option.OkOrReturnMissingFieldErr(m_imageFilePath),
            m_mapFileName = Option.OkOrReturnMissingFieldErr(m_mapFileName),
            m_cacheHandles = Option.OkOrReturnMissingFieldErr(m_cacheHandles),
            m_miniSave = Option.OkOrReturnMissingFieldErr(m_miniSave),
            m_gameSpeed = Option.OkOrReturnMissingFieldErr(m_gameSpeed),
            m_defaultDifficulty = Option.OkOrReturnMissingFieldErr(m_defaultDifficulty),
        };
    }
    public Option<List<GameSPlayerDetails>> Parse_GameSDetails_m_playerList()
    {                             
        ValidateOptTag();
        var isProvided = ReadByte();

        Option<List<GameSPlayerDetails>> m_playerList = default;
        if (isProvided != 0)
        {                                   
            ValidateArrayTag();
            var arrayLength = ParseVlqInt();
            var array = ReadList(Parse_GameSPlayerDetails, arrayLength);
            m_playerList = Option.Some(array);
        }
        else
        {
            m_playerList = Option.None;
        }

        return m_playerList;
    }
    public List<byte> Parse_GameSDetails_m_title()
    {                             
        var m_title = tagged_blob();
        return m_title;
    }
    public List<byte> Parse_GameSDetails_m_difficulty()
    {                             
        var m_difficulty = tagged_blob();
        return m_difficulty;
    }
    public GameSThumbnail Parse_GameSDetails_m_thumbnail()
    {                             
        var m_thumbnail = Parse_GameSThumbnail();
        return m_thumbnail;
    }
    public bool Parse_GameSDetails_m_isBlizzardMap()
    {                             
        var m_isBlizzardMap = tagged_bool();
        return m_isBlizzardMap;
    }
    public long Parse_GameSDetails_m_timeUTC()
    {                             
        var m_timeUTC = tagged_vlq_int();
        return ProtocolConversion<long>.From(m_timeUTC);
    }
    public long Parse_GameSDetails_m_timeLocalOffset()
    {                             
        var m_timeLocalOffset = tagged_vlq_int();
        return ProtocolConversion<long>.From(m_timeLocalOffset);
    }
    public List<byte> Parse_GameSDetails_m_description()
    {                             
        var m_description = tagged_blob();
        return m_description;
    }
    public List<byte> Parse_GameSDetails_m_imageFilePath()
    {                             
        var m_imageFilePath = tagged_blob();
        return m_imageFilePath;
    }
    public List<byte> Parse_GameSDetails_m_mapFileName()
    {                             
        var m_mapFileName = tagged_blob();
        return m_mapFileName;
    }
    public Option<List<List<byte>>> Parse_GameSDetails_m_cacheHandles()
    {                             
        ValidateOptTag();
        var isProvided = ReadByte();

        Option<List<List<byte>>> m_cacheHandles = default;
        if (isProvided != 0)
        {                                   
            ValidateArrayTag();
            var arrayLength = ParseVlqInt();
            var array = ReadList(tagged_blob, arrayLength);
            m_cacheHandles = Option.Some(array);
        }
        else
        {
            m_cacheHandles = Option.None;
        }

        return m_cacheHandles;
    }
    public bool Parse_GameSDetails_m_miniSave()
    {                             
        var m_miniSave = tagged_bool();
        return m_miniSave;
    }
    public GameEGameSpeed Parse_GameSDetails_m_gameSpeed()
    {                             
        var m_gameSpeed = Parse_GameEGameSpeed();
        return m_gameSpeed;
    }
    public uint Parse_GameSDetails_m_defaultDifficulty()
    {                             
        var m_defaultDifficulty = tagged_vlq_int();
        return ProtocolConversion<uint>.From(m_defaultDifficulty);
    }

    public ReplaySHeader Parse_ReplaySHeader() 
    {
        Option<List<byte>> m_signature = Option.None;
        Option<SVersion> m_version = Option.None;
        Option<byte> m_type = Option.None;
        Option<uint> m_elapsedGameLoops = Option.None;
        ValidateStructTag();
        var structFieldCount = ParseVlqInt();           
        for (var i = 0; i < structFieldCount; i++)
        {
            var fieldTag = ParseVlqInt();
    
            switch (fieldTag)
            {
                case 0:
                {
                    if (m_signature is { HasValue: false })                           
                    {
                        var parsed_m_signature = Parse_ReplaySHeader_m_signature();
                        m_signature = Option.Some(parsed_m_signature);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 1:
                {
                    if (m_version is { HasValue: false })                           
                    {
                        var parsed_m_version = Parse_ReplaySHeader_m_version();
                        m_version = Option.Some(parsed_m_version);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 2:
                {
                    if (m_type is { HasValue: false })                           
                    {
                        var parsed_m_type = Parse_ReplaySHeader_m_type();
                        m_type = Option.Some(parsed_m_type);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
                case 3:
                {
                    if (m_elapsedGameLoops is { HasValue: false })                           
                    {
                        var parsed_m_elapsedGameLoops = Parse_ReplaySHeader_m_elapsedGameLoops();
                        m_elapsedGameLoops = Option.Some(parsed_m_elapsedGameLoops);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Duplicate tag!");
                    }
                }
                break;
            }
        }
        return new ReplaySHeader
        {   
            m_signature = Option.OkOrReturnMissingFieldErr(m_signature),
            m_version = Option.OkOrReturnMissingFieldErr(m_version),
            m_type = Option.OkOrReturnMissingFieldErr(m_type),
            m_elapsedGameLoops = Option.OkOrReturnMissingFieldErr(m_elapsedGameLoops),
        };
    }
    public List<byte> Parse_ReplaySHeader_m_signature()
    {                             
        var m_signature = tagged_blob();
        return m_signature;
    }
    public SVersion Parse_ReplaySHeader_m_version()
    {                             
        var m_version = Parse_SVersion();
        return m_version;
    }
    public byte Parse_ReplaySHeader_m_type()
    {                             
        var m_type = tagged_vlq_int();
        return ProtocolConversion<byte>.From(m_type);
    }
    public uint Parse_ReplaySHeader_m_elapsedGameLoops()
    {                             
        var m_elapsedGameLoops = tagged_vlq_int();
        return ProtocolConversion<uint>.From(m_elapsedGameLoops);
    }

    public TRacePreference Parse_TRacePreference() 
    {
        var m_race = Option.Some<Option<TRaceId>>(Option.None);
        if (m_race is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_race = Parse_TRacePreference_m_race();
            m_race = Option.Some(parsed_m_race);
        }

        return new TRacePreference
        {   
            m_race = Option.OkOrReturnMissingFieldErr(m_race),
        };
    }

    public Option<TRaceId> Parse_TRacePreference_m_race()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_TRaceId();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public TTeamPreference Parse_TTeamPreference() 
    {
        var m_team = Option.Some<Option<uint8>>(Option.None);
        if (m_team is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_team = Parse_TTeamPreference_m_team();
            m_team = Option.Some(parsed_m_team);
        }

        return new TTeamPreference
        {   
            m_team = Option.OkOrReturnMissingFieldErr(m_team),
        };
    }

    public Option<uint8> Parse_TTeamPreference_m_team()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_uint8();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public SUserInitialData Parse_SUserInitialData() 
    {
        Option<CUserName> m_name = Option.None;
        Option<uint32> m_randomSeed = Option.None;
        Option<TRacePreference> m_racePreference = Option.None;
        Option<TTeamPreference> m_teamPreference = Option.None;
        Option<bool> m_testMap = Option.None;
        Option<bool> m_testAuto = Option.None;
        Option<EObserve> m_observe = Option.None;
        if (m_name is { HasValue: false })                           
        {
            var parsed_m_name = Parse_SUserInitialData_m_name();
            m_name = Option.Some(parsed_m_name);
        }

        if (m_randomSeed is { HasValue: false })                           
        {
            var parsed_m_randomSeed = Parse_SUserInitialData_m_randomSeed();
            m_randomSeed = Option.Some(parsed_m_randomSeed);
        }

        if (m_racePreference is { HasValue: false })                           
        {
            var parsed_m_racePreference = Parse_SUserInitialData_m_racePreference();
            m_racePreference = Option.Some(parsed_m_racePreference);
        }

        if (m_teamPreference is { HasValue: false })                           
        {
            var parsed_m_teamPreference = Parse_SUserInitialData_m_teamPreference();
            m_teamPreference = Option.Some(parsed_m_teamPreference);
        }

        if (m_testMap is { HasValue: false })                           
        {
            var parsed_m_testMap = Parse_SUserInitialData_m_testMap();
            m_testMap = Option.Some(parsed_m_testMap);
        }

        if (m_testAuto is { HasValue: false })                           
        {
            var parsed_m_testAuto = Parse_SUserInitialData_m_testAuto();
            m_testAuto = Option.Some(parsed_m_testAuto);
        }

        if (m_observe is { HasValue: false })                           
        {
            var parsed_m_observe = Parse_SUserInitialData_m_observe();
            m_observe = Option.Some(parsed_m_observe);
        }

        return new SUserInitialData
        {   
            m_name = Option.OkOrReturnMissingFieldErr(m_name),
            m_randomSeed = Option.OkOrReturnMissingFieldErr(m_randomSeed),
            m_racePreference = Option.OkOrReturnMissingFieldErr(m_racePreference),
            m_teamPreference = Option.OkOrReturnMissingFieldErr(m_teamPreference),
            m_testMap = Option.OkOrReturnMissingFieldErr(m_testMap),
            m_testAuto = Option.OkOrReturnMissingFieldErr(m_testAuto),
            m_observe = Option.OkOrReturnMissingFieldErr(m_observe),
        };
    }

    public CUserName Parse_SUserInitialData_m_name()
    {                             
        var m_name = Parse_CUserName();
        return m_name;
    }

    public uint32 Parse_SUserInitialData_m_randomSeed()
    {                             
        var m_randomSeed = Parse_uint32();
        return m_randomSeed;
    }

    public TRacePreference Parse_SUserInitialData_m_racePreference()
    {                             
        var m_racePreference = Parse_TRacePreference();
        return m_racePreference;
    }

    public TTeamPreference Parse_SUserInitialData_m_teamPreference()
    {                             
        var m_teamPreference = Parse_TTeamPreference();
        return m_teamPreference;
    }

    public bool Parse_SUserInitialData_m_testMap()
    {                             
        var m_testMap = parse_bool();
        return m_testMap;
    }

    public bool Parse_SUserInitialData_m_testAuto()
    {                             
        var m_testAuto = parse_bool();
        return m_testAuto;
    }

    public EObserve Parse_SUserInitialData_m_observe()
    {                             
        var m_observe = Parse_EObserve();
        return m_observe;
    }

    public GameTColorPreference Parse_GameTColorPreference() 
    {
        var m_color = Option.Some<Option<GameTColorId>>(Option.None);
        if (m_color is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_color = Parse_GameTColorPreference_m_color();
            m_color = Option.Some(parsed_m_color);
        }

        return new GameTColorPreference
        {   
            m_color = Option.OkOrReturnMissingFieldErr(m_color),
        };
    }

    public Option<GameTColorId> Parse_GameTColorPreference_m_color()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameTColorId();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameSCmdAbil Parse_GameSCmdAbil() 
    {
        Option<GameTAbilLink> m_abilLink = Option.None;
        Option<long> m_abilCmdIndex = Option.None;
        var m_abilCmdData = Option.Some<Option<uint8>>(Option.None);
        if (m_abilLink is { HasValue: false })                           
        {
            var parsed_m_abilLink = Parse_GameSCmdAbil_m_abilLink();
            m_abilLink = Option.Some(parsed_m_abilLink);
        }

        if (m_abilCmdIndex is { HasValue: false })                           
        {
            var parsed_m_abilCmdIndex = Parse_GameSCmdAbil_m_abilCmdIndex();
            m_abilCmdIndex = Option.Some(parsed_m_abilCmdIndex);
        }

        if (m_abilCmdData is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_abilCmdData = Parse_GameSCmdAbil_m_abilCmdData();
            m_abilCmdData = Option.Some(parsed_m_abilCmdData);
        }

        return new GameSCmdAbil
        {   
            m_abilLink = Option.OkOrReturnMissingFieldErr(m_abilLink),
            m_abilCmdIndex = Option.OkOrReturnMissingFieldErr(m_abilCmdIndex),
            m_abilCmdData = Option.OkOrReturnMissingFieldErr(m_abilCmdData),
        };
    }

    public GameTAbilLink Parse_GameSCmdAbil_m_abilLink()
    {                             
        var m_abilLink = Parse_GameTAbilLink();
        return m_abilLink;
    }

    public long Parse_GameSCmdAbil_m_abilCmdIndex()
    {                             
        var m_abilCmdIndex = parse_packed_int(0, 5);
        return m_abilCmdIndex;
    }

    public Option<uint8> Parse_GameSCmdAbil_m_abilCmdData()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_uint8();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameSCmdDataTargetUnit Parse_GameSCmdDataTargetUnit() 
    {
        Option<uint8> m_targetUnitFlags = Option.None;
        Option<uint8> m_timer = Option.None;
        Option<GameTUnitTag> m_tag = Option.None;
        Option<GameTUnitLink> m_snapshotUnitLink = Option.None;
        var m_snapshotPlayerId = Option.Some<Option<GameTPlayerId>>(Option.None);
        Option<GameSMapCoord3D> m_snapshotPoint = Option.None;
        if (m_targetUnitFlags is { HasValue: false })                           
        {
            var parsed_m_targetUnitFlags = Parse_GameSCmdDataTargetUnit_m_targetUnitFlags();
            m_targetUnitFlags = Option.Some(parsed_m_targetUnitFlags);
        }

        if (m_timer is { HasValue: false })                           
        {
            var parsed_m_timer = Parse_GameSCmdDataTargetUnit_m_timer();
            m_timer = Option.Some(parsed_m_timer);
        }

        if (m_tag is { HasValue: false })                           
        {
            var parsed_m_tag = Parse_GameSCmdDataTargetUnit_m_tag();
            m_tag = Option.Some(parsed_m_tag);
        }

        if (m_snapshotUnitLink is { HasValue: false })                           
        {
            var parsed_m_snapshotUnitLink = Parse_GameSCmdDataTargetUnit_m_snapshotUnitLink();
            m_snapshotUnitLink = Option.Some(parsed_m_snapshotUnitLink);
        }

        if (m_snapshotPlayerId is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_snapshotPlayerId = Parse_GameSCmdDataTargetUnit_m_snapshotPlayerId();
            m_snapshotPlayerId = Option.Some(parsed_m_snapshotPlayerId);
        }

        if (m_snapshotPoint is { HasValue: false })                           
        {
            var parsed_m_snapshotPoint = Parse_GameSCmdDataTargetUnit_m_snapshotPoint();
            m_snapshotPoint = Option.Some(parsed_m_snapshotPoint);
        }

        return new GameSCmdDataTargetUnit
        {   
            m_targetUnitFlags = Option.OkOrReturnMissingFieldErr(m_targetUnitFlags),
            m_timer = Option.OkOrReturnMissingFieldErr(m_timer),
            m_tag = Option.OkOrReturnMissingFieldErr(m_tag),
            m_snapshotUnitLink = Option.OkOrReturnMissingFieldErr(m_snapshotUnitLink),
            m_snapshotPlayerId = Option.OkOrReturnMissingFieldErr(m_snapshotPlayerId),
            m_snapshotPoint = Option.OkOrReturnMissingFieldErr(m_snapshotPoint),
        };
    }

    public uint8 Parse_GameSCmdDataTargetUnit_m_targetUnitFlags()
    {                             
        var m_targetUnitFlags = Parse_uint8();
        return m_targetUnitFlags;
    }

    public uint8 Parse_GameSCmdDataTargetUnit_m_timer()
    {                             
        var m_timer = Parse_uint8();
        return m_timer;
    }

    public GameTUnitTag Parse_GameSCmdDataTargetUnit_m_tag()
    {                             
        var m_tag = Parse_GameTUnitTag();
        return m_tag;
    }

    public GameTUnitLink Parse_GameSCmdDataTargetUnit_m_snapshotUnitLink()
    {                             
        var m_snapshotUnitLink = Parse_GameTUnitLink();
        return m_snapshotUnitLink;
    }

    public Option<GameTPlayerId> Parse_GameSCmdDataTargetUnit_m_snapshotPlayerId()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameTPlayerId();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameSMapCoord3D Parse_GameSCmdDataTargetUnit_m_snapshotPoint()
    {                             
        var m_snapshotPoint = Parse_GameSMapCoord3D();
        return m_snapshotPoint;
    }

    public GameSSetLobbySlotEvent Parse_GameSSetLobbySlotEvent() 
    {
        Option<GameTLobbySlotId> m_slotId = Option.None;
        Option<GameSLobbySlotChange> m_slotChange = Option.None;
        if (m_slotId is { HasValue: false })                           
        {
            var parsed_m_slotId = Parse_GameSSetLobbySlotEvent_m_slotId();
            m_slotId = Option.Some(parsed_m_slotId);
        }

        if (m_slotChange is { HasValue: false })                           
        {
            var parsed_m_slotChange = Parse_GameSSetLobbySlotEvent_m_slotChange();
            m_slotChange = Option.Some(parsed_m_slotChange);
        }

        return new GameSSetLobbySlotEvent
        {   
            m_slotId = Option.OkOrReturnMissingFieldErr(m_slotId),
            m_slotChange = Option.OkOrReturnMissingFieldErr(m_slotChange),
        };
    }

    public GameTLobbySlotId Parse_GameSSetLobbySlotEvent_m_slotId()
    {                             
        var m_slotId = Parse_GameTLobbySlotId();
        return m_slotId;
    }

    public GameSLobbySlotChange Parse_GameSSetLobbySlotEvent_m_slotChange()
    {                             
        var m_slotChange = Parse_GameSLobbySlotChange();
        return m_slotChange;
    }

    public GameSDropUserEvent Parse_GameSDropUserEvent() 
    {
        Option<TUserId> m_userId = Option.None;
        Option<ELeaveReason> m_reason = Option.None;
        if (m_userId is { HasValue: false })                           
        {
            var parsed_m_userId = Parse_GameSDropUserEvent_m_userId();
            m_userId = Option.Some(parsed_m_userId);
        }

        if (m_reason is { HasValue: false })                           
        {
            var parsed_m_reason = Parse_GameSDropUserEvent_m_reason();
            m_reason = Option.Some(parsed_m_reason);
        }

        return new GameSDropUserEvent
        {   
            m_userId = Option.OkOrReturnMissingFieldErr(m_userId),
            m_reason = Option.OkOrReturnMissingFieldErr(m_reason),
        };
    }

    public TUserId Parse_GameSDropUserEvent_m_userId()
    {                             
        var m_userId = Parse_TUserId();
        return m_userId;
    }

    public ELeaveReason Parse_GameSDropUserEvent_m_reason()
    {                             
        var m_reason = Parse_ELeaveReason();
        return m_reason;
    }

    public GameSStartGameEvent Parse_GameSStartGameEvent() 
    {
        return new GameSStartGameEvent
        {   
        };
    }

    public GameSDropOurselvesEvent Parse_GameSDropOurselvesEvent() 
    {
        return new GameSDropOurselvesEvent
        {   
        };
    }

    public GameSBankFileEvent Parse_GameSBankFileEvent() 
    {
        Option<List<byte>> m_name = Option.None;
        if (m_name is { HasValue: false })                           
        {
            var parsed_m_name = Parse_GameSBankFileEvent_m_name();
            m_name = Option.Some(parsed_m_name);
        }

        return new GameSBankFileEvent
        {   
            m_name = Option.OkOrReturnMissingFieldErr(m_name),
        };
    }

    public List<byte> Parse_GameSBankFileEvent_m_name()
    {                             
        var arrayLength = take_n_bits_into_i64(7);
        var array = new List<byte>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_unaligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSBankSectionEvent Parse_GameSBankSectionEvent() 
    {
        Option<List<byte>> m_name = Option.None;
        if (m_name is { HasValue: false })                           
        {
            var parsed_m_name = Parse_GameSBankSectionEvent_m_name();
            m_name = Option.Some(parsed_m_name);
        }

        return new GameSBankSectionEvent
        {   
            m_name = Option.OkOrReturnMissingFieldErr(m_name),
        };
    }

    public List<byte> Parse_GameSBankSectionEvent_m_name()
    {                             
        var arrayLength = take_n_bits_into_i64(6);
        var array = new List<byte>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_unaligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSBankKeyEvent Parse_GameSBankKeyEvent() 
    {
        Option<List<byte>> m_name = Option.None;
        Option<uint32> m_type = Option.None;
        Option<List<byte>> m_data = Option.None;
        if (m_name is { HasValue: false })                           
        {
            var parsed_m_name = Parse_GameSBankKeyEvent_m_name();
            m_name = Option.Some(parsed_m_name);
        }

        if (m_type is { HasValue: false })                           
        {
            var parsed_m_type = Parse_GameSBankKeyEvent_m_type();
            m_type = Option.Some(parsed_m_type);
        }

        if (m_data is { HasValue: false })                           
        {
            var parsed_m_data = Parse_GameSBankKeyEvent_m_data();
            m_data = Option.Some(parsed_m_data);
        }

        return new GameSBankKeyEvent
        {   
            m_name = Option.OkOrReturnMissingFieldErr(m_name),
            m_type = Option.OkOrReturnMissingFieldErr(m_type),
            m_data = Option.OkOrReturnMissingFieldErr(m_data),
        };
    }

    public List<byte> Parse_GameSBankKeyEvent_m_name()
    {                             
        var arrayLength = take_n_bits_into_i64(6);
        var array = new List<byte>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_unaligned_byte();
            array.Add(data);
        }
        return array;
    }

    public uint32 Parse_GameSBankKeyEvent_m_type()
    {                             
        var m_type = Parse_uint32();
        return m_type;
    }

    public List<byte> Parse_GameSBankKeyEvent_m_data()
    {                             
        var arrayLength = take_n_bits_into_i64(5);
        var array = new List<byte>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_unaligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSBankValueEvent Parse_GameSBankValueEvent() 
    {
        Option<uint32> m_type = Option.None;
        Option<List<byte>> m_name = Option.None;
        Option<List<byte>> m_data = Option.None;
        if (m_type is { HasValue: false })                           
        {
            var parsed_m_type = Parse_GameSBankValueEvent_m_type();
            m_type = Option.Some(parsed_m_type);
        }

        if (m_name is { HasValue: false })                           
        {
            var parsed_m_name = Parse_GameSBankValueEvent_m_name();
            m_name = Option.Some(parsed_m_name);
        }

        if (m_data is { HasValue: false })                           
        {
            var parsed_m_data = Parse_GameSBankValueEvent_m_data();
            m_data = Option.Some(parsed_m_data);
        }

        return new GameSBankValueEvent
        {   
            m_type = Option.OkOrReturnMissingFieldErr(m_type),
            m_name = Option.OkOrReturnMissingFieldErr(m_name),
            m_data = Option.OkOrReturnMissingFieldErr(m_data),
        };
    }

    public uint32 Parse_GameSBankValueEvent_m_type()
    {                             
        var m_type = Parse_uint32();
        return m_type;
    }

    public List<byte> Parse_GameSBankValueEvent_m_name()
    {                             
        var arrayLength = take_n_bits_into_i64(6);
        var array = new List<byte>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_unaligned_byte();
            array.Add(data);
        }
        return array;
    }

    public List<byte> Parse_GameSBankValueEvent_m_data()
    {                             
        var arrayLength = take_n_bits_into_i64(10);
        var array = new List<byte>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_unaligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSUserOptionsEvent Parse_GameSUserOptionsEvent() 
    {
        Option<bool> m_developmentCheatsEnabled = Option.None;
        Option<bool> m_multiplayerCheatsEnabled = Option.None;
        Option<bool> m_syncChecksummingEnabled = Option.None;
        Option<bool> m_isMapToMapTransition = Option.None;
        if (m_developmentCheatsEnabled is { HasValue: false })                           
        {
            var parsed_m_developmentCheatsEnabled = Parse_GameSUserOptionsEvent_m_developmentCheatsEnabled();
            m_developmentCheatsEnabled = Option.Some(parsed_m_developmentCheatsEnabled);
        }

        if (m_multiplayerCheatsEnabled is { HasValue: false })                           
        {
            var parsed_m_multiplayerCheatsEnabled = Parse_GameSUserOptionsEvent_m_multiplayerCheatsEnabled();
            m_multiplayerCheatsEnabled = Option.Some(parsed_m_multiplayerCheatsEnabled);
        }

        if (m_syncChecksummingEnabled is { HasValue: false })                           
        {
            var parsed_m_syncChecksummingEnabled = Parse_GameSUserOptionsEvent_m_syncChecksummingEnabled();
            m_syncChecksummingEnabled = Option.Some(parsed_m_syncChecksummingEnabled);
        }

        if (m_isMapToMapTransition is { HasValue: false })                           
        {
            var parsed_m_isMapToMapTransition = Parse_GameSUserOptionsEvent_m_isMapToMapTransition();
            m_isMapToMapTransition = Option.Some(parsed_m_isMapToMapTransition);
        }

        return new GameSUserOptionsEvent
        {   
            m_developmentCheatsEnabled = Option.OkOrReturnMissingFieldErr(m_developmentCheatsEnabled),
            m_multiplayerCheatsEnabled = Option.OkOrReturnMissingFieldErr(m_multiplayerCheatsEnabled),
            m_syncChecksummingEnabled = Option.OkOrReturnMissingFieldErr(m_syncChecksummingEnabled),
            m_isMapToMapTransition = Option.OkOrReturnMissingFieldErr(m_isMapToMapTransition),
        };
    }

    public bool Parse_GameSUserOptionsEvent_m_developmentCheatsEnabled()
    {                             
        var m_developmentCheatsEnabled = parse_bool();
        return m_developmentCheatsEnabled;
    }

    public bool Parse_GameSUserOptionsEvent_m_multiplayerCheatsEnabled()
    {                             
        var m_multiplayerCheatsEnabled = parse_bool();
        return m_multiplayerCheatsEnabled;
    }

    public bool Parse_GameSUserOptionsEvent_m_syncChecksummingEnabled()
    {                             
        var m_syncChecksummingEnabled = parse_bool();
        return m_syncChecksummingEnabled;
    }

    public bool Parse_GameSUserOptionsEvent_m_isMapToMapTransition()
    {                             
        var m_isMapToMapTransition = parse_bool();
        return m_isMapToMapTransition;
    }

    public GameSUserFinishedLoadingEvent Parse_GameSUserFinishedLoadingEvent() 
    {
        return new GameSUserFinishedLoadingEvent
        {   
        };
    }

    public GameSUserFinishedLoadingSyncEvent Parse_GameSUserFinishedLoadingSyncEvent() 
    {
        return new GameSUserFinishedLoadingSyncEvent
        {   
        };
    }

    public GameSSetGameDurationEvent Parse_GameSSetGameDurationEvent() 
    {
        Option<uint32> m_gameDuration = Option.None;
        if (m_gameDuration is { HasValue: false })                           
        {
            var parsed_m_gameDuration = Parse_GameSSetGameDurationEvent_m_gameDuration();
            m_gameDuration = Option.Some(parsed_m_gameDuration);
        }

        return new GameSSetGameDurationEvent
        {   
            m_gameDuration = Option.OkOrReturnMissingFieldErr(m_gameDuration),
        };
    }

    public uint32 Parse_GameSSetGameDurationEvent_m_gameDuration()
    {                             
        var m_gameDuration = Parse_uint32();
        return m_gameDuration;
    }

    public GameSTurnEvent Parse_GameSTurnEvent() 
    {
        return new GameSTurnEvent
        {   
        };
    }

    public GameSPauseGameEvent Parse_GameSPauseGameEvent() 
    {
        Option<uint8> m_pauseTypeIndex = Option.None;
        if (m_pauseTypeIndex is { HasValue: false })                           
        {
            var parsed_m_pauseTypeIndex = Parse_GameSPauseGameEvent_m_pauseTypeIndex();
            m_pauseTypeIndex = Option.Some(parsed_m_pauseTypeIndex);
        }

        return new GameSPauseGameEvent
        {   
            m_pauseTypeIndex = Option.OkOrReturnMissingFieldErr(m_pauseTypeIndex),
        };
    }

    public uint8 Parse_GameSPauseGameEvent_m_pauseTypeIndex()
    {                             
        var m_pauseTypeIndex = Parse_uint8();
        return m_pauseTypeIndex;
    }

    public GameSUnpauseGameEvent Parse_GameSUnpauseGameEvent() 
    {
        Option<uint8> m_pauseTypeIndex = Option.None;
        if (m_pauseTypeIndex is { HasValue: false })                           
        {
            var parsed_m_pauseTypeIndex = Parse_GameSUnpauseGameEvent_m_pauseTypeIndex();
            m_pauseTypeIndex = Option.Some(parsed_m_pauseTypeIndex);
        }

        return new GameSUnpauseGameEvent
        {   
            m_pauseTypeIndex = Option.OkOrReturnMissingFieldErr(m_pauseTypeIndex),
        };
    }

    public uint8 Parse_GameSUnpauseGameEvent_m_pauseTypeIndex()
    {                             
        var m_pauseTypeIndex = Parse_uint8();
        return m_pauseTypeIndex;
    }

    public GameSSingleStepGameEvent Parse_GameSSingleStepGameEvent() 
    {
        return new GameSSingleStepGameEvent
        {   
        };
    }

    public GameSSetGameSpeedEvent Parse_GameSSetGameSpeedEvent() 
    {
        Option<GameEGameSpeed> m_speed = Option.None;
        if (m_speed is { HasValue: false })                           
        {
            var parsed_m_speed = Parse_GameSSetGameSpeedEvent_m_speed();
            m_speed = Option.Some(parsed_m_speed);
        }

        return new GameSSetGameSpeedEvent
        {   
            m_speed = Option.OkOrReturnMissingFieldErr(m_speed),
        };
    }

    public GameEGameSpeed Parse_GameSSetGameSpeedEvent_m_speed()
    {                             
        var m_speed = Parse_GameEGameSpeed();
        return m_speed;
    }

    public GameSAddGameSpeedEvent Parse_GameSAddGameSpeedEvent() 
    {
        Option<int8> m_delta = Option.None;
        if (m_delta is { HasValue: false })                           
        {
            var parsed_m_delta = Parse_GameSAddGameSpeedEvent_m_delta();
            m_delta = Option.Some(parsed_m_delta);
        }

        return new GameSAddGameSpeedEvent
        {   
            m_delta = Option.OkOrReturnMissingFieldErr(m_delta),
        };
    }

    public int8 Parse_GameSAddGameSpeedEvent_m_delta()
    {                             
        var m_delta = Parse_int8();
        return m_delta;
    }

    public GameSRestartGameEvent Parse_GameSRestartGameEvent() 
    {
        Option<uint32> m_reloadGameLoop = Option.None;
        if (m_reloadGameLoop is { HasValue: false })                           
        {
            var parsed_m_reloadGameLoop = Parse_GameSRestartGameEvent_m_reloadGameLoop();
            m_reloadGameLoop = Option.Some(parsed_m_reloadGameLoop);
        }

        return new GameSRestartGameEvent
        {   
            m_reloadGameLoop = Option.OkOrReturnMissingFieldErr(m_reloadGameLoop),
        };
    }

    public uint32 Parse_GameSRestartGameEvent_m_reloadGameLoop()
    {                             
        var m_reloadGameLoop = Parse_uint32();
        return m_reloadGameLoop;
    }

    public GameSSaveGameEvent Parse_GameSSaveGameEvent() 
    {
        Option<CFilePath> m_fileName = Option.None;
        Option<bool> m_automatic = Option.None;
        Option<bool> m_overwrite = Option.None;
        Option<List<byte>> m_name = Option.None;
        Option<List<byte>> m_description = Option.None;
        if (m_fileName is { HasValue: false })                           
        {
            var parsed_m_fileName = Parse_GameSSaveGameEvent_m_fileName();
            m_fileName = Option.Some(parsed_m_fileName);
        }

        if (m_automatic is { HasValue: false })                           
        {
            var parsed_m_automatic = Parse_GameSSaveGameEvent_m_automatic();
            m_automatic = Option.Some(parsed_m_automatic);
        }

        if (m_overwrite is { HasValue: false })                           
        {
            var parsed_m_overwrite = Parse_GameSSaveGameEvent_m_overwrite();
            m_overwrite = Option.Some(parsed_m_overwrite);
        }

        if (m_name is { HasValue: false })                           
        {
            var parsed_m_name = Parse_GameSSaveGameEvent_m_name();
            m_name = Option.Some(parsed_m_name);
        }

        if (m_description is { HasValue: false })                           
        {
            var parsed_m_description = Parse_GameSSaveGameEvent_m_description();
            m_description = Option.Some(parsed_m_description);
        }

        return new GameSSaveGameEvent
        {   
            m_fileName = Option.OkOrReturnMissingFieldErr(m_fileName),
            m_automatic = Option.OkOrReturnMissingFieldErr(m_automatic),
            m_overwrite = Option.OkOrReturnMissingFieldErr(m_overwrite),
            m_name = Option.OkOrReturnMissingFieldErr(m_name),
            m_description = Option.OkOrReturnMissingFieldErr(m_description),
        };
    }

    public CFilePath Parse_GameSSaveGameEvent_m_fileName()
    {                             
        var m_fileName = Parse_CFilePath();
        return m_fileName;
    }

    public bool Parse_GameSSaveGameEvent_m_automatic()
    {                             
        var m_automatic = parse_bool();
        return m_automatic;
    }

    public bool Parse_GameSSaveGameEvent_m_overwrite()
    {                             
        var m_overwrite = parse_bool();
        return m_overwrite;
    }

    public List<byte> Parse_GameSSaveGameEvent_m_name()
    {                             
        var arrayLength = take_n_bits_into_i64(6);
        var array = new List<byte>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_unaligned_byte();
            array.Add(data);
        }
        return array;
    }

    public List<byte> Parse_GameSSaveGameEvent_m_description()
    {                             
        var arrayLength = take_n_bits_into_i64(9);
        var array = new List<byte>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_unaligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSSaveGameDoneEvent Parse_GameSSaveGameDoneEvent() 
    {
        return new GameSSaveGameDoneEvent
        {   
        };
    }

    public GameSCheatEventData Parse_GameSCheatEventData() 
    {
        Option<GameSPoint> m_point = Option.None;
        Option<int32> m_time = Option.None;
        Option<GameCCheatString> m_verb = Option.None;
        Option<GameCCheatString> m_arguments = Option.None;
        if (m_point is { HasValue: false })                           
        {
            var parsed_m_point = Parse_GameSCheatEventData_m_point();
            m_point = Option.Some(parsed_m_point);
        }

        if (m_time is { HasValue: false })                           
        {
            var parsed_m_time = Parse_GameSCheatEventData_m_time();
            m_time = Option.Some(parsed_m_time);
        }

        if (m_verb is { HasValue: false })                           
        {
            var parsed_m_verb = Parse_GameSCheatEventData_m_verb();
            m_verb = Option.Some(parsed_m_verb);
        }

        if (m_arguments is { HasValue: false })                           
        {
            var parsed_m_arguments = Parse_GameSCheatEventData_m_arguments();
            m_arguments = Option.Some(parsed_m_arguments);
        }

        return new GameSCheatEventData
        {   
            m_point = Option.OkOrReturnMissingFieldErr(m_point),
            m_time = Option.OkOrReturnMissingFieldErr(m_time),
            m_verb = Option.OkOrReturnMissingFieldErr(m_verb),
            m_arguments = Option.OkOrReturnMissingFieldErr(m_arguments),
        };
    }

    public GameSPoint Parse_GameSCheatEventData_m_point()
    {                             
        var m_point = Parse_GameSPoint();
        return m_point;
    }

    public int32 Parse_GameSCheatEventData_m_time()
    {                             
        var m_time = Parse_int32();
        return m_time;
    }

    public GameCCheatString Parse_GameSCheatEventData_m_verb()
    {                             
        var m_verb = Parse_GameCCheatString();
        return m_verb;
    }

    public GameCCheatString Parse_GameSCheatEventData_m_arguments()
    {                             
        var m_arguments = Parse_GameCCheatString();
        return m_arguments;
    }

    public GameSSessionCheatEvent Parse_GameSSessionCheatEvent() 
    {
        Option<GameSCheatEventData> m_data = Option.None;
        if (m_data is { HasValue: false })                           
        {
            var parsed_m_data = Parse_GameSSessionCheatEvent_m_data();
            m_data = Option.Some(parsed_m_data);
        }

        return new GameSSessionCheatEvent
        {   
            m_data = Option.OkOrReturnMissingFieldErr(m_data),
        };
    }

    public GameSCheatEventData Parse_GameSSessionCheatEvent_m_data()
    {                             
        var m_data = Parse_GameSCheatEventData();
        return m_data;
    }

    public GameSPlayerLeaveEvent Parse_GameSPlayerLeaveEvent() 
    {
        return new GameSPlayerLeaveEvent
        {   
        };
    }

    public GameSGameCheatEvent Parse_GameSGameCheatEvent() 
    {
        Option<GameSCheatEventData> m_data = Option.None;
        if (m_data is { HasValue: false })                           
        {
            var parsed_m_data = Parse_GameSGameCheatEvent_m_data();
            m_data = Option.Some(parsed_m_data);
        }

        return new GameSGameCheatEvent
        {   
            m_data = Option.OkOrReturnMissingFieldErr(m_data),
        };
    }

    public GameSCheatEventData Parse_GameSGameCheatEvent_m_data()
    {                             
        var m_data = Parse_GameSCheatEventData();
        return m_data;
    }

    public GameSCmdEvent Parse_GameSCmdEvent() 
    {
        Option<long> m_cmdFlags = Option.None;
        var m_abil = Option.Some<Option<GameSCmdAbil>>(Option.None);
        Option<GameSCmdData> m_data = Option.None;
        var m_otherUnit = Option.Some<Option<GameTUnitTag>>(Option.None);
        if (m_cmdFlags is { HasValue: false })                           
        {
            var parsed_m_cmdFlags = Parse_GameSCmdEvent_m_cmdFlags();
            m_cmdFlags = Option.Some(parsed_m_cmdFlags);
        }

        if (m_abil is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_abil = Parse_GameSCmdEvent_m_abil();
            m_abil = Option.Some(parsed_m_abil);
        }

        if (m_data is { HasValue: false })                           
        {
            var parsed_m_data = Parse_GameSCmdEvent_m_data();
            m_data = Option.Some(parsed_m_data);
        }

        if (m_otherUnit is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_otherUnit = Parse_GameSCmdEvent_m_otherUnit();
            m_otherUnit = Option.Some(parsed_m_otherUnit);
        }

        return new GameSCmdEvent
        {   
            m_cmdFlags = Option.OkOrReturnMissingFieldErr(m_cmdFlags),
            m_abil = Option.OkOrReturnMissingFieldErr(m_abil),
            m_data = Option.OkOrReturnMissingFieldErr(m_data),
            m_otherUnit = Option.OkOrReturnMissingFieldErr(m_otherUnit),
        };
    }

    public long Parse_GameSCmdEvent_m_cmdFlags()
    {                             
        var m_cmdFlags = parse_packed_int(0, 17);
        return m_cmdFlags;
    }

    public Option<GameSCmdAbil> Parse_GameSCmdEvent_m_abil()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameSCmdAbil();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameSCmdData Parse_GameSCmdEvent_m_data()
    {                             
        var m_data = Parse_GameSCmdData();
        return m_data;
    }

    public Option<GameTUnitTag> Parse_GameSCmdEvent_m_otherUnit()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameTUnitTag();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameSSelectionDeltaEvent Parse_GameSSelectionDeltaEvent() 
    {
        Option<GameTControlGroupId> m_controlGroupId = Option.None;
        Option<GameSSelectionDelta> m_delta = Option.None;
        if (m_controlGroupId is { HasValue: false })                           
        {
            var parsed_m_controlGroupId = Parse_GameSSelectionDeltaEvent_m_controlGroupId();
            m_controlGroupId = Option.Some(parsed_m_controlGroupId);
        }

        if (m_delta is { HasValue: false })                           
        {
            var parsed_m_delta = Parse_GameSSelectionDeltaEvent_m_delta();
            m_delta = Option.Some(parsed_m_delta);
        }

        return new GameSSelectionDeltaEvent
        {   
            m_controlGroupId = Option.OkOrReturnMissingFieldErr(m_controlGroupId),
            m_delta = Option.OkOrReturnMissingFieldErr(m_delta),
        };
    }

    public GameTControlGroupId Parse_GameSSelectionDeltaEvent_m_controlGroupId()
    {                             
        var m_controlGroupId = Parse_GameTControlGroupId();
        return m_controlGroupId;
    }

    public GameSSelectionDelta Parse_GameSSelectionDeltaEvent_m_delta()
    {                             
        var m_delta = Parse_GameSSelectionDelta();
        return m_delta;
    }

    public GameSControlGroupUpdateEvent Parse_GameSControlGroupUpdateEvent() 
    {
        Option<GameTControlGroupIndex> m_controlGroupIndex = Option.None;
        Option<GameEControlGroupUpdate> m_controlGroupUpdate = Option.None;
        Option<GameSSelectionMask> m_mask = Option.None;
        if (m_controlGroupIndex is { HasValue: false })                           
        {
            var parsed_m_controlGroupIndex = Parse_GameSControlGroupUpdateEvent_m_controlGroupIndex();
            m_controlGroupIndex = Option.Some(parsed_m_controlGroupIndex);
        }

        if (m_controlGroupUpdate is { HasValue: false })                           
        {
            var parsed_m_controlGroupUpdate = Parse_GameSControlGroupUpdateEvent_m_controlGroupUpdate();
            m_controlGroupUpdate = Option.Some(parsed_m_controlGroupUpdate);
        }

        if (m_mask is { HasValue: false })                           
        {
            var parsed_m_mask = Parse_GameSControlGroupUpdateEvent_m_mask();
            m_mask = Option.Some(parsed_m_mask);
        }

        return new GameSControlGroupUpdateEvent
        {   
            m_controlGroupIndex = Option.OkOrReturnMissingFieldErr(m_controlGroupIndex),
            m_controlGroupUpdate = Option.OkOrReturnMissingFieldErr(m_controlGroupUpdate),
            m_mask = Option.OkOrReturnMissingFieldErr(m_mask),
        };
    }

    public GameTControlGroupIndex Parse_GameSControlGroupUpdateEvent_m_controlGroupIndex()
    {                             
        var m_controlGroupIndex = Parse_GameTControlGroupIndex();
        return m_controlGroupIndex;
    }

    public GameEControlGroupUpdate Parse_GameSControlGroupUpdateEvent_m_controlGroupUpdate()
    {                             
        var m_controlGroupUpdate = Parse_GameEControlGroupUpdate();
        return m_controlGroupUpdate;
    }

    public GameSSelectionMask Parse_GameSControlGroupUpdateEvent_m_mask()
    {                             
        var m_mask = Parse_GameSSelectionMask();
        return m_mask;
    }

    public GameSSelectionSyncCheckEvent Parse_GameSSelectionSyncCheckEvent() 
    {
        Option<GameTControlGroupId> m_controlGroupId = Option.None;
        Option<GameSSelectionSyncData> m_selectionSyncData = Option.None;
        if (m_controlGroupId is { HasValue: false })                           
        {
            var parsed_m_controlGroupId = Parse_GameSSelectionSyncCheckEvent_m_controlGroupId();
            m_controlGroupId = Option.Some(parsed_m_controlGroupId);
        }

        if (m_selectionSyncData is { HasValue: false })                           
        {
            var parsed_m_selectionSyncData = Parse_GameSSelectionSyncCheckEvent_m_selectionSyncData();
            m_selectionSyncData = Option.Some(parsed_m_selectionSyncData);
        }

        return new GameSSelectionSyncCheckEvent
        {   
            m_controlGroupId = Option.OkOrReturnMissingFieldErr(m_controlGroupId),
            m_selectionSyncData = Option.OkOrReturnMissingFieldErr(m_selectionSyncData),
        };
    }

    public GameTControlGroupId Parse_GameSSelectionSyncCheckEvent_m_controlGroupId()
    {                             
        var m_controlGroupId = Parse_GameTControlGroupId();
        return m_controlGroupId;
    }

    public GameSSelectionSyncData Parse_GameSSelectionSyncCheckEvent_m_selectionSyncData()
    {                             
        var m_selectionSyncData = Parse_GameSSelectionSyncData();
        return m_selectionSyncData;
    }

    public GameSResourceTradeEvent Parse_GameSResourceTradeEvent() 
    {
        Option<GameTPlayerId> m_recipientId = Option.None;
        Option<List<int32>> m_resources = Option.None;
        if (m_recipientId is { HasValue: false })                           
        {
            var parsed_m_recipientId = Parse_GameSResourceTradeEvent_m_recipientId();
            m_recipientId = Option.Some(parsed_m_recipientId);
        }

        if (m_resources is { HasValue: false })                           
        {
            var parsed_m_resources = Parse_GameSResourceTradeEvent_m_resources();
            m_resources = Option.Some(parsed_m_resources);
        }

        return new GameSResourceTradeEvent
        {   
            m_recipientId = Option.OkOrReturnMissingFieldErr(m_recipientId),
            m_resources = Option.OkOrReturnMissingFieldErr(m_resources),
        };
    }

    public GameTPlayerId Parse_GameSResourceTradeEvent_m_recipientId()
    {                             
        var m_recipientId = Parse_GameTPlayerId();
        return m_recipientId;
    }

    public List<int32> Parse_GameSResourceTradeEvent_m_resources()
    {                             
        var arrayLength = take_n_bits_into_i64(3);
        var array = new List<int32>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = Parse_int32();
            array.Add(data);
        }
        return array;
    }

    public GameSTriggerChatMessageEvent Parse_GameSTriggerChatMessageEvent() 
    {
        Option<GameCTriggerChatMessageString> m_chatMessage = Option.None;
        if (m_chatMessage is { HasValue: false })                           
        {
            var parsed_m_chatMessage = Parse_GameSTriggerChatMessageEvent_m_chatMessage();
            m_chatMessage = Option.Some(parsed_m_chatMessage);
        }

        return new GameSTriggerChatMessageEvent
        {   
            m_chatMessage = Option.OkOrReturnMissingFieldErr(m_chatMessage),
        };
    }

    public GameCTriggerChatMessageString Parse_GameSTriggerChatMessageEvent_m_chatMessage()
    {                             
        var m_chatMessage = Parse_GameCTriggerChatMessageString();
        return m_chatMessage;
    }

    public GameSAICommunicateEvent Parse_GameSAICommunicateEvent() 
    {
        Option<int8> m_beacon = Option.None;
        Option<int8> m_ally = Option.None;
        Option<int8> m_autocast = Option.None;
        Option<GameTUnitTag> m_targetUnitTag = Option.None;
        Option<GameTUnitLink> m_targetUnitSnapshotUnitLink = Option.None;
        var m_targetUnitSnapshotPlayerId = Option.Some<Option<GameTPlayerId>>(Option.None);
        Option<GameSPoint3> m_targetPoint = Option.None;
        if (m_beacon is { HasValue: false })                           
        {
            var parsed_m_beacon = Parse_GameSAICommunicateEvent_m_beacon();
            m_beacon = Option.Some(parsed_m_beacon);
        }

        if (m_ally is { HasValue: false })                           
        {
            var parsed_m_ally = Parse_GameSAICommunicateEvent_m_ally();
            m_ally = Option.Some(parsed_m_ally);
        }

        if (m_autocast is { HasValue: false })                           
        {
            var parsed_m_autocast = Parse_GameSAICommunicateEvent_m_autocast();
            m_autocast = Option.Some(parsed_m_autocast);
        }

        if (m_targetUnitTag is { HasValue: false })                           
        {
            var parsed_m_targetUnitTag = Parse_GameSAICommunicateEvent_m_targetUnitTag();
            m_targetUnitTag = Option.Some(parsed_m_targetUnitTag);
        }

        if (m_targetUnitSnapshotUnitLink is { HasValue: false })                           
        {
            var parsed_m_targetUnitSnapshotUnitLink = Parse_GameSAICommunicateEvent_m_targetUnitSnapshotUnitLink();
            m_targetUnitSnapshotUnitLink = Option.Some(parsed_m_targetUnitSnapshotUnitLink);
        }

        if (m_targetUnitSnapshotPlayerId is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_targetUnitSnapshotPlayerId = Parse_GameSAICommunicateEvent_m_targetUnitSnapshotPlayerId();
            m_targetUnitSnapshotPlayerId = Option.Some(parsed_m_targetUnitSnapshotPlayerId);
        }

        if (m_targetPoint is { HasValue: false })                           
        {
            var parsed_m_targetPoint = Parse_GameSAICommunicateEvent_m_targetPoint();
            m_targetPoint = Option.Some(parsed_m_targetPoint);
        }

        return new GameSAICommunicateEvent
        {   
            m_beacon = Option.OkOrReturnMissingFieldErr(m_beacon),
            m_ally = Option.OkOrReturnMissingFieldErr(m_ally),
            m_autocast = Option.OkOrReturnMissingFieldErr(m_autocast),
            m_targetUnitTag = Option.OkOrReturnMissingFieldErr(m_targetUnitTag),
            m_targetUnitSnapshotUnitLink = Option.OkOrReturnMissingFieldErr(m_targetUnitSnapshotUnitLink),
            m_targetUnitSnapshotPlayerId = Option.OkOrReturnMissingFieldErr(m_targetUnitSnapshotPlayerId),
            m_targetPoint = Option.OkOrReturnMissingFieldErr(m_targetPoint),
        };
    }

    public int8 Parse_GameSAICommunicateEvent_m_beacon()
    {                             
        var m_beacon = Parse_int8();
        return m_beacon;
    }

    public int8 Parse_GameSAICommunicateEvent_m_ally()
    {                             
        var m_ally = Parse_int8();
        return m_ally;
    }

    public int8 Parse_GameSAICommunicateEvent_m_autocast()
    {                             
        var m_autocast = Parse_int8();
        return m_autocast;
    }

    public GameTUnitTag Parse_GameSAICommunicateEvent_m_targetUnitTag()
    {                             
        var m_targetUnitTag = Parse_GameTUnitTag();
        return m_targetUnitTag;
    }

    public GameTUnitLink Parse_GameSAICommunicateEvent_m_targetUnitSnapshotUnitLink()
    {                             
        var m_targetUnitSnapshotUnitLink = Parse_GameTUnitLink();
        return m_targetUnitSnapshotUnitLink;
    }

    public Option<GameTPlayerId> Parse_GameSAICommunicateEvent_m_targetUnitSnapshotPlayerId()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameTPlayerId();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameSPoint3 Parse_GameSAICommunicateEvent_m_targetPoint()
    {                             
        var m_targetPoint = Parse_GameSPoint3();
        return m_targetPoint;
    }

    public GameSSetAbsoluteGameSpeedEvent Parse_GameSSetAbsoluteGameSpeedEvent() 
    {
        Option<GameEGameSpeed> m_speed = Option.None;
        if (m_speed is { HasValue: false })                           
        {
            var parsed_m_speed = Parse_GameSSetAbsoluteGameSpeedEvent_m_speed();
            m_speed = Option.Some(parsed_m_speed);
        }

        return new GameSSetAbsoluteGameSpeedEvent
        {   
            m_speed = Option.OkOrReturnMissingFieldErr(m_speed),
        };
    }

    public GameEGameSpeed Parse_GameSSetAbsoluteGameSpeedEvent_m_speed()
    {                             
        var m_speed = Parse_GameEGameSpeed();
        return m_speed;
    }

    public GameSAddAbsoluteGameSpeedEvent Parse_GameSAddAbsoluteGameSpeedEvent() 
    {
        Option<int8> m_delta = Option.None;
        if (m_delta is { HasValue: false })                           
        {
            var parsed_m_delta = Parse_GameSAddAbsoluteGameSpeedEvent_m_delta();
            m_delta = Option.Some(parsed_m_delta);
        }

        return new GameSAddAbsoluteGameSpeedEvent
        {   
            m_delta = Option.OkOrReturnMissingFieldErr(m_delta),
        };
    }

    public int8 Parse_GameSAddAbsoluteGameSpeedEvent_m_delta()
    {                             
        var m_delta = Parse_int8();
        return m_delta;
    }

    public GameSBroadcastCheatEvent Parse_GameSBroadcastCheatEvent() 
    {
        Option<GameCCheatString> m_verb = Option.None;
        Option<GameCCheatString> m_arguments = Option.None;
        if (m_verb is { HasValue: false })                           
        {
            var parsed_m_verb = Parse_GameSBroadcastCheatEvent_m_verb();
            m_verb = Option.Some(parsed_m_verb);
        }

        if (m_arguments is { HasValue: false })                           
        {
            var parsed_m_arguments = Parse_GameSBroadcastCheatEvent_m_arguments();
            m_arguments = Option.Some(parsed_m_arguments);
        }

        return new GameSBroadcastCheatEvent
        {   
            m_verb = Option.OkOrReturnMissingFieldErr(m_verb),
            m_arguments = Option.OkOrReturnMissingFieldErr(m_arguments),
        };
    }

    public GameCCheatString Parse_GameSBroadcastCheatEvent_m_verb()
    {                             
        var m_verb = Parse_GameCCheatString();
        return m_verb;
    }

    public GameCCheatString Parse_GameSBroadcastCheatEvent_m_arguments()
    {                             
        var m_arguments = Parse_GameCCheatString();
        return m_arguments;
    }

    public GameSAllianceEvent Parse_GameSAllianceEvent() 
    {
        Option<uint32> m_alliance = Option.None;
        Option<uint32> m_control = Option.None;
        if (m_alliance is { HasValue: false })                           
        {
            var parsed_m_alliance = Parse_GameSAllianceEvent_m_alliance();
            m_alliance = Option.Some(parsed_m_alliance);
        }

        if (m_control is { HasValue: false })                           
        {
            var parsed_m_control = Parse_GameSAllianceEvent_m_control();
            m_control = Option.Some(parsed_m_control);
        }

        return new GameSAllianceEvent
        {   
            m_alliance = Option.OkOrReturnMissingFieldErr(m_alliance),
            m_control = Option.OkOrReturnMissingFieldErr(m_control),
        };
    }

    public uint32 Parse_GameSAllianceEvent_m_alliance()
    {                             
        var m_alliance = Parse_uint32();
        return m_alliance;
    }

    public uint32 Parse_GameSAllianceEvent_m_control()
    {                             
        var m_control = Parse_uint32();
        return m_control;
    }

    public GameSUnitClickEvent Parse_GameSUnitClickEvent() 
    {
        Option<GameTUnitTag> m_unitTag = Option.None;
        if (m_unitTag is { HasValue: false })                           
        {
            var parsed_m_unitTag = Parse_GameSUnitClickEvent_m_unitTag();
            m_unitTag = Option.Some(parsed_m_unitTag);
        }

        return new GameSUnitClickEvent
        {   
            m_unitTag = Option.OkOrReturnMissingFieldErr(m_unitTag),
        };
    }

    public GameTUnitTag Parse_GameSUnitClickEvent_m_unitTag()
    {                             
        var m_unitTag = Parse_GameTUnitTag();
        return m_unitTag;
    }

    public GameSUnitHighlightEvent Parse_GameSUnitHighlightEvent() 
    {
        Option<GameTUnitTag> m_unitTag = Option.None;
        Option<uint8> m_flags = Option.None;
        if (m_unitTag is { HasValue: false })                           
        {
            var parsed_m_unitTag = Parse_GameSUnitHighlightEvent_m_unitTag();
            m_unitTag = Option.Some(parsed_m_unitTag);
        }

        if (m_flags is { HasValue: false })                           
        {
            var parsed_m_flags = Parse_GameSUnitHighlightEvent_m_flags();
            m_flags = Option.Some(parsed_m_flags);
        }

        return new GameSUnitHighlightEvent
        {   
            m_unitTag = Option.OkOrReturnMissingFieldErr(m_unitTag),
            m_flags = Option.OkOrReturnMissingFieldErr(m_flags),
        };
    }

    public GameTUnitTag Parse_GameSUnitHighlightEvent_m_unitTag()
    {                             
        var m_unitTag = Parse_GameTUnitTag();
        return m_unitTag;
    }

    public uint8 Parse_GameSUnitHighlightEvent_m_flags()
    {                             
        var m_flags = Parse_uint8();
        return m_flags;
    }

    public GameSTriggerReplySelectedEvent Parse_GameSTriggerReplySelectedEvent() 
    {
        Option<int32> m_conversationId = Option.None;
        Option<int32> m_replyId = Option.None;
        if (m_conversationId is { HasValue: false })                           
        {
            var parsed_m_conversationId = Parse_GameSTriggerReplySelectedEvent_m_conversationId();
            m_conversationId = Option.Some(parsed_m_conversationId);
        }

        if (m_replyId is { HasValue: false })                           
        {
            var parsed_m_replyId = Parse_GameSTriggerReplySelectedEvent_m_replyId();
            m_replyId = Option.Some(parsed_m_replyId);
        }

        return new GameSTriggerReplySelectedEvent
        {   
            m_conversationId = Option.OkOrReturnMissingFieldErr(m_conversationId),
            m_replyId = Option.OkOrReturnMissingFieldErr(m_replyId),
        };
    }

    public int32 Parse_GameSTriggerReplySelectedEvent_m_conversationId()
    {                             
        var m_conversationId = Parse_int32();
        return m_conversationId;
    }

    public int32 Parse_GameSTriggerReplySelectedEvent_m_replyId()
    {                             
        var m_replyId = Parse_int32();
        return m_replyId;
    }

    public GameSTriggerAbortMissionEvent Parse_GameSTriggerAbortMissionEvent() 
    {
        return new GameSTriggerAbortMissionEvent
        {   
        };
    }

    public GameSTriggerPurchaseMadeEvent Parse_GameSTriggerPurchaseMadeEvent() 
    {
        Option<int32> m_purchaseItemId = Option.None;
        if (m_purchaseItemId is { HasValue: false })                           
        {
            var parsed_m_purchaseItemId = Parse_GameSTriggerPurchaseMadeEvent_m_purchaseItemId();
            m_purchaseItemId = Option.Some(parsed_m_purchaseItemId);
        }

        return new GameSTriggerPurchaseMadeEvent
        {   
            m_purchaseItemId = Option.OkOrReturnMissingFieldErr(m_purchaseItemId),
        };
    }

    public int32 Parse_GameSTriggerPurchaseMadeEvent_m_purchaseItemId()
    {                             
        var m_purchaseItemId = Parse_int32();
        return m_purchaseItemId;
    }

    public GameSTriggerPurchaseExitEvent Parse_GameSTriggerPurchaseExitEvent() 
    {
        return new GameSTriggerPurchaseExitEvent
        {   
        };
    }

    public GameSTriggerPlanetMissionLaunchedEvent Parse_GameSTriggerPlanetMissionLaunchedEvent() 
    {
        Option<int32> m_difficultyLevel = Option.None;
        if (m_difficultyLevel is { HasValue: false })                           
        {
            var parsed_m_difficultyLevel = Parse_GameSTriggerPlanetMissionLaunchedEvent_m_difficultyLevel();
            m_difficultyLevel = Option.Some(parsed_m_difficultyLevel);
        }

        return new GameSTriggerPlanetMissionLaunchedEvent
        {   
            m_difficultyLevel = Option.OkOrReturnMissingFieldErr(m_difficultyLevel),
        };
    }

    public int32 Parse_GameSTriggerPlanetMissionLaunchedEvent_m_difficultyLevel()
    {                             
        var m_difficultyLevel = Parse_int32();
        return m_difficultyLevel;
    }

    public GameSTriggerPlanetPanelCanceledEvent Parse_GameSTriggerPlanetPanelCanceledEvent() 
    {
        return new GameSTriggerPlanetPanelCanceledEvent
        {   
        };
    }

    public GameSTriggerDialogControlEvent Parse_GameSTriggerDialogControlEvent() 
    {
        Option<int32> m_controlId = Option.None;
        Option<int32> m_eventType = Option.None;
        Option<m_eventData> m_eventData = Option.None;
        if (m_controlId is { HasValue: false })                           
        {
            var parsed_m_controlId = Parse_GameSTriggerDialogControlEvent_m_controlId();
            m_controlId = Option.Some(parsed_m_controlId);
        }

        if (m_eventType is { HasValue: false })                           
        {
            var parsed_m_eventType = Parse_GameSTriggerDialogControlEvent_m_eventType();
            m_eventType = Option.Some(parsed_m_eventType);
        }

        if (m_eventData is { HasValue: false })                           
        {
            var parsed_m_eventData = Parse_GameSTriggerDialogControlEvent_m_eventData();
            m_eventData = Option.Some(parsed_m_eventData);
        }

        return new GameSTriggerDialogControlEvent
        {   
            m_controlId = Option.OkOrReturnMissingFieldErr(m_controlId),
            m_eventType = Option.OkOrReturnMissingFieldErr(m_eventType),
            m_eventData = Option.OkOrReturnMissingFieldErr(m_eventData),
        };
    }

    public int32 Parse_GameSTriggerDialogControlEvent_m_controlId()
    {                             
        var m_controlId = Parse_int32();
        return m_controlId;
    }

    public int32 Parse_GameSTriggerDialogControlEvent_m_eventType()
    {                             
        var m_eventType = Parse_int32();
        return m_eventType;
    }

    public m_eventData Parse_GameSTriggerDialogControlEvent_m_eventData()
    {                             
        var m_eventData = Parse_m_eventData();
        return m_eventData;
    }

    public GameSTriggerSkippedEvent Parse_GameSTriggerSkippedEvent() 
    {
        return new GameSTriggerSkippedEvent
        {   
        };
    }

    public GameSTriggerSoundLengthQueryEvent Parse_GameSTriggerSoundLengthQueryEvent() 
    {
        Option<uint32> m_soundHash = Option.None;
        Option<uint32> m_length = Option.None;
        if (m_soundHash is { HasValue: false })                           
        {
            var parsed_m_soundHash = Parse_GameSTriggerSoundLengthQueryEvent_m_soundHash();
            m_soundHash = Option.Some(parsed_m_soundHash);
        }

        if (m_length is { HasValue: false })                           
        {
            var parsed_m_length = Parse_GameSTriggerSoundLengthQueryEvent_m_length();
            m_length = Option.Some(parsed_m_length);
        }

        return new GameSTriggerSoundLengthQueryEvent
        {   
            m_soundHash = Option.OkOrReturnMissingFieldErr(m_soundHash),
            m_length = Option.OkOrReturnMissingFieldErr(m_length),
        };
    }

    public uint32 Parse_GameSTriggerSoundLengthQueryEvent_m_soundHash()
    {                             
        var m_soundHash = Parse_uint32();
        return m_soundHash;
    }

    public uint32 Parse_GameSTriggerSoundLengthQueryEvent_m_length()
    {                             
        var m_length = Parse_uint32();
        return m_length;
    }

    public GameSTriggerSoundLengthSyncEvent Parse_GameSTriggerSoundLengthSyncEvent() 
    {
        Option<GameSSyncSoundLength> m_syncInfo = Option.None;
        if (m_syncInfo is { HasValue: false })                           
        {
            var parsed_m_syncInfo = Parse_GameSTriggerSoundLengthSyncEvent_m_syncInfo();
            m_syncInfo = Option.Some(parsed_m_syncInfo);
        }

        return new GameSTriggerSoundLengthSyncEvent
        {   
            m_syncInfo = Option.OkOrReturnMissingFieldErr(m_syncInfo),
        };
    }

    public GameSSyncSoundLength Parse_GameSTriggerSoundLengthSyncEvent_m_syncInfo()
    {                             
        var m_syncInfo = Parse_GameSSyncSoundLength();
        return m_syncInfo;
    }

    public GameSTriggerSoundOffsetEvent Parse_GameSTriggerSoundOffsetEvent() 
    {
        Option<GameTTriggerSoundTag> m_sound = Option.None;
        if (m_sound is { HasValue: false })                           
        {
            var parsed_m_sound = Parse_GameSTriggerSoundOffsetEvent_m_sound();
            m_sound = Option.Some(parsed_m_sound);
        }

        return new GameSTriggerSoundOffsetEvent
        {   
            m_sound = Option.OkOrReturnMissingFieldErr(m_sound),
        };
    }

    public GameTTriggerSoundTag Parse_GameSTriggerSoundOffsetEvent_m_sound()
    {                             
        var m_sound = Parse_GameTTriggerSoundTag();
        return m_sound;
    }

    public GameSTriggerTransmissionOffsetEvent Parse_GameSTriggerTransmissionOffsetEvent() 
    {
        Option<int32> m_transmissionId = Option.None;
        if (m_transmissionId is { HasValue: false })                           
        {
            var parsed_m_transmissionId = Parse_GameSTriggerTransmissionOffsetEvent_m_transmissionId();
            m_transmissionId = Option.Some(parsed_m_transmissionId);
        }

        return new GameSTriggerTransmissionOffsetEvent
        {   
            m_transmissionId = Option.OkOrReturnMissingFieldErr(m_transmissionId),
        };
    }

    public int32 Parse_GameSTriggerTransmissionOffsetEvent_m_transmissionId()
    {                             
        var m_transmissionId = Parse_int32();
        return m_transmissionId;
    }

    public GameSTriggerTransmissionCompleteEvent Parse_GameSTriggerTransmissionCompleteEvent() 
    {
        Option<int32> m_transmissionId = Option.None;
        if (m_transmissionId is { HasValue: false })                           
        {
            var parsed_m_transmissionId = Parse_GameSTriggerTransmissionCompleteEvent_m_transmissionId();
            m_transmissionId = Option.Some(parsed_m_transmissionId);
        }

        return new GameSTriggerTransmissionCompleteEvent
        {   
            m_transmissionId = Option.OkOrReturnMissingFieldErr(m_transmissionId),
        };
    }

    public int32 Parse_GameSTriggerTransmissionCompleteEvent_m_transmissionId()
    {                             
        var m_transmissionId = Parse_int32();
        return m_transmissionId;
    }

    public GameSCameraUpdateEvent Parse_GameSCameraUpdateEvent() 
    {
        Option<GameSPointMini> m_target = Option.None;
        var m_distance = Option.Some<Option<GameTFixedMiniBits>>(Option.None);
        var m_pitch = Option.Some<Option<GameTFixedMiniBits>>(Option.None);
        var m_yaw = Option.Some<Option<GameTFixedMiniBits>>(Option.None);
        if (m_target is { HasValue: false })                           
        {
            var parsed_m_target = Parse_GameSCameraUpdateEvent_m_target();
            m_target = Option.Some(parsed_m_target);
        }

        if (m_distance is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_distance = Parse_GameSCameraUpdateEvent_m_distance();
            m_distance = Option.Some(parsed_m_distance);
        }

        if (m_pitch is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_pitch = Parse_GameSCameraUpdateEvent_m_pitch();
            m_pitch = Option.Some(parsed_m_pitch);
        }

        if (m_yaw is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_yaw = Parse_GameSCameraUpdateEvent_m_yaw();
            m_yaw = Option.Some(parsed_m_yaw);
        }

        return new GameSCameraUpdateEvent
        {   
            m_target = Option.OkOrReturnMissingFieldErr(m_target),
            m_distance = Option.OkOrReturnMissingFieldErr(m_distance),
            m_pitch = Option.OkOrReturnMissingFieldErr(m_pitch),
            m_yaw = Option.OkOrReturnMissingFieldErr(m_yaw),
        };
    }

    public GameSPointMini Parse_GameSCameraUpdateEvent_m_target()
    {                             
        var m_target = Parse_GameSPointMini();
        return m_target;
    }

    public Option<GameTFixedMiniBits> Parse_GameSCameraUpdateEvent_m_distance()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameTFixedMiniBits();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public Option<GameTFixedMiniBits> Parse_GameSCameraUpdateEvent_m_pitch()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameTFixedMiniBits();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public Option<GameTFixedMiniBits> Parse_GameSCameraUpdateEvent_m_yaw()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_GameTFixedMiniBits();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameSTriggerConversationSkippedEvent Parse_GameSTriggerConversationSkippedEvent() 
    {
        Option<GameEConversationSkip> m_skipType = Option.None;
        if (m_skipType is { HasValue: false })                           
        {
            var parsed_m_skipType = Parse_GameSTriggerConversationSkippedEvent_m_skipType();
            m_skipType = Option.Some(parsed_m_skipType);
        }

        return new GameSTriggerConversationSkippedEvent
        {   
            m_skipType = Option.OkOrReturnMissingFieldErr(m_skipType),
        };
    }

    public GameEConversationSkip Parse_GameSTriggerConversationSkippedEvent_m_skipType()
    {                             
        var m_skipType = Parse_GameEConversationSkip();
        return m_skipType;
    }

    public GameSTriggerMouseClickedEvent Parse_GameSTriggerMouseClickedEvent() 
    {
        Option<uint32> m_button = Option.None;
        Option<bool> m_down = Option.None;
        Option<uint32> m_posXUI = Option.None;
        Option<uint32> m_posYUI = Option.None;
        Option<GameTFixedBits> m_posXWorld = Option.None;
        Option<GameTFixedBits> m_posYWorld = Option.None;
        Option<GameTFixedBits> m_posZWorld = Option.None;
        if (m_button is { HasValue: false })                           
        {
            var parsed_m_button = Parse_GameSTriggerMouseClickedEvent_m_button();
            m_button = Option.Some(parsed_m_button);
        }

        if (m_down is { HasValue: false })                           
        {
            var parsed_m_down = Parse_GameSTriggerMouseClickedEvent_m_down();
            m_down = Option.Some(parsed_m_down);
        }

        if (m_posXUI is { HasValue: false })                           
        {
            var parsed_m_posXUI = Parse_GameSTriggerMouseClickedEvent_m_posXUI();
            m_posXUI = Option.Some(parsed_m_posXUI);
        }

        if (m_posYUI is { HasValue: false })                           
        {
            var parsed_m_posYUI = Parse_GameSTriggerMouseClickedEvent_m_posYUI();
            m_posYUI = Option.Some(parsed_m_posYUI);
        }

        if (m_posXWorld is { HasValue: false })                           
        {
            var parsed_m_posXWorld = Parse_GameSTriggerMouseClickedEvent_m_posXWorld();
            m_posXWorld = Option.Some(parsed_m_posXWorld);
        }

        if (m_posYWorld is { HasValue: false })                           
        {
            var parsed_m_posYWorld = Parse_GameSTriggerMouseClickedEvent_m_posYWorld();
            m_posYWorld = Option.Some(parsed_m_posYWorld);
        }

        if (m_posZWorld is { HasValue: false })                           
        {
            var parsed_m_posZWorld = Parse_GameSTriggerMouseClickedEvent_m_posZWorld();
            m_posZWorld = Option.Some(parsed_m_posZWorld);
        }

        return new GameSTriggerMouseClickedEvent
        {   
            m_button = Option.OkOrReturnMissingFieldErr(m_button),
            m_down = Option.OkOrReturnMissingFieldErr(m_down),
            m_posXUI = Option.OkOrReturnMissingFieldErr(m_posXUI),
            m_posYUI = Option.OkOrReturnMissingFieldErr(m_posYUI),
            m_posXWorld = Option.OkOrReturnMissingFieldErr(m_posXWorld),
            m_posYWorld = Option.OkOrReturnMissingFieldErr(m_posYWorld),
            m_posZWorld = Option.OkOrReturnMissingFieldErr(m_posZWorld),
        };
    }

    public uint32 Parse_GameSTriggerMouseClickedEvent_m_button()
    {                             
        var m_button = Parse_uint32();
        return m_button;
    }

    public bool Parse_GameSTriggerMouseClickedEvent_m_down()
    {                             
        var m_down = parse_bool();
        return m_down;
    }

    public uint32 Parse_GameSTriggerMouseClickedEvent_m_posXUI()
    {                             
        var m_posXUI = Parse_uint32();
        return m_posXUI;
    }

    public uint32 Parse_GameSTriggerMouseClickedEvent_m_posYUI()
    {                             
        var m_posYUI = Parse_uint32();
        return m_posYUI;
    }

    public GameTFixedBits Parse_GameSTriggerMouseClickedEvent_m_posXWorld()
    {                             
        var m_posXWorld = Parse_GameTFixedBits();
        return m_posXWorld;
    }

    public GameTFixedBits Parse_GameSTriggerMouseClickedEvent_m_posYWorld()
    {                             
        var m_posYWorld = Parse_GameTFixedBits();
        return m_posYWorld;
    }

    public GameTFixedBits Parse_GameSTriggerMouseClickedEvent_m_posZWorld()
    {                             
        var m_posZWorld = Parse_GameTFixedBits();
        return m_posZWorld;
    }

    public GameSTriggerPlanetPanelReplayEvent Parse_GameSTriggerPlanetPanelReplayEvent() 
    {
        return new GameSTriggerPlanetPanelReplayEvent
        {   
        };
    }

    public GameSTriggerSoundtrackDoneEvent Parse_GameSTriggerSoundtrackDoneEvent() 
    {
        Option<uint32> m_soundtrack = Option.None;
        if (m_soundtrack is { HasValue: false })                           
        {
            var parsed_m_soundtrack = Parse_GameSTriggerSoundtrackDoneEvent_m_soundtrack();
            m_soundtrack = Option.Some(parsed_m_soundtrack);
        }

        return new GameSTriggerSoundtrackDoneEvent
        {   
            m_soundtrack = Option.OkOrReturnMissingFieldErr(m_soundtrack),
        };
    }

    public uint32 Parse_GameSTriggerSoundtrackDoneEvent_m_soundtrack()
    {                             
        var m_soundtrack = Parse_uint32();
        return m_soundtrack;
    }

    public GameSTriggerPlanetMissionSelectedEvent Parse_GameSTriggerPlanetMissionSelectedEvent() 
    {
        Option<int32> m_planetId = Option.None;
        if (m_planetId is { HasValue: false })                           
        {
            var parsed_m_planetId = Parse_GameSTriggerPlanetMissionSelectedEvent_m_planetId();
            m_planetId = Option.Some(parsed_m_planetId);
        }

        return new GameSTriggerPlanetMissionSelectedEvent
        {   
            m_planetId = Option.OkOrReturnMissingFieldErr(m_planetId),
        };
    }

    public int32 Parse_GameSTriggerPlanetMissionSelectedEvent_m_planetId()
    {                             
        var m_planetId = Parse_int32();
        return m_planetId;
    }

    public GameSTriggerKeyPressedEvent Parse_GameSTriggerKeyPressedEvent() 
    {
        Option<int8> m_key = Option.None;
        Option<int8> m_flags = Option.None;
        if (m_key is { HasValue: false })                           
        {
            var parsed_m_key = Parse_GameSTriggerKeyPressedEvent_m_key();
            m_key = Option.Some(parsed_m_key);
        }

        if (m_flags is { HasValue: false })                           
        {
            var parsed_m_flags = Parse_GameSTriggerKeyPressedEvent_m_flags();
            m_flags = Option.Some(parsed_m_flags);
        }

        return new GameSTriggerKeyPressedEvent
        {   
            m_key = Option.OkOrReturnMissingFieldErr(m_key),
            m_flags = Option.OkOrReturnMissingFieldErr(m_flags),
        };
    }

    public int8 Parse_GameSTriggerKeyPressedEvent_m_key()
    {                             
        var m_key = Parse_int8();
        return m_key;
    }

    public int8 Parse_GameSTriggerKeyPressedEvent_m_flags()
    {                             
        var m_flags = Parse_int8();
        return m_flags;
    }

    public GameSTriggerPlanetPanelBirthCompleteEvent Parse_GameSTriggerPlanetPanelBirthCompleteEvent() 
    {
        return new GameSTriggerPlanetPanelBirthCompleteEvent
        {   
        };
    }

    public GameSTriggerPlanetPanelDeathCompleteEvent Parse_GameSTriggerPlanetPanelDeathCompleteEvent() 
    {
        return new GameSTriggerPlanetPanelDeathCompleteEvent
        {   
        };
    }

    public GameSResourceRequestEvent Parse_GameSResourceRequestEvent() 
    {
        Option<List<int32>> m_resources = Option.None;
        if (m_resources is { HasValue: false })                           
        {
            var parsed_m_resources = Parse_GameSResourceRequestEvent_m_resources();
            m_resources = Option.Some(parsed_m_resources);
        }

        return new GameSResourceRequestEvent
        {   
            m_resources = Option.OkOrReturnMissingFieldErr(m_resources),
        };
    }

    public List<int32> Parse_GameSResourceRequestEvent_m_resources()
    {                             
        var arrayLength = take_n_bits_into_i64(3);
        var array = new List<int32>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = Parse_int32();
            array.Add(data);
        }
        return array;
    }

    public GameSResourceRequestFulfillEvent Parse_GameSResourceRequestFulfillEvent() 
    {
        Option<int32> m_fulfillRequestId = Option.None;
        if (m_fulfillRequestId is { HasValue: false })                           
        {
            var parsed_m_fulfillRequestId = Parse_GameSResourceRequestFulfillEvent_m_fulfillRequestId();
            m_fulfillRequestId = Option.Some(parsed_m_fulfillRequestId);
        }

        return new GameSResourceRequestFulfillEvent
        {   
            m_fulfillRequestId = Option.OkOrReturnMissingFieldErr(m_fulfillRequestId),
        };
    }

    public int32 Parse_GameSResourceRequestFulfillEvent_m_fulfillRequestId()
    {                             
        var m_fulfillRequestId = Parse_int32();
        return m_fulfillRequestId;
    }

    public GameSResourceRequestCancelEvent Parse_GameSResourceRequestCancelEvent() 
    {
        Option<int32> m_cancelRequestId = Option.None;
        if (m_cancelRequestId is { HasValue: false })                           
        {
            var parsed_m_cancelRequestId = Parse_GameSResourceRequestCancelEvent_m_cancelRequestId();
            m_cancelRequestId = Option.Some(parsed_m_cancelRequestId);
        }

        return new GameSResourceRequestCancelEvent
        {   
            m_cancelRequestId = Option.OkOrReturnMissingFieldErr(m_cancelRequestId),
        };
    }

    public int32 Parse_GameSResourceRequestCancelEvent_m_cancelRequestId()
    {                             
        var m_cancelRequestId = Parse_int32();
        return m_cancelRequestId;
    }

    public GameSTriggerResearchPanelExitEvent Parse_GameSTriggerResearchPanelExitEvent() 
    {
        return new GameSTriggerResearchPanelExitEvent
        {   
        };
    }

    public GameSTriggerResearchPanelPurchaseEvent Parse_GameSTriggerResearchPanelPurchaseEvent() 
    {
        return new GameSTriggerResearchPanelPurchaseEvent
        {   
        };
    }

    public GameSTriggerResearchPanelSelectionChangedEvent Parse_GameSTriggerResearchPanelSelectionChangedEvent() 
    {
        Option<int32> m_researchItemId = Option.None;
        if (m_researchItemId is { HasValue: false })                           
        {
            var parsed_m_researchItemId = Parse_GameSTriggerResearchPanelSelectionChangedEvent_m_researchItemId();
            m_researchItemId = Option.Some(parsed_m_researchItemId);
        }

        return new GameSTriggerResearchPanelSelectionChangedEvent
        {   
            m_researchItemId = Option.OkOrReturnMissingFieldErr(m_researchItemId),
        };
    }

    public int32 Parse_GameSTriggerResearchPanelSelectionChangedEvent_m_researchItemId()
    {                             
        var m_researchItemId = Parse_int32();
        return m_researchItemId;
    }

    public GameSLagMessageEvent Parse_GameSLagMessageEvent() 
    {
        Option<GameTPlayerId> m_laggingPlayerId = Option.None;
        if (m_laggingPlayerId is { HasValue: false })                           
        {
            var parsed_m_laggingPlayerId = Parse_GameSLagMessageEvent_m_laggingPlayerId();
            m_laggingPlayerId = Option.Some(parsed_m_laggingPlayerId);
        }

        return new GameSLagMessageEvent
        {   
            m_laggingPlayerId = Option.OkOrReturnMissingFieldErr(m_laggingPlayerId),
        };
    }

    public GameTPlayerId Parse_GameSLagMessageEvent_m_laggingPlayerId()
    {                             
        var m_laggingPlayerId = Parse_GameTPlayerId();
        return m_laggingPlayerId;
    }

    public GameSTriggerMercenaryPanelExitEvent Parse_GameSTriggerMercenaryPanelExitEvent() 
    {
        return new GameSTriggerMercenaryPanelExitEvent
        {   
        };
    }

    public GameSTriggerMercenaryPanelPurchaseEvent Parse_GameSTriggerMercenaryPanelPurchaseEvent() 
    {
        return new GameSTriggerMercenaryPanelPurchaseEvent
        {   
        };
    }

    public GameSTriggerMercenaryPanelSelectionChangedEvent Parse_GameSTriggerMercenaryPanelSelectionChangedEvent() 
    {
        Option<int32> m_mercenaryId = Option.None;
        if (m_mercenaryId is { HasValue: false })                           
        {
            var parsed_m_mercenaryId = Parse_GameSTriggerMercenaryPanelSelectionChangedEvent_m_mercenaryId();
            m_mercenaryId = Option.Some(parsed_m_mercenaryId);
        }

        return new GameSTriggerMercenaryPanelSelectionChangedEvent
        {   
            m_mercenaryId = Option.OkOrReturnMissingFieldErr(m_mercenaryId),
        };
    }

    public int32 Parse_GameSTriggerMercenaryPanelSelectionChangedEvent_m_mercenaryId()
    {                             
        var m_mercenaryId = Parse_int32();
        return m_mercenaryId;
    }

    public GameSTriggerVictoryPanelExitEvent Parse_GameSTriggerVictoryPanelExitEvent() 
    {
        return new GameSTriggerVictoryPanelExitEvent
        {   
        };
    }

    public GameSTriggerBattleReportPanelExitEvent Parse_GameSTriggerBattleReportPanelExitEvent() 
    {
        return new GameSTriggerBattleReportPanelExitEvent
        {   
        };
    }

    public GameSTriggerBattleReportPanelPlayMissionEvent Parse_GameSTriggerBattleReportPanelPlayMissionEvent() 
    {
        Option<int32> m_battleReportId = Option.None;
        Option<int32> m_difficultyLevel = Option.None;
        if (m_battleReportId is { HasValue: false })                           
        {
            var parsed_m_battleReportId = Parse_GameSTriggerBattleReportPanelPlayMissionEvent_m_battleReportId();
            m_battleReportId = Option.Some(parsed_m_battleReportId);
        }

        if (m_difficultyLevel is { HasValue: false })                           
        {
            var parsed_m_difficultyLevel = Parse_GameSTriggerBattleReportPanelPlayMissionEvent_m_difficultyLevel();
            m_difficultyLevel = Option.Some(parsed_m_difficultyLevel);
        }

        return new GameSTriggerBattleReportPanelPlayMissionEvent
        {   
            m_battleReportId = Option.OkOrReturnMissingFieldErr(m_battleReportId),
            m_difficultyLevel = Option.OkOrReturnMissingFieldErr(m_difficultyLevel),
        };
    }

    public int32 Parse_GameSTriggerBattleReportPanelPlayMissionEvent_m_battleReportId()
    {                             
        var m_battleReportId = Parse_int32();
        return m_battleReportId;
    }

    public int32 Parse_GameSTriggerBattleReportPanelPlayMissionEvent_m_difficultyLevel()
    {                             
        var m_difficultyLevel = Parse_int32();
        return m_difficultyLevel;
    }

    public GameSTriggerBattleReportPanelPlaySceneEvent Parse_GameSTriggerBattleReportPanelPlaySceneEvent() 
    {
        Option<int32> m_battleReportId = Option.None;
        if (m_battleReportId is { HasValue: false })                           
        {
            var parsed_m_battleReportId = Parse_GameSTriggerBattleReportPanelPlaySceneEvent_m_battleReportId();
            m_battleReportId = Option.Some(parsed_m_battleReportId);
        }

        return new GameSTriggerBattleReportPanelPlaySceneEvent
        {   
            m_battleReportId = Option.OkOrReturnMissingFieldErr(m_battleReportId),
        };
    }

    public int32 Parse_GameSTriggerBattleReportPanelPlaySceneEvent_m_battleReportId()
    {                             
        var m_battleReportId = Parse_int32();
        return m_battleReportId;
    }

    public GameSTriggerBattleReportPanelSelectionChangedEvent Parse_GameSTriggerBattleReportPanelSelectionChangedEvent() 
    {
        Option<int32> m_battleReportId = Option.None;
        if (m_battleReportId is { HasValue: false })                           
        {
            var parsed_m_battleReportId = Parse_GameSTriggerBattleReportPanelSelectionChangedEvent_m_battleReportId();
            m_battleReportId = Option.Some(parsed_m_battleReportId);
        }

        return new GameSTriggerBattleReportPanelSelectionChangedEvent
        {   
            m_battleReportId = Option.OkOrReturnMissingFieldErr(m_battleReportId),
        };
    }

    public int32 Parse_GameSTriggerBattleReportPanelSelectionChangedEvent_m_battleReportId()
    {                             
        var m_battleReportId = Parse_int32();
        return m_battleReportId;
    }

    public GameSTriggerVictoryPanelPlayMissionAgainEvent Parse_GameSTriggerVictoryPanelPlayMissionAgainEvent() 
    {
        Option<int32> m_difficultyLevel = Option.None;
        if (m_difficultyLevel is { HasValue: false })                           
        {
            var parsed_m_difficultyLevel = Parse_GameSTriggerVictoryPanelPlayMissionAgainEvent_m_difficultyLevel();
            m_difficultyLevel = Option.Some(parsed_m_difficultyLevel);
        }

        return new GameSTriggerVictoryPanelPlayMissionAgainEvent
        {   
            m_difficultyLevel = Option.OkOrReturnMissingFieldErr(m_difficultyLevel),
        };
    }

    public int32 Parse_GameSTriggerVictoryPanelPlayMissionAgainEvent_m_difficultyLevel()
    {                             
        var m_difficultyLevel = Parse_int32();
        return m_difficultyLevel;
    }

    public GameSTriggerMovieStartedEvent Parse_GameSTriggerMovieStartedEvent() 
    {
        return new GameSTriggerMovieStartedEvent
        {   
        };
    }

    public GameSTriggerMovieFinishedEvent Parse_GameSTriggerMovieFinishedEvent() 
    {
        return new GameSTriggerMovieFinishedEvent
        {   
        };
    }

    public GameSDecrementGameTimeRemainingEvent Parse_GameSDecrementGameTimeRemainingEvent() 
    {
        Option<GameTFixedUInt> m_decrementMs = Option.None;
        if (m_decrementMs is { HasValue: false })                           
        {
            var parsed_m_decrementMs = Parse_GameSDecrementGameTimeRemainingEvent_m_decrementMs();
            m_decrementMs = Option.Some(parsed_m_decrementMs);
        }

        return new GameSDecrementGameTimeRemainingEvent
        {   
            m_decrementMs = Option.OkOrReturnMissingFieldErr(m_decrementMs),
        };
    }

    public GameTFixedUInt Parse_GameSDecrementGameTimeRemainingEvent_m_decrementMs()
    {                             
        var m_decrementMs = Parse_GameTFixedUInt();
        return m_decrementMs;
    }

    public GameSTriggerPortraitLoadedEvent Parse_GameSTriggerPortraitLoadedEvent() 
    {
        Option<int32> m_portraitId = Option.None;
        if (m_portraitId is { HasValue: false })                           
        {
            var parsed_m_portraitId = Parse_GameSTriggerPortraitLoadedEvent_m_portraitId();
            m_portraitId = Option.Some(parsed_m_portraitId);
        }

        return new GameSTriggerPortraitLoadedEvent
        {   
            m_portraitId = Option.OkOrReturnMissingFieldErr(m_portraitId),
        };
    }

    public int32 Parse_GameSTriggerPortraitLoadedEvent_m_portraitId()
    {                             
        var m_portraitId = Parse_int32();
        return m_portraitId;
    }

    public GameSTriggerMovieFunctionEvent Parse_GameSTriggerMovieFunctionEvent() 
    {
        Option<List<byte>> m_functionName = Option.None;
        if (m_functionName is { HasValue: false })                           
        {
            var parsed_m_functionName = Parse_GameSTriggerMovieFunctionEvent_m_functionName();
            m_functionName = Option.Some(parsed_m_functionName);
        }

        return new GameSTriggerMovieFunctionEvent
        {   
            m_functionName = Option.OkOrReturnMissingFieldErr(m_functionName),
        };
    }

    public List<byte> Parse_GameSTriggerMovieFunctionEvent_m_functionName()
    {                             
        var arrayLength = take_n_bits_into_i64(7);
        var array = new List<byte>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = take_unaligned_byte();
            array.Add(data);
        }
        return array;
    }

    public GameSTriggerCustomDialogDismissedEvent Parse_GameSTriggerCustomDialogDismissedEvent() 
    {
        Option<int32> m_result = Option.None;
        if (m_result is { HasValue: false })                           
        {
            var parsed_m_result = Parse_GameSTriggerCustomDialogDismissedEvent_m_result();
            m_result = Option.Some(parsed_m_result);
        }

        return new GameSTriggerCustomDialogDismissedEvent
        {   
            m_result = Option.OkOrReturnMissingFieldErr(m_result),
        };
    }

    public int32 Parse_GameSTriggerCustomDialogDismissedEvent_m_result()
    {                             
        var m_result = Parse_int32();
        return m_result;
    }

    public GameSTriggerGameMenuItemSelectedEvent Parse_GameSTriggerGameMenuItemSelectedEvent() 
    {
        Option<int32> m_gameMenuItemIndex = Option.None;
        if (m_gameMenuItemIndex is { HasValue: false })                           
        {
            var parsed_m_gameMenuItemIndex = Parse_GameSTriggerGameMenuItemSelectedEvent_m_gameMenuItemIndex();
            m_gameMenuItemIndex = Option.Some(parsed_m_gameMenuItemIndex);
        }

        return new GameSTriggerGameMenuItemSelectedEvent
        {   
            m_gameMenuItemIndex = Option.OkOrReturnMissingFieldErr(m_gameMenuItemIndex),
        };
    }

    public int32 Parse_GameSTriggerGameMenuItemSelectedEvent_m_gameMenuItemIndex()
    {                             
        var m_gameMenuItemIndex = Parse_int32();
        return m_gameMenuItemIndex;
    }

    public GameSTriggerCameraMoveEvent Parse_GameSTriggerCameraMoveEvent() 
    {
        Option<int8> m_reason = Option.None;
        if (m_reason is { HasValue: false })                           
        {
            var parsed_m_reason = Parse_GameSTriggerCameraMoveEvent_m_reason();
            m_reason = Option.Some(parsed_m_reason);
        }

        return new GameSTriggerCameraMoveEvent
        {   
            m_reason = Option.OkOrReturnMissingFieldErr(m_reason),
        };
    }

    public int8 Parse_GameSTriggerCameraMoveEvent_m_reason()
    {                             
        var m_reason = Parse_int8();
        return m_reason;
    }

    public GameSTriggerPurchasePanelSelectedPurchaseItemChangedEvent Parse_GameSTriggerPurchasePanelSelectedPurchaseItemChangedEvent() 
    {
        Option<int32> m_purchaseItemId = Option.None;
        if (m_purchaseItemId is { HasValue: false })                           
        {
            var parsed_m_purchaseItemId = Parse_GameSTriggerPurchasePanelSelectedPurchaseItemChangedEvent_m_purchaseItemId();
            m_purchaseItemId = Option.Some(parsed_m_purchaseItemId);
        }

        return new GameSTriggerPurchasePanelSelectedPurchaseItemChangedEvent
        {   
            m_purchaseItemId = Option.OkOrReturnMissingFieldErr(m_purchaseItemId),
        };
    }

    public int32 Parse_GameSTriggerPurchasePanelSelectedPurchaseItemChangedEvent_m_purchaseItemId()
    {                             
        var m_purchaseItemId = Parse_int32();
        return m_purchaseItemId;
    }

    public GameSTriggerPurchasePanelSelectedPurchaseCategoryChangedEvent Parse_GameSTriggerPurchasePanelSelectedPurchaseCategoryChangedEvent() 
    {
        Option<int32> m_purchaseCategoryId = Option.None;
        if (m_purchaseCategoryId is { HasValue: false })                           
        {
            var parsed_m_purchaseCategoryId = Parse_GameSTriggerPurchasePanelSelectedPurchaseCategoryChangedEvent_m_purchaseCategoryId();
            m_purchaseCategoryId = Option.Some(parsed_m_purchaseCategoryId);
        }

        return new GameSTriggerPurchasePanelSelectedPurchaseCategoryChangedEvent
        {   
            m_purchaseCategoryId = Option.OkOrReturnMissingFieldErr(m_purchaseCategoryId),
        };
    }

    public int32 Parse_GameSTriggerPurchasePanelSelectedPurchaseCategoryChangedEvent_m_purchaseCategoryId()
    {                             
        var m_purchaseCategoryId = Parse_int32();
        return m_purchaseCategoryId;
    }

    public GameSTriggerButtonPressedEvent Parse_GameSTriggerButtonPressedEvent() 
    {
        Option<GameTButtonLink> m_button = Option.None;
        if (m_button is { HasValue: false })                           
        {
            var parsed_m_button = Parse_GameSTriggerButtonPressedEvent_m_button();
            m_button = Option.Some(parsed_m_button);
        }

        return new GameSTriggerButtonPressedEvent
        {   
            m_button = Option.OkOrReturnMissingFieldErr(m_button),
        };
    }

    public GameTButtonLink Parse_GameSTriggerButtonPressedEvent_m_button()
    {                             
        var m_button = Parse_GameTButtonLink();
        return m_button;
    }

    public GameSTriggerGameCreditsFinishedEvent Parse_GameSTriggerGameCreditsFinishedEvent() 
    {
        return new GameSTriggerGameCreditsFinishedEvent
        {   
        };
    }

    public GameSPoint Parse_GameSPoint() 
    {
        Option<GameTFixedBits> x = Option.None;
        Option<GameTFixedBits> y = Option.None;
        if (x is { HasValue: false })                           
        {
            var parsed_x = Parse_GameSPoint_x();
            x = Option.Some(parsed_x);
        }

        if (y is { HasValue: false })                           
        {
            var parsed_y = Parse_GameSPoint_y();
            y = Option.Some(parsed_y);
        }

        return new GameSPoint
        {   
            x = Option.OkOrReturnMissingFieldErr(x),
            y = Option.OkOrReturnMissingFieldErr(y),
        };
    }

    public GameTFixedBits Parse_GameSPoint_x()
    {                             
        var x = Parse_GameTFixedBits();
        return x;
    }

    public GameTFixedBits Parse_GameSPoint_y()
    {                             
        var y = Parse_GameTFixedBits();
        return y;
    }

    public GameSPoint3 Parse_GameSPoint3() 
    {
        Option<GameTFixedBits> x = Option.None;
        Option<GameTFixedBits> y = Option.None;
        Option<GameTFixedBits> z = Option.None;
        if (x is { HasValue: false })                           
        {
            var parsed_x = Parse_GameSPoint3_x();
            x = Option.Some(parsed_x);
        }

        if (y is { HasValue: false })                           
        {
            var parsed_y = Parse_GameSPoint3_y();
            y = Option.Some(parsed_y);
        }

        if (z is { HasValue: false })                           
        {
            var parsed_z = Parse_GameSPoint3_z();
            z = Option.Some(parsed_z);
        }

        return new GameSPoint3
        {   
            x = Option.OkOrReturnMissingFieldErr(x),
            y = Option.OkOrReturnMissingFieldErr(y),
            z = Option.OkOrReturnMissingFieldErr(z),
        };
    }

    public GameTFixedBits Parse_GameSPoint3_x()
    {                             
        var x = Parse_GameTFixedBits();
        return x;
    }

    public GameTFixedBits Parse_GameSPoint3_y()
    {                             
        var y = Parse_GameTFixedBits();
        return y;
    }

    public GameTFixedBits Parse_GameSPoint3_z()
    {                             
        var z = Parse_GameTFixedBits();
        return z;
    }

    public GameSPointMini Parse_GameSPointMini() 
    {
        Option<GameTFixedMiniBits> x = Option.None;
        Option<GameTFixedMiniBits> y = Option.None;
        if (x is { HasValue: false })                           
        {
            var parsed_x = Parse_GameSPointMini_x();
            x = Option.Some(parsed_x);
        }

        if (y is { HasValue: false })                           
        {
            var parsed_y = Parse_GameSPointMini_y();
            y = Option.Some(parsed_y);
        }

        return new GameSPointMini
        {   
            x = Option.OkOrReturnMissingFieldErr(x),
            y = Option.OkOrReturnMissingFieldErr(y),
        };
    }

    public GameTFixedMiniBits Parse_GameSPointMini_x()
    {                             
        var x = Parse_GameTFixedMiniBits();
        return x;
    }

    public GameTFixedMiniBits Parse_GameSPointMini_y()
    {                             
        var y = Parse_GameTFixedMiniBits();
        return y;
    }

    public GameSMapCoord Parse_GameSMapCoord() 
    {
        Option<GameTMapCoordFixedBits> x = Option.None;
        Option<GameTMapCoordFixedBits> y = Option.None;
        if (x is { HasValue: false })                           
        {
            var parsed_x = Parse_GameSMapCoord_x();
            x = Option.Some(parsed_x);
        }

        if (y is { HasValue: false })                           
        {
            var parsed_y = Parse_GameSMapCoord_y();
            y = Option.Some(parsed_y);
        }

        return new GameSMapCoord
        {   
            x = Option.OkOrReturnMissingFieldErr(x),
            y = Option.OkOrReturnMissingFieldErr(y),
        };
    }

    public GameTMapCoordFixedBits Parse_GameSMapCoord_x()
    {                             
        var x = Parse_GameTMapCoordFixedBits();
        return x;
    }

    public GameTMapCoordFixedBits Parse_GameSMapCoord_y()
    {                             
        var y = Parse_GameTMapCoordFixedBits();
        return y;
    }

    public GameSMapCoord3D Parse_GameSMapCoord3D() 
    {
        Option<GameTMapCoordFixedBits> x = Option.None;
        Option<GameTMapCoordFixedBits> y = Option.None;
        Option<GameTFixedBits> z = Option.None;
        if (x is { HasValue: false })                           
        {
            var parsed_x = Parse_GameSMapCoord3D_x();
            x = Option.Some(parsed_x);
        }

        if (y is { HasValue: false })                           
        {
            var parsed_y = Parse_GameSMapCoord3D_y();
            y = Option.Some(parsed_y);
        }

        if (z is { HasValue: false })                           
        {
            var parsed_z = Parse_GameSMapCoord3D_z();
            z = Option.Some(parsed_z);
        }

        return new GameSMapCoord3D
        {   
            x = Option.OkOrReturnMissingFieldErr(x),
            y = Option.OkOrReturnMissingFieldErr(y),
            z = Option.OkOrReturnMissingFieldErr(z),
        };
    }

    public GameTMapCoordFixedBits Parse_GameSMapCoord3D_x()
    {                             
        var x = Parse_GameTMapCoordFixedBits();
        return x;
    }

    public GameTMapCoordFixedBits Parse_GameSMapCoord3D_y()
    {                             
        var y = Parse_GameTMapCoordFixedBits();
        return y;
    }

    public GameTFixedBits Parse_GameSMapCoord3D_z()
    {                             
        var z = Parse_GameTFixedBits();
        return z;
    }

    public GameSSyncSoundLength Parse_GameSSyncSoundLength() 
    {
        Option<List<uint32>> m_soundHash = Option.None;
        Option<List<uint32>> m_length = Option.None;
        if (m_soundHash is { HasValue: false })                           
        {
            var parsed_m_soundHash = Parse_GameSSyncSoundLength_m_soundHash();
            m_soundHash = Option.Some(parsed_m_soundHash);
        }

        if (m_length is { HasValue: false })                           
        {
            var parsed_m_length = Parse_GameSSyncSoundLength_m_length();
            m_length = Option.Some(parsed_m_length);
        }

        return new GameSSyncSoundLength
        {   
            m_soundHash = Option.OkOrReturnMissingFieldErr(m_soundHash),
            m_length = Option.OkOrReturnMissingFieldErr(m_length),
        };
    }

    public List<uint32> Parse_GameSSyncSoundLength_m_soundHash()
    {                             
        var arrayLength = take_n_bits_into_i64(8);
        var array = new List<uint32>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = Parse_uint32();
            array.Add(data);
        }
        return array;
    }

    public List<uint32> Parse_GameSSyncSoundLength_m_length()
    {                             
        var arrayLength = take_n_bits_into_i64(8);
        var array = new List<uint32>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = Parse_uint32();
            array.Add(data);
        }
        return array;
    }

    public GameSGameOptions Parse_GameSGameOptions() 
    {
        Option<bool> m_lockTeams = Option.None;
        Option<bool> m_teamsTogether = Option.None;
        Option<bool> m_advancedSharedControl = Option.None;
        Option<bool> m_randomRaces = Option.None;
        Option<bool> m_battleNet = Option.None;
        Option<bool> m_amm = Option.None;
        Option<bool> m_ranked = Option.None;
        Option<bool> m_noVictoryOrDefeat = Option.None;
        Option<GameEOptionFog> m_fog = Option.None;
        Option<GameEOptionObservers> m_observers = Option.None;
        Option<GameEOptionUserDifficulty> m_userDifficulty = Option.None;
        if (m_lockTeams is { HasValue: false })                           
        {
            var parsed_m_lockTeams = Parse_GameSGameOptions_m_lockTeams();
            m_lockTeams = Option.Some(parsed_m_lockTeams);
        }

        if (m_teamsTogether is { HasValue: false })                           
        {
            var parsed_m_teamsTogether = Parse_GameSGameOptions_m_teamsTogether();
            m_teamsTogether = Option.Some(parsed_m_teamsTogether);
        }

        if (m_advancedSharedControl is { HasValue: false })                           
        {
            var parsed_m_advancedSharedControl = Parse_GameSGameOptions_m_advancedSharedControl();
            m_advancedSharedControl = Option.Some(parsed_m_advancedSharedControl);
        }

        if (m_randomRaces is { HasValue: false })                           
        {
            var parsed_m_randomRaces = Parse_GameSGameOptions_m_randomRaces();
            m_randomRaces = Option.Some(parsed_m_randomRaces);
        }

        if (m_battleNet is { HasValue: false })                           
        {
            var parsed_m_battleNet = Parse_GameSGameOptions_m_battleNet();
            m_battleNet = Option.Some(parsed_m_battleNet);
        }

        if (m_amm is { HasValue: false })                           
        {
            var parsed_m_amm = Parse_GameSGameOptions_m_amm();
            m_amm = Option.Some(parsed_m_amm);
        }

        if (m_ranked is { HasValue: false })                           
        {
            var parsed_m_ranked = Parse_GameSGameOptions_m_ranked();
            m_ranked = Option.Some(parsed_m_ranked);
        }

        if (m_noVictoryOrDefeat is { HasValue: false })                           
        {
            var parsed_m_noVictoryOrDefeat = Parse_GameSGameOptions_m_noVictoryOrDefeat();
            m_noVictoryOrDefeat = Option.Some(parsed_m_noVictoryOrDefeat);
        }

        if (m_fog is { HasValue: false })                           
        {
            var parsed_m_fog = Parse_GameSGameOptions_m_fog();
            m_fog = Option.Some(parsed_m_fog);
        }

        if (m_observers is { HasValue: false })                           
        {
            var parsed_m_observers = Parse_GameSGameOptions_m_observers();
            m_observers = Option.Some(parsed_m_observers);
        }

        if (m_userDifficulty is { HasValue: false })                           
        {
            var parsed_m_userDifficulty = Parse_GameSGameOptions_m_userDifficulty();
            m_userDifficulty = Option.Some(parsed_m_userDifficulty);
        }

        return new GameSGameOptions
        {   
            m_lockTeams = Option.OkOrReturnMissingFieldErr(m_lockTeams),
            m_teamsTogether = Option.OkOrReturnMissingFieldErr(m_teamsTogether),
            m_advancedSharedControl = Option.OkOrReturnMissingFieldErr(m_advancedSharedControl),
            m_randomRaces = Option.OkOrReturnMissingFieldErr(m_randomRaces),
            m_battleNet = Option.OkOrReturnMissingFieldErr(m_battleNet),
            m_amm = Option.OkOrReturnMissingFieldErr(m_amm),
            m_ranked = Option.OkOrReturnMissingFieldErr(m_ranked),
            m_noVictoryOrDefeat = Option.OkOrReturnMissingFieldErr(m_noVictoryOrDefeat),
            m_fog = Option.OkOrReturnMissingFieldErr(m_fog),
            m_observers = Option.OkOrReturnMissingFieldErr(m_observers),
            m_userDifficulty = Option.OkOrReturnMissingFieldErr(m_userDifficulty),
        };
    }

    public bool Parse_GameSGameOptions_m_lockTeams()
    {                             
        var m_lockTeams = parse_bool();
        return m_lockTeams;
    }

    public bool Parse_GameSGameOptions_m_teamsTogether()
    {                             
        var m_teamsTogether = parse_bool();
        return m_teamsTogether;
    }

    public bool Parse_GameSGameOptions_m_advancedSharedControl()
    {                             
        var m_advancedSharedControl = parse_bool();
        return m_advancedSharedControl;
    }

    public bool Parse_GameSGameOptions_m_randomRaces()
    {                             
        var m_randomRaces = parse_bool();
        return m_randomRaces;
    }

    public bool Parse_GameSGameOptions_m_battleNet()
    {                             
        var m_battleNet = parse_bool();
        return m_battleNet;
    }

    public bool Parse_GameSGameOptions_m_amm()
    {                             
        var m_amm = parse_bool();
        return m_amm;
    }

    public bool Parse_GameSGameOptions_m_ranked()
    {                             
        var m_ranked = parse_bool();
        return m_ranked;
    }

    public bool Parse_GameSGameOptions_m_noVictoryOrDefeat()
    {                             
        var m_noVictoryOrDefeat = parse_bool();
        return m_noVictoryOrDefeat;
    }

    public GameEOptionFog Parse_GameSGameOptions_m_fog()
    {                             
        var m_fog = Parse_GameEOptionFog();
        return m_fog;
    }

    public GameEOptionObservers Parse_GameSGameOptions_m_observers()
    {                             
        var m_observers = Parse_GameEOptionObservers();
        return m_observers;
    }

    public GameEOptionUserDifficulty Parse_GameSGameOptions_m_userDifficulty()
    {                             
        var m_userDifficulty = Parse_GameEOptionUserDifficulty();
        return m_userDifficulty;
    }

    public GameSSlotDescription Parse_GameSSlotDescription() 
    {
        Option<GameCAllowedColors> m_allowedColors = Option.None;
        Option<CAllowedRaces> m_allowedRaces = Option.None;
        Option<GameCAllowedDifficulty> m_allowedDifficulty = Option.None;
        Option<GameCAllowedControls> m_allowedControls = Option.None;
        Option<CAllowedObserveTypes> m_allowedObserveTypes = Option.None;
        if (m_allowedColors is { HasValue: false })                           
        {
            var parsed_m_allowedColors = Parse_GameSSlotDescription_m_allowedColors();
            m_allowedColors = Option.Some(parsed_m_allowedColors);
        }

        if (m_allowedRaces is { HasValue: false })                           
        {
            var parsed_m_allowedRaces = Parse_GameSSlotDescription_m_allowedRaces();
            m_allowedRaces = Option.Some(parsed_m_allowedRaces);
        }

        if (m_allowedDifficulty is { HasValue: false })                           
        {
            var parsed_m_allowedDifficulty = Parse_GameSSlotDescription_m_allowedDifficulty();
            m_allowedDifficulty = Option.Some(parsed_m_allowedDifficulty);
        }

        if (m_allowedControls is { HasValue: false })                           
        {
            var parsed_m_allowedControls = Parse_GameSSlotDescription_m_allowedControls();
            m_allowedControls = Option.Some(parsed_m_allowedControls);
        }

        if (m_allowedObserveTypes is { HasValue: false })                           
        {
            var parsed_m_allowedObserveTypes = Parse_GameSSlotDescription_m_allowedObserveTypes();
            m_allowedObserveTypes = Option.Some(parsed_m_allowedObserveTypes);
        }

        return new GameSSlotDescription
        {   
            m_allowedColors = Option.OkOrReturnMissingFieldErr(m_allowedColors),
            m_allowedRaces = Option.OkOrReturnMissingFieldErr(m_allowedRaces),
            m_allowedDifficulty = Option.OkOrReturnMissingFieldErr(m_allowedDifficulty),
            m_allowedControls = Option.OkOrReturnMissingFieldErr(m_allowedControls),
            m_allowedObserveTypes = Option.OkOrReturnMissingFieldErr(m_allowedObserveTypes),
        };
    }

    public GameCAllowedColors Parse_GameSSlotDescription_m_allowedColors()
    {                             
        var m_allowedColors = Parse_GameCAllowedColors();
        return m_allowedColors;
    }

    public CAllowedRaces Parse_GameSSlotDescription_m_allowedRaces()
    {                             
        var m_allowedRaces = Parse_CAllowedRaces();
        return m_allowedRaces;
    }

    public GameCAllowedDifficulty Parse_GameSSlotDescription_m_allowedDifficulty()
    {                             
        var m_allowedDifficulty = Parse_GameCAllowedDifficulty();
        return m_allowedDifficulty;
    }

    public GameCAllowedControls Parse_GameSSlotDescription_m_allowedControls()
    {                             
        var m_allowedControls = Parse_GameCAllowedControls();
        return m_allowedControls;
    }

    public CAllowedObserveTypes Parse_GameSSlotDescription_m_allowedObserveTypes()
    {                             
        var m_allowedObserveTypes = Parse_CAllowedObserveTypes();
        return m_allowedObserveTypes;
    }

    public GameSGameDescription Parse_GameSGameDescription() 
    {
        Option<uint32> m_randomValue = Option.None;
        Option<GameCGameCacheName> m_gameCacheName = Option.None;
        Option<GameSGameOptions> m_gameOptions = Option.None;
        Option<GameEGameSpeed> m_gameSpeed = Option.None;
        Option<GameEGameType> m_gameType = Option.None;
        Option<TUserCount> m_maxUsers = Option.None;
        Option<TUserCount> m_maxObservers = Option.None;
        Option<GameTPlayerCount> m_maxPlayers = Option.None;
        Option<GameTTeamCount> m_maxTeams = Option.None;
        Option<GameTColorCount> m_maxColors = Option.None;
        Option<TRaceCount> m_maxRaces = Option.None;
        Option<GameTControlCount> m_maxControls = Option.None;
        Option<uint8> m_mapSizeX = Option.None;
        Option<uint8> m_mapSizeY = Option.None;
        Option<GameTSyncChecksum> m_mapFileSyncChecksum = Option.None;
        Option<CFilePath> m_mapFileName = Option.None;
        Option<GameCAuthorName> m_mapAuthorName = Option.None;
        Option<GameTSyncChecksum> m_modFileSyncChecksum = Option.None;
        Option<GameSSlotDescriptions> m_slotDescriptions = Option.None;
        Option<GameTDifficulty> m_defaultDifficulty = Option.None;
        Option<GameCCacheHandles> m_cacheHandles = Option.None;
        Option<bool> m_isBlizzardMap = Option.None;
        Option<bool> m_isPremadeFFA = Option.None;
        if (m_randomValue is { HasValue: false })                           
        {
            var parsed_m_randomValue = Parse_GameSGameDescription_m_randomValue();
            m_randomValue = Option.Some(parsed_m_randomValue);
        }

        if (m_gameCacheName is { HasValue: false })                           
        {
            var parsed_m_gameCacheName = Parse_GameSGameDescription_m_gameCacheName();
            m_gameCacheName = Option.Some(parsed_m_gameCacheName);
        }

        if (m_gameOptions is { HasValue: false })                           
        {
            var parsed_m_gameOptions = Parse_GameSGameDescription_m_gameOptions();
            m_gameOptions = Option.Some(parsed_m_gameOptions);
        }

        if (m_gameSpeed is { HasValue: false })                           
        {
            var parsed_m_gameSpeed = Parse_GameSGameDescription_m_gameSpeed();
            m_gameSpeed = Option.Some(parsed_m_gameSpeed);
        }

        if (m_gameType is { HasValue: false })                           
        {
            var parsed_m_gameType = Parse_GameSGameDescription_m_gameType();
            m_gameType = Option.Some(parsed_m_gameType);
        }

        if (m_maxUsers is { HasValue: false })                           
        {
            var parsed_m_maxUsers = Parse_GameSGameDescription_m_maxUsers();
            m_maxUsers = Option.Some(parsed_m_maxUsers);
        }

        if (m_maxObservers is { HasValue: false })                           
        {
            var parsed_m_maxObservers = Parse_GameSGameDescription_m_maxObservers();
            m_maxObservers = Option.Some(parsed_m_maxObservers);
        }

        if (m_maxPlayers is { HasValue: false })                           
        {
            var parsed_m_maxPlayers = Parse_GameSGameDescription_m_maxPlayers();
            m_maxPlayers = Option.Some(parsed_m_maxPlayers);
        }

        if (m_maxTeams is { HasValue: false })                           
        {
            var parsed_m_maxTeams = Parse_GameSGameDescription_m_maxTeams();
            m_maxTeams = Option.Some(parsed_m_maxTeams);
        }

        if (m_maxColors is { HasValue: false })                           
        {
            var parsed_m_maxColors = Parse_GameSGameDescription_m_maxColors();
            m_maxColors = Option.Some(parsed_m_maxColors);
        }

        if (m_maxRaces is { HasValue: false })                           
        {
            var parsed_m_maxRaces = Parse_GameSGameDescription_m_maxRaces();
            m_maxRaces = Option.Some(parsed_m_maxRaces);
        }

        if (m_maxControls is { HasValue: false })                           
        {
            var parsed_m_maxControls = Parse_GameSGameDescription_m_maxControls();
            m_maxControls = Option.Some(parsed_m_maxControls);
        }

        if (m_mapSizeX is { HasValue: false })                           
        {
            var parsed_m_mapSizeX = Parse_GameSGameDescription_m_mapSizeX();
            m_mapSizeX = Option.Some(parsed_m_mapSizeX);
        }

        if (m_mapSizeY is { HasValue: false })                           
        {
            var parsed_m_mapSizeY = Parse_GameSGameDescription_m_mapSizeY();
            m_mapSizeY = Option.Some(parsed_m_mapSizeY);
        }

        if (m_mapFileSyncChecksum is { HasValue: false })                           
        {
            var parsed_m_mapFileSyncChecksum = Parse_GameSGameDescription_m_mapFileSyncChecksum();
            m_mapFileSyncChecksum = Option.Some(parsed_m_mapFileSyncChecksum);
        }

        if (m_mapFileName is { HasValue: false })                           
        {
            var parsed_m_mapFileName = Parse_GameSGameDescription_m_mapFileName();
            m_mapFileName = Option.Some(parsed_m_mapFileName);
        }

        if (m_mapAuthorName is { HasValue: false })                           
        {
            var parsed_m_mapAuthorName = Parse_GameSGameDescription_m_mapAuthorName();
            m_mapAuthorName = Option.Some(parsed_m_mapAuthorName);
        }

        if (m_modFileSyncChecksum is { HasValue: false })                           
        {
            var parsed_m_modFileSyncChecksum = Parse_GameSGameDescription_m_modFileSyncChecksum();
            m_modFileSyncChecksum = Option.Some(parsed_m_modFileSyncChecksum);
        }

        if (m_slotDescriptions is { HasValue: false })                           
        {
            var parsed_m_slotDescriptions = Parse_GameSGameDescription_m_slotDescriptions();
            m_slotDescriptions = Option.Some(parsed_m_slotDescriptions);
        }

        if (m_defaultDifficulty is { HasValue: false })                           
        {
            var parsed_m_defaultDifficulty = Parse_GameSGameDescription_m_defaultDifficulty();
            m_defaultDifficulty = Option.Some(parsed_m_defaultDifficulty);
        }

        if (m_cacheHandles is { HasValue: false })                           
        {
            var parsed_m_cacheHandles = Parse_GameSGameDescription_m_cacheHandles();
            m_cacheHandles = Option.Some(parsed_m_cacheHandles);
        }

        if (m_isBlizzardMap is { HasValue: false })                           
        {
            var parsed_m_isBlizzardMap = Parse_GameSGameDescription_m_isBlizzardMap();
            m_isBlizzardMap = Option.Some(parsed_m_isBlizzardMap);
        }

        if (m_isPremadeFFA is { HasValue: false })                           
        {
            var parsed_m_isPremadeFFA = Parse_GameSGameDescription_m_isPremadeFFA();
            m_isPremadeFFA = Option.Some(parsed_m_isPremadeFFA);
        }

        return new GameSGameDescription
        {   
            m_randomValue = Option.OkOrReturnMissingFieldErr(m_randomValue),
            m_gameCacheName = Option.OkOrReturnMissingFieldErr(m_gameCacheName),
            m_gameOptions = Option.OkOrReturnMissingFieldErr(m_gameOptions),
            m_gameSpeed = Option.OkOrReturnMissingFieldErr(m_gameSpeed),
            m_gameType = Option.OkOrReturnMissingFieldErr(m_gameType),
            m_maxUsers = Option.OkOrReturnMissingFieldErr(m_maxUsers),
            m_maxObservers = Option.OkOrReturnMissingFieldErr(m_maxObservers),
            m_maxPlayers = Option.OkOrReturnMissingFieldErr(m_maxPlayers),
            m_maxTeams = Option.OkOrReturnMissingFieldErr(m_maxTeams),
            m_maxColors = Option.OkOrReturnMissingFieldErr(m_maxColors),
            m_maxRaces = Option.OkOrReturnMissingFieldErr(m_maxRaces),
            m_maxControls = Option.OkOrReturnMissingFieldErr(m_maxControls),
            m_mapSizeX = Option.OkOrReturnMissingFieldErr(m_mapSizeX),
            m_mapSizeY = Option.OkOrReturnMissingFieldErr(m_mapSizeY),
            m_mapFileSyncChecksum = Option.OkOrReturnMissingFieldErr(m_mapFileSyncChecksum),
            m_mapFileName = Option.OkOrReturnMissingFieldErr(m_mapFileName),
            m_mapAuthorName = Option.OkOrReturnMissingFieldErr(m_mapAuthorName),
            m_modFileSyncChecksum = Option.OkOrReturnMissingFieldErr(m_modFileSyncChecksum),
            m_slotDescriptions = Option.OkOrReturnMissingFieldErr(m_slotDescriptions),
            m_defaultDifficulty = Option.OkOrReturnMissingFieldErr(m_defaultDifficulty),
            m_cacheHandles = Option.OkOrReturnMissingFieldErr(m_cacheHandles),
            m_isBlizzardMap = Option.OkOrReturnMissingFieldErr(m_isBlizzardMap),
            m_isPremadeFFA = Option.OkOrReturnMissingFieldErr(m_isPremadeFFA),
        };
    }

    public uint32 Parse_GameSGameDescription_m_randomValue()
    {                             
        var m_randomValue = Parse_uint32();
        return m_randomValue;
    }

    public GameCGameCacheName Parse_GameSGameDescription_m_gameCacheName()
    {                             
        var m_gameCacheName = Parse_GameCGameCacheName();
        return m_gameCacheName;
    }

    public GameSGameOptions Parse_GameSGameDescription_m_gameOptions()
    {                             
        var m_gameOptions = Parse_GameSGameOptions();
        return m_gameOptions;
    }

    public GameEGameSpeed Parse_GameSGameDescription_m_gameSpeed()
    {                             
        var m_gameSpeed = Parse_GameEGameSpeed();
        return m_gameSpeed;
    }

    public GameEGameType Parse_GameSGameDescription_m_gameType()
    {                             
        var m_gameType = Parse_GameEGameType();
        return m_gameType;
    }

    public TUserCount Parse_GameSGameDescription_m_maxUsers()
    {                             
        var m_maxUsers = Parse_TUserCount();
        return m_maxUsers;
    }

    public TUserCount Parse_GameSGameDescription_m_maxObservers()
    {                             
        var m_maxObservers = Parse_TUserCount();
        return m_maxObservers;
    }

    public GameTPlayerCount Parse_GameSGameDescription_m_maxPlayers()
    {                             
        var m_maxPlayers = Parse_GameTPlayerCount();
        return m_maxPlayers;
    }

    public GameTTeamCount Parse_GameSGameDescription_m_maxTeams()
    {                             
        var m_maxTeams = Parse_GameTTeamCount();
        return m_maxTeams;
    }

    public GameTColorCount Parse_GameSGameDescription_m_maxColors()
    {                             
        var m_maxColors = Parse_GameTColorCount();
        return m_maxColors;
    }

    public TRaceCount Parse_GameSGameDescription_m_maxRaces()
    {                             
        var m_maxRaces = Parse_TRaceCount();
        return m_maxRaces;
    }

    public GameTControlCount Parse_GameSGameDescription_m_maxControls()
    {                             
        var m_maxControls = Parse_GameTControlCount();
        return m_maxControls;
    }

    public uint8 Parse_GameSGameDescription_m_mapSizeX()
    {                             
        var m_mapSizeX = Parse_uint8();
        return m_mapSizeX;
    }

    public uint8 Parse_GameSGameDescription_m_mapSizeY()
    {                             
        var m_mapSizeY = Parse_uint8();
        return m_mapSizeY;
    }

    public GameTSyncChecksum Parse_GameSGameDescription_m_mapFileSyncChecksum()
    {                             
        var m_mapFileSyncChecksum = Parse_GameTSyncChecksum();
        return m_mapFileSyncChecksum;
    }

    public CFilePath Parse_GameSGameDescription_m_mapFileName()
    {                             
        var m_mapFileName = Parse_CFilePath();
        return m_mapFileName;
    }

    public GameCAuthorName Parse_GameSGameDescription_m_mapAuthorName()
    {                             
        var m_mapAuthorName = Parse_GameCAuthorName();
        return m_mapAuthorName;
    }

    public GameTSyncChecksum Parse_GameSGameDescription_m_modFileSyncChecksum()
    {                             
        var m_modFileSyncChecksum = Parse_GameTSyncChecksum();
        return m_modFileSyncChecksum;
    }

    public GameSSlotDescriptions Parse_GameSGameDescription_m_slotDescriptions()
    {                             
        var m_slotDescriptions = Parse_GameSSlotDescriptions();
        return m_slotDescriptions;
    }

    public GameTDifficulty Parse_GameSGameDescription_m_defaultDifficulty()
    {                             
        var m_defaultDifficulty = Parse_GameTDifficulty();
        return m_defaultDifficulty;
    }

    public GameCCacheHandles Parse_GameSGameDescription_m_cacheHandles()
    {                             
        var m_cacheHandles = Parse_GameCCacheHandles();
        return m_cacheHandles;
    }

    public bool Parse_GameSGameDescription_m_isBlizzardMap()
    {                             
        var m_isBlizzardMap = parse_bool();
        return m_isBlizzardMap;
    }

    public bool Parse_GameSGameDescription_m_isPremadeFFA()
    {                             
        var m_isPremadeFFA = parse_bool();
        return m_isPremadeFFA;
    }

    public GameSLobbySlot Parse_GameSLobbySlot() 
    {
        Option<GameTControlId> m_control = Option.None;
        var m_userId = Option.Some<Option<TUserId>>(Option.None);
        Option<GameTTeamId> m_teamId = Option.None;
        Option<GameTColorPreference> m_colorPref = Option.None;
        Option<TRacePreference> m_racePref = Option.None;
        Option<GameTDifficulty> m_difficulty = Option.None;
        Option<GameTHandicap> m_handicap = Option.None;
        Option<EObserve> m_observe = Option.None;
        Option<GameCRewardArray> m_rewards = Option.None;
        if (m_control is { HasValue: false })                           
        {
            var parsed_m_control = Parse_GameSLobbySlot_m_control();
            m_control = Option.Some(parsed_m_control);
        }

        if (m_userId is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_userId = Parse_GameSLobbySlot_m_userId();
            m_userId = Option.Some(parsed_m_userId);
        }

        if (m_teamId is { HasValue: false })                           
        {
            var parsed_m_teamId = Parse_GameSLobbySlot_m_teamId();
            m_teamId = Option.Some(parsed_m_teamId);
        }

        if (m_colorPref is { HasValue: false })                           
        {
            var parsed_m_colorPref = Parse_GameSLobbySlot_m_colorPref();
            m_colorPref = Option.Some(parsed_m_colorPref);
        }

        if (m_racePref is { HasValue: false })                           
        {
            var parsed_m_racePref = Parse_GameSLobbySlot_m_racePref();
            m_racePref = Option.Some(parsed_m_racePref);
        }

        if (m_difficulty is { HasValue: false })                           
        {
            var parsed_m_difficulty = Parse_GameSLobbySlot_m_difficulty();
            m_difficulty = Option.Some(parsed_m_difficulty);
        }

        if (m_handicap is { HasValue: false })                           
        {
            var parsed_m_handicap = Parse_GameSLobbySlot_m_handicap();
            m_handicap = Option.Some(parsed_m_handicap);
        }

        if (m_observe is { HasValue: false })                           
        {
            var parsed_m_observe = Parse_GameSLobbySlot_m_observe();
            m_observe = Option.Some(parsed_m_observe);
        }

        if (m_rewards is { HasValue: false })                           
        {
            var parsed_m_rewards = Parse_GameSLobbySlot_m_rewards();
            m_rewards = Option.Some(parsed_m_rewards);
        }

        return new GameSLobbySlot
        {   
            m_control = Option.OkOrReturnMissingFieldErr(m_control),
            m_userId = Option.OkOrReturnMissingFieldErr(m_userId),
            m_teamId = Option.OkOrReturnMissingFieldErr(m_teamId),
            m_colorPref = Option.OkOrReturnMissingFieldErr(m_colorPref),
            m_racePref = Option.OkOrReturnMissingFieldErr(m_racePref),
            m_difficulty = Option.OkOrReturnMissingFieldErr(m_difficulty),
            m_handicap = Option.OkOrReturnMissingFieldErr(m_handicap),
            m_observe = Option.OkOrReturnMissingFieldErr(m_observe),
            m_rewards = Option.OkOrReturnMissingFieldErr(m_rewards),
        };
    }

    public GameTControlId Parse_GameSLobbySlot_m_control()
    {                             
        var m_control = Parse_GameTControlId();
        return m_control;
    }

    public Option<TUserId> Parse_GameSLobbySlot_m_userId()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_TUserId();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public GameTTeamId Parse_GameSLobbySlot_m_teamId()
    {                             
        var m_teamId = Parse_GameTTeamId();
        return m_teamId;
    }

    public GameTColorPreference Parse_GameSLobbySlot_m_colorPref()
    {                             
        var m_colorPref = Parse_GameTColorPreference();
        return m_colorPref;
    }

    public TRacePreference Parse_GameSLobbySlot_m_racePref()
    {                             
        var m_racePref = Parse_TRacePreference();
        return m_racePref;
    }

    public GameTDifficulty Parse_GameSLobbySlot_m_difficulty()
    {                             
        var m_difficulty = Parse_GameTDifficulty();
        return m_difficulty;
    }

    public GameTHandicap Parse_GameSLobbySlot_m_handicap()
    {                             
        var m_handicap = Parse_GameTHandicap();
        return m_handicap;
    }

    public EObserve Parse_GameSLobbySlot_m_observe()
    {                             
        var m_observe = Parse_EObserve();
        return m_observe;
    }

    public GameCRewardArray Parse_GameSLobbySlot_m_rewards()
    {                             
        var m_rewards = Parse_GameCRewardArray();
        return m_rewards;
    }

    public GameSLobbyState Parse_GameSLobbyState() 
    {
        Option<GameEPhase> m_phase = Option.None;
        Option<TUserCount> m_maxUsers = Option.None;
        Option<TUserCount> m_maxObservers = Option.None;
        Option<GameCLobbySlotArray> m_slots = Option.None;
        Option<uint32> m_randomSeed = Option.None;
        var m_hostUserId = Option.Some<Option<TUserId>>(Option.None);
        Option<bool> m_isSinglePlayer = Option.None;
        Option<uint32> m_gameDuration = Option.None;
        Option<GameTDifficulty> m_defaultDifficulty = Option.None;
        if (m_phase is { HasValue: false })                           
        {
            var parsed_m_phase = Parse_GameSLobbyState_m_phase();
            m_phase = Option.Some(parsed_m_phase);
        }

        if (m_maxUsers is { HasValue: false })                           
        {
            var parsed_m_maxUsers = Parse_GameSLobbyState_m_maxUsers();
            m_maxUsers = Option.Some(parsed_m_maxUsers);
        }

        if (m_maxObservers is { HasValue: false })                           
        {
            var parsed_m_maxObservers = Parse_GameSLobbyState_m_maxObservers();
            m_maxObservers = Option.Some(parsed_m_maxObservers);
        }

        if (m_slots is { HasValue: false })                           
        {
            var parsed_m_slots = Parse_GameSLobbyState_m_slots();
            m_slots = Option.Some(parsed_m_slots);
        }

        if (m_randomSeed is { HasValue: false })                           
        {
            var parsed_m_randomSeed = Parse_GameSLobbyState_m_randomSeed();
            m_randomSeed = Option.Some(parsed_m_randomSeed);
        }

        if (m_hostUserId is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_hostUserId = Parse_GameSLobbyState_m_hostUserId();
            m_hostUserId = Option.Some(parsed_m_hostUserId);
        }

        if (m_isSinglePlayer is { HasValue: false })                           
        {
            var parsed_m_isSinglePlayer = Parse_GameSLobbyState_m_isSinglePlayer();
            m_isSinglePlayer = Option.Some(parsed_m_isSinglePlayer);
        }

        if (m_gameDuration is { HasValue: false })                           
        {
            var parsed_m_gameDuration = Parse_GameSLobbyState_m_gameDuration();
            m_gameDuration = Option.Some(parsed_m_gameDuration);
        }

        if (m_defaultDifficulty is { HasValue: false })                           
        {
            var parsed_m_defaultDifficulty = Parse_GameSLobbyState_m_defaultDifficulty();
            m_defaultDifficulty = Option.Some(parsed_m_defaultDifficulty);
        }

        return new GameSLobbyState
        {   
            m_phase = Option.OkOrReturnMissingFieldErr(m_phase),
            m_maxUsers = Option.OkOrReturnMissingFieldErr(m_maxUsers),
            m_maxObservers = Option.OkOrReturnMissingFieldErr(m_maxObservers),
            m_slots = Option.OkOrReturnMissingFieldErr(m_slots),
            m_randomSeed = Option.OkOrReturnMissingFieldErr(m_randomSeed),
            m_hostUserId = Option.OkOrReturnMissingFieldErr(m_hostUserId),
            m_isSinglePlayer = Option.OkOrReturnMissingFieldErr(m_isSinglePlayer),
            m_gameDuration = Option.OkOrReturnMissingFieldErr(m_gameDuration),
            m_defaultDifficulty = Option.OkOrReturnMissingFieldErr(m_defaultDifficulty),
        };
    }

    public GameEPhase Parse_GameSLobbyState_m_phase()
    {                             
        var m_phase = Parse_GameEPhase();
        return m_phase;
    }

    public TUserCount Parse_GameSLobbyState_m_maxUsers()
    {                             
        var m_maxUsers = Parse_TUserCount();
        return m_maxUsers;
    }

    public TUserCount Parse_GameSLobbyState_m_maxObservers()
    {                             
        var m_maxObservers = Parse_TUserCount();
        return m_maxObservers;
    }

    public GameCLobbySlotArray Parse_GameSLobbyState_m_slots()
    {                             
        var m_slots = Parse_GameCLobbySlotArray();
        return m_slots;
    }

    public uint32 Parse_GameSLobbyState_m_randomSeed()
    {                             
        var m_randomSeed = Parse_uint32();
        return m_randomSeed;
    }

    public Option<TUserId> Parse_GameSLobbyState_m_hostUserId()
    {                             
            var isProvided = parse_bool();

            if (isProvided)
            {
                var res = Parse_TUserId();

                return Option.Some(res);
            }
            else
            {
                return Option.None;
            }
    }

    public bool Parse_GameSLobbyState_m_isSinglePlayer()
    {                             
        var m_isSinglePlayer = parse_bool();
        return m_isSinglePlayer;
    }

    public uint32 Parse_GameSLobbyState_m_gameDuration()
    {                             
        var m_gameDuration = Parse_uint32();
        return m_gameDuration;
    }

    public GameTDifficulty Parse_GameSLobbyState_m_defaultDifficulty()
    {                             
        var m_defaultDifficulty = Parse_GameTDifficulty();
        return m_defaultDifficulty;
    }

    public GameSLobbySyncState Parse_GameSLobbySyncState() 
    {
        Option<CUserInitialDataArray> m_userInitialData = Option.None;
        Option<GameSGameDescription> m_gameDescription = Option.None;
        Option<GameSLobbyState> m_lobbyState = Option.None;
        if (m_userInitialData is { HasValue: false })                           
        {
            var parsed_m_userInitialData = Parse_GameSLobbySyncState_m_userInitialData();
            m_userInitialData = Option.Some(parsed_m_userInitialData);
        }

        if (m_gameDescription is { HasValue: false })                           
        {
            var parsed_m_gameDescription = Parse_GameSLobbySyncState_m_gameDescription();
            m_gameDescription = Option.Some(parsed_m_gameDescription);
        }

        if (m_lobbyState is { HasValue: false })                           
        {
            var parsed_m_lobbyState = Parse_GameSLobbySyncState_m_lobbyState();
            m_lobbyState = Option.Some(parsed_m_lobbyState);
        }

        return new GameSLobbySyncState
        {   
            m_userInitialData = Option.OkOrReturnMissingFieldErr(m_userInitialData),
            m_gameDescription = Option.OkOrReturnMissingFieldErr(m_gameDescription),
            m_lobbyState = Option.OkOrReturnMissingFieldErr(m_lobbyState),
        };
    }

    public CUserInitialDataArray Parse_GameSLobbySyncState_m_userInitialData()
    {                             
        var m_userInitialData = Parse_CUserInitialDataArray();
        return m_userInitialData;
    }

    public GameSGameDescription Parse_GameSLobbySyncState_m_gameDescription()
    {                             
        var m_gameDescription = Parse_GameSGameDescription();
        return m_gameDescription;
    }

    public GameSLobbyState Parse_GameSLobbySyncState_m_lobbyState()
    {                             
        var m_lobbyState = Parse_GameSLobbyState();
        return m_lobbyState;
    }

    public GameSChatMessage Parse_GameSChatMessage() 
    {
        Option<GameEMessageRecipient> m_recipient = Option.None;
        Option<GameCChatString> m_string = Option.None;
        if (m_recipient is { HasValue: false })                           
        {
            var parsed_m_recipient = Parse_GameSChatMessage_m_recipient();
            m_recipient = Option.Some(parsed_m_recipient);
        }

        if (m_string is { HasValue: false })                           
        {
            var parsed_m_string = Parse_GameSChatMessage_m_string();
            m_string = Option.Some(parsed_m_string);
        }

        return new GameSChatMessage
        {   
            m_recipient = Option.OkOrReturnMissingFieldErr(m_recipient),
            m_string = Option.OkOrReturnMissingFieldErr(m_string),
        };
    }

    public GameEMessageRecipient Parse_GameSChatMessage_m_recipient()
    {                             
        var m_recipient = Parse_GameEMessageRecipient();
        return m_recipient;
    }

    public GameCChatString Parse_GameSChatMessage_m_string()
    {                             
        var m_string = Parse_GameCChatString();
        return m_string;
    }

    public GameSPingMessage Parse_GameSPingMessage() 
    {
        Option<GameEMessageRecipient> m_recipient = Option.None;
        Option<GameSPoint> m_point = Option.None;
        if (m_recipient is { HasValue: false })                           
        {
            var parsed_m_recipient = Parse_GameSPingMessage_m_recipient();
            m_recipient = Option.Some(parsed_m_recipient);
        }

        if (m_point is { HasValue: false })                           
        {
            var parsed_m_point = Parse_GameSPingMessage_m_point();
            m_point = Option.Some(parsed_m_point);
        }

        return new GameSPingMessage
        {   
            m_recipient = Option.OkOrReturnMissingFieldErr(m_recipient),
            m_point = Option.OkOrReturnMissingFieldErr(m_point),
        };
    }

    public GameEMessageRecipient Parse_GameSPingMessage_m_recipient()
    {                             
        var m_recipient = Parse_GameEMessageRecipient();
        return m_recipient;
    }

    public GameSPoint Parse_GameSPingMessage_m_point()
    {                             
        var m_point = Parse_GameSPoint();
        return m_point;
    }

    public GameSLoadingProgressMessage Parse_GameSLoadingProgressMessage() 
    {
        Option<int32> m_progress = Option.None;
        if (m_progress is { HasValue: false })                           
        {
            var parsed_m_progress = Parse_GameSLoadingProgressMessage_m_progress();
            m_progress = Option.Some(parsed_m_progress);
        }

        return new GameSLoadingProgressMessage
        {   
            m_progress = Option.OkOrReturnMissingFieldErr(m_progress),
        };
    }

    public int32 Parse_GameSLoadingProgressMessage_m_progress()
    {                             
        var m_progress = Parse_int32();
        return m_progress;
    }

    public GameSServerPingMessage Parse_GameSServerPingMessage() 
    {
        return new GameSServerPingMessage
        {   
        };
    }

    public GameSSelectionDeltaSubgroup Parse_GameSSelectionDeltaSubgroup() 
    {
        Option<GameTUnitLink> m_unitLink = Option.None;
        Option<GameTSubgroupPriority> m_intraSubgroupPriority = Option.None;
        Option<GameTSelectionCount> m_count = Option.None;
        if (m_unitLink is { HasValue: false })                           
        {
            var parsed_m_unitLink = Parse_GameSSelectionDeltaSubgroup_m_unitLink();
            m_unitLink = Option.Some(parsed_m_unitLink);
        }

        if (m_intraSubgroupPriority is { HasValue: false })                           
        {
            var parsed_m_intraSubgroupPriority = Parse_GameSSelectionDeltaSubgroup_m_intraSubgroupPriority();
            m_intraSubgroupPriority = Option.Some(parsed_m_intraSubgroupPriority);
        }

        if (m_count is { HasValue: false })                           
        {
            var parsed_m_count = Parse_GameSSelectionDeltaSubgroup_m_count();
            m_count = Option.Some(parsed_m_count);
        }

        return new GameSSelectionDeltaSubgroup
        {   
            m_unitLink = Option.OkOrReturnMissingFieldErr(m_unitLink),
            m_intraSubgroupPriority = Option.OkOrReturnMissingFieldErr(m_intraSubgroupPriority),
            m_count = Option.OkOrReturnMissingFieldErr(m_count),
        };
    }

    public GameTUnitLink Parse_GameSSelectionDeltaSubgroup_m_unitLink()
    {                             
        var m_unitLink = Parse_GameTUnitLink();
        return m_unitLink;
    }

    public GameTSubgroupPriority Parse_GameSSelectionDeltaSubgroup_m_intraSubgroupPriority()
    {                             
        var m_intraSubgroupPriority = Parse_GameTSubgroupPriority();
        return m_intraSubgroupPriority;
    }

    public GameTSelectionCount Parse_GameSSelectionDeltaSubgroup_m_count()
    {                             
        var m_count = Parse_GameTSelectionCount();
        return m_count;
    }

    public GameSSelectionDelta Parse_GameSSelectionDelta() 
    {
        Option<GameTSubgroupIndex> m_subgroupIndex = Option.None;
        Option<GameSSelectionMask> m_removeMask = Option.None;
        Option<List<GameSSelectionDeltaSubgroup>> m_addSubgroups = Option.None;
        Option<List<GameTUnitTag>> m_addUnitTags = Option.None;
        if (m_subgroupIndex is { HasValue: false })                           
        {
            var parsed_m_subgroupIndex = Parse_GameSSelectionDelta_m_subgroupIndex();
            m_subgroupIndex = Option.Some(parsed_m_subgroupIndex);
        }

        if (m_removeMask is { HasValue: false })                           
        {
            var parsed_m_removeMask = Parse_GameSSelectionDelta_m_removeMask();
            m_removeMask = Option.Some(parsed_m_removeMask);
        }

        if (m_addSubgroups is { HasValue: false })                           
        {
            var parsed_m_addSubgroups = Parse_GameSSelectionDelta_m_addSubgroups();
            m_addSubgroups = Option.Some(parsed_m_addSubgroups);
        }

        if (m_addUnitTags is { HasValue: false })                           
        {
            var parsed_m_addUnitTags = Parse_GameSSelectionDelta_m_addUnitTags();
            m_addUnitTags = Option.Some(parsed_m_addUnitTags);
        }

        return new GameSSelectionDelta
        {   
            m_subgroupIndex = Option.OkOrReturnMissingFieldErr(m_subgroupIndex),
            m_removeMask = Option.OkOrReturnMissingFieldErr(m_removeMask),
            m_addSubgroups = Option.OkOrReturnMissingFieldErr(m_addSubgroups),
            m_addUnitTags = Option.OkOrReturnMissingFieldErr(m_addUnitTags),
        };
    }

    public GameTSubgroupIndex Parse_GameSSelectionDelta_m_subgroupIndex()
    {                             
        var m_subgroupIndex = Parse_GameTSubgroupIndex();
        return m_subgroupIndex;
    }

    public GameSSelectionMask Parse_GameSSelectionDelta_m_removeMask()
    {                             
        var m_removeMask = Parse_GameSSelectionMask();
        return m_removeMask;
    }

    public List<GameSSelectionDeltaSubgroup> Parse_GameSSelectionDelta_m_addSubgroups()
    {                             
        var arrayLength = take_n_bits_into_i64(8);
        var array = new List<GameSSelectionDeltaSubgroup>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = Parse_GameSSelectionDeltaSubgroup();
            array.Add(data);
        }
        return array;
    }

    public List<GameTUnitTag> Parse_GameSSelectionDelta_m_addUnitTags()
    {                             
        var arrayLength = take_n_bits_into_i64(8);
        var array = new List<GameTUnitTag>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = Parse_GameTUnitTag();
            array.Add(data);
        }
        return array;
    }

    public GameSSelectionSyncData Parse_GameSSelectionSyncData() 
    {
        Option<GameTSelectionCount> m_count = Option.None;
        Option<GameTSubgroupCount> m_subgroupCount = Option.None;
        Option<GameTSubgroupIndex> m_activeSubgroupIndex = Option.None;
        Option<GameTSyncChecksum> m_unitTagsChecksum = Option.None;
        Option<GameTSyncChecksum> m_subgroupIndicesChecksum = Option.None;
        Option<GameTSyncChecksum> m_subgroupsChecksum = Option.None;
        if (m_count is { HasValue: false })                           
        {
            var parsed_m_count = Parse_GameSSelectionSyncData_m_count();
            m_count = Option.Some(parsed_m_count);
        }

        if (m_subgroupCount is { HasValue: false })                           
        {
            var parsed_m_subgroupCount = Parse_GameSSelectionSyncData_m_subgroupCount();
            m_subgroupCount = Option.Some(parsed_m_subgroupCount);
        }

        if (m_activeSubgroupIndex is { HasValue: false })                           
        {
            var parsed_m_activeSubgroupIndex = Parse_GameSSelectionSyncData_m_activeSubgroupIndex();
            m_activeSubgroupIndex = Option.Some(parsed_m_activeSubgroupIndex);
        }

        if (m_unitTagsChecksum is { HasValue: false })                           
        {
            var parsed_m_unitTagsChecksum = Parse_GameSSelectionSyncData_m_unitTagsChecksum();
            m_unitTagsChecksum = Option.Some(parsed_m_unitTagsChecksum);
        }

        if (m_subgroupIndicesChecksum is { HasValue: false })                           
        {
            var parsed_m_subgroupIndicesChecksum = Parse_GameSSelectionSyncData_m_subgroupIndicesChecksum();
            m_subgroupIndicesChecksum = Option.Some(parsed_m_subgroupIndicesChecksum);
        }

        if (m_subgroupsChecksum is { HasValue: false })                           
        {
            var parsed_m_subgroupsChecksum = Parse_GameSSelectionSyncData_m_subgroupsChecksum();
            m_subgroupsChecksum = Option.Some(parsed_m_subgroupsChecksum);
        }

        return new GameSSelectionSyncData
        {   
            m_count = Option.OkOrReturnMissingFieldErr(m_count),
            m_subgroupCount = Option.OkOrReturnMissingFieldErr(m_subgroupCount),
            m_activeSubgroupIndex = Option.OkOrReturnMissingFieldErr(m_activeSubgroupIndex),
            m_unitTagsChecksum = Option.OkOrReturnMissingFieldErr(m_unitTagsChecksum),
            m_subgroupIndicesChecksum = Option.OkOrReturnMissingFieldErr(m_subgroupIndicesChecksum),
            m_subgroupsChecksum = Option.OkOrReturnMissingFieldErr(m_subgroupsChecksum),
        };
    }

    public GameTSelectionCount Parse_GameSSelectionSyncData_m_count()
    {                             
        var m_count = Parse_GameTSelectionCount();
        return m_count;
    }

    public GameTSubgroupCount Parse_GameSSelectionSyncData_m_subgroupCount()
    {                             
        var m_subgroupCount = Parse_GameTSubgroupCount();
        return m_subgroupCount;
    }

    public GameTSubgroupIndex Parse_GameSSelectionSyncData_m_activeSubgroupIndex()
    {                             
        var m_activeSubgroupIndex = Parse_GameTSubgroupIndex();
        return m_activeSubgroupIndex;
    }

    public GameTSyncChecksum Parse_GameSSelectionSyncData_m_unitTagsChecksum()
    {                             
        var m_unitTagsChecksum = Parse_GameTSyncChecksum();
        return m_unitTagsChecksum;
    }

    public GameTSyncChecksum Parse_GameSSelectionSyncData_m_subgroupIndicesChecksum()
    {                             
        var m_subgroupIndicesChecksum = Parse_GameTSyncChecksum();
        return m_subgroupIndicesChecksum;
    }

    public GameTSyncChecksum Parse_GameSSelectionSyncData_m_subgroupsChecksum()
    {                             
        var m_subgroupsChecksum = Parse_GameTSyncChecksum();
        return m_subgroupsChecksum;
    }

    public GameSSessionSyncInfo Parse_GameSSessionSyncInfo() 
    {
        Option<uint32> m_gameLoop = Option.None;
        Option<List<GameTSyncChecksum>> m_checksums = Option.None;
        if (m_gameLoop is { HasValue: false })                           
        {
            var parsed_m_gameLoop = Parse_GameSSessionSyncInfo_m_gameLoop();
            m_gameLoop = Option.Some(parsed_m_gameLoop);
        }

        if (m_checksums is { HasValue: false })                           
        {
            var parsed_m_checksums = Parse_GameSSessionSyncInfo_m_checksums();
            m_checksums = Option.Some(parsed_m_checksums);
        }

        return new GameSSessionSyncInfo
        {   
            m_gameLoop = Option.OkOrReturnMissingFieldErr(m_gameLoop),
            m_checksums = Option.OkOrReturnMissingFieldErr(m_checksums),
        };
    }

    public uint32 Parse_GameSSessionSyncInfo_m_gameLoop()
    {                             
        var m_gameLoop = Parse_uint32();
        return m_gameLoop;
    }

    public List<GameTSyncChecksum> Parse_GameSSessionSyncInfo_m_checksums()
    {                             
        var arrayLength = take_n_bits_into_i64(6);
        var array = new List<GameTSyncChecksum>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = Parse_GameTSyncChecksum();
            array.Add(data);
        }
        return array;
    }

    public GameSGameSyncInfo Parse_GameSGameSyncInfo() 
    {
        Option<List<GameTSyncChecksum>> m_checksums = Option.None;
        if (m_checksums is { HasValue: false })                           
        {
            var parsed_m_checksums = Parse_GameSGameSyncInfo_m_checksums();
            m_checksums = Option.Some(parsed_m_checksums);
        }

        return new GameSGameSyncInfo
        {   
            m_checksums = Option.OkOrReturnMissingFieldErr(m_checksums),
        };
    }

    public List<GameTSyncChecksum> Parse_GameSGameSyncInfo_m_checksums()
    {                             
        var arrayLength = take_n_bits_into_i64(8);
        var array = new List<GameTSyncChecksum>();

        for (var i = 0 ; i < arrayLength ; ++i)
        {
            var data = Parse_GameTSyncChecksum();
            array.Add(data);
        }
        return array;
    }

    public ReplaySInitData Parse_ReplaySInitData() 
    {
        Option<GameSLobbySyncState> m_syncLobbyState = Option.None;
        if (m_syncLobbyState is { HasValue: false })                           
        {
            var parsed_m_syncLobbyState = Parse_ReplaySInitData_m_syncLobbyState();
            m_syncLobbyState = Option.Some(parsed_m_syncLobbyState);
        }

        return new ReplaySInitData
        {   
            m_syncLobbyState = Option.OkOrReturnMissingFieldErr(m_syncLobbyState),
        };
    }

    public GameSLobbySyncState Parse_ReplaySInitData_m_syncLobbyState()
    {                             
        var m_syncLobbyState = Parse_GameSLobbySyncState();
        return m_syncLobbyState;
    }
    public EObserve Parse_EObserve()
    {
        ValidateIntTag();
        var variantTag = ParseVlqInt();

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new EObserve_e_none();
            }
            break;                  
            case 1:
            {                        
                return new EObserve_e_spectator();
            }
            break;                  
            case 2:
            {                        
                return new EObserve_e_referee();
            }
            break;                  
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEGameSpeed Parse_GameEGameSpeed()
    {
        ValidateIntTag();
        var variantTag = ParseVlqInt();

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEGameSpeed_e_slower();
            }
            break;                  
            case 1:
            {                        
                return new GameEGameSpeed_e_slow();
            }
            break;                  
            case 2:
            {                        
                return new GameEGameSpeed_e_normal();
            }
            break;                  
            case 3:
            {                        
                return new GameEGameSpeed_e_fast();
            }
            break;                  
            case 4:
            {                        
                return new GameEGameSpeed_e_faster();
            }
            break;                  
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEResultDetails Parse_GameEResultDetails()
    {
        ValidateIntTag();
        var variantTag = ParseVlqInt();

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEResultDetails_e_undecided();
            }
            break;                  
            case 1:
            {                        
                return new GameEResultDetails_e_win();
            }
            break;                  
            case 2:
            {                        
                return new GameEResultDetails_e_loss();
            }
            break;                  
            case 3:
            {                        
                return new GameEResultDetails_e_tie();
            }
            break;                  
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public ELeaveReason Parse_ELeaveReason()
    {
        ValidateIntTag();
        var numBits = 11;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new ELeaveReason_e_userLeft();
            }
            break;                  
            case 1:
            {                        
                return new ELeaveReason_e_userDropped();
            }
            break;                  
            case 2:
            {                        
                return new ELeaveReason_e_userBanned();
            }
            break;                  
            case 3:
            {                        
                return new ELeaveReason_e_userVictory();
            }
            break;                  
            case 4:
            {                        
                return new ELeaveReason_e_userDefeat();
            }
            break;                  
            case 5:
            {                        
                return new ELeaveReason_e_userTied();
            }
            break;                  
            case 6:
            {                        
                return new ELeaveReason_e_userDesynced();
            }
            break;                  
            case 7:
            {                        
                return new ELeaveReason_e_userOutOfTime();
            }
            break;                  
            case 8:
            {                        
                return new ELeaveReason_e_weWereUnresponsive();
            }
            break;                  
            case 9:
            {                        
                return new ELeaveReason_e_weContinuedAlone();
            }
            break;                  
            case 10:
            {                        
                return new ELeaveReason_e_replayDesynced();
            }
            break;                  
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameESynchronous Parse_GameESynchronous()
    {
        ValidateIntTag();
        var numBits = 3;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameESynchronous_e_local();
            }
            break;                  
            case 1:
            {                        
                var res = Parse_GameSSetLobbySlotEvent();

                return new GameESynchronous_e_session(res);
            }
            break;                  
            case 2:
            {                        
                var res = Parse_GameSBankFileEvent();

                return new GameESynchronous_e_game(res);
            }
            break;                  
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameESynthesized Parse_GameESynthesized()
    {
        ValidateIntTag();
        var numBits = 2;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                var res = Parse_GameSDropOurselvesEvent();

                return new GameESynthesized_e_synthesized(res);
            }
            break;                  
            case 1:
            {                        
                var res = Parse_GameSSetLobbySlotEvent();

                return new GameESynthesized_e_notSynthesized(res);
            }
            break;                  
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEDebug Parse_GameEDebug()
    {
        ValidateIntTag();
        var numBits = 2;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                var res = Parse_GameSSingleStepGameEvent();

                return new GameEDebug_e_debug(res);
            }
            break;                  
            case 1:
            {                        
                var res = Parse_GameSSetLobbySlotEvent();

                return new GameEDebug_e_notDebug(res);
            }
            break;                  
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEEventId Parse_GameEEventId()
    {
        ValidateIntTag();
        var numBits = 87;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                var res = Parse_GameSSetLobbySlotEvent();

                return new GameEEventId_e_setLobbySlot(res);
            }
            break;                  
            case 1:
            {                        
                var res = Parse_GameSDropUserEvent();

                return new GameEEventId_e_dropUser(res);
            }
            break;                  
            case 2:
            {                        
                var res = Parse_GameSStartGameEvent();

                return new GameEEventId_e_startGame(res);
            }
            break;                  
            case 3:
            {                        
                var res = Parse_GameSDropOurselvesEvent();

                return new GameEEventId_e_dropOurselves(res);
            }
            break;                  
            case 4:
            {                        
                var res = Parse_GameSUserFinishedLoadingEvent();

                return new GameEEventId_e_userFinishedLoading(res);
            }
            break;                  
            case 5:
            {                        
                var res = Parse_GameSUserFinishedLoadingSyncEvent();

                return new GameEEventId_e_userFinishedLoadingSync(res);
            }
            break;                  
            case 6:
            {                        
                var res = Parse_GameSSetGameDurationEvent();

                return new GameEEventId_e_setGameDuration(res);
            }
            break;                  
            case 7:
            {                        
                var res = Parse_GameSBankFileEvent();

                return new GameEEventId_e_bankFile(res);
            }
            break;                  
            case 8:
            {                        
                var res = Parse_GameSBankSectionEvent();

                return new GameEEventId_e_bankSection(res);
            }
            break;                  
            case 9:
            {                        
                var res = Parse_GameSBankKeyEvent();

                return new GameEEventId_e_bankKey(res);
            }
            break;                  
            case 10:
            {                        
                var res = Parse_GameSBankValueEvent();

                return new GameEEventId_e_bankValue(res);
            }
            break;                  
            case 11:
            {                        
                var res = Parse_GameSUserOptionsEvent();

                return new GameEEventId_e_userOptions(res);
            }
            break;                  
            case 12:
            {                        
                var res = Parse_GameSTurnEvent();

                return new GameEEventId_e_turn(res);
            }
            break;                  
            case 16:
            {                        
                var res = Parse_GameSPauseGameEvent();

                return new GameEEventId_e_pauseGame(res);
            }
            break;                  
            case 17:
            {                        
                var res = Parse_GameSUnpauseGameEvent();

                return new GameEEventId_e_unpauseGame(res);
            }
            break;                  
            case 18:
            {                        
                var res = Parse_GameSSingleStepGameEvent();

                return new GameEEventId_e_singleStepGame(res);
            }
            break;                  
            case 19:
            {                        
                var res = Parse_GameSSetGameSpeedEvent();

                return new GameEEventId_e_setGameSpeed(res);
            }
            break;                  
            case 20:
            {                        
                var res = Parse_GameSAddGameSpeedEvent();

                return new GameEEventId_e_addGameSpeed(res);
            }
            break;                  
            case 21:
            {                        
                var res = Parse_GameSRestartGameEvent();

                return new GameEEventId_e_restartGame(res);
            }
            break;                  
            case 22:
            {                        
                var res = Parse_GameSSaveGameEvent();

                return new GameEEventId_e_saveGame(res);
            }
            break;                  
            case 23:
            {                        
                var res = Parse_GameSSaveGameDoneEvent();

                return new GameEEventId_e_saveGameDone(res);
            }
            break;                  
            case 24:
            {                        
                var res = Parse_GameSSessionCheatEvent();

                return new GameEEventId_e_sessionCheat(res);
            }
            break;                  
            case 25:
            {                        
                var res = Parse_GameSPlayerLeaveEvent();

                return new GameEEventId_e_playerLeave(res);
            }
            break;                  
            case 26:
            {                        
                var res = Parse_GameSGameCheatEvent();

                return new GameEEventId_e_gameCheat(res);
            }
            break;                  
            case 27:
            {                        
                var res = Parse_GameSCmdEvent();

                return new GameEEventId_e_cmd(res);
            }
            break;                  
            case 28:
            {                        
                var res = Parse_GameSSelectionDeltaEvent();

                return new GameEEventId_e_selectionDelta(res);
            }
            break;                  
            case 29:
            {                        
                var res = Parse_GameSControlGroupUpdateEvent();

                return new GameEEventId_e_controlGroupUpdate(res);
            }
            break;                  
            case 30:
            {                        
                var res = Parse_GameSSelectionSyncCheckEvent();

                return new GameEEventId_e_selectionSyncCheck(res);
            }
            break;                  
            case 31:
            {                        
                var res = Parse_GameSResourceTradeEvent();

                return new GameEEventId_e_resourceTrade(res);
            }
            break;                  
            case 32:
            {                        
                var res = Parse_GameSTriggerChatMessageEvent();

                return new GameEEventId_e_triggerChatMessage(res);
            }
            break;                  
            case 33:
            {                        
                var res = Parse_GameSAICommunicateEvent();

                return new GameEEventId_e_aiCommunicate(res);
            }
            break;                  
            case 34:
            {                        
                var res = Parse_GameSSetAbsoluteGameSpeedEvent();

                return new GameEEventId_e_setAbsoluteGameSpeed(res);
            }
            break;                  
            case 35:
            {                        
                var res = Parse_GameSAddAbsoluteGameSpeedEvent();

                return new GameEEventId_e_addAbsoluteGameSpeed(res);
            }
            break;                  
            case 37:
            {                        
                var res = Parse_GameSBroadcastCheatEvent();

                return new GameEEventId_e_broadcastCheat(res);
            }
            break;                  
            case 38:
            {                        
                var res = Parse_GameSAllianceEvent();

                return new GameEEventId_e_alliance(res);
            }
            break;                  
            case 39:
            {                        
                var res = Parse_GameSUnitClickEvent();

                return new GameEEventId_e_unitClick(res);
            }
            break;                  
            case 40:
            {                        
                var res = Parse_GameSUnitHighlightEvent();

                return new GameEEventId_e_unitHighlight(res);
            }
            break;                  
            case 41:
            {                        
                var res = Parse_GameSTriggerReplySelectedEvent();

                return new GameEEventId_e_triggerReplySelected(res);
            }
            break;                  
            case 44:
            {                        
                var res = Parse_GameSTriggerSkippedEvent();

                return new GameEEventId_e_triggerSkipped(res);
            }
            break;                  
            case 45:
            {                        
                var res = Parse_GameSTriggerSoundLengthQueryEvent();

                return new GameEEventId_e_triggerSoundLengthQuery(res);
            }
            break;                  
            case 46:
            {                        
                var res = Parse_GameSTriggerSoundOffsetEvent();

                return new GameEEventId_e_triggerSoundOffset(res);
            }
            break;                  
            case 47:
            {                        
                var res = Parse_GameSTriggerTransmissionOffsetEvent();

                return new GameEEventId_e_triggerTransmissionOffset(res);
            }
            break;                  
            case 48:
            {                        
                var res = Parse_GameSTriggerTransmissionCompleteEvent();

                return new GameEEventId_e_triggerTransmissionComplete(res);
            }
            break;                  
            case 49:
            {                        
                var res = Parse_GameSCameraUpdateEvent();

                return new GameEEventId_e_cameraUpdate(res);
            }
            break;                  
            case 50:
            {                        
                var res = Parse_GameSTriggerAbortMissionEvent();

                return new GameEEventId_e_triggerAbortMission(res);
            }
            break;                  
            case 51:
            {                        
                var res = Parse_GameSTriggerPurchaseMadeEvent();

                return new GameEEventId_e_triggerPurchaseMade(res);
            }
            break;                  
            case 52:
            {                        
                var res = Parse_GameSTriggerPurchaseExitEvent();

                return new GameEEventId_e_triggerPurchaseExit(res);
            }
            break;                  
            case 53:
            {                        
                var res = Parse_GameSTriggerPlanetMissionLaunchedEvent();

                return new GameEEventId_e_triggerPlanetMissionLaunched(res);
            }
            break;                  
            case 54:
            {                        
                var res = Parse_GameSTriggerPlanetPanelCanceledEvent();

                return new GameEEventId_e_triggerPlanetPanelCanceled(res);
            }
            break;                  
            case 55:
            {                        
                var res = Parse_GameSTriggerDialogControlEvent();

                return new GameEEventId_e_triggerDialogControl(res);
            }
            break;                  
            case 56:
            {                        
                var res = Parse_GameSTriggerSoundLengthSyncEvent();

                return new GameEEventId_e_triggerSoundLengthSync(res);
            }
            break;                  
            case 57:
            {                        
                var res = Parse_GameSTriggerConversationSkippedEvent();

                return new GameEEventId_e_triggerConversationSkipped(res);
            }
            break;                  
            case 58:
            {                        
                var res = Parse_GameSTriggerMouseClickedEvent();

                return new GameEEventId_e_triggerMouseClicked(res);
            }
            break;                  
            case 63:
            {                        
                var res = Parse_GameSTriggerPlanetPanelReplayEvent();

                return new GameEEventId_e_triggerPlanetPanelPanelReplay(res);
            }
            break;                  
            case 64:
            {                        
                var res = Parse_GameSTriggerSoundtrackDoneEvent();

                return new GameEEventId_e_triggerSoundtrackDone(res);
            }
            break;                  
            case 65:
            {                        
                var res = Parse_GameSTriggerPlanetMissionSelectedEvent();

                return new GameEEventId_e_triggerPlanetMissionSelected(res);
            }
            break;                  
            case 66:
            {                        
                var res = Parse_GameSTriggerKeyPressedEvent();

                return new GameEEventId_e_triggerKeyPressed(res);
            }
            break;                  
            case 67:
            {                        
                var res = Parse_GameSTriggerMovieFunctionEvent();

                return new GameEEventId_e_triggerMovieFunction(res);
            }
            break;                  
            case 68:
            {                        
                var res = Parse_GameSTriggerPlanetPanelBirthCompleteEvent();

                return new GameEEventId_e_triggerPlanetPanelPanelBirthComplete(res);
            }
            break;                  
            case 69:
            {                        
                var res = Parse_GameSTriggerPlanetPanelDeathCompleteEvent();

                return new GameEEventId_e_triggerPlanetPanelPanelDeathComplete(res);
            }
            break;                  
            case 70:
            {                        
                var res = Parse_GameSResourceRequestEvent();

                return new GameEEventId_e_resourceRequest(res);
            }
            break;                  
            case 71:
            {                        
                var res = Parse_GameSResourceRequestFulfillEvent();

                return new GameEEventId_e_resourceRequestFulfill(res);
            }
            break;                  
            case 72:
            {                        
                var res = Parse_GameSResourceRequestCancelEvent();

                return new GameEEventId_e_resourceRequestCancel(res);
            }
            break;                  
            case 73:
            {                        
                var res = Parse_GameSTriggerResearchPanelExitEvent();

                return new GameEEventId_e_triggerResearchPanelExit(res);
            }
            break;                  
            case 74:
            {                        
                var res = Parse_GameSTriggerResearchPanelPurchaseEvent();

                return new GameEEventId_e_triggerResearchPanelPurchase(res);
            }
            break;                  
            case 75:
            {                        
                var res = Parse_GameSTriggerResearchPanelSelectionChangedEvent();

                return new GameEEventId_e_triggerResearchPanelSelectionChanged(res);
            }
            break;                  
            case 76:
            {                        
                var res = Parse_GameSLagMessageEvent();

                return new GameEEventId_e_lagMessage(res);
            }
            break;                  
            case 77:
            {                        
                var res = Parse_GameSTriggerMercenaryPanelExitEvent();

                return new GameEEventId_e_triggerMercenaryPanelExit(res);
            }
            break;                  
            case 78:
            {                        
                var res = Parse_GameSTriggerMercenaryPanelPurchaseEvent();

                return new GameEEventId_e_triggerMercenaryPanelPurchase(res);
            }
            break;                  
            case 79:
            {                        
                var res = Parse_GameSTriggerMercenaryPanelSelectionChangedEvent();

                return new GameEEventId_e_triggerMercenaryPanelSelectionChanged(res);
            }
            break;                  
            case 80:
            {                        
                var res = Parse_GameSTriggerVictoryPanelExitEvent();

                return new GameEEventId_e_triggerVictoryPanelExit(res);
            }
            break;                  
            case 81:
            {                        
                var res = Parse_GameSTriggerBattleReportPanelExitEvent();

                return new GameEEventId_e_triggerBattleReportPanelExit(res);
            }
            break;                  
            case 82:
            {                        
                var res = Parse_GameSTriggerBattleReportPanelPlayMissionEvent();

                return new GameEEventId_e_triggerBattleReportPanelPlayMission(res);
            }
            break;                  
            case 83:
            {                        
                var res = Parse_GameSTriggerBattleReportPanelPlaySceneEvent();

                return new GameEEventId_e_triggerBattleReportPanelPlayScene(res);
            }
            break;                  
            case 84:
            {                        
                var res = Parse_GameSTriggerBattleReportPanelSelectionChangedEvent();

                return new GameEEventId_e_triggerBattleReportSelectionChanged(res);
            }
            break;                  
            case 85:
            {                        
                var res = Parse_GameSTriggerVictoryPanelPlayMissionAgainEvent();

                return new GameEEventId_e_triggerVictoryPanelPlayMissionAgain(res);
            }
            break;                  
            case 86:
            {                        
                var res = Parse_GameSTriggerMovieStartedEvent();

                return new GameEEventId_e_triggerMovieStarted(res);
            }
            break;                  
            case 87:
            {                        
                var res = Parse_GameSTriggerMovieFinishedEvent();

                return new GameEEventId_e_triggerMovieFinished(res);
            }
            break;                  
            case 88:
            {                        
                var res = Parse_GameSDecrementGameTimeRemainingEvent();

                return new GameEEventId_e_decrementGameTimeRemaining(res);
            }
            break;                  
            case 89:
            {                        
                var res = Parse_GameSTriggerPortraitLoadedEvent();

                return new GameEEventId_e_triggerPortraitLoaded(res);
            }
            break;                  
            case 90:
            {                        
                var res = Parse_GameSTriggerCustomDialogDismissedEvent();

                return new GameEEventId_e_triggerQueryDialogDismissed(res);
            }
            break;                  
            case 91:
            {                        
                var res = Parse_GameSTriggerGameMenuItemSelectedEvent();

                return new GameEEventId_e_triggerGameMenuItemSelected(res);
            }
            break;                  
            case 92:
            {                        
                var res = Parse_GameSTriggerCameraMoveEvent();

                return new GameEEventId_e_triggerCameraMove(res);
            }
            break;                  
            case 93:
            {                        
                var res = Parse_GameSTriggerPurchasePanelSelectedPurchaseItemChangedEvent();

                return new GameEEventId_e_triggerPurchasePanelSelectedPurchaseItemChanged(res);
            }
            break;                  
            case 94:
            {                        
                var res = Parse_GameSTriggerPurchasePanelSelectedPurchaseCategoryChangedEvent();

                return new GameEEventId_e_triggerPurchasePanelSelectedPurchaseCategoryChanged(res);
            }
            break;                  
            case 95:
            {                        
                var res = Parse_GameSTriggerButtonPressedEvent();

                return new GameEEventId_e_triggerButtonPressed(res);
            }
            break;                  
            case 96:
            {                        
                var res = Parse_GameSTriggerGameCreditsFinishedEvent();

                return new GameEEventId_e_triggerGameCreditsFinished(res);
            }
            break;                  
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEPhase Parse_GameEPhase()
    {
        ValidateIntTag();
        var numBits = 6;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEPhase_e_initializing();
            }
            break;                  
            case 1:
            {                        
                return new GameEPhase_e_lobby();
            }
            break;                  
            case 2:
            {                        
                return new GameEPhase_e_closed();
            }
            break;                  
            case 3:
            {                        
                return new GameEPhase_e_loading();
            }
            break;                  
            case 4:
            {                        
                return new GameEPhase_e_playing();
            }
            break;                  
            case 5:
            {                        
                return new GameEPhase_e_gameover();
            }
            break;                  
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEConversationSkip Parse_GameEConversationSkip()
    {
        ValidateIntTag();
        var numBits = 2;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEConversationSkip_e_skipOneLine();
            }
            break;                  
            case 1:
            {                        
                return new GameEConversationSkip_e_skipAllLines();
            }
            break;                  
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEOptionFog Parse_GameEOptionFog()
    {
        ValidateIntTag();
        var numBits = 4;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEOptionFog_e_default();
            }
            break;                  
            case 1:
            {                        
                return new GameEOptionFog_e_hideTerrain();
            }
            break;                  
            case 2:
            {                        
                return new GameEOptionFog_e_mapExplored();
            }
            break;                  
            case 3:
            {                        
                return new GameEOptionFog_e_alwaysVisible();
            }
            break;                  
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEOptionObservers Parse_GameEOptionObservers()
    {
        ValidateIntTag();
        var numBits = 4;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEOptionObservers_e_none();
            }
            break;                  
            case 1:
            {                        
                return new GameEOptionObservers_e_onJoin();
            }
            break;                  
            case 2:
            {                        
                return new GameEOptionObservers_e_onJoinAndDefeat();
            }
            break;                  
            case 3:
            {                        
                return new GameEOptionObservers_e_refereesOnJoin();
            }
            break;                  
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEOptionUserDifficulty Parse_GameEOptionUserDifficulty()
    {
        ValidateIntTag();
        var numBits = 3;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEOptionUserDifficulty_e_none();
            }
            break;                  
            case 1:
            {                        
                return new GameEOptionUserDifficulty_e_global();
            }
            break;                  
            case 2:
            {                        
                return new GameEOptionUserDifficulty_e_individual();
            }
            break;                  
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEGameLaunch Parse_GameEGameLaunch()
    {
        ValidateIntTag();
        var numBits = 5;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEGameLaunch_e_invalid();
            }
            break;                  
            case 1:
            {                        
                return new GameEGameLaunch_e_normal();
            }
            break;                  
            case 2:
            {                        
                return new GameEGameLaunch_e_replay();
            }
            break;                  
            case 3:
            {                        
                return new GameEGameLaunch_e_save();
            }
            break;                  
            case 4:
            {                        
                return new GameEGameLaunch_e_transition();
            }
            break;                  
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEGameType Parse_GameEGameType()
    {
        ValidateIntTag();
        var numBits = 7;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEGameType_e_melee();
            }
            break;                  
            case 1:
            {                        
                return new GameEGameType_e_freeForAll();
            }
            break;                  
            case 2:
            {                        
                return new GameEGameType_e_useSettings();
            }
            break;                  
            case 3:
            {                        
                return new GameEGameType_e_oneOnOne();
            }
            break;                  
            case 4:
            {                        
                return new GameEGameType_e_twoTeamPlay();
            }
            break;                  
            case 5:
            {                        
                return new GameEGameType_e_threeTeamPlay();
            }
            break;                  
            case 6:
            {                        
                return new GameEGameType_e_fourTeamPlay();
            }
            break;                  
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEControl Parse_GameEControl()
    {
        ValidateIntTag();
        var numBits = 4;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEControl_e_open();
            }
            break;                  
            case 1:
            {                        
                return new GameEControl_e_closed();
            }
            break;                  
            case 2:
            {                        
                return new GameEControl_e_user();
            }
            break;                  
            case 3:
            {                        
                return new GameEControl_e_computer();
            }
            break;                  
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEMessageRecipient Parse_GameEMessageRecipient()
    {
        ValidateIntTag();
        var numBits = 4;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEMessageRecipient_e_all();
            }
            break;                  
            case 1:
            {                        
                return new GameEMessageRecipient_e_allies();
            }
            break;                  
            case 2:
            {                        
                return new GameEMessageRecipient_e_individual();
            }
            break;                  
            case 3:
            {                        
                return new GameEMessageRecipient_e_battlenet();
            }
            break;                  
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEMessageId Parse_GameEMessageId()
    {
        ValidateIntTag();
        var numBits = 4;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                var res = Parse_GameSChatMessage();

                return new GameEMessageId_e_chat(res);
            }
            break;                  
            case 1:
            {                        
                var res = Parse_GameSPingMessage();

                return new GameEMessageId_e_ping(res);
            }
            break;                  
            case 2:
            {                        
                var res = Parse_GameSLoadingProgressMessage();

                return new GameEMessageId_e_loadingProgress(res);
            }
            break;                  
            case 3:
            {                        
                var res = Parse_GameSServerPingMessage();

                return new GameEMessageId_e_serverPing(res);
            }
            break;                  
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEResultCode Parse_GameEResultCode()
    {
        ValidateIntTag();
        var numBits = 4;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEResultCode_e_undecided();
            }
            break;                  
            case 1:
            {                        
                return new GameEResultCode_e_loss();
            }
            break;                  
            case 2:
            {                        
                return new GameEResultCode_e_tie();
            }
            break;                  
            case 3:
            {                        
                return new GameEResultCode_e_win();
            }
            break;                  
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public GameEControlGroupUpdate Parse_GameEControlGroupUpdate()
    {
        ValidateIntTag();
        var numBits = 4;
        var variantTag = parse_packed_int(0, numBits);

        switch (variantTag)
        {
        
            case 0:
            {                        
                return new GameEControlGroupUpdate_e_set();
            }
            break;                  
            case 1:
            {                        
                return new GameEControlGroupUpdate_e_append();
            }
            break;                  
            case 2:
            {                        
                return new GameEControlGroupUpdate_e_recall();
            }
            break;                  
            case 3:
            {                        
                return new GameEControlGroupUpdate_e_clear();
            }
            break;                  
            default:
            {
                throw new Exception("INVALID TAG");
            }
        }
    }
    public TRaceId Parse_TRaceId()
    {
        var offset = 0;
        var numBits = 8;
        var res = parse_packed_int(offset, numBits);

        return new TRaceId
        {
            Value = res
        };
    }
    public TRaceCount Parse_TRaceCount()
    {
        var offset = 1;
        var numBits = 8;
        var res = parse_packed_int(offset, numBits);

        return new TRaceCount
        {
            Value = res
        };
    }
    public int8 Parse_int8()
    {
        var offset = -128;
        var numBits = 8;
        var res = parse_packed_int(offset, numBits);

        return new int8
        {
            Value = res
        };
    }
    public int16 Parse_int16()
    {
        var offset = -32768;
        var numBits = 16;
        var res = parse_packed_int(offset, numBits);

        return new int16
        {
            Value = res
        };
    }
    public int32 Parse_int32()
    {
        var offset = -2147483648;
        var numBits = 32;
        var res = parse_packed_int(offset, numBits);

        return new int32
        {
            Value = res
        };
    }
    public int64 Parse_int64()
    {
        var offset = -9223372036854775808;
        var numBits = 64;
        var res = parse_packed_int(offset, numBits);

        return new int64
        {
            Value = res
        };
    }
    public uint8 Parse_uint8()
    {
        var offset = 0;
        var numBits = 8;
        var res = parse_packed_int(offset, numBits);

        return new uint8
        {
            Value = res
        };
    }
    public uint16 Parse_uint16()
    {
        var offset = 0;
        var numBits = 16;
        var res = parse_packed_int(offset, numBits);

        return new uint16
        {
            Value = res
        };
    }
    public uint32 Parse_uint32()
    {
        var offset = 0;
        var numBits = 32;
        var res = parse_packed_int(offset, numBits);

        return new uint32
        {
            Value = res
        };
    }
    public uint64 Parse_uint64()
    {
        var offset = 0;
        var numBits = 64;
        var res = parse_packed_int(offset, numBits);

        return new uint64
        {
            Value = res
        };
    }
    public uint6 Parse_uint6()
    {
        var offset = 0;
        var numBits = 6;
        var res = parse_packed_int(offset, numBits);

        return new uint6
        {
            Value = res
        };
    }
    public uint14 Parse_uint14()
    {
        var offset = 0;
        var numBits = 14;
        var res = parse_packed_int(offset, numBits);

        return new uint14
        {
            Value = res
        };
    }
    public uint22 Parse_uint22()
    {
        var offset = 0;
        var numBits = 22;
        var res = parse_packed_int(offset, numBits);

        return new uint22
        {
            Value = res
        };
    }
    public TUserId Parse_TUserId()
    {
        var offset = 0;
        var numBits = 4;
        var res = parse_packed_int(offset, numBits);

        return new TUserId
        {
            Value = res
        };
    }
    public TUserCount Parse_TUserCount()
    {
        var offset = 0;
        var numBits = 5;
        var res = parse_packed_int(offset, numBits);

        return new TUserCount
        {
            Value = res
        };
    }
    public GameTColorId Parse_GameTColorId()
    {
        var offset = 0;
        var numBits = 5;
        var res = parse_packed_int(offset, numBits);

        return new GameTColorId
        {
            Value = res
        };
    }
    public GameTColorCount Parse_GameTColorCount()
    {
        var offset = 1;
        var numBits = 6;
        var res = parse_packed_int(offset, numBits);

        return new GameTColorCount
        {
            Value = res
        };
    }
    public GameTFixedInt Parse_GameTFixedInt()
    {
        var offset = -524288;
        var numBits = 20;
        var res = parse_packed_int(offset, numBits);

        return new GameTFixedInt
        {
            Value = res
        };
    }
    public GameTFixedUInt Parse_GameTFixedUInt()
    {
        var offset = 0;
        var numBits = 19;
        var res = parse_packed_int(offset, numBits);

        return new GameTFixedUInt
        {
            Value = res
        };
    }
    public GameTMapCoordFixedBits Parse_GameTMapCoordFixedBits()
    {
        var offset = 0;
        var numBits = 20;
        var res = parse_packed_int(offset, numBits);

        return new GameTMapCoordFixedBits
        {
            Value = res
        };
    }
    public GameTHandicap Parse_GameTHandicap()
    {
        var offset = 0;
        var numBits = 7;
        var res = parse_packed_int(offset, numBits);

        return new GameTHandicap
        {
            Value = res
        };
    }
    public GameTDifficulty Parse_GameTDifficulty()
    {
        var offset = 0;
        var numBits = 6;
        var res = parse_packed_int(offset, numBits);

        return new GameTDifficulty
        {
            Value = res
        };
    }
    public GameTControlId Parse_GameTControlId()
    {
        var offset = 0;
        var numBits = 8;
        var res = parse_packed_int(offset, numBits);

        return new GameTControlId
        {
            Value = res
        };
    }
    public GameTControlCount Parse_GameTControlCount()
    {
        var offset = 1;
        var numBits = 8;
        var res = parse_packed_int(offset, numBits);

        return new GameTControlCount
        {
            Value = res
        };
    }
    public GameTLobbySlotCount Parse_GameTLobbySlotCount()
    {
        var offset = 0;
        var numBits = 5;
        var res = parse_packed_int(offset, numBits);

        return new GameTLobbySlotCount
        {
            Value = res
        };
    }
    public GameTLobbySlotId Parse_GameTLobbySlotId()
    {
        var offset = 0;
        var numBits = 4;
        var res = parse_packed_int(offset, numBits);

        return new GameTLobbySlotId
        {
            Value = res
        };
    }
    public GameTPlayerId Parse_GameTPlayerId()
    {
        var offset = 0;
        var numBits = 4;
        var res = parse_packed_int(offset, numBits);

        return new GameTPlayerId
        {
            Value = res
        };
    }
    public GameTPlayerCount Parse_GameTPlayerCount()
    {
        var offset = 0;
        var numBits = 5;
        var res = parse_packed_int(offset, numBits);

        return new GameTPlayerCount
        {
            Value = res
        };
    }
    public GameTSelectionCount Parse_GameTSelectionCount()
    {
        var offset = 0;
        var numBits = 8;
        var res = parse_packed_int(offset, numBits);

        return new GameTSelectionCount
        {
            Value = res
        };
    }
    public GameTSelectionIndex Parse_GameTSelectionIndex()
    {
        var offset = 0;
        var numBits = 8;
        var res = parse_packed_int(offset, numBits);

        return new GameTSelectionIndex
        {
            Value = res
        };
    }
    public GameTSubgroupPriority Parse_GameTSubgroupPriority()
    {
        var offset = 0;
        var numBits = 8;
        var res = parse_packed_int(offset, numBits);

        return new GameTSubgroupPriority
        {
            Value = res
        };
    }
    public GameTSubgroupCount Parse_GameTSubgroupCount()
    {
        var offset = 0;
        var numBits = 8;
        var res = parse_packed_int(offset, numBits);

        return new GameTSubgroupCount
        {
            Value = res
        };
    }
    public GameTSubgroupIndex Parse_GameTSubgroupIndex()
    {
        var offset = 0;
        var numBits = 8;
        var res = parse_packed_int(offset, numBits);

        return new GameTSubgroupIndex
        {
            Value = res
        };
    }
    public GameTControlGroupCount Parse_GameTControlGroupCount()
    {
        var offset = 0;
        var numBits = 4;
        var res = parse_packed_int(offset, numBits);

        return new GameTControlGroupCount
        {
            Value = res
        };
    }
    public GameTControlGroupIndex Parse_GameTControlGroupIndex()
    {
        var offset = 0;
        var numBits = 4;
        var res = parse_packed_int(offset, numBits);

        return new GameTControlGroupIndex
        {
            Value = res
        };
    }
    public GameTControlGroupId Parse_GameTControlGroupId()
    {
        var offset = 0;
        var numBits = 4;
        var res = parse_packed_int(offset, numBits);

        return new GameTControlGroupId
        {
            Value = res
        };
    }
    public GameTTeamId Parse_GameTTeamId()
    {
        var offset = 0;
        var numBits = 4;
        var res = parse_packed_int(offset, numBits);

        return new GameTTeamId
        {
            Value = res
        };
    }
    public GameTTeamCount Parse_GameTTeamCount()
    {
        var offset = 1;
        var numBits = 5;
        var res = parse_packed_int(offset, numBits);

        return new GameTTeamCount
        {
            Value = res
        };
    }
    public CAllowedRaces Parse_CAllowedRaces()
    {
        var bitArrayLengthBits = 8;
        var bitArrayLength = take_n_bits_into_i64(bitArrayLengthBits);

        var value = take_bit_array(bitArrayLength);

        return new CAllowedRaces
        {
            Value = value
        };
    }
    public CAllowedObserveTypes Parse_CAllowedObserveTypes()
    {
        var bitArrayLengthBits = 2;
        var bitArrayLength = take_n_bits_into_i64(bitArrayLengthBits);

        var value = take_bit_array(bitArrayLength);

        return new CAllowedObserveTypes
        {
            Value = value
        };
    }
    public GameCAllowedColors Parse_GameCAllowedColors()
    {
        var bitArrayLengthBits = 6;
        var bitArrayLength = take_n_bits_into_i64(bitArrayLengthBits);

        var value = take_bit_array(bitArrayLength);

        return new GameCAllowedColors
        {
            Value = value
        };
    }
    public GameCAllowedDifficulty Parse_GameCAllowedDifficulty()
    {
        var bitArrayLengthBits = 6;
        var bitArrayLength = take_n_bits_into_i64(bitArrayLengthBits);

        var value = take_bit_array(bitArrayLength);

        return new GameCAllowedDifficulty
        {
            Value = value
        };
    }
    public GameCAllowedControls Parse_GameCAllowedControls()
    {
        var bitArrayLengthBits = 8;
        var bitArrayLength = take_n_bits_into_i64(bitArrayLengthBits);

        var value = take_bit_array(bitArrayLength);

        return new GameCAllowedControls
        {
            Value = value
        };
    }
    public GameSelectionMaskType Parse_GameSelectionMaskType()
    {
        var bitArrayLengthBits = 8;
        var bitArrayLength = take_n_bits_into_i64(bitArrayLengthBits);

        var value = take_bit_array(bitArrayLength);

        return new GameSelectionMaskType
        {
            Value = value
        };
    }
    public GameTAchievementLink Parse_GameTAchievementLink()
    {
        var value = Parse_uint16();

        return new GameTAchievementLink
        {
            Value = value,
        };
    }
    public GameTAchievementTermLink Parse_GameTAchievementTermLink()
    {
        var value = Parse_uint16();

        return new GameTAchievementTermLink
        {
            Value = value,
        };
    }
    public GameTButtonLink Parse_GameTButtonLink()
    {
        var value = Parse_uint16();

        return new GameTButtonLink
        {
            Value = value,
        };
    }
    public GameTUnitLink Parse_GameTUnitLink()
    {
        var value = Parse_uint16();

        return new GameTUnitLink
        {
            Value = value,
        };
    }
    public GameTUnitTag Parse_GameTUnitTag()
    {
        var value = Parse_uint32();

        return new GameTUnitTag
        {
            Value = value,
        };
    }
    public GameTTriggerSoundTag Parse_GameTTriggerSoundTag()
    {
        var value = Parse_uint32();

        return new GameTTriggerSoundTag
        {
            Value = value,
        };
    }
    public GameTAbilLink Parse_GameTAbilLink()
    {
        var value = Parse_uint16();

        return new GameTAbilLink
        {
            Value = value,
        };
    }
    public GameTFixedBits Parse_GameTFixedBits()
    {
        var value = Parse_int32();

        return new GameTFixedBits
        {
            Value = value,
        };
    }
    public GameTFixedMiniBits Parse_GameTFixedMiniBits()
    {
        var value = Parse_uint16();

        return new GameTFixedMiniBits
        {
            Value = value,
        };
    }
    public GameTReward Parse_GameTReward()
    {
        var value = Parse_uint32();

        return new GameTReward
        {
            Value = value,
        };
    }
    public GameTSyncChecksum Parse_GameTSyncChecksum()
    {
        var value = Parse_uint32();

        return new GameTSyncChecksum
        {
            Value = value,
        };
    }
    public GameTSyncValue Parse_GameTSyncValue()
    {
        var value = Parse_uint16();

        return new GameTSyncValue
        {
            Value = value,
        };
    }
    public Gamec_ignoreSyncValue Parse_Gamec_ignoreSyncValue()
    {
        var value = Parse_GameTSyncValue();

        return new Gamec_ignoreSyncValue
        {
            Value = value,
        };
    }
    public GameCPlayerDetailsArray Parse_GameCPlayerDetailsArray()
    {
        ValidateArrayTag();

        var arrayLength = ParseVlqInt();
        var value = ReadList(Parse_GameSPlayerDetails, arrayLength);

        return new GameCPlayerDetailsArray
        {
            Value = value
        };
    }
    public CUserInitialDataArray Parse_CUserInitialDataArray()
    {
        var arrayLengthNumBits = 4;
        var arrayLength = parse_packed_int(0, arrayLengthNumBits);

        var value = ReadList(Parse_SUserInitialData, arrayLength);

        return new CUserInitialDataArray
        {
            Value = value
        };
    }
    public GameCCacheHandles Parse_GameCCacheHandles()
    {
        var arrayLengthNumBits = 3;
        var arrayLength = parse_packed_int(0, arrayLengthNumBits);

        var value = ReadList(Parse_GameCCacheHandle, arrayLength);

        return new GameCCacheHandles
        {
            Value = value
        };
    }
    public GameSSlotDescriptions Parse_GameSSlotDescriptions()
    {
        var arrayLengthNumBits = 4;
        var arrayLength = parse_packed_int(0, arrayLengthNumBits);

        var value = ReadList(Parse_GameSSlotDescription, arrayLength);

        return new GameSSlotDescriptions
        {
            Value = value
        };
    }
    public GameCRewardArray Parse_GameCRewardArray()
    {
        var arrayLengthNumBits = 4;
        var arrayLength = parse_packed_int(0, arrayLengthNumBits);

        var value = ReadList(Parse_GameTReward, arrayLength);

        return new GameCRewardArray
        {
            Value = value
        };
    }
    public GameCLobbySlotArray Parse_GameCLobbySlotArray()
    {
        var arrayLengthNumBits = 4;
        var arrayLength = parse_packed_int(0, arrayLengthNumBits);

        var value = ReadList(Parse_GameSLobbySlot, arrayLength);

        return new GameCLobbySlotArray
        {
            Value = value
        };
    }
    public GameSelectionIndexArrayType Parse_GameSelectionIndexArrayType()
    {
        var arrayLengthNumBits = 8;
        var arrayLength = parse_packed_int(0, arrayLengthNumBits);

        var value = ReadList(Parse_GameTSelectionIndex, arrayLength);

        return new GameSelectionIndexArrayType
        {
            Value = value
        };
    }
    public CFilePath Parse_CFilePath()
    {
        var strSizeNumBits = 11;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new CFilePath
        {
            Value = value
        };
    }
    public CUserName Parse_CUserName()
    {
        var strSizeNumBits = 8;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new CUserName
        {
            Value = value
        };
    }
    public GameCCheatString Parse_GameCCheatString()
    {
        var strSizeNumBits = 11;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new GameCCheatString
        {
            Value = value
        };
    }
    public GameCTriggerChatMessageString Parse_GameCTriggerChatMessageString()
    {
        var strSizeNumBits = 11;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new GameCTriggerChatMessageString
        {
            Value = value
        };
    }
    public GameCGameCacheName Parse_GameCGameCacheName()
    {
        var strSizeNumBits = 11;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new GameCGameCacheName
        {
            Value = value
        };
    }
    public GameCAuthorName Parse_GameCAuthorName()
    {
        var strSizeNumBits = 8;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new GameCAuthorName
        {
            Value = value
        };
    }
    public GameCChatString Parse_GameCChatString()
    {
        var strSizeNumBits = 11;
        var strSize = parse_packed_int(0, strSizeNumBits);

        byte_align();

        var value = take_bit_array(strSize * 8);

        return new GameCChatString
        {
            Value = value
        };
    }
    public GameCCacheHandle Parse_GameCCacheHandle()
    {
        byte_align();
        var numBits = 6;
        
        var value = take_bit_array(numBits);

        return new GameCCacheHandle
        {
            Value = value
        };
    }

}
