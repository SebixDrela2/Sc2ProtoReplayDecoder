
using Sc2ReplayAnalyzer.Global;

namespace Sc2ReplayAnalyzer.Json.BitPackedProtocolDefinitions;

// NNet.SVarUint32
public abstract class SVarUint32 { }

// m_uint6
public  class m_uint6 : SVarUint32
{
    public uint6 Value;
}

// m_uint14
public  class m_uint14 : SVarUint32
{
    public uint14 Value;
}

// m_uint22
public  class m_uint22 : SVarUint32
{
    public uint22 Value;
}

// m_uint32
public  class m_uint32 : SVarUint32
{
    public uint32 Value;
}

// NNet.Game.SCmdData
public abstract class GameSCmdData { }

// TargetPoint
public  class TargetPoint : GameSCmdData
{
    public GameSMapCoord3D Value;
}

// TargetUnit
public  class TargetUnit : GameSCmdData
{
    public GameSCmdDataTargetUnit Value;
}

// Data
public  class Data : GameSCmdData
{
    public uint32 Value;
}

// m_eventData
public abstract class m_eventData { }

// Checked
public  class Checked : m_eventData
{
    public bool Value;
}

// ValueChanged
public  class ValueChanged : m_eventData
{
    public uint32 Value;
}

// SelectionChanged
public  class SelectionChanged : m_eventData
{
    public int32 Value;
}

// TextChanged
public  class TextChanged : m_eventData
{
    public GameCChatString Value;
}

// MouseButton
public  class MouseButton : m_eventData
{
    public uint32 Value;
}

// NNet.Game.SLobbySlotChange
public abstract class GameSLobbySlotChange { }

// m_control
public  class m_control : GameSLobbySlotChange
{
    public GameTControlId Value;
}

// m_userId
public  class m_userId : GameSLobbySlotChange
{
    public Option<TUserId> Value;
}

// m_teamId
public  class m_teamId : GameSLobbySlotChange
{
    public GameTTeamId Value;
}

// m_colorPref
public  class m_colorPref : GameSLobbySlotChange
{
    public GameTColorPreference Value;
}

// m_racePref
public  class m_racePref : GameSLobbySlotChange
{
    public TRacePreference Value;
}

// m_difficulty
public  class m_difficulty : GameSLobbySlotChange
{
    public GameTDifficulty Value;
}

// m_aiBuild
public  class m_aiBuild : GameSLobbySlotChange
{
    public GameTAIBuild Value;
}

// m_handicap
public  class m_handicap : GameSLobbySlotChange
{
    public GameTHandicap Value;
}

// m_observe
public  class m_observe : GameSLobbySlotChange
{
    public EObserve Value;
}

// m_logoIndex
public  class m_logoIndex : GameSLobbySlotChange
{
    public GameTPlayerLogoIndex Value;
}

// m_hero
public  class m_hero : GameSLobbySlotChange
{
    public CHeroHandle Value;
}

// m_skin
public  class m_skin : GameSLobbySlotChange
{
    public CSkinHandle Value;
}

// m_mount
public  class m_mount : GameSLobbySlotChange
{
    public CMountHandle Value;
}

// m_licenses
public  class m_licenses : GameSLobbySlotChange
{
    public GameCLicenseArray Value;
}

// m_tandemLeaderId
public  class m_tandemLeaderId : GameSLobbySlotChange
{
    public Option<TUserId> Value;
}

// m_commander
public  class m_commander : GameSLobbySlotChange
{
    public CCommanderHandle Value;
}

// m_commanderLevel
public  class m_commanderLevel : GameSLobbySlotChange
{
    public uint32 Value;
}

// m_hasSilencePenalty
public  class m_hasSilencePenalty : GameSLobbySlotChange
{
    public bool Value;
}

// m_tandemId
public  class m_tandemId : GameSLobbySlotChange
{
    public Option<TUserId> Value;
}

// m_commanderMasteryLevel
public  class m_commanderMasteryLevel : GameSLobbySlotChange
{
    public uint32 Value;
}

// m_brutalPlusDifficulty
public  class m_brutalPlusDifficulty : GameSLobbySlotChange
{
    public uint32 Value;
}

// m_retryMutationIndexes
public  class m_retryMutationIndexes : GameSLobbySlotChange
{
    public GameCRetryMutationIndexArray Value;
}

// m_aCEnemyRace
public  class m_aCEnemyRace : GameSLobbySlotChange
{
    public uint32 Value;
}

// m_aCEnemyWaveType
public  class m_aCEnemyWaveType : GameSLobbySlotChange
{
    public uint32 Value;
}

// m_selectedCommanderPrestige
public  class m_selectedCommanderPrestige : GameSLobbySlotChange
{
    public uint32 Value;
}

// NNet.Game.SSelectionMask
public abstract class GameSSelectionMask { }

// Mask
public  class Mask : GameSSelectionMask
{
    public GameSelectionMaskType Value;
}

// OneIndices
public  class OneIndices : GameSSelectionMask
{
    public GameSelectionIndexArrayType Value;
}

// ZeroIndices
public  class ZeroIndices : GameSSelectionMask
{
    public GameSelectionIndexArrayType Value;
}

// NNet.TRacePreference
public  class TRacePreference
{
    public Option<TRaceId> m_race;
}

// NNet.TTeamPreference
public  class TTeamPreference
{
    public Option<uint8> m_team;
}

// NNet.SUserInitialData
public  class SUserInitialData
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

// NNet.SVersion
public  class SVersion
{
    public uint8 m_flags;
    public uint8 m_major;
    public uint8 m_minor;
    public uint8 m_revision;
    public uint32 m_build;
    public uint32 m_baseBuild;
}

// NNet.SMD5
public  class SMD5
{
    public Option<uint8[]> m_dataDeprecated;
    public u8[] m_data;
}

// NNet.Game.TColorPreference
public  class GameTColorPreference
{
    public Option<GameTColorId> m_color;
}

// NNet.Game.SCmdAbil
public  class GameSCmdAbil
{
    public GameTAbilLink m_abilLink;
    public i64 m_abilCmdIndex;
    public Option<uint8> m_abilCmdData;
}

// NNet.Game.SCmdDataTargetUnit
public  class GameSCmdDataTargetUnit
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
public  class GameSSetLobbySlotEvent
{
    public GameTLobbySlotId m_slotId;
    public GameSLobbySlotChange m_slotChange;
}

// NNet.Game.SDropUserEvent
public  class GameSDropUserEvent
{
    public TUserId m_dropSessionUserId;
    public ELeaveReason m_reason;
}

// NNet.Game.SStartGameEvent
public  class GameSStartGameEvent
{
}

// NNet.Game.SDropOurselvesEvent
public  class GameSDropOurselvesEvent
{
}

// NNet.Game.SBankFileEvent
public  class GameSBankFileEvent
{
    public u8[] m_name;
}

