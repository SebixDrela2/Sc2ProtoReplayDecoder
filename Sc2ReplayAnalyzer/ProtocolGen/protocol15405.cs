
namespace Sc2ReplayAnalyzer.Json.protocol15405;

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
    public uint Value;
}

// m_uint22
public class m_uint22 : ISVarUint32
{
    public uint Value;
}

// m_uint32
public class m_uint32 : ISVarUint32
{
    public uint Value;
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

// NNet.SUserInitialData
public class SUserInitialData
{
    public CUserName m_name;
    public uint32 m_randomSeed;
    public TRacePreference m_racePreference;
    public bool m_testMap;
    public bool m_testAuto;
    public EObserve m_observe;
}

// NNet.Game.TColorPreference
public class GameTColorPreference
{
    public Option<GameTColorId> m_color;
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
    public uint32 m_cmdFlags;
    public GameTAbilLink m_abilLink;
    public uint8 m_abilCmdIndex;
    public uint8 m_abilCmdData;
    public uint8 m_targetUnitFlags;
    public uint8 m_targetUnitTimer;
    public GameTUnitTag m_otherUnit;
    public GameTUnitTag m_targetUnitTag;
    public GameTUnitLink m_targetUnitSnapshotUnitLink;
    public Option<GameTPlayerId> m_targetUnitSnapshotPlayerId;
    public GameSPoint3 m_targetPoint;
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
    public GameSPoint m_target;
    public GameTFixedBits m_distance;
    public GameTFixedBits m_pitch;
    public GameTFixedBits m_yaw;
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
    public uint32 m_decrementMs;
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
    public GameTSyncChecksum m_modFileSyncChecksum;
    public GameSSlotDescriptions m_slotDescriptions;
    public GameTDifficulty m_defaultDifficulty;
    public GameCCacheHandles m_cacheHandles;
    public bool m_isBlizzardMap;
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

// NNet.Game.SGameOptions_PublicBeta1
public class GameSGameOptions_PublicBeta1
{
    public bool m_lockTeams;
    public bool m_teamsTogether;
    public bool m_advancedSharedControl;
    public bool m_randomRaces;
    public bool m_amm;
    public bool m_ranked;
    public bool m_noVictoryOrDefeat;
    public GameEGameLaunch m_launch;
    public GameEOptionFog m_fog;
    public GameEOptionObservers m_observers;
    public GameEOptionUserDifficulty m_userDifficulty;
}

// NNet.Game.SGameDescription_PublicBeta1
public class GameSGameDescription_PublicBeta1
{
    public uint32 m_randomValue;
    public GameCGameCacheName m_gameCacheName;
    public GameSGameOptions_PublicBeta1 m_gameOptions;
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
    public GameTSyncChecksum m_modFileSyncChecksum;
    public CFilePath m_saveFileName;
    public GameSSlotDescriptions m_slotDescriptions;
    public GameTDifficulty m_defaultDifficulty;
    public GameCCacheHandles m_cacheHandles;
}

// NNet.Game.SLobbySlot_PublicBeta1
public class GameSLobbySlot_PublicBeta1
{
    public GameTControlId m_control;
    public Option<TUserId> m_userId;
    public GameTTeamId m_teamId;
    public GameTColorPreference m_colorPref;
    public TRacePreference m_racePref;
    public GameTDifficulty m_difficulty;
    public GameTHandicap m_handicap;
    public EObserve m_observe;
}

// NNet.Game.SLobbyState_PublicBeta1
public class GameSLobbyState_PublicBeta1
{
    public GameEPhase m_phase;
    public TUserCount m_maxUsers;
    public TUserCount m_maxObservers;
    public GameCLobbySlotArray_PublicBeta1 m_slots;
    public uint32 m_randomSeed;
    public Option<TUserId> m_hostUserId;
    public bool m_isSinglePlayer;
    public uint32 m_gameDuration;
    public GameTDifficulty m_defaultDifficulty;
}

// NNet.Game.SLobbySyncState_PublicBeta1
public class GameSLobbySyncState_PublicBeta1
{
    public CUserInitialDataArray m_userInitialData;
    public GameSGameDescription_PublicBeta1 m_gameDescription;
    public GameSLobbyState_PublicBeta1 m_lobbyState;
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

// NNet.Game.SSelectionDeltaSubgroup
public class GameSSelectionDeltaSubgroup
{
    public GameTUnitLink m_unitLink;
    public GameTSubgroupPriority m_intraSubgroupPriority;
    public GameTSelectionCount m_count;
}

// NNet.Game.SSelectionMask
public class GameSSelectionMask
{
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
    e_bankFile = 7,
    e_bankSection = 8,
    e_bankKey = 9,
    e_bankValue = 10,
    e_userOptions = 11,
    e_turn = 12,
    e_pauseGame = 16,
    e_unpauseGame = 17,
    e_singleStepGame = 18,
    e_setGameSpeed = 19,
    e_addGameSpeed = 20,
    e_restartGame = 21,
    e_saveGame = 22,
    e_saveGameDone = 23,
    e_sessionCheat = 24,
    e_playerLeave = 25,
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
    e_broadcastCheat = 37,
    e_alliance = 38,
    e_unitClick = 39,
    e_unitHighlight = 40,
    e_triggerReplySelected = 41,
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
    e_lagMessage = 76,
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
    e_triggerCameraMove = 92,
    e_triggerPurchasePanelSelectedPurchaseItemChanged = 93,
    e_triggerPurchasePanelSelectedPurchaseCategoryChanged = 94,
    e_triggerButtonPressed = 95,
    e_triggerGameCreditsFinished = 96,
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
    e_normal = 1,
    e_replay = 2,
    e_save = 3,
    e_transition = 4,
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
}

// NNet.Game.EMessageId
public enum GameEMessageId
{
    e_chat = 0,
    e_ping = 1,
    e_loadingProgress = 2,
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

// NNet.Game.TPlayerCount
public class GameTPlayerCount
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

// NNet.Game.c_maxRewards
public class Gamec_maxRewards
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

// NNet.Game.TReward
public class GameTReward
{
    public uint16 Value;
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

// NNet.Game.CRewardArray
public class GameCRewardArray
{
    public GameTReward Value;
}

// NNet.Game.CLobbySlotArray
public class GameCLobbySlotArray
{
    public GameSLobbySlot Value;
}

// NNet.Game.CLobbySlotArray_PublicBeta1
public class GameCLobbySlotArray_PublicBeta1
{
    public GameSLobbySlot_PublicBeta1 Value;
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
            }
        }
        return new GameSToonNameDetails
        {   
            m_region = Option.OkOrReturnMissingFieldErr(m_region),
            m_programId = Option.OkOrReturnMissingFieldErr(m_programId),
            m_realm = Option.OkOrReturnMissingFieldErr(m_realm),
            m_name = Option.OkOrReturnMissingFieldErr(m_name),
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
        var isProvided = ReadByte(); // nom::number::complete::u8(tail)

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
        var isProvided = ReadByte(); // nom::number::complete::u8(tail)

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

    public SUserInitialData Parse_SUserInitialData() 
    {
        Option<CUserName> m_name = Option.None;
        Option<uint32> m_randomSeed = Option.None;
        Option<TRacePreference> m_racePreference = Option.None;
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

    public IGameSLobbySlotChange Parse_GameSSetLobbySlotEvent_m_slotChange()
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
        Option<uint32> m_cmdFlags = Option.None;
        Option<GameTAbilLink> m_abilLink = Option.None;
        Option<uint8> m_abilCmdIndex = Option.None;
        Option<uint8> m_abilCmdData = Option.None;
        Option<uint8> m_targetUnitFlags = Option.None;
        Option<uint8> m_targetUnitTimer = Option.None;
        Option<GameTUnitTag> m_otherUnit = Option.None;
        Option<GameTUnitTag> m_targetUnitTag = Option.None;
        Option<GameTUnitLink> m_targetUnitSnapshotUnitLink = Option.None;
        var m_targetUnitSnapshotPlayerId = Option.Some<Option<GameTPlayerId>>(Option.None);
        Option<GameSPoint3> m_targetPoint = Option.None;
        if (m_cmdFlags is { HasValue: false })                           
        {
            var parsed_m_cmdFlags = Parse_GameSCmdEvent_m_cmdFlags();
            m_cmdFlags = Option.Some(parsed_m_cmdFlags);
        }

        if (m_abilLink is { HasValue: false })                           
        {
            var parsed_m_abilLink = Parse_GameSCmdEvent_m_abilLink();
            m_abilLink = Option.Some(parsed_m_abilLink);
        }

        if (m_abilCmdIndex is { HasValue: false })                           
        {
            var parsed_m_abilCmdIndex = Parse_GameSCmdEvent_m_abilCmdIndex();
            m_abilCmdIndex = Option.Some(parsed_m_abilCmdIndex);
        }

        if (m_abilCmdData is { HasValue: false })                           
        {
            var parsed_m_abilCmdData = Parse_GameSCmdEvent_m_abilCmdData();
            m_abilCmdData = Option.Some(parsed_m_abilCmdData);
        }

        if (m_targetUnitFlags is { HasValue: false })                           
        {
            var parsed_m_targetUnitFlags = Parse_GameSCmdEvent_m_targetUnitFlags();
            m_targetUnitFlags = Option.Some(parsed_m_targetUnitFlags);
        }

        if (m_targetUnitTimer is { HasValue: false })                           
        {
            var parsed_m_targetUnitTimer = Parse_GameSCmdEvent_m_targetUnitTimer();
            m_targetUnitTimer = Option.Some(parsed_m_targetUnitTimer);
        }

        if (m_otherUnit is { HasValue: false })                           
        {
            var parsed_m_otherUnit = Parse_GameSCmdEvent_m_otherUnit();
            m_otherUnit = Option.Some(parsed_m_otherUnit);
        }

        if (m_targetUnitTag is { HasValue: false })                           
        {
            var parsed_m_targetUnitTag = Parse_GameSCmdEvent_m_targetUnitTag();
            m_targetUnitTag = Option.Some(parsed_m_targetUnitTag);
        }

        if (m_targetUnitSnapshotUnitLink is { HasValue: false })                           
        {
            var parsed_m_targetUnitSnapshotUnitLink = Parse_GameSCmdEvent_m_targetUnitSnapshotUnitLink();
            m_targetUnitSnapshotUnitLink = Option.Some(parsed_m_targetUnitSnapshotUnitLink);
        }

        if (m_targetUnitSnapshotPlayerId is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_targetUnitSnapshotPlayerId = Parse_GameSCmdEvent_m_targetUnitSnapshotPlayerId();
            m_targetUnitSnapshotPlayerId = Option.Some(parsed_m_targetUnitSnapshotPlayerId);
        }

        if (m_targetPoint is { HasValue: false })                           
        {
            var parsed_m_targetPoint = Parse_GameSCmdEvent_m_targetPoint();
            m_targetPoint = Option.Some(parsed_m_targetPoint);
        }

        return new GameSCmdEvent
        {   
            m_cmdFlags = Option.OkOrReturnMissingFieldErr(m_cmdFlags),
            m_abilLink = Option.OkOrReturnMissingFieldErr(m_abilLink),
            m_abilCmdIndex = Option.OkOrReturnMissingFieldErr(m_abilCmdIndex),
            m_abilCmdData = Option.OkOrReturnMissingFieldErr(m_abilCmdData),
            m_targetUnitFlags = Option.OkOrReturnMissingFieldErr(m_targetUnitFlags),
            m_targetUnitTimer = Option.OkOrReturnMissingFieldErr(m_targetUnitTimer),
            m_otherUnit = Option.OkOrReturnMissingFieldErr(m_otherUnit),
            m_targetUnitTag = Option.OkOrReturnMissingFieldErr(m_targetUnitTag),
            m_targetUnitSnapshotUnitLink = Option.OkOrReturnMissingFieldErr(m_targetUnitSnapshotUnitLink),
            m_targetUnitSnapshotPlayerId = Option.OkOrReturnMissingFieldErr(m_targetUnitSnapshotPlayerId),
            m_targetPoint = Option.OkOrReturnMissingFieldErr(m_targetPoint),
        };
    }

    public uint32 Parse_GameSCmdEvent_m_cmdFlags()
    {                             
        var m_cmdFlags = Parse_uint32();
        return m_cmdFlags;
    }

    public GameTAbilLink Parse_GameSCmdEvent_m_abilLink()
    {                             
        var m_abilLink = Parse_GameTAbilLink();
        return m_abilLink;
    }

    public uint8 Parse_GameSCmdEvent_m_abilCmdIndex()
    {                             
        var m_abilCmdIndex = Parse_uint8();
        return m_abilCmdIndex;
    }

    public uint8 Parse_GameSCmdEvent_m_abilCmdData()
    {                             
        var m_abilCmdData = Parse_uint8();
        return m_abilCmdData;
    }

    public uint8 Parse_GameSCmdEvent_m_targetUnitFlags()
    {                             
        var m_targetUnitFlags = Parse_uint8();
        return m_targetUnitFlags;
    }

    public uint8 Parse_GameSCmdEvent_m_targetUnitTimer()
    {                             
        var m_targetUnitTimer = Parse_uint8();
        return m_targetUnitTimer;
    }

    public GameTUnitTag Parse_GameSCmdEvent_m_otherUnit()
    {                             
        var m_otherUnit = Parse_GameTUnitTag();
        return m_otherUnit;
    }

    public GameTUnitTag Parse_GameSCmdEvent_m_targetUnitTag()
    {                             
        var m_targetUnitTag = Parse_GameTUnitTag();
        return m_targetUnitTag;
    }

    public GameTUnitLink Parse_GameSCmdEvent_m_targetUnitSnapshotUnitLink()
    {                             
        var m_targetUnitSnapshotUnitLink = Parse_GameTUnitLink();
        return m_targetUnitSnapshotUnitLink;
    }

    public Option<GameTPlayerId> Parse_GameSCmdEvent_m_targetUnitSnapshotPlayerId()
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

    public GameSPoint3 Parse_GameSCmdEvent_m_targetPoint()
    {                             
        var m_targetPoint = Parse_GameSPoint3();
        return m_targetPoint;
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

    public Im_eventData Parse_GameSTriggerDialogControlEvent_m_eventData()
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
        Option<GameSPoint> m_target = Option.None;
        Option<GameTFixedBits> m_distance = Option.None;
        Option<GameTFixedBits> m_pitch = Option.None;
        Option<GameTFixedBits> m_yaw = Option.None;
        if (m_target is { HasValue: false })                           
        {
            var parsed_m_target = Parse_GameSCameraUpdateEvent_m_target();
            m_target = Option.Some(parsed_m_target);
        }

        if (m_distance is { HasValue: false })                           
        {
            var parsed_m_distance = Parse_GameSCameraUpdateEvent_m_distance();
            m_distance = Option.Some(parsed_m_distance);
        }

        if (m_pitch is { HasValue: false })                           
        {
            var parsed_m_pitch = Parse_GameSCameraUpdateEvent_m_pitch();
            m_pitch = Option.Some(parsed_m_pitch);
        }

        if (m_yaw is { HasValue: false })                           
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

    public GameSPoint Parse_GameSCameraUpdateEvent_m_target()
    {                             
        var m_target = Parse_GameSPoint();
        return m_target;
    }

    public GameTFixedBits Parse_GameSCameraUpdateEvent_m_distance()
    {                             
        var m_distance = Parse_GameTFixedBits();
        return m_distance;
    }

    public GameTFixedBits Parse_GameSCameraUpdateEvent_m_pitch()
    {                             
        var m_pitch = Parse_GameTFixedBits();
        return m_pitch;
    }

    public GameTFixedBits Parse_GameSCameraUpdateEvent_m_yaw()
    {                             
        var m_yaw = Parse_GameTFixedBits();
        return m_yaw;
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
        Option<uint32> m_decrementMs = Option.None;
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

    public uint32 Parse_GameSDecrementGameTimeRemainingEvent_m_decrementMs()
    {                             
        var m_decrementMs = Parse_uint32();
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
        Option<GameTSyncChecksum> m_modFileSyncChecksum = Option.None;
        Option<GameSSlotDescriptions> m_slotDescriptions = Option.None;
        Option<GameTDifficulty> m_defaultDifficulty = Option.None;
        Option<GameCCacheHandles> m_cacheHandles = Option.None;
        Option<bool> m_isBlizzardMap = Option.None;
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
            m_modFileSyncChecksum = Option.OkOrReturnMissingFieldErr(m_modFileSyncChecksum),
            m_slotDescriptions = Option.OkOrReturnMissingFieldErr(m_slotDescriptions),
            m_defaultDifficulty = Option.OkOrReturnMissingFieldErr(m_defaultDifficulty),
            m_cacheHandles = Option.OkOrReturnMissingFieldErr(m_cacheHandles),
            m_isBlizzardMap = Option.OkOrReturnMissingFieldErr(m_isBlizzardMap),
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

    public GameSGameOptions_PublicBeta1 Parse_GameSGameOptions_PublicBeta1() 
    {
        Option<bool> m_lockTeams = Option.None;
        Option<bool> m_teamsTogether = Option.None;
        Option<bool> m_advancedSharedControl = Option.None;
        Option<bool> m_randomRaces = Option.None;
        Option<bool> m_amm = Option.None;
        Option<bool> m_ranked = Option.None;
        Option<bool> m_noVictoryOrDefeat = Option.None;
        Option<GameEGameLaunch> m_launch = Option.None;
        Option<GameEOptionFog> m_fog = Option.None;
        Option<GameEOptionObservers> m_observers = Option.None;
        Option<GameEOptionUserDifficulty> m_userDifficulty = Option.None;
        if (m_lockTeams is { HasValue: false })                           
        {
            var parsed_m_lockTeams = Parse_GameSGameOptions_PublicBeta1_m_lockTeams();
            m_lockTeams = Option.Some(parsed_m_lockTeams);
        }

        if (m_teamsTogether is { HasValue: false })                           
        {
            var parsed_m_teamsTogether = Parse_GameSGameOptions_PublicBeta1_m_teamsTogether();
            m_teamsTogether = Option.Some(parsed_m_teamsTogether);
        }

        if (m_advancedSharedControl is { HasValue: false })                           
        {
            var parsed_m_advancedSharedControl = Parse_GameSGameOptions_PublicBeta1_m_advancedSharedControl();
            m_advancedSharedControl = Option.Some(parsed_m_advancedSharedControl);
        }

        if (m_randomRaces is { HasValue: false })                           
        {
            var parsed_m_randomRaces = Parse_GameSGameOptions_PublicBeta1_m_randomRaces();
            m_randomRaces = Option.Some(parsed_m_randomRaces);
        }

        if (m_amm is { HasValue: false })                           
        {
            var parsed_m_amm = Parse_GameSGameOptions_PublicBeta1_m_amm();
            m_amm = Option.Some(parsed_m_amm);
        }

        if (m_ranked is { HasValue: false })                           
        {
            var parsed_m_ranked = Parse_GameSGameOptions_PublicBeta1_m_ranked();
            m_ranked = Option.Some(parsed_m_ranked);
        }

        if (m_noVictoryOrDefeat is { HasValue: false })                           
        {
            var parsed_m_noVictoryOrDefeat = Parse_GameSGameOptions_PublicBeta1_m_noVictoryOrDefeat();
            m_noVictoryOrDefeat = Option.Some(parsed_m_noVictoryOrDefeat);
        }

        if (m_launch is { HasValue: false })                           
        {
            var parsed_m_launch = Parse_GameSGameOptions_PublicBeta1_m_launch();
            m_launch = Option.Some(parsed_m_launch);
        }

        if (m_fog is { HasValue: false })                           
        {
            var parsed_m_fog = Parse_GameSGameOptions_PublicBeta1_m_fog();
            m_fog = Option.Some(parsed_m_fog);
        }

        if (m_observers is { HasValue: false })                           
        {
            var parsed_m_observers = Parse_GameSGameOptions_PublicBeta1_m_observers();
            m_observers = Option.Some(parsed_m_observers);
        }

        if (m_userDifficulty is { HasValue: false })                           
        {
            var parsed_m_userDifficulty = Parse_GameSGameOptions_PublicBeta1_m_userDifficulty();
            m_userDifficulty = Option.Some(parsed_m_userDifficulty);
        }

        return new GameSGameOptions_PublicBeta1
        {   
            m_lockTeams = Option.OkOrReturnMissingFieldErr(m_lockTeams),
            m_teamsTogether = Option.OkOrReturnMissingFieldErr(m_teamsTogether),
            m_advancedSharedControl = Option.OkOrReturnMissingFieldErr(m_advancedSharedControl),
            m_randomRaces = Option.OkOrReturnMissingFieldErr(m_randomRaces),
            m_amm = Option.OkOrReturnMissingFieldErr(m_amm),
            m_ranked = Option.OkOrReturnMissingFieldErr(m_ranked),
            m_noVictoryOrDefeat = Option.OkOrReturnMissingFieldErr(m_noVictoryOrDefeat),
            m_launch = Option.OkOrReturnMissingFieldErr(m_launch),
            m_fog = Option.OkOrReturnMissingFieldErr(m_fog),
            m_observers = Option.OkOrReturnMissingFieldErr(m_observers),
            m_userDifficulty = Option.OkOrReturnMissingFieldErr(m_userDifficulty),
        };
    }

    public bool Parse_GameSGameOptions_PublicBeta1_m_lockTeams()
    {                             
        var m_lockTeams = parse_bool();
        return m_lockTeams;
    }

    public bool Parse_GameSGameOptions_PublicBeta1_m_teamsTogether()
    {                             
        var m_teamsTogether = parse_bool();
        return m_teamsTogether;
    }

    public bool Parse_GameSGameOptions_PublicBeta1_m_advancedSharedControl()
    {                             
        var m_advancedSharedControl = parse_bool();
        return m_advancedSharedControl;
    }

    public bool Parse_GameSGameOptions_PublicBeta1_m_randomRaces()
    {                             
        var m_randomRaces = parse_bool();
        return m_randomRaces;
    }

    public bool Parse_GameSGameOptions_PublicBeta1_m_amm()
    {                             
        var m_amm = parse_bool();
        return m_amm;
    }

    public bool Parse_GameSGameOptions_PublicBeta1_m_ranked()
    {                             
        var m_ranked = parse_bool();
        return m_ranked;
    }

    public bool Parse_GameSGameOptions_PublicBeta1_m_noVictoryOrDefeat()
    {                             
        var m_noVictoryOrDefeat = parse_bool();
        return m_noVictoryOrDefeat;
    }

    public GameEGameLaunch Parse_GameSGameOptions_PublicBeta1_m_launch()
    {                             
        var m_launch = Parse_GameEGameLaunch();
        return m_launch;
    }

    public GameEOptionFog Parse_GameSGameOptions_PublicBeta1_m_fog()
    {                             
        var m_fog = Parse_GameEOptionFog();
        return m_fog;
    }

    public GameEOptionObservers Parse_GameSGameOptions_PublicBeta1_m_observers()
    {                             
        var m_observers = Parse_GameEOptionObservers();
        return m_observers;
    }

    public GameEOptionUserDifficulty Parse_GameSGameOptions_PublicBeta1_m_userDifficulty()
    {                             
        var m_userDifficulty = Parse_GameEOptionUserDifficulty();
        return m_userDifficulty;
    }

    public GameSGameDescription_PublicBeta1 Parse_GameSGameDescription_PublicBeta1() 
    {
        Option<uint32> m_randomValue = Option.None;
        Option<GameCGameCacheName> m_gameCacheName = Option.None;
        Option<GameSGameOptions_PublicBeta1> m_gameOptions = Option.None;
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
        Option<GameTSyncChecksum> m_modFileSyncChecksum = Option.None;
        Option<CFilePath> m_saveFileName = Option.None;
        Option<GameSSlotDescriptions> m_slotDescriptions = Option.None;
        Option<GameTDifficulty> m_defaultDifficulty = Option.None;
        Option<GameCCacheHandles> m_cacheHandles = Option.None;
        if (m_randomValue is { HasValue: false })                           
        {
            var parsed_m_randomValue = Parse_GameSGameDescription_PublicBeta1_m_randomValue();
            m_randomValue = Option.Some(parsed_m_randomValue);
        }

        if (m_gameCacheName is { HasValue: false })                           
        {
            var parsed_m_gameCacheName = Parse_GameSGameDescription_PublicBeta1_m_gameCacheName();
            m_gameCacheName = Option.Some(parsed_m_gameCacheName);
        }

        if (m_gameOptions is { HasValue: false })                           
        {
            var parsed_m_gameOptions = Parse_GameSGameDescription_PublicBeta1_m_gameOptions();
            m_gameOptions = Option.Some(parsed_m_gameOptions);
        }

        if (m_gameSpeed is { HasValue: false })                           
        {
            var parsed_m_gameSpeed = Parse_GameSGameDescription_PublicBeta1_m_gameSpeed();
            m_gameSpeed = Option.Some(parsed_m_gameSpeed);
        }

        if (m_gameType is { HasValue: false })                           
        {
            var parsed_m_gameType = Parse_GameSGameDescription_PublicBeta1_m_gameType();
            m_gameType = Option.Some(parsed_m_gameType);
        }

        if (m_maxUsers is { HasValue: false })                           
        {
            var parsed_m_maxUsers = Parse_GameSGameDescription_PublicBeta1_m_maxUsers();
            m_maxUsers = Option.Some(parsed_m_maxUsers);
        }

        if (m_maxObservers is { HasValue: false })                           
        {
            var parsed_m_maxObservers = Parse_GameSGameDescription_PublicBeta1_m_maxObservers();
            m_maxObservers = Option.Some(parsed_m_maxObservers);
        }

        if (m_maxPlayers is { HasValue: false })                           
        {
            var parsed_m_maxPlayers = Parse_GameSGameDescription_PublicBeta1_m_maxPlayers();
            m_maxPlayers = Option.Some(parsed_m_maxPlayers);
        }

        if (m_maxTeams is { HasValue: false })                           
        {
            var parsed_m_maxTeams = Parse_GameSGameDescription_PublicBeta1_m_maxTeams();
            m_maxTeams = Option.Some(parsed_m_maxTeams);
        }

        if (m_maxColors is { HasValue: false })                           
        {
            var parsed_m_maxColors = Parse_GameSGameDescription_PublicBeta1_m_maxColors();
            m_maxColors = Option.Some(parsed_m_maxColors);
        }

        if (m_maxRaces is { HasValue: false })                           
        {
            var parsed_m_maxRaces = Parse_GameSGameDescription_PublicBeta1_m_maxRaces();
            m_maxRaces = Option.Some(parsed_m_maxRaces);
        }

        if (m_maxControls is { HasValue: false })                           
        {
            var parsed_m_maxControls = Parse_GameSGameDescription_PublicBeta1_m_maxControls();
            m_maxControls = Option.Some(parsed_m_maxControls);
        }

        if (m_mapSizeX is { HasValue: false })                           
        {
            var parsed_m_mapSizeX = Parse_GameSGameDescription_PublicBeta1_m_mapSizeX();
            m_mapSizeX = Option.Some(parsed_m_mapSizeX);
        }

        if (m_mapSizeY is { HasValue: false })                           
        {
            var parsed_m_mapSizeY = Parse_GameSGameDescription_PublicBeta1_m_mapSizeY();
            m_mapSizeY = Option.Some(parsed_m_mapSizeY);
        }

        if (m_mapFileSyncChecksum is { HasValue: false })                           
        {
            var parsed_m_mapFileSyncChecksum = Parse_GameSGameDescription_PublicBeta1_m_mapFileSyncChecksum();
            m_mapFileSyncChecksum = Option.Some(parsed_m_mapFileSyncChecksum);
        }

        if (m_mapFileName is { HasValue: false })                           
        {
            var parsed_m_mapFileName = Parse_GameSGameDescription_PublicBeta1_m_mapFileName();
            m_mapFileName = Option.Some(parsed_m_mapFileName);
        }

        if (m_modFileSyncChecksum is { HasValue: false })                           
        {
            var parsed_m_modFileSyncChecksum = Parse_GameSGameDescription_PublicBeta1_m_modFileSyncChecksum();
            m_modFileSyncChecksum = Option.Some(parsed_m_modFileSyncChecksum);
        }

        if (m_saveFileName is { HasValue: false })                           
        {
            var parsed_m_saveFileName = Parse_GameSGameDescription_PublicBeta1_m_saveFileName();
            m_saveFileName = Option.Some(parsed_m_saveFileName);
        }

        if (m_slotDescriptions is { HasValue: false })                           
        {
            var parsed_m_slotDescriptions = Parse_GameSGameDescription_PublicBeta1_m_slotDescriptions();
            m_slotDescriptions = Option.Some(parsed_m_slotDescriptions);
        }

        if (m_defaultDifficulty is { HasValue: false })                           
        {
            var parsed_m_defaultDifficulty = Parse_GameSGameDescription_PublicBeta1_m_defaultDifficulty();
            m_defaultDifficulty = Option.Some(parsed_m_defaultDifficulty);
        }

        if (m_cacheHandles is { HasValue: false })                           
        {
            var parsed_m_cacheHandles = Parse_GameSGameDescription_PublicBeta1_m_cacheHandles();
            m_cacheHandles = Option.Some(parsed_m_cacheHandles);
        }

        return new GameSGameDescription_PublicBeta1
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
            m_modFileSyncChecksum = Option.OkOrReturnMissingFieldErr(m_modFileSyncChecksum),
            m_saveFileName = Option.OkOrReturnMissingFieldErr(m_saveFileName),
            m_slotDescriptions = Option.OkOrReturnMissingFieldErr(m_slotDescriptions),
            m_defaultDifficulty = Option.OkOrReturnMissingFieldErr(m_defaultDifficulty),
            m_cacheHandles = Option.OkOrReturnMissingFieldErr(m_cacheHandles),
        };
    }

    public uint32 Parse_GameSGameDescription_PublicBeta1_m_randomValue()
    {                             
        var m_randomValue = Parse_uint32();
        return m_randomValue;
    }

    public GameCGameCacheName Parse_GameSGameDescription_PublicBeta1_m_gameCacheName()
    {                             
        var m_gameCacheName = Parse_GameCGameCacheName();
        return m_gameCacheName;
    }

    public GameSGameOptions_PublicBeta1 Parse_GameSGameDescription_PublicBeta1_m_gameOptions()
    {                             
        var m_gameOptions = Parse_GameSGameOptions_PublicBeta1();
        return m_gameOptions;
    }

    public GameEGameSpeed Parse_GameSGameDescription_PublicBeta1_m_gameSpeed()
    {                             
        var m_gameSpeed = Parse_GameEGameSpeed();
        return m_gameSpeed;
    }

    public GameEGameType Parse_GameSGameDescription_PublicBeta1_m_gameType()
    {                             
        var m_gameType = Parse_GameEGameType();
        return m_gameType;
    }

    public TUserCount Parse_GameSGameDescription_PublicBeta1_m_maxUsers()
    {                             
        var m_maxUsers = Parse_TUserCount();
        return m_maxUsers;
    }

    public TUserCount Parse_GameSGameDescription_PublicBeta1_m_maxObservers()
    {                             
        var m_maxObservers = Parse_TUserCount();
        return m_maxObservers;
    }

    public GameTPlayerCount Parse_GameSGameDescription_PublicBeta1_m_maxPlayers()
    {                             
        var m_maxPlayers = Parse_GameTPlayerCount();
        return m_maxPlayers;
    }

    public GameTTeamCount Parse_GameSGameDescription_PublicBeta1_m_maxTeams()
    {                             
        var m_maxTeams = Parse_GameTTeamCount();
        return m_maxTeams;
    }

    public GameTColorCount Parse_GameSGameDescription_PublicBeta1_m_maxColors()
    {                             
        var m_maxColors = Parse_GameTColorCount();
        return m_maxColors;
    }

    public TRaceCount Parse_GameSGameDescription_PublicBeta1_m_maxRaces()
    {                             
        var m_maxRaces = Parse_TRaceCount();
        return m_maxRaces;
    }

    public GameTControlCount Parse_GameSGameDescription_PublicBeta1_m_maxControls()
    {                             
        var m_maxControls = Parse_GameTControlCount();
        return m_maxControls;
    }

    public uint8 Parse_GameSGameDescription_PublicBeta1_m_mapSizeX()
    {                             
        var m_mapSizeX = Parse_uint8();
        return m_mapSizeX;
    }

    public uint8 Parse_GameSGameDescription_PublicBeta1_m_mapSizeY()
    {                             
        var m_mapSizeY = Parse_uint8();
        return m_mapSizeY;
    }

    public GameTSyncChecksum Parse_GameSGameDescription_PublicBeta1_m_mapFileSyncChecksum()
    {                             
        var m_mapFileSyncChecksum = Parse_GameTSyncChecksum();
        return m_mapFileSyncChecksum;
    }

    public CFilePath Parse_GameSGameDescription_PublicBeta1_m_mapFileName()
    {                             
        var m_mapFileName = Parse_CFilePath();
        return m_mapFileName;
    }

    public GameTSyncChecksum Parse_GameSGameDescription_PublicBeta1_m_modFileSyncChecksum()
    {                             
        var m_modFileSyncChecksum = Parse_GameTSyncChecksum();
        return m_modFileSyncChecksum;
    }

    public CFilePath Parse_GameSGameDescription_PublicBeta1_m_saveFileName()
    {                             
        var m_saveFileName = Parse_CFilePath();
        return m_saveFileName;
    }

    public GameSSlotDescriptions Parse_GameSGameDescription_PublicBeta1_m_slotDescriptions()
    {                             
        var m_slotDescriptions = Parse_GameSSlotDescriptions();
        return m_slotDescriptions;
    }

    public GameTDifficulty Parse_GameSGameDescription_PublicBeta1_m_defaultDifficulty()
    {                             
        var m_defaultDifficulty = Parse_GameTDifficulty();
        return m_defaultDifficulty;
    }

    public GameCCacheHandles Parse_GameSGameDescription_PublicBeta1_m_cacheHandles()
    {                             
        var m_cacheHandles = Parse_GameCCacheHandles();
        return m_cacheHandles;
    }

    public GameSLobbySlot_PublicBeta1 Parse_GameSLobbySlot_PublicBeta1() 
    {
        Option<GameTControlId> m_control = Option.None;
        var m_userId = Option.Some<Option<TUserId>>(Option.None);
        Option<GameTTeamId> m_teamId = Option.None;
        Option<GameTColorPreference> m_colorPref = Option.None;
        Option<TRacePreference> m_racePref = Option.None;
        Option<GameTDifficulty> m_difficulty = Option.None;
        Option<GameTHandicap> m_handicap = Option.None;
        Option<EObserve> m_observe = Option.None;
        if (m_control is { HasValue: false })                           
        {
            var parsed_m_control = Parse_GameSLobbySlot_PublicBeta1_m_control();
            m_control = Option.Some(parsed_m_control);
        }

        if (m_userId is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_userId = Parse_GameSLobbySlot_PublicBeta1_m_userId();
            m_userId = Option.Some(parsed_m_userId);
        }

        if (m_teamId is { HasValue: false })                           
        {
            var parsed_m_teamId = Parse_GameSLobbySlot_PublicBeta1_m_teamId();
            m_teamId = Option.Some(parsed_m_teamId);
        }

        if (m_colorPref is { HasValue: false })                           
        {
            var parsed_m_colorPref = Parse_GameSLobbySlot_PublicBeta1_m_colorPref();
            m_colorPref = Option.Some(parsed_m_colorPref);
        }

        if (m_racePref is { HasValue: false })                           
        {
            var parsed_m_racePref = Parse_GameSLobbySlot_PublicBeta1_m_racePref();
            m_racePref = Option.Some(parsed_m_racePref);
        }

        if (m_difficulty is { HasValue: false })                           
        {
            var parsed_m_difficulty = Parse_GameSLobbySlot_PublicBeta1_m_difficulty();
            m_difficulty = Option.Some(parsed_m_difficulty);
        }

        if (m_handicap is { HasValue: false })                           
        {
            var parsed_m_handicap = Parse_GameSLobbySlot_PublicBeta1_m_handicap();
            m_handicap = Option.Some(parsed_m_handicap);
        }

        if (m_observe is { HasValue: false })                           
        {
            var parsed_m_observe = Parse_GameSLobbySlot_PublicBeta1_m_observe();
            m_observe = Option.Some(parsed_m_observe);
        }

        return new GameSLobbySlot_PublicBeta1
        {   
            m_control = Option.OkOrReturnMissingFieldErr(m_control),
            m_userId = Option.OkOrReturnMissingFieldErr(m_userId),
            m_teamId = Option.OkOrReturnMissingFieldErr(m_teamId),
            m_colorPref = Option.OkOrReturnMissingFieldErr(m_colorPref),
            m_racePref = Option.OkOrReturnMissingFieldErr(m_racePref),
            m_difficulty = Option.OkOrReturnMissingFieldErr(m_difficulty),
            m_handicap = Option.OkOrReturnMissingFieldErr(m_handicap),
            m_observe = Option.OkOrReturnMissingFieldErr(m_observe),
        };
    }

    public GameTControlId Parse_GameSLobbySlot_PublicBeta1_m_control()
    {                             
        var m_control = Parse_GameTControlId();
        return m_control;
    }

    public Option<TUserId> Parse_GameSLobbySlot_PublicBeta1_m_userId()
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

    public GameTTeamId Parse_GameSLobbySlot_PublicBeta1_m_teamId()
    {                             
        var m_teamId = Parse_GameTTeamId();
        return m_teamId;
    }

    public GameTColorPreference Parse_GameSLobbySlot_PublicBeta1_m_colorPref()
    {                             
        var m_colorPref = Parse_GameTColorPreference();
        return m_colorPref;
    }

    public TRacePreference Parse_GameSLobbySlot_PublicBeta1_m_racePref()
    {                             
        var m_racePref = Parse_TRacePreference();
        return m_racePref;
    }

    public GameTDifficulty Parse_GameSLobbySlot_PublicBeta1_m_difficulty()
    {                             
        var m_difficulty = Parse_GameTDifficulty();
        return m_difficulty;
    }

    public GameTHandicap Parse_GameSLobbySlot_PublicBeta1_m_handicap()
    {                             
        var m_handicap = Parse_GameTHandicap();
        return m_handicap;
    }

    public EObserve Parse_GameSLobbySlot_PublicBeta1_m_observe()
    {                             
        var m_observe = Parse_EObserve();
        return m_observe;
    }

    public GameSLobbyState_PublicBeta1 Parse_GameSLobbyState_PublicBeta1() 
    {
        Option<GameEPhase> m_phase = Option.None;
        Option<TUserCount> m_maxUsers = Option.None;
        Option<TUserCount> m_maxObservers = Option.None;
        Option<GameCLobbySlotArray_PublicBeta1> m_slots = Option.None;
        Option<uint32> m_randomSeed = Option.None;
        var m_hostUserId = Option.Some<Option<TUserId>>(Option.None);
        Option<bool> m_isSinglePlayer = Option.None;
        Option<uint32> m_gameDuration = Option.None;
        Option<GameTDifficulty> m_defaultDifficulty = Option.None;
        if (m_phase is { HasValue: false })                           
        {
            var parsed_m_phase = Parse_GameSLobbyState_PublicBeta1_m_phase();
            m_phase = Option.Some(parsed_m_phase);
        }

        if (m_maxUsers is { HasValue: false })                           
        {
            var parsed_m_maxUsers = Parse_GameSLobbyState_PublicBeta1_m_maxUsers();
            m_maxUsers = Option.Some(parsed_m_maxUsers);
        }

        if (m_maxObservers is { HasValue: false })                           
        {
            var parsed_m_maxObservers = Parse_GameSLobbyState_PublicBeta1_m_maxObservers();
            m_maxObservers = Option.Some(parsed_m_maxObservers);
        }

        if (m_slots is { HasValue: false })                           
        {
            var parsed_m_slots = Parse_GameSLobbyState_PublicBeta1_m_slots();
            m_slots = Option.Some(parsed_m_slots);
        }

        if (m_randomSeed is { HasValue: false })                           
        {
            var parsed_m_randomSeed = Parse_GameSLobbyState_PublicBeta1_m_randomSeed();
            m_randomSeed = Option.Some(parsed_m_randomSeed);
        }

        if (m_hostUserId is { HasValue: true, Value.HasValue: false })
        {
            var parsed_m_hostUserId = Parse_GameSLobbyState_PublicBeta1_m_hostUserId();
            m_hostUserId = Option.Some(parsed_m_hostUserId);
        }

        if (m_isSinglePlayer is { HasValue: false })                           
        {
            var parsed_m_isSinglePlayer = Parse_GameSLobbyState_PublicBeta1_m_isSinglePlayer();
            m_isSinglePlayer = Option.Some(parsed_m_isSinglePlayer);
        }

        if (m_gameDuration is { HasValue: false })                           
        {
            var parsed_m_gameDuration = Parse_GameSLobbyState_PublicBeta1_m_gameDuration();
            m_gameDuration = Option.Some(parsed_m_gameDuration);
        }

        if (m_defaultDifficulty is { HasValue: false })                           
        {
            var parsed_m_defaultDifficulty = Parse_GameSLobbyState_PublicBeta1_m_defaultDifficulty();
            m_defaultDifficulty = Option.Some(parsed_m_defaultDifficulty);
        }

        return new GameSLobbyState_PublicBeta1
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

    public GameEPhase Parse_GameSLobbyState_PublicBeta1_m_phase()
    {                             
        var m_phase = Parse_GameEPhase();
        return m_phase;
    }

    public TUserCount Parse_GameSLobbyState_PublicBeta1_m_maxUsers()
    {                             
        var m_maxUsers = Parse_TUserCount();
        return m_maxUsers;
    }

    public TUserCount Parse_GameSLobbyState_PublicBeta1_m_maxObservers()
    {                             
        var m_maxObservers = Parse_TUserCount();
        return m_maxObservers;
    }

    public GameCLobbySlotArray_PublicBeta1 Parse_GameSLobbyState_PublicBeta1_m_slots()
    {                             
        var m_slots = Parse_GameCLobbySlotArray_PublicBeta1();
        return m_slots;
    }

    public uint32 Parse_GameSLobbyState_PublicBeta1_m_randomSeed()
    {                             
        var m_randomSeed = Parse_uint32();
        return m_randomSeed;
    }

    public Option<TUserId> Parse_GameSLobbyState_PublicBeta1_m_hostUserId()
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

    public bool Parse_GameSLobbyState_PublicBeta1_m_isSinglePlayer()
    {                             
        var m_isSinglePlayer = parse_bool();
        return m_isSinglePlayer;
    }

    public uint32 Parse_GameSLobbyState_PublicBeta1_m_gameDuration()
    {                             
        var m_gameDuration = Parse_uint32();
        return m_gameDuration;
    }

    public GameTDifficulty Parse_GameSLobbyState_PublicBeta1_m_defaultDifficulty()
    {                             
        var m_defaultDifficulty = Parse_GameTDifficulty();
        return m_defaultDifficulty;
    }

    public GameSLobbySyncState_PublicBeta1 Parse_GameSLobbySyncState_PublicBeta1() 
    {
        Option<CUserInitialDataArray> m_userInitialData = Option.None;
        Option<GameSGameDescription_PublicBeta1> m_gameDescription = Option.None;
        Option<GameSLobbyState_PublicBeta1> m_lobbyState = Option.None;
        if (m_userInitialData is { HasValue: false })                           
        {
            var parsed_m_userInitialData = Parse_GameSLobbySyncState_PublicBeta1_m_userInitialData();
            m_userInitialData = Option.Some(parsed_m_userInitialData);
        }

        if (m_gameDescription is { HasValue: false })                           
        {
            var parsed_m_gameDescription = Parse_GameSLobbySyncState_PublicBeta1_m_gameDescription();
            m_gameDescription = Option.Some(parsed_m_gameDescription);
        }

        if (m_lobbyState is { HasValue: false })                           
        {
            var parsed_m_lobbyState = Parse_GameSLobbySyncState_PublicBeta1_m_lobbyState();
            m_lobbyState = Option.Some(parsed_m_lobbyState);
        }

        return new GameSLobbySyncState_PublicBeta1
        {   
            m_userInitialData = Option.OkOrReturnMissingFieldErr(m_userInitialData),
            m_gameDescription = Option.OkOrReturnMissingFieldErr(m_gameDescription),
            m_lobbyState = Option.OkOrReturnMissingFieldErr(m_lobbyState),
        };
    }

    public CUserInitialDataArray Parse_GameSLobbySyncState_PublicBeta1_m_userInitialData()
    {                             
        var m_userInitialData = Parse_CUserInitialDataArray();
        return m_userInitialData;
    }

    public GameSGameDescription_PublicBeta1 Parse_GameSLobbySyncState_PublicBeta1_m_gameDescription()
    {                             
        var m_gameDescription = Parse_GameSGameDescription_PublicBeta1();
        return m_gameDescription;
    }

    public GameSLobbyState_PublicBeta1 Parse_GameSLobbySyncState_PublicBeta1_m_lobbyState()
    {                             
        var m_lobbyState = Parse_GameSLobbyState_PublicBeta1();
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

    public GameSSelectionMask Parse_GameSSelectionMask() 
    {
        return new GameSSelectionMask
        {   
        };
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

}