// NNet.Game.SBankSectionEvent
public  class GameSBankSectionEvent
{
    public u8[] m_name;
}

// NNet.Game.SBankKeyEvent
public  class GameSBankKeyEvent
{
    public u8[] m_name;
    public uint32 m_type;
    public u8[] m_data;
}

// NNet.Game.SBankValueEvent
public  class GameSBankValueEvent
{
    public uint32 m_type;
    public u8[] m_name;
    public u8[] m_data;
}

// NNet.Game.SBankSignatureEvent
public  class GameSBankSignatureEvent
{
    public uint8[] m_signature;
    public CToonHandle m_toonHandle;
}

// NNet.Game.SUserOptionsEvent
public  class GameSUserOptionsEvent
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
    public u8[] m_hotkeyProfile;
}

// NNet.Game.SPickMapTagEvent
public  class GameSPickMapTagEvent
{
    public uint8 m_pickedMapTag;
}

// NNet.Game.SUserFinishedLoadingEvent
public  class GameSUserFinishedLoadingEvent
{
}

// NNet.Game.SUserFinishedLoadingSyncEvent
public  class GameSUserFinishedLoadingSyncEvent
{
}

// NNet.Game.SSetGameDurationEvent
public  class GameSSetGameDurationEvent
{
    public uint32 m_gameDuration;
}

// NNet.Game.STurnEvent
public  class GameSTurnEvent
{
}

// NNet.Game.SCameraSaveEvent
public  class GameSCameraSaveEvent
{
    public i64 m_which;
    public GameSPointMini m_target;
}

// NNet.Game.SPauseGameEvent
public  class GameSPauseGameEvent
{
    public uint8 m_pauseTypeIndex;
}

// NNet.Game.SUnpauseGameEvent
public  class GameSUnpauseGameEvent
{
    public uint8 m_pauseTypeIndex;
}

// NNet.Game.SSingleStepGameEvent
public  class GameSSingleStepGameEvent
{
}

// NNet.Game.SSetGameSpeedEvent
public  class GameSSetGameSpeedEvent
{
    public GameEGameSpeed m_speed;
}

// NNet.Game.SAddGameSpeedEvent
public  class GameSAddGameSpeedEvent
{
    public int8 m_delta;
}

// NNet.Game.SReplayJumpEvent
public  class GameSReplayJumpEvent
{
    public Option<uint32> m_replayJumpGameLoop;
}

// NNet.Game.SSaveGameEvent
public  class GameSSaveGameEvent
{
    public CFilePath m_fileName;
    public bool m_automatic;
    public bool m_overwrite;
    public u8[] m_name;
    public u8[] m_description;
}

// NNet.Game.SSaveGameDoneEvent
public  class GameSSaveGameDoneEvent
{
}

// NNet.Game.SLoadGameDoneEvent
public  class GameSLoadGameDoneEvent
{
}

// NNet.Game.SCheatEventData
public  class GameSCheatEventData
{
    public GameSPoint m_point;
    public int32 m_time;
    public GameCCheatString m_verb;
    public GameCCheatString m_arguments;
}

// NNet.Game.SSessionCheatEvent
public  class GameSSessionCheatEvent
{
    public GameSCheatEventData m_data;
}

// NNet.Game.SCommandManagerResetEvent
public  class GameSCommandManagerResetEvent
{
    public uint32 m_sequence;
}

// NNet.Game.SGameCheatEvent
public  class GameSGameCheatEvent
{
    public GameSCheatEventData m_data;
}

// NNet.Game.SCmdEvent
public  class GameSCmdEvent
{
    public i64 m_cmdFlags;
    public Option<GameSCmdAbil> m_abil;
    public GameSCmdData m_data;
    public i64 m_sequence;
    public Option<GameTUnitTag> m_otherUnit;
    public Option<uint32> m_unitGroup;
}

// NNet.Game.SSelectionDeltaEvent
public  class GameSSelectionDeltaEvent
{
    public GameTControlGroupId m_controlGroupId;
    public GameSSelectionDelta m_delta;
}

// NNet.Game.SControlGroupUpdateEvent
public  class GameSControlGroupUpdateEvent
{
    public GameTControlGroupIndex m_controlGroupIndex;
    public GameEControlGroupUpdate m_controlGroupUpdate;
    public GameSSelectionMask m_mask;
}

// NNet.Game.SSelectionSyncCheckEvent
public  class GameSSelectionSyncCheckEvent
{
    public GameTControlGroupId m_controlGroupId;
    public GameSSelectionSyncData m_selectionSyncData;
}

// NNet.Game.SResourceTradeEvent
public  class GameSResourceTradeEvent
{
    public GameTPlayerId m_recipientId;
    public int32[] m_resources;
}

// NNet.Game.STriggerChatMessageEvent
public  class GameSTriggerChatMessageEvent
{
    public GameCTriggerChatMessageString m_chatMessage;
}

// NNet.Game.SAICommunicateEvent
public  class GameSAICommunicateEvent
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
public  class GameSSetAbsoluteGameSpeedEvent
{
    public GameEGameSpeed m_speed;
}

// NNet.Game.SAddAbsoluteGameSpeedEvent
public  class GameSAddAbsoluteGameSpeedEvent
{
    public int8 m_delta;
}

// NNet.Game.STriggerPingEvent
public  class GameSTriggerPingEvent
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
public  class GameSBroadcastCheatEvent
{
    public GameCCheatString m_verb;
    public GameCCheatString m_arguments;
}

// NNet.Game.SAllianceEvent
public  class GameSAllianceEvent
{
    public uint32 m_alliance;
    public uint32 m_control;
}

// NNet.Game.SUnitClickEvent
public  class GameSUnitClickEvent
{
    public GameTUnitTag m_unitTag;
}

// NNet.Game.SUnitHighlightEvent
public  class GameSUnitHighlightEvent
{
    public GameTUnitTag m_unitTag;
    public uint8 m_flags;
}

// NNet.Game.STriggerReplySelectedEvent
public  class GameSTriggerReplySelectedEvent
{
    public int32 m_conversationId;
    public int32 m_replyId;
}

// NNet.Game.SHijackReplaySessionUserInfo
public  class GameSHijackReplaySessionUserInfo
{
    public TUserId m_sessionUserId;
    public bool m_addNewGameUser;
    public TUserId m_gameUserId;
}

// NNet.Game.SHijackReplaySessionEvent
public  class GameSHijackReplaySessionEvent
{
    public GameSHijackReplaySessionUserInfo[] m_userInfos;
    public GameEHijackMethod m_method;
}

// NNet.Game.SHijackReplayGameUserInfo
public  class GameSHijackReplayGameUserInfo
{
    public TUserId m_gameUserId;
    public EObserve m_observe;
    public CUserName m_name;
    public Option<CToonHandle> m_toonHandle;
    public Option<CClanTag> m_clanTag;
    public Option<GameCCacheHandle> m_clanLogo;
}

// NNet.Game.SHijackReplayGameEvent
public  class GameSHijackReplayGameEvent
{
    public GameSHijackReplayGameUserInfo[] m_userInfos;
    public GameEHijackMethod m_method;
}

// NNet.Game.STriggerAbortMissionEvent
public  class GameSTriggerAbortMissionEvent
{
}

// NNet.Game.STriggerPurchaseMadeEvent
public  class GameSTriggerPurchaseMadeEvent
{
    public int32 m_purchaseItemId;
}

// NNet.Game.STriggerPurchaseExitEvent
public  class GameSTriggerPurchaseExitEvent
{
}

// NNet.Game.STriggerPlanetMissionLaunchedEvent
public  class GameSTriggerPlanetMissionLaunchedEvent
{
    public int32 m_difficultyLevel;
}

// NNet.Game.STriggerPlanetPanelCanceledEvent
public  class GameSTriggerPlanetPanelCanceledEvent
{
}

// NNet.Game.STriggerDialogControlEvent
public  class GameSTriggerDialogControlEvent
{
    public int32 m_controlId;
    public int32 m_eventType;
    public m_eventData m_eventData;
}

// NNet.Game.STriggerSkippedEvent
public  class GameSTriggerSkippedEvent
{
}

// NNet.Game.STriggerSoundLengthQueryEvent
public  class GameSTriggerSoundLengthQueryEvent
{
    public uint32 m_soundHash;
    public uint32 m_length;
}

// NNet.Game.STriggerSoundLengthSyncEvent
public  class GameSTriggerSoundLengthSyncEvent
{
    public GameSSyncSoundLength m_syncInfo;
}

// NNet.Game.STriggerAnimLengthQueryByNameEvent
public  class GameSTriggerAnimLengthQueryByNameEvent
{
    public GameTQueryID m_queryId;
    public uint32 m_lengthMs;
    public uint32 m_finishGameLoop;
}

// NNet.Game.STriggerAnimLengthQueryByPropsEvent
public  class GameSTriggerAnimLengthQueryByPropsEvent
{
    public GameTQueryID m_queryId;
    public uint32 m_lengthMs;
}

// NNet.Game.STriggerAnimOffsetEvent
public  class GameSTriggerAnimOffsetEvent
{
    public GameTQueryID m_animWaitQueryId;
}

// NNet.Game.STriggerSoundOffsetEvent
public  class GameSTriggerSoundOffsetEvent
{
    public GameTTriggerSoundTag m_sound;
}

// NNet.Game.STriggerTransmissionOffsetEvent
public  class GameSTriggerTransmissionOffsetEvent
{
    public int32 m_transmissionId;
    public GameTTriggerThreadTag m_thread;
}

// NNet.Game.STriggerTransmissionCompleteEvent
public  class GameSTriggerTransmissionCompleteEvent
{
    public int32 m_transmissionId;
}

// NNet.Game.SCameraUpdateEvent
public  class GameSCameraUpdateEvent
{
    public Option<GameSPointMini> m_target;
    public Option<GameTFixedMiniBitsUnsigned> m_distance;
    public Option<GameTFixedMiniBitsUnsigned> m_pitch;
    public Option<GameTFixedMiniBitsUnsigned> m_yaw;
    public Option<int8> m_reason;
    public bool m_follow;
}

// NNet.Game.STriggerConversationSkippedEvent
public  class GameSTriggerConversationSkippedEvent
{
    public GameEConversationSkip m_skipType;
}

// NNet.Game.STriggerMouseClickedEvent
public  class GameSTriggerMouseClickedEvent
{
    public uint32 m_button;
    public bool m_down;
    public GameSUICoord m_posUI;
    public GameSMapCoord3D m_posWorld;
    public int8 m_flags;
}

// NNet.Game.STriggerMouseMovedEvent
public  class GameSTriggerMouseMovedEvent
{
    public GameSUICoord m_posUI;
    public GameSMapCoord3D m_posWorld;
    public int8 m_flags;
}

// NNet.Game.SAchievementAwardedEvent
public  class GameSAchievementAwardedEvent
{
    public GameTAchievementLink m_achievementLink;
}

// NNet.Game.STriggerHotkeyPressedEvent
public  class GameSTriggerHotkeyPressedEvent
{
    public uint32 m_hotkey;
    public bool m_down;
}

// NNet.Game.STriggerTargetModeUpdateEvent
public  class GameSTriggerTargetModeUpdateEvent
{
    public GameTAbilLink m_abilLink;
    public i64 m_abilCmdIndex;
    public int8 m_state;
}

// NNet.Game.STriggerPlanetPanelReplayEvent
public  class GameSTriggerPlanetPanelReplayEvent
{
}

// NNet.Game.STriggerSoundtrackDoneEvent
public  class GameSTriggerSoundtrackDoneEvent
{
    public uint32 m_soundtrack;
}

// NNet.Game.STriggerPlanetMissionSelectedEvent
public  class GameSTriggerPlanetMissionSelectedEvent
{
    public int32 m_planetId;
}

// NNet.Game.STriggerKeyPressedEvent
public  class GameSTriggerKeyPressedEvent
{
    public int8 m_key;
    public int8 m_flags;
}

// NNet.Game.STriggerPlanetPanelBirthCompleteEvent
public  class GameSTriggerPlanetPanelBirthCompleteEvent
{
}

// NNet.Game.STriggerPlanetPanelDeathCompleteEvent
public  class GameSTriggerPlanetPanelDeathCompleteEvent
{
}

// NNet.Game.SResourceRequestEvent
public  class GameSResourceRequestEvent
{
    public int32[] m_resources;
}

// NNet.Game.SResourceRequestFulfillEvent
public  class GameSResourceRequestFulfillEvent
{
    public int32 m_fulfillRequestId;
}

// NNet.Game.SResourceRequestCancelEvent
public  class GameSResourceRequestCancelEvent
{
    public int32 m_cancelRequestId;
}

// NNet.Game.STriggerResearchPanelExitEvent
public  class GameSTriggerResearchPanelExitEvent
{
}

// NNet.Game.STriggerResearchPanelPurchaseEvent
public  class GameSTriggerResearchPanelPurchaseEvent
{
}

// NNet.Game.STriggerCommandErrorEvent
public  class GameSTriggerCommandErrorEvent
{
    public int32 m_error;
    public Option<GameSCmdAbil> m_abil;
}

// NNet.Game.STriggerResearchPanelSelectionChangedEvent
public  class GameSTriggerResearchPanelSelectionChangedEvent
{
    public int32 m_researchItemId;
}

// NNet.Game.STriggerMercenaryPanelExitEvent
public  class GameSTriggerMercenaryPanelExitEvent
{
}

// NNet.Game.STriggerMercenaryPanelPurchaseEvent
public  class GameSTriggerMercenaryPanelPurchaseEvent
{
}

// NNet.Game.STriggerMercenaryPanelSelectionChangedEvent
public  class GameSTriggerMercenaryPanelSelectionChangedEvent
{
    public int32 m_mercenaryId;
}

// NNet.Game.STriggerVictoryPanelExitEvent
public  class GameSTriggerVictoryPanelExitEvent
{
}

// NNet.Game.STriggerBattleReportPanelExitEvent
public  class GameSTriggerBattleReportPanelExitEvent
{
}

// NNet.Game.STriggerBattleReportPanelPlayMissionEvent
public  class GameSTriggerBattleReportPanelPlayMissionEvent
{
    public int32 m_battleReportId;
    public int32 m_difficultyLevel;
}

// NNet.Game.STriggerBattleReportPanelPlaySceneEvent
public  class GameSTriggerBattleReportPanelPlaySceneEvent
{
    public int32 m_battleReportId;
}

// NNet.Game.STriggerBattleReportPanelSelectionChangedEvent
public  class GameSTriggerBattleReportPanelSelectionChangedEvent
{
    public int32 m_battleReportId;
}

// NNet.Game.STriggerVictoryPanelPlayMissionAgainEvent
public  class GameSTriggerVictoryPanelPlayMissionAgainEvent
{
    public int32 m_difficultyLevel;
}

// NNet.Game.STriggerMovieStartedEvent
public  class GameSTriggerMovieStartedEvent
{
}

// NNet.Game.STriggerMovieFinishedEvent
public  class GameSTriggerMovieFinishedEvent
{
}

// NNet.Game.SDecrementGameTimeRemainingEvent
public  class GameSDecrementGameTimeRemainingEvent
{
    public int32 m_decrementSeconds;
}

// NNet.Game.STriggerPortraitLoadedEvent
public  class GameSTriggerPortraitLoadedEvent
{
    public int32 m_portraitId;
}

// NNet.Game.STriggerMovieFunctionEvent
public  class GameSTriggerMovieFunctionEvent
{
    public u8[] m_functionName;
}

// NNet.Game.STriggerCustomDialogDismissedEvent
public  class GameSTriggerCustomDialogDismissedEvent
{
    public int32 m_result;
}

// NNet.Game.STriggerGameMenuItemSelectedEvent
public  class GameSTriggerGameMenuItemSelectedEvent
{
    public int32 m_gameMenuItemIndex;
}

// NNet.Game.STriggerMouseWheelEvent
public  class GameSTriggerMouseWheelEvent
{
    public GameTFixedMiniBitsSigned m_wheelSpin;
    public int8 m_flags;
}

// NNet.Game.STriggerPurchasePanelSelectedPurchaseItemChangedEvent
public  class GameSTriggerPurchasePanelSelectedPurchaseItemChangedEvent
{
    public int32 m_purchaseItemId;
}

// NNet.Game.STriggerPurchasePanelSelectedPurchaseCategoryChangedEvent
public  class GameSTriggerPurchasePanelSelectedPurchaseCategoryChangedEvent
{
    public int32 m_purchaseCategoryId;
}

// NNet.Game.STriggerButtonPressedEvent
public  class GameSTriggerButtonPressedEvent
{
    public GameTButtonLink m_button;
}

// NNet.Game.STriggerGameCreditsFinishedEvent
public  class GameSTriggerGameCreditsFinishedEvent
{
}

// NNet.Game.STriggerCutsceneBookmarkFiredEvent
public  class GameSTriggerCutsceneBookmarkFiredEvent
{
    public int32 m_cutsceneId;
    public u8[] m_bookmarkName;
}

// NNet.Game.STriggerCutsceneEndSceneFiredEvent
public  class GameSTriggerCutsceneEndSceneFiredEvent
{
    public int32 m_cutsceneId;
}

// NNet.Game.STriggerCutsceneConversationLineEvent
public  class GameSTriggerCutsceneConversationLineEvent
{
    public int32 m_cutsceneId;
    public u8[] m_conversationLine;
    public u8[] m_altConversationLine;
}

// NNet.Game.STriggerCutsceneConversationLineMissingEvent
public  class GameSTriggerCutsceneConversationLineMissingEvent
{
    public int32 m_cutsceneId;
    public u8[] m_conversationLine;
}

// NNet.Game.SGameUserLeaveEvent
public  class GameSGameUserLeaveEvent
{
    public ELeaveReason m_leaveReason;
}

// NNet.Game.SGameUserJoinEvent
public  class GameSGameUserJoinEvent
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
public  class GameSCommandManagerStateEvent
{
    public GameECommandManagerState m_state;
    public Option<i64> m_sequence;
}

// NNet.Game.SCmdUpdateTargetPointEvent
public  class GameSCmdUpdateTargetPointEvent
{
    public GameSMapCoord3D m_target;
}

// NNet.Game.SCmdUpdateTargetUnitEvent
public  class GameSCmdUpdateTargetUnitEvent
{
    public GameSCmdDataTargetUnit m_target;
}

// NNet.Game.SCatalogModifyEvent
public  class GameSCatalogModifyEvent
{
    public uint8 m_catalog;
    public uint16 m_entry;
    public u8[] m_field;
    public u8[] m_value;
}

// NNet.Game.SHeroTalentTreeSelectedEvent
public  class GameSHeroTalentTreeSelectedEvent
{
    public uint32 m_index;
}

// NNet.Game.STriggerProfilerLoggingFinishedEvent
public  class GameSTriggerProfilerLoggingFinishedEvent
{
}

// NNet.Game.SHeroTalentTreeSelectionPanelToggledEvent
public  class GameSHeroTalentTreeSelectionPanelToggledEvent
{
    public bool m_shown;
}

// NNet.Game.SMuteChatEvent
public  class GameSMuteChatEvent
{
    public TUserId m_targetUserId;
    public bool m_muted;
}

// NNet.Game.SConvertToReplaySessionEvent
public  class GameSConvertToReplaySessionEvent
{
    public Option<int32> m_replayJumpGameLoop;
}

// NNet.Game.SSetSyncLoadingTimeEvent
public  class GameSSetSyncLoadingTimeEvent
{
    public uint32 m_syncTime;
}

// NNet.Game.SSetSyncPlayingTimeEvent
public  class GameSSetSyncPlayingTimeEvent
{
    public uint32 m_syncTime;
}

// NNet.Game.SPeerSetSyncLoadingTimeEvent
public  class GameSPeerSetSyncLoadingTimeEvent
{
    public uint32 m_syncTime;
}

// NNet.Game.SPeerSetSyncPlayingTimeEvent
public  class GameSPeerSetSyncPlayingTimeEvent
{
    public uint32 m_syncTime;
}

// NNet.Game.SPoint
public  class GameSPoint
{
    public GameTFixedBits x;
    public GameTFixedBits y;
}

// NNet.Game.SPoint3
public  class GameSPoint3
{
    public GameTFixedBits x;
    public GameTFixedBits y;
    public GameTFixedBits z;
}

// NNet.Game.SPointMini
public  class GameSPointMini
{
    public GameTFixedMiniBitsUnsigned x;
    public GameTFixedMiniBitsUnsigned y;
}

// NNet.Game.SMapCoord
public  class GameSMapCoord
{
    public GameTMapCoordFixedBits x;
    public GameTMapCoordFixedBits y;
}

// NNet.Game.SMapCoord3D
public  class GameSMapCoord3D
{
    public GameTMapCoordFixedBits x;
    public GameTMapCoordFixedBits y;
    public GameTFixedBits z;
}

// NNet.Game.SUICoord
public  class GameSUICoord
{
    public GameTUICoordX x;
    public GameTUICoordY y;
}

// NNet.Game.SSyncSoundLength
public  class GameSSyncSoundLength
{
    public uint32[] m_soundHash;
    public uint32[] m_length;
}

// NNet.Game.SThumbnail
public  class GameSThumbnail
{
    public u8[] m_file;
}

// NNet.Game.SColor
public  class GameSColor
{
    public uint8 m_a;
    public uint8 m_r;
    public uint8 m_g;
    public uint8 m_b;
}

// NNet.Game.SToonNameDetails
public  class GameSToonNameDetails
{
    public uint8 m_region;
    public u8[] m_programId;
    public uint32 m_realm;
    public u8[] m_name;
    public uint64 m_id;
}

// NNet.Game.SPlayerDetails
public  class GameSPlayerDetails
{
    public CUserName m_name;
    public GameSToonNameDetails m_toon;
    public u8[] m_race;
    public GameSColor m_color;
    public GameTControlId m_control;
    public GameTTeamId m_teamId;
    public GameTHandicap m_handicap;
    public EObserve m_observe;
    public GameEResultDetails m_result;
    public Option<uint8> m_workingSetSlotId;
    public u8[] m_hero;
}

// NNet.Game.SDetails
public  class GameSDetails
{
    public Option<GameCPlayerDetailsArray> m_playerList;
    public u8[] m_title;
    public u8[] m_difficulty;
    public GameSThumbnail m_thumbnail;
    public bool m_isBlizzardMap;
    public int64 m_timeUTC;
    public int64 m_timeLocalOffset;
    public Option<bool> m_restartAsTransitionMap;
    public bool m_disableRecoverGame;
    public u8[] m_description;
    public CFilePath m_imageFilePath;
    public uint8 m_campaignIndex;
    public CFilePath m_mapFileName;
    public Option<GameCCacheHandles> m_cacheHandles;
    public bool m_miniSave;
    public GameEGameSpeed m_gameSpeed;
    public GameTDifficulty m_defaultDifficulty;
    public Option<GameCModPaths> m_modPaths;
}

// NNet.Game.SGameOptions
public  class GameSGameOptions
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
public  class GameSSlotDescription
{
    public GameCAllowedColors m_allowedColors;
    public CAllowedRaces m_allowedRaces;
    public GameCAllowedDifficulty m_allowedDifficulty;
    public GameCAllowedControls m_allowedControls;
    public CAllowedObserveTypes m_allowedObserveTypes;
    public GameCAllowedAIBuild m_allowedAIBuilds;
}

// NNet.Game.SGameDescription
public  class GameSGameDescription
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
public  class GameCRewardOverride
{
    public uint32 m_key;
    public GameCRewardArray m_rewards;
}

// NNet.Game.SLobbySlot
public  class GameSLobbySlot
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
    public uint32 m_trophyId;
    public GameCRewardOverrideArray m_rewardOverrides;
    public uint32 m_brutalPlusDifficulty;
    public GameCRetryMutationIndexArray m_retryMutationIndexes;
    public uint32 m_aCEnemyRace;
    public uint32 m_aCEnemyWaveType;
    public uint32 m_selectedCommanderPrestige;
}

// NNet.Game.SLobbyState
public  class GameSLobbyState
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
public  class GameSLobbySyncState
{
    public CUserInitialDataArray m_userInitialData;
    public GameSGameDescription m_gameDescription;
    public GameSLobbyState m_lobbyState;
}

// NNet.Game.SChatMessage
public  class GameSChatMessage
{
    public GameEMessageRecipient m_recipient;
    public GameCChatString m_string;
}

// NNet.Game.SPingMessage
public  class GameSPingMessage
{
    public GameEMessageRecipient m_recipient;
    public GameSPoint m_point;
}

// NNet.Game.SLoadingProgressMessage
public  class GameSLoadingProgressMessage
{
    public int32 m_progress;
}

// NNet.Game.SServerPingMessage
public  class GameSServerPingMessage
{
}

// NNet.Game.SReconnectNotifyMessage
public  class GameSReconnectNotifyMessage
{
    public EReconnectStatus m_status;
}

// NNet.Game.SSelectionDeltaSubgroup
public  class GameSSelectionDeltaSubgroup
{
    public GameTUnitLink m_unitLink;
    public GameTSubgroupPriority m_subgroupPriority;
    public GameTSubgroupPriority m_intraSubgroupPriority;
    public GameTSelectionCount m_count;
}

// NNet.Game.SSelectionDelta
public  class GameSSelectionDelta
{
    public GameTSubgroupIndex m_subgroupIndex;
    public GameSSelectionMask m_removeMask;
    public GameSSelectionDeltaSubgroup[] m_addSubgroups;
    public GameTUnitTag[] m_addUnitTags;
}

// NNet.Game.SSelectionSyncData
public  class GameSSelectionSyncData
{
    public GameTSelectionCount m_count;
    public GameTSubgroupCount m_subgroupCount;
    public GameTSubgroupIndex m_activeSubgroupIndex;
    public GameTSyncChecksum m_unitTagsChecksum;
    public GameTSyncChecksum m_subgroupIndicesChecksum;
    public GameTSyncChecksum m_subgroupsChecksum;
}

// NNet.Game.SSessionSyncInfo
public  class GameSSessionSyncInfo
{
    public GameTSyncChecksum[] m_checksums;
}

// NNet.Game.SGameSyncInfo
public  class GameSGameSyncInfo
{
    public GameTSyncChecksum[] m_checksums;
}

// NNet.Replay.SInitData
public  class ReplaySInitData
{
    public GameSLobbySyncState m_syncLobbyState;
}

// NNet.Replay.SGameUserId
public  class ReplaySGameUserId
{
    public i64 m_userId;
}

// NNet.EObserve
public abstract record class EObserve { }
// e_none
public record class EObserve_e_none() : EObserve;
// e_spectator
public record class EObserve_e_spectator() : EObserve;
// e_referee
public record class EObserve_e_referee() : EObserve;

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
// e_userTimeout
public record class ELeaveReason_e_userTimeout() : ELeaveReason;
// e_userDisconnected
public record class ELeaveReason_e_userDisconnected() : ELeaveReason;
// e_unrecoverable
public record class ELeaveReason_e_unrecoverable() : ELeaveReason;
// e_userCatchupDesynced
public record class ELeaveReason_e_userCatchupDesynced() : ELeaveReason;
// e_takeCommandDropped
public record class ELeaveReason_e_takeCommandDropped() : ELeaveReason;

// NNet.EReconnectStatus
public abstract record class EReconnectStatus { }
// e_connected
public record class EReconnectStatus_e_connected() : EReconnectStatus;
// e_reconnected
public record class EReconnectStatus_e_reconnected() : EReconnectStatus;
// e_disconnected
public record class EReconnectStatus_e_disconnected() : EReconnectStatus;
// e_unrecoverable
public record class EReconnectStatus_e_unrecoverable() : EReconnectStatus;

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
public record class GameEDebug_e_debug(GameSPickMapTagEvent Value) : GameEDebug;
// e_notDebug
public record class GameEDebug_e_notDebug(GameSSetLobbySlotEvent Value) : GameEDebug;

// NNet.Game.EHijackMethod
public abstract record class GameEHijackMethod { }
// e_recover
public record class GameEHijackMethod_e_recover() : GameEHijackMethod;
// e_takeCommand
public record class GameEHijackMethod_e_takeCommand() : GameEHijackMethod;

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
// e_userOptions
public record class GameEEventId_e_userOptions(GameSUserOptionsEvent Value) : GameEEventId;
// e_pickMapTag
public record class GameEEventId_e_pickMapTag(GameSPickMapTagEvent Value) : GameEEventId;
// e_turn
public record class GameEEventId_e_turn(GameSTurnEvent Value) : GameEEventId;
// e_bankFile
public record class GameEEventId_e_bankFile(GameSBankFileEvent Value) : GameEEventId;
// e_bankSection
public record class GameEEventId_e_bankSection(GameSBankSectionEvent Value) : GameEEventId;
// e_bankKey
public record class GameEEventId_e_bankKey(GameSBankKeyEvent Value) : GameEEventId;
// e_bankValue
public record class GameEEventId_e_bankValue(GameSBankValueEvent Value) : GameEEventId;
// e_bankSignature
public record class GameEEventId_e_bankSignature(GameSBankSignatureEvent Value) : GameEEventId;
// e_cameraSave
public record class GameEEventId_e_cameraSave(GameSCameraSaveEvent Value) : GameEEventId;
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
// e_replayJump
public record class GameEEventId_e_replayJump(GameSReplayJumpEvent Value) : GameEEventId;
// e_saveGame
public record class GameEEventId_e_saveGame(GameSSaveGameEvent Value) : GameEEventId;
// e_saveGameDone
public record class GameEEventId_e_saveGameDone(GameSSaveGameDoneEvent Value) : GameEEventId;
// e_loadGameDone
public record class GameEEventId_e_loadGameDone(GameSLoadGameDoneEvent Value) : GameEEventId;
// e_sessionCheat
public record class GameEEventId_e_sessionCheat(GameSSessionCheatEvent Value) : GameEEventId;
// e_commandManagerReset
public record class GameEEventId_e_commandManagerReset(GameSCommandManagerResetEvent Value) : GameEEventId;
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
// e_triggerPing
public record class GameEEventId_e_triggerPing(GameSTriggerPingEvent Value) : GameEEventId;
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
// e_hijackReplaySession
public record class GameEEventId_e_hijackReplaySession(GameSHijackReplaySessionEvent Value) : GameEEventId;
// e_hijackReplayGame
public record class GameEEventId_e_hijackReplayGame(GameSHijackReplayGameEvent Value) : GameEEventId;
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
// e_triggerMouseMoved
public record class GameEEventId_e_triggerMouseMoved(GameSTriggerMouseMovedEvent Value) : GameEEventId;
// e_achievementAwarded
public record class GameEEventId_e_achievementAwarded(GameSAchievementAwardedEvent Value) : GameEEventId;
// e_triggerHotkeyPressed
public record class GameEEventId_e_triggerHotkeyPressed(GameSTriggerHotkeyPressedEvent Value) : GameEEventId;
// e_triggerTargetModeUpdate
public record class GameEEventId_e_triggerTargetModeUpdate(GameSTriggerTargetModeUpdateEvent Value) : GameEEventId;
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
// e_triggerCommandError
public record class GameEEventId_e_triggerCommandError(GameSTriggerCommandErrorEvent Value) : GameEEventId;
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
// e_triggerMouseWheel
public record class GameEEventId_e_triggerMouseWheel(GameSTriggerMouseWheelEvent Value) : GameEEventId;
// e_triggerPurchasePanelSelectedPurchaseItemChanged
public record class GameEEventId_e_triggerPurchasePanelSelectedPurchaseItemChanged(GameSTriggerPurchasePanelSelectedPurchaseItemChangedEvent Value) : GameEEventId;
// e_triggerPurchasePanelSelectedPurchaseCategoryChanged
public record class GameEEventId_e_triggerPurchasePanelSelectedPurchaseCategoryChanged(GameSTriggerPurchasePanelSelectedPurchaseCategoryChangedEvent Value) : GameEEventId;
// e_triggerButtonPressed
public record class GameEEventId_e_triggerButtonPressed(GameSTriggerButtonPressedEvent Value) : GameEEventId;
// e_triggerGameCreditsFinished
public record class GameEEventId_e_triggerGameCreditsFinished(GameSTriggerGameCreditsFinishedEvent Value) : GameEEventId;
// e_triggerCutsceneBookmarkFired
public record class GameEEventId_e_triggerCutsceneBookmarkFired(GameSTriggerCutsceneBookmarkFiredEvent Value) : GameEEventId;
// e_triggerCutsceneEndSceneFired
public record class GameEEventId_e_triggerCutsceneEndSceneFired(GameSTriggerCutsceneEndSceneFiredEvent Value) : GameEEventId;
// e_triggerCutsceneConversationLine
public record class GameEEventId_e_triggerCutsceneConversationLine(GameSTriggerCutsceneConversationLineEvent Value) : GameEEventId;
// e_triggerCutsceneConversationLineMissing
public record class GameEEventId_e_triggerCutsceneConversationLineMissing(GameSTriggerCutsceneConversationLineMissingEvent Value) : GameEEventId;
// e_gameUserLeave
public record class GameEEventId_e_gameUserLeave(GameSGameUserLeaveEvent Value) : GameEEventId;
// e_gameUserJoin
public record class GameEEventId_e_gameUserJoin(GameSGameUserJoinEvent Value) : GameEEventId;
// e_commandManagerState
public record class GameEEventId_e_commandManagerState(GameSCommandManagerStateEvent Value) : GameEEventId;
// e_cmdUpdateTargetPoint
public record class GameEEventId_e_cmdUpdateTargetPoint(GameSCmdUpdateTargetPointEvent Value) : GameEEventId;
// e_cmdUpdateTargetUnit
public record class GameEEventId_e_cmdUpdateTargetUnit(GameSCmdUpdateTargetUnitEvent Value) : GameEEventId;
// e_triggerAnimLengthQueryByName
public record class GameEEventId_e_triggerAnimLengthQueryByName(GameSTriggerAnimLengthQueryByNameEvent Value) : GameEEventId;
// e_triggerAnimLengthQueryByProps
public record class GameEEventId_e_triggerAnimLengthQueryByProps(GameSTriggerAnimLengthQueryByPropsEvent Value) : GameEEventId;
// e_triggerAnimOffset
public record class GameEEventId_e_triggerAnimOffset(GameSTriggerAnimOffsetEvent Value) : GameEEventId;
// e_catalogModify
public record class GameEEventId_e_catalogModify(GameSCatalogModifyEvent Value) : GameEEventId;
// e_heroTalentTreeSelected
public record class GameEEventId_e_heroTalentTreeSelected(GameSHeroTalentTreeSelectedEvent Value) : GameEEventId;
// e_triggerProfilerLoggingFinished
public record class GameEEventId_e_triggerProfilerLoggingFinished(GameSTriggerProfilerLoggingFinishedEvent Value) : GameEEventId;
// e_heroTalentTreeSelectionPanelToggled
public record class GameEEventId_e_heroTalentTreeSelectionPanelToggled(GameSHeroTalentTreeSelectionPanelToggledEvent Value) : GameEEventId;
// e_muteUserChanged
public record class GameEEventId_e_muteUserChanged(GameSMuteChatEvent Value) : GameEEventId;
// e_convertToReplaySession
public record class GameEEventId_e_convertToReplaySession(GameSConvertToReplaySessionEvent Value) : GameEEventId;
// e_setSyncLoadingTime
public record class GameEEventId_e_setSyncLoadingTime(GameSSetSyncLoadingTimeEvent Value) : GameEEventId;
// e_setSyncPlayingTime
public record class GameEEventId_e_setSyncPlayingTime(GameSSetSyncPlayingTimeEvent Value) : GameEEventId;
// e_peerSetSyncLoadingTime
public record class GameEEventId_e_peerSetSyncLoadingTime(GameSPeerSetSyncLoadingTimeEvent Value) : GameEEventId;
// e_peerSetSyncPlayingTime
public record class GameEEventId_e_peerSetSyncPlayingTime(GameSPeerSetSyncPlayingTimeEvent Value) : GameEEventId;

// NNet.Game.ECommandManagerState
public abstract record class GameECommandManagerState { }
// e_fireDone
public record class GameECommandManagerState_e_fireDone() : GameECommandManagerState;
// e_fireOnce
public record class GameECommandManagerState_e_fireOnce() : GameECommandManagerState;
// e_fireMany
public record class GameECommandManagerState_e_fireMany() : GameECommandManagerState;

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
// e_map
public record class GameEGameLaunch_e_map() : GameEGameLaunch;
// e_replay
public record class GameEGameLaunch_e_replay() : GameEGameLaunch;
// e_save
public record class GameEGameLaunch_e_save() : GameEGameLaunch;
// e_transition
public record class GameEGameLaunch_e_transition() : GameEGameLaunch;
// e_serverReplay
public record class GameEGameLaunch_e_serverReplay() : GameEGameLaunch;

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
// e_observers
public record class GameEMessageRecipient_e_observers() : GameEMessageRecipient;

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
// e_reconnectNotify
public record class GameEMessageId_e_reconnectNotify(GameSReconnectNotifyMessage Value) : GameEMessageId;

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
// e_setAndSteal
public record class GameEControlGroupUpdate_e_setAndSteal() : GameEControlGroupUpdate;
// e_appendAndSteal
public record class GameEControlGroupUpdate_e_appendAndSteal() : GameEControlGroupUpdate;

// NNet.TRaceId
public partial class TRaceId
{
    public long Value;
}

// NNet.TRaceCount
public partial class TRaceCount
{
    public long Value;
}

// NNet.int8
public partial class int8
{
    public long Value;
}

// NNet.int16
public partial class int16
{
    public long Value;
}

// NNet.int32
public partial class int32
{
    public long Value;
}

// NNet.int64
public partial class int64
{
    public long Value;
}

// NNet.uint8
public partial class uint8
{
    public long Value;
}

// NNet.uint16
public partial class uint16
{
    public long Value;
}

// NNet.uint32
public partial class uint32
{
    public long Value;
}

// NNet.uint64
public partial class uint64
{
    public long Value;
}

// NNet.uint6
public partial class uint6
{
    public long Value;
}

// NNet.uint14
public partial class uint14
{
    public long Value;
}

// NNet.uint22
public partial class uint22
{
    public long Value;
}

// NNet.TUserId
public partial class TUserId
{
    public long Value;
}

// NNet.TUserCount
public partial class TUserCount
{
    public long Value;
}

// NNet.Game.TColorId
public partial class GameTColorId
{
    public long Value;
}

// NNet.Game.TColorCount
public partial class GameTColorCount
{
    public long Value;
}

// NNet.Game.TFixedInt
public partial class GameTFixedInt
{
    public long Value;
}

// NNet.Game.TFixedUInt
public partial class GameTFixedUInt
{
    public long Value;
}

// NNet.Game.TMapCoordFixedBits
public partial class GameTMapCoordFixedBits
{
    public long Value;
}

// NNet.Game.TUICoordX
public partial class GameTUICoordX
{
    public long Value;
}

// NNet.Game.TUICoordY
public partial class GameTUICoordY
{
    public long Value;
}

// NNet.Game.TDifficulty
public partial class GameTDifficulty
{
    public long Value;
}

// NNet.Game.TAIBuild
public partial class GameTAIBuild
{
    public long Value;
}

// NNet.Game.EClientDebugFlags
public partial class GameEClientDebugFlags
{
    public long Value;
}

// NNet.Game.TControlId
public partial class GameTControlId
{
    public long Value;
}

// NNet.Game.TControlCount
public partial class GameTControlCount
{
    public long Value;
}

// NNet.Game.TLobbySlotCount
public partial class GameTLobbySlotCount
{
    public long Value;
}

// NNet.Game.TLobbySlotId
public partial class GameTLobbySlotId
{
    public long Value;
}

// NNet.Game.TPlayerId
public partial class GameTPlayerId
{
    public long Value;
}

// NNet.Game.TPlayerCount
public partial class GameTPlayerCount
{
    public long Value;
}

// NNet.Game.TSelectionCount
public partial class GameTSelectionCount
{
    public long Value;
}

// NNet.Game.TSelectionIndex
public partial class GameTSelectionIndex
{
    public long Value;
}

// NNet.Game.TSubgroupPriority
public partial class GameTSubgroupPriority
{
    public long Value;
}

// NNet.Game.TSubgroupCount
public partial class GameTSubgroupCount
{
    public long Value;
}

// NNet.Game.TSubgroupIndex
public partial class GameTSubgroupIndex
{
    public long Value;
}

// NNet.Game.TControlGroupCount
public partial class GameTControlGroupCount
{
    public long Value;
}

// NNet.Game.TControlGroupIndex
public partial class GameTControlGroupIndex
{
    public long Value;
}

// NNet.Game.TControlGroupId
public partial class GameTControlGroupId
{
    public long Value;
}

// NNet.Game.TTeamId
public partial class GameTTeamId
{
    public long Value;
}

// NNet.Game.TTeamCount
public partial class GameTTeamCount
{
    public long Value;
}

// NNet.CAllowedRaces
public  class CAllowedRaces
{
    public byte[] Value;
}

// NNet.CAllowedObserveTypes
public  class CAllowedObserveTypes
{
    public byte[] Value;
}

// NNet.Game.CAllowedColors
public  class GameCAllowedColors
{
    public byte[] Value;
}

// NNet.Game.CAllowedDifficulty
public  class GameCAllowedDifficulty
{
    public byte[] Value;
}

// NNet.Game.CAllowedAIBuild
public  class GameCAllowedAIBuild
{
    public byte[] Value;
}

// NNet.Game.CAllowedControls
public  class GameCAllowedControls
{
    public byte[] Value;
}

// NNet.Game.SelectionMaskType
public  class GameSelectionMaskType
{
    public byte[] Value;
}

// NNet.Game.TQueryID
public  class GameTQueryID
{
    public uint16 Value;
}

// NNet.Game.c_invalidQueryId
public  class Gamec_invalidQueryId
{
    public uint16 Value;
}

// NNet.Game.TAchievementLink
public  class GameTAchievementLink
{
    public uint16 Value;
}

// NNet.Game.TAchievementTermLink
public  class GameTAchievementTermLink
{
    public uint16 Value;
}

// NNet.Game.TButtonLink
public  class GameTButtonLink
{
    public uint16 Value;
}

// NNet.Game.TUnitLink
public  class GameTUnitLink
{
    public uint16 Value;
}

// NNet.Game.TUnitTag
public  class GameTUnitTag
{
    public uint32 Value;
}

// NNet.Game.TTriggerThreadTag
public  class GameTTriggerThreadTag
{
    public uint32 Value;
}

// NNet.Game.TTriggerSoundTag
public  class GameTTriggerSoundTag
{
    public uint32 Value;
}

// NNet.Game.TAbilLink
public  class GameTAbilLink
{
    public uint16 Value;
}

// NNet.Game.TFixedBits
public  class GameTFixedBits
{
    public int32 Value;
}

// NNet.Game.TFixedMiniBitsUnsigned
public  class GameTFixedMiniBitsUnsigned
{
    public uint16 Value;
}

// NNet.Game.TFixedMiniBitsSigned
public  class GameTFixedMiniBitsSigned
{
    public int16 Value;
}

// NNet.Game.TPlayerLogoIndex
public  class GameTPlayerLogoIndex
{
    public uint32 Value;
}

// NNet.Game.c_maxPlayerLogoIndex
public  class Gamec_maxPlayerLogoIndex
{
    public GameTPlayerLogoIndex Value;
}

// NNet.Game.THeroLink
public  class GameTHeroLink
{
    public uint16 Value;
}

// NNet.Game.THandicap
public  class GameTHandicap
{
    public uint32 Value;
}

// NNet.Game.TReward
public  class GameTReward
{
    public uint32 Value;
}

// NNet.Game.TLicense
public  class GameTLicense
{
    public uint32 Value;
}

// NNet.Game.TSyncChecksum
public  class GameTSyncChecksum
{
    public uint32 Value;
}

// NNet.Game.TSyncValue
public  class GameTSyncValue
{
    public uint16 Value;
}

// NNet.Game.c_ignoreSyncValue
public  class Gamec_ignoreSyncValue
{
    public GameTSyncValue Value;
}

// NNet.CUserInitialDataArray
public  class CUserInitialDataArray
{
    public SUserInitialData[] Value;
}

// NNet.Game.CPlayerDetailsArray
public  class GameCPlayerDetailsArray
{
    public GameSPlayerDetails[] Value;
}

// NNet.Game.CModPaths
public  class GameCModPaths
{
    public CFilePath[] Value;
}

// NNet.Game.CCacheHandles
public  class GameCCacheHandles
{
    public GameCCacheHandle[] Value;
}

// NNet.Game.SSlotDescriptions
public  class GameSSlotDescriptions
{
    public GameSSlotDescription[] Value;
}

// NNet.Game.CArtifactArray
public  class GameCArtifactArray
{
    public CArtifactHandle[] Value;
}

// NNet.Game.CCommanderMasteryTalentArray
public  class GameCCommanderMasteryTalentArray
{
    public uint32[] Value;
}

// NNet.Game.CRetryMutationIndexArray
public  class GameCRetryMutationIndexArray
{
    public uint32[] Value;
}

// NNet.Game.CRewardArray
public  class GameCRewardArray
{
    public GameTReward[] Value;
}

// NNet.Game.CRewardOverrideArray
public  class GameCRewardOverrideArray
{
    public GameCRewardOverride[] Value;
}

// NNet.Game.CLicenseArray
public  class GameCLicenseArray
{
    public GameTLicense[] Value;
}

// NNet.Game.CLobbySlotArray
public  class GameCLobbySlotArray
{
    public GameSLobbySlot[] Value;
}

// NNet.Game.SelectionIndexArrayType
public  class GameSelectionIndexArrayType
{
    public GameTSelectionIndex[] Value;
}

// NNet.CFilePath
public  class CFilePath
{
    public byte[] Value;
}

// NNet.CUserName
public  class CUserName
{
    public byte[] Value;
}

// NNet.CClanTag
public  class CClanTag
{
    public byte[] Value;
}

// NNet.CHeroHandle
public  class CHeroHandle
{
    public byte[] Value;
}

// NNet.CSkinHandle
public  class CSkinHandle
{
    public byte[] Value;
}

// NNet.CMountHandle
public  class CMountHandle
{
    public byte[] Value;
}

// NNet.CArtifactHandle
public  class CArtifactHandle
{
    public byte[] Value;
}

// NNet.CToonHandle
public  class CToonHandle
{
    public byte[] Value;
}

// NNet.CCommanderHandle
public  class CCommanderHandle
{
    public byte[] Value;
}

// NNet.Game.CCheatString
public  class GameCCheatString
{
    public byte[] Value;
}

// NNet.Game.CTriggerChatMessageString
public  class GameCTriggerChatMessageString
{
    public byte[] Value;
}

// NNet.Game.CGameCacheName
public  class GameCGameCacheName
{
    public byte[] Value;
}

// NNet.Game.CAuthorName
public  class GameCAuthorName
{
    public byte[] Value;
}

// NNet.Game.CChatString
public  class GameCChatString
{
    public byte[] Value;
}

// NNet.CCacheHandle
public  class CCacheHandle
{
    public byte[] Value;
}

// NNet.Game.CCacheHandle
public  class GameCCacheHandle
{
    public byte[] Value;
}

