using Sc2ReplayAnalyzer.Decoder.Events.GameEvents;
using Sc2ReplayAnalyzer.Json.BitPackedProtocolDefinitions;


namespace Sc2ReplayAnalyzer.Decoder.Parser;

internal static partial class Parse
{
    public static GameEvents GameEvents(IReadOnlyList<GameEventTriplet> gameEventsData)
    {
        List<GameEvent> gameevents = new();

        foreach (var gameEventData in gameEventsData)
        {
            GameEvent gameEvent = GetGameEvent(gameEventData);
            GameEvent detailEvent = gameEvent.EventId switch
            {
                GameEEventId_e_bankFile(var value) => GetSBankFileEvent(value, gameEvent),
                GameEEventId_e_bankKey(var value) => GetSBankKeyEvent(value, gameEvent),
                GameEEventId_e_bankSection(var value) => GetSBankSectionEvent(value, gameEvent),
                GameEEventId_e_bankSignature(var value) => GetSBankSignatureEvent(value, gameEvent),
                GameEEventId_e_bankValue(var value) => GetSBankValueEvent(value, gameEvent),
                GameEEventId_e_cameraUpdate(var value) => GetSCameraUpdateEvent(value, gameEvent),
                GameEEventId_e_cmd(var value) => GetSCmdEvent(value, gameEvent),
                GameEEventId_e_cmdUpdateTargetPoint(var value) => GetSCmdUpdateTargetPointEvent(value, gameEvent),
                GameEEventId_e_commandManagerState(var value) => GetSCommandManagerStateEvent(value, gameEvent),
                GameEEventId_e_controlGroupUpdate(var value) => GetSControlGroupUpdateEvent(value, gameEvent),
                GameEEventId_e_gameUserLeave(var value) => GetSGameUserLeaveEvent(value, gameEvent),
                GameEEventId_e_selectionDelta(var value) => GetSSelectionDeltaEvent(value, gameEvent),
                GameEEventId_e_setSyncLoadingTime(var value) => GetSSetSyncLoadingTimeEvent(value, gameEvent),
                GameEEventId_e_setSyncPlayingTime(var value) => GetSSetSyncPlayingTimeEvent(value, gameEvent),
                GameEEventId_e_triggerDialogControl(var value) => GetSTriggerDialogControlEvent(value, gameEvent),
                GameEEventId_e_triggerPing(var value) => GetSTriggerPingEvent(value, gameEvent),
                GameEEventId_e_triggerSoundLengthSync(var value) => new STriggerSoundLengthSyncEvent(gameEvent),
                GameEEventId_e_userFinishedLoadingSync(var value) => new SUserFinishedLoadingSyncEvent(gameEvent),
                GameEEventId_e_userOptions(var value) => GetSUserOptionsEvent(value, gameEvent),
                GameEEventId_e_cmdUpdateTargetUnit(var value) => GetSCmdUpdateTargetUnitEvent(value, gameEvent),
                GameEEventId_e_triggerKeyPressed(var value) => GetSTriggerKeyPressedEvent(value, gameEvent),
                GameEEventId_e_unitClick(var value) => GetSUnitClickEvent(value, gameEvent),
                GameEEventId_e_decrementGameTimeRemaining(var value) => GetSDecrementGameTimeRemainingEvent(value, gameEvent),
                GameEEventId_e_triggerChatMessage(var value) => GetSTriggerChatMessageEvent(value, gameEvent),
                GameEEventId_e_triggerMouseClicked(var value) => GetSTriggerMouseClickedEvent(value, gameEvent),
                GameEEventId_e_triggerSoundtrackDone(var value) => GetSTriggerSoundtrackDoneEvent(value, gameEvent),
                GameEEventId_e_cameraSave(var value) => GetSCameraSaveEvent(value, gameEvent),
                GameEEventId_e_triggerCutsceneBookmarkFired(var value) => GetSTriggerCutsceneBookmarkFiredEvent(value, gameEvent),
                GameEEventId_e_triggerCutsceneEndSceneFired(var value) => GetSTriggerCutsceneEndSceneFiredEvent(value, gameEvent),
                GameEEventId_e_triggerSoundLengthQuery(var value) => GetSTriggerSoundLengthQueryEvent(value, gameEvent),
                GameEEventId_e_triggerSoundOffset(var value) => GetSTriggerSoundOffsetEvent(value, gameEvent),
                GameEEventId_e_triggerTargetModeUpdate(var value) => GetSTriggerTargetModeUpdateEvent(value, gameEvent),
                GameEEventId_e_triggerTransmissionComplete(var value) => GetSTriggerTransmissionCompleteEvent(value, gameEvent),
                GameEEventId_e_achievementAwarded(var value) => GetSAchievementAwardedEvent(value, gameEvent),
                GameEEventId_e_triggerTransmissionOffset(var value) => GetSTriggerTransmissionOffsetEvent(value, gameEvent),
                GameEEventId_e_triggerButtonPressed(var value) => GetSTriggerButtonPressedEvent(value, gameEvent),
                GameEEventId_e_triggerGameMenuItemSelected(var value) => GetSTriggerGameMenuItemSelectedEvent(value, gameEvent),
                GameEEventId_e_triggerMouseMoved(var value) => GetSTriggerMouseMovedEvent(value, gameEvent),

                var enclosedEvent => null
            };

            gameevents.Add(detailEvent);
        }

        return new GameEvents(gameevents);
    }

    private static GameEvent GetGameEvent(GameEventTriplet gameEventData)
    {
        int userId = (int)gameEventData.UserID;
        GameEEventId eventId = gameEventData.EventID;
        string type = gameEventData.EventID.GetType().Name;
        long gameloop = gameEventData.Delta;

        return new GameEvent(userId, eventId, type, gameloop);
    }

    private static STriggerDialogControlEvent GetSTriggerDialogControlEvent(GameSTriggerDialogControlEvent sTriggerDialogControlEvent, GameEvent gameEvent)
    {
        long m_controlId = sTriggerDialogControlEvent.m_controlId.Value;
        int? mouseButton = (int?)((sTriggerDialogControlEvent.m_eventData as MouseButton)?.Value?.Value);
        string? textChanged = (sTriggerDialogControlEvent.m_eventData as TextChanged)?.Value?.Value.ReadStringBytes();
        long m_eventType = sTriggerDialogControlEvent.m_eventType.Value;
        return new STriggerDialogControlEvent(gameEvent, m_controlId, mouseButton, textChanged, m_eventType);
    }

    private static SSetSyncPlayingTimeEvent GetSSetSyncPlayingTimeEvent(GameSSetSyncPlayingTimeEvent sSetSyncPlayingTimeEvent, GameEvent gameEvent)
    {
        int m_syncTime = (int)sSetSyncPlayingTimeEvent.m_syncTime.Value;

        return new SSetSyncPlayingTimeEvent(gameEvent, m_syncTime);
    }

    private static SSetSyncLoadingTimeEvent GetSSetSyncLoadingTimeEvent(GameSSetSyncLoadingTimeEvent sSetSyncLoadingTimeEvent, GameEvent gameEvent)
    {
        int m_syncTime = (int)sSetSyncLoadingTimeEvent.m_syncTime.Value;
        return new SSetSyncLoadingTimeEvent(gameEvent, m_syncTime);
    }

    private static SGameUserLeaveEvent GetSGameUserLeaveEvent(GameSGameUserLeaveEvent sGameUserLeaveEvent, GameEvent gameEvent)
    {
        string leaveReason = sGameUserLeaveEvent.m_leaveReason.GetKind();
        return new SGameUserLeaveEvent(gameEvent, leaveReason);
    }

    private static SControlGroupUpdateEvent GetSControlGroupUpdateEvent(GameSControlGroupUpdateEvent sControlGroupUpdateEvent, GameEvent gameEvent)
    {
        string controlGroupUpdate = sControlGroupUpdateEvent.m_controlGroupUpdate.GetKind();
        return new SControlGroupUpdateEvent(gameEvent, controlGroupUpdate);
    }

    private static SCommandManagerStateEvent GetSCommandManagerStateEvent(GameSCommandManagerStateEvent sCommandManagerStateEvent, GameEvent gameEvent)
    {
        string state = sCommandManagerStateEvent.m_state.GetKind();
        int sequence = (int)sCommandManagerStateEvent.m_sequence.DefaultIfNone();
        return new SCommandManagerStateEvent(gameEvent, state, sequence);
    }

    private static SCmdUpdateTargetPointEvent GetSCmdUpdateTargetPointEvent(GameSCmdUpdateTargetPointEvent sCmdUpdateTargetPointEvent, GameEvent gameEvent)
    {   
        var target = sCmdUpdateTargetPointEvent.m_target;

        var x = target.x.Value;
        var y = target.y.Value;
        var z = target.z.Value.Value;

        return new SCmdUpdateTargetPointEvent(gameEvent, x, y, z);
    }

    private static SBankValueEvent GetSBankValueEvent(GameSBankValueEvent sBankValueEvent, GameEvent gameEvent)
    {
        string data = sBankValueEvent.m_data.ReadStringBytes();
        string name = sBankValueEvent.m_name.ReadStringBytes();
        int type = (int)sBankValueEvent.m_type.Value;

        return new SBankValueEvent(gameEvent, name, data, type);
    }

    private static SBankSignatureEvent GetSBankSignatureEvent(GameSBankSignatureEvent sBankSignatureEvent, GameEvent gameEvent)
    {
        string toonHandle = sBankSignatureEvent.m_toonHandle.Value.ReadStringBytes();
        var signature = sBankSignatureEvent.m_signature.Select(x => (int)x.Value).ToList();

        return new SBankSignatureEvent(gameEvent, toonHandle, signature);
    }

    private static SBankSectionEvent GetSBankSectionEvent(GameSBankSectionEvent sBankSectionEvent, GameEvent gameEvent)
    {
        string name = sBankSectionEvent.m_name.ReadStringBytes();

        return new SBankSectionEvent(gameEvent, name);
    }

    private static SBankKeyEvent GetSBankKeyEvent(GameSBankKeyEvent sBankKeyEvent, GameEvent gameEvent)
    {
        string data = sBankKeyEvent.m_data.ReadStringBytes();
        string name = sBankKeyEvent.m_name.ReadStringBytes();
        int type = (int)sBankKeyEvent.m_type.Value;

        return new SBankKeyEvent(gameEvent, name, data, type);
    }

    private static SBankFileEvent GetSBankFileEvent(GameSBankFileEvent sBankFileEvent, GameEvent gameEvent)
    {
        string name = sBankFileEvent.m_name.ReadStringBytes();

        return new SBankFileEvent(gameEvent, name);
    }

    private static SCameraUpdateEvent GetSCameraUpdateEvent(GameSCameraUpdateEvent sCameraUpdateEvent, GameEvent gameEvent)
    {
        string? reason = "FIX"; //sCameraUpdateEvent.m_reason.;
        int? distance = (int?)(sCameraUpdateEvent.m_distance.DefaultIfNone()?.Value.Value);
        int? yaw = (int?)sCameraUpdateEvent.m_yaw.DefaultIfNone()?.Value.Value;
        int? pitch = (int?)sCameraUpdateEvent.m_pitch.DefaultIfNone()?.Value.Value;
        bool follow = sCameraUpdateEvent.m_follow;
        
        (long? targetX, long? targetY) = GetSCameraUpdateEventTarget(sCameraUpdateEvent);
        return new SCameraUpdateEvent(gameEvent, reason, distance, targetX, targetY, yaw, pitch, follow);
    }

    private static (long?, long?) GetSCameraUpdateEventTarget(GameSCameraUpdateEvent sCameraUpdateEvent)
    {
        if (sCameraUpdateEvent.m_target.HasValue)
        {
            var target = sCameraUpdateEvent.m_target.Value;

            var x = target.x.Value.Value;
            var y = target.y.Value.Value;
        }

        return (null, null);
    }

    private static SCmdEvent GetSCmdEvent(GameSCmdEvent gameSCmdEvent, GameEvent gameEvent)
    {
        int? unitGroup = (int?)(gameSCmdEvent.m_unitGroup.DefaultIfNone()?.Value);
        (int abilLink, int abilCmdIndex, string? abilCmdData) = GetAbil(gameSCmdEvent);
        int cmdFalgs = (int)gameSCmdEvent.m_cmdFlags;
        int sequence = (int)gameSCmdEvent.m_sequence;
        int? otherUnit = (int?)(gameSCmdEvent.m_otherUnit.DefaultIfNone()?.Value.Value);
        (long? targetX, long? targetY, long? targetZ) = GetSCmdEventTarget(gameSCmdEvent);
        return new SCmdEvent(gameEvent, unitGroup, abilLink, abilCmdIndex, abilCmdData, targetX, targetY, targetZ, cmdFalgs, sequence, otherUnit);
    }

    private static (long?, long?, long?) GetSCmdEventTarget(GameSCmdEvent gameSCmdEvent)
    {
        var data = gameSCmdEvent.m_data;

        if (data is not null)
        {
            if (data is TargetPoint targetPoint)
            {
                var cords = targetPoint.Value;

                long x = cords.x.Value;
                long y = cords.y.Value;
                long z = cords.z.Value.Value;
                return (x, y, z);
            }
        }

        return (null, null, null);
    }

    private static (int, int, string?) GetAbil(GameSCmdEvent gameSCmdEvent)
    {
        if (gameSCmdEvent.m_abil.HasValue)
        {
            var abil = gameSCmdEvent.m_abil.Value;

            int link = (int)abil.m_abilLink.Value.Value;
            int cmdIndex = (int)abil.m_abilCmdIndex;
            string? cmdData = "FIX"; //abil.m_abilCmdData.DefaultIfNone()?

            return (link, cmdIndex, cmdData);
        }
        return (0, 0, null);
    }

    private static SSelectionDeltaEvent GetSSelectionDeltaEvent(GameSSelectionDeltaEvent gameSSelectionDelta, GameEvent gameEvent)
    {
        var delta = GetSelectionDeltaEventDelta(gameSSelectionDelta);
        int controlGroupId = (int)gameSSelectionDelta.m_controlGroupId.Value;

        return new SSelectionDeltaEvent(gameEvent, delta, controlGroupId);
    }

    private static SelectionDeltaEventDelta GetSelectionDeltaEventDelta(GameSSelectionDeltaEvent gameSSelectionDelta)
    {
        var delta = gameSSelectionDelta.m_delta;

        if (delta is not null)
        {
            List<int> addUnitTags = delta.m_addUnitTags.Select(x => (int)x.Value.Value).ToList();
            List<SelectionDeltaEventDeltaSubGroup> subgroups = new();
            List<int> zeroIndices = new();

            if (delta.m_addSubgroups is { }subGroupList)
            {
                foreach (var subGroup in subGroupList)
                {
                    subgroups.Add(new SelectionDeltaEventDeltaSubGroup(
                            (int)subGroup.m_unitLink.Value.Value,
                            (int)subGroup.m_subgroupPriority.Value,
                            (int)subGroup.m_count.Value,
                            (int)subGroup.m_intraSubgroupPriority.Value
                        ));
                }
            }

            if (delta.m_removeMask is { } removeMask && removeMask is ZeroIndices zeroIndicies)
            {
                zeroIndices = [.. zeroIndicies.Value.Value.Select(x => (int)x.Value)];
            }

            int subgroupIndex = (int)delta.m_subgroupIndex.Value;

            return new SelectionDeltaEventDelta(addUnitTags, subgroups, zeroIndices, subgroupIndex);
        }

        return new SelectionDeltaEventDelta(new List<int>(), new List<SelectionDeltaEventDeltaSubGroup>(), new List<int>(), 0);
    }

    private static STriggerPingEvent GetSTriggerPingEvent(GameSTriggerPingEvent gameSTriggerPingEvent, GameEvent gameEvent)
    {
        bool pingedMinimap = gameSTriggerPingEvent.m_pingedMinimap;
        int unitLink = (int)gameSTriggerPingEvent.m_unitLink.Value.Value;
        bool unitIsUnderConstruction = gameSTriggerPingEvent.m_unitIsUnderConstruction;
        long option = gameSTriggerPingEvent.m_option.Value;
        int unit = (int)gameSTriggerPingEvent.m_unit.Value.Value;
        (long unitX, long unitY, long unitZ) = GetUnitPosition(gameSTriggerPingEvent);
        int? unitControlPlayerId = (int?)gameSTriggerPingEvent.m_unitControlPlayerId.Value?.Value;
        (long pointX, long pointY) = GetPoint(gameSTriggerPingEvent);
        int? unitUpkeepPlayerId = (int?)(gameSTriggerPingEvent.m_unitUpkeepPlayerId.DefaultIfNone()?.Value);

        return new STriggerPingEvent(gameEvent,
                                     pingedMinimap,
                                     unitLink,
                                     unitIsUnderConstruction,
                                     option,
                                     unit,
                                     unitX,
                                     unitY,
                                     unitZ,
                                     unitControlPlayerId,
                                     pointX,
                                     pointY,
                                     unitUpkeepPlayerId);
    }

    private static (long, long) GetPoint(GameSTriggerPingEvent gameSTriggerPingEvent)
    {
        if (gameSTriggerPingEvent.m_point is { })
        {
            var point = gameSTriggerPingEvent.m_point;

            long x = point.x.Value.Value;
            long y = point.y.Value.Value;

            return (x, y);
        }
        return (0, 0);
    }

    private static (long, long, long) GetUnitPosition(GameSTriggerPingEvent gameSTriggerPingEvent)
    {
        if (gameSTriggerPingEvent.m_unitPosition is { })
        {
            var pos = gameSTriggerPingEvent.m_unitPosition;

            long x = pos.x.Value;
            long y = pos.y.Value;
            long z = pos.z.Value.Value;

            return (x, y, z);
        }

        return (0, 0, 0);
    }

    private static SUserOptionsEvent GetSUserOptionsEvent(GameSUserOptionsEvent gameSUserOptionsEvent, GameEvent gameEvent)
    {
        bool testCheatsEnabled = gameSUserOptionsEvent.m_testCheatsEnabled;
        bool multiplayerCheatsEnabled = gameSUserOptionsEvent.m_multiplayerCheatsEnabled;
        bool gameFullyDownloaded = gameSUserOptionsEvent.m_gameFullyDownloaded;
        string hotkeyProfile = gameSUserOptionsEvent.m_hotkeyProfile.ReadStringBytes();
        bool useGalaxyAsserts = gameSUserOptionsEvent.m_useGalaxyAsserts;
        bool debugPauseEnabled = gameSUserOptionsEvent.m_debugPauseEnabled;
        bool cameraFollow = gameSUserOptionsEvent.m_cameraFollow;
        bool isMapToMapTransition = gameSUserOptionsEvent.m_isMapToMapTransition;
        int buildNum = (int)gameSUserOptionsEvent.m_buildNum.Value;
        int versionFlags = (int)gameSUserOptionsEvent.m_versionFlags.Value;
        bool developmentCheatsEnabled = gameSUserOptionsEvent.m_developmentCheatsEnabled;
        bool platformMac = gameSUserOptionsEvent.m_platformMac;
        int baseBuildNum = (int)gameSUserOptionsEvent.m_baseBuildNum.Value;
        bool syncChecksummingEnabled = gameSUserOptionsEvent.m_syncChecksummingEnabled;
        return new SUserOptionsEvent(gameEvent,
                                     testCheatsEnabled,
                                     multiplayerCheatsEnabled,
                                     gameFullyDownloaded,
                                     hotkeyProfile,
                                     useGalaxyAsserts,
                                     debugPauseEnabled,
                                     cameraFollow,
                                     isMapToMapTransition,
                                     buildNum,
                                     versionFlags,
                                     developmentCheatsEnabled,
                                     platformMac,
                                     baseBuildNum,
                                     syncChecksummingEnabled);
    }

    private static SCmdUpdateTargetUnitEvent GetSCmdUpdateTargetUnitEvent(GameSCmdUpdateTargetUnitEvent sCmdUpdateTargetUnitEvent, GameEvent gameEvent)
    {
        if (sCmdUpdateTargetUnitEvent.m_target is GameSCmdDataTargetUnit targetUnit)
        {
            int m_snapshotControlPlayerId = (int)(targetUnit.m_snapshotControlPlayerId.DefaultIfNone()?.Value);
            (long pointX, long pointY, long pointZ) = GetSnapshotPoint(targetUnit);
            int m_snapshotUpkeepPlayerId = (int)(targetUnit.m_snapshotUpkeepPlayerId.DefaultIfNone()?.Value);
            int m_timer = (int)targetUnit.m_timer.Value;
            int m_targetUnitFlags = (int)targetUnit.m_targetUnitFlags.Value;
            int m_snapshotUnitLink = (int)targetUnit.m_snapshotUnitLink.Value.Value;
            int m_tag = (int)targetUnit.m_tag.Value.Value;

            return new SCmdUpdateTargetUnitEvent(gameEvent, m_snapshotControlPlayerId, pointX, pointY, pointZ, m_snapshotUpkeepPlayerId, m_timer, m_targetUnitFlags, m_snapshotUnitLink,m_tag);
        }

        return new SCmdUpdateTargetUnitEvent(gameEvent,0,0,0,0,0,0,0,0,0);
    }

    private static (long, long, long) GetSnapshotPoint(GameSCmdDataTargetUnit targetUnit)
    {
        if (targetUnit.m_snapshotPoint is { })
        {
            var cords = targetUnit.m_snapshotPoint;

            return (cords.x.Value,cords.y.Value,cords.z.Value.Value);
        }

        return (0, 0, 0);
    }

    private static STriggerKeyPressedEvent GetSTriggerKeyPressedEvent(GameSTriggerKeyPressedEvent sTriggerKeyPressedEvent, GameEvent gameEvent)
    {
        int flags = (int)sTriggerKeyPressedEvent.m_flags.Value;
        int key = (int)sTriggerKeyPressedEvent.m_key.Value;

        return new STriggerKeyPressedEvent(gameEvent, flags, key);
    }

    private static SUnitClickEvent GetSUnitClickEvent(GameSUnitClickEvent sUnitClickEvent, GameEvent gameEvent)
    {
        int unitTag = (int)sUnitClickEvent.m_unitTag.Value.Value;

        return new SUnitClickEvent(gameEvent, unitTag);
    }

    private static SDecrementGameTimeRemainingEvent GetSDecrementGameTimeRemainingEvent(GameSDecrementGameTimeRemainingEvent sDecrementGameTimeRemainingEvent, GameEvent gameEvent)
    {
        int decerementSeconds = (int)sDecrementGameTimeRemainingEvent.m_decrementSeconds.Value;

        return new SDecrementGameTimeRemainingEvent(gameEvent, decerementSeconds);
    }

    private static STriggerChatMessageEvent GetSTriggerChatMessageEvent(GameSTriggerChatMessageEvent sTriggerChatMessageEvent, GameEvent gameEvent)
    {
        string chatMessage = sTriggerChatMessageEvent.m_chatMessage.Value.ReadStringBytes()
            ;
        return new STriggerChatMessageEvent(gameEvent, chatMessage);
    }

    private static STriggerMouseClickedEvent GetSTriggerMouseClickedEvent(GameSTriggerMouseClickedEvent sTriggerMouseClickedEvent, GameEvent gameEvent)
    {
        bool down = sTriggerMouseClickedEvent.m_down;
        int button = (int)sTriggerMouseClickedEvent.m_button.Value;
        int flags = (int)sTriggerMouseClickedEvent.m_flags.Value;
        (long posX, long posY) = GetPosUI(sTriggerMouseClickedEvent);
        return new STriggerMouseClickedEvent(gameEvent, down, button, flags, posX, posY);
    }

    private static (long posX, long posY) GetPosUI(GameSTriggerMouseClickedEvent sTriggerMouseClickedEvent)
    {
        if (sTriggerMouseClickedEvent.m_posUI is { })
        {
            var pos = sTriggerMouseClickedEvent.m_posUI;

            return (pos.x.Value, pos.y.Value);
        }

        return (0, 0);
    }

    private static SCameraSaveEvent GetSCameraSaveEvent(GameSCameraSaveEvent gameSCameraSaveEvent, GameEvent gameEvent)
    {
        int which = (int)gameSCameraSaveEvent.m_which;
        (long targetX, long targetY) = SCameraSaveEventTarget(gameSCameraSaveEvent);

        return new SCameraSaveEvent(gameEvent, which, targetX, targetY);
    }

    private static (long targetX, long targetY) SCameraSaveEventTarget(GameSCameraSaveEvent gameSCameraSaveEvent)
    {
        if (gameSCameraSaveEvent.m_target is { })
        {
            var target = gameSCameraSaveEvent.m_target;

            return (target.x.Value.Value, target.y.Value.Value);
        }

        return (0, 0);
    }

    private static STriggerSoundtrackDoneEvent GetSTriggerSoundtrackDoneEvent(GameSTriggerSoundtrackDoneEvent gameSTriggerMouseMovedEvent, GameEvent gameEvent)
    {
        int soundtrack = (int)gameSTriggerMouseMovedEvent.m_soundtrack.Value;

        return new STriggerSoundtrackDoneEvent(gameEvent, soundtrack);
    }

    private static STriggerCutsceneBookmarkFiredEvent GetSTriggerCutsceneBookmarkFiredEvent(GameSTriggerCutsceneBookmarkFiredEvent gameSTriggerCutsceneBookmarkFiredEvent, GameEvent gameEvent)
    {
        long m_cutsceneId = gameSTriggerCutsceneBookmarkFiredEvent.m_cutsceneId.Value;
        string m_bookmarkName = gameSTriggerCutsceneBookmarkFiredEvent.m_bookmarkName.ReadStringBytes();

        return new STriggerCutsceneBookmarkFiredEvent(gameEvent, m_cutsceneId, m_bookmarkName);
    }

    private static STriggerCutsceneEndSceneFiredEvent GetSTriggerCutsceneEndSceneFiredEvent(GameSTriggerCutsceneEndSceneFiredEvent gameSTriggerCutsceneEndSceneFiredEvent, GameEvent gameEvent)
    {
        long m_cutsceneId = gameSTriggerCutsceneEndSceneFiredEvent.m_cutsceneId.Value;

        return new STriggerCutsceneEndSceneFiredEvent(gameEvent, m_cutsceneId);
    }

    private static STriggerSoundLengthQueryEvent GetSTriggerSoundLengthQueryEvent(GameSTriggerSoundLengthQueryEvent gameSTriggerSoundLengthQueryEvent, GameEvent gameEvent)
    {
        long m_soundHash = gameSTriggerSoundLengthQueryEvent.m_soundHash.Value;
        int m_length = (int)gameSTriggerSoundLengthQueryEvent.m_length.Value;

        return new STriggerSoundLengthQueryEvent(gameEvent, m_soundHash, m_length);
    }

    private static STriggerSoundOffsetEvent GetSTriggerSoundOffsetEvent(GameSTriggerSoundOffsetEvent gameSTriggerSoundOffsetEvent, GameEvent gameEvent)
    {
        int m_sound = (int)gameSTriggerSoundOffsetEvent.m_sound.Value.Value;

        return new STriggerSoundOffsetEvent(gameEvent, m_sound);
    }

    private static STriggerTargetModeUpdateEvent GetSTriggerTargetModeUpdateEvent(GameSTriggerTargetModeUpdateEvent gameSTriggerTargetModeUpdateEvent, GameEvent gameEvent)
    {
        int m_abilCmdIndex = (int)gameSTriggerTargetModeUpdateEvent.m_abilCmdIndex;
        int m_abilLink = (int)gameSTriggerTargetModeUpdateEvent.m_abilLink.Value.Value;
        int m_state = (int)gameSTriggerTargetModeUpdateEvent.m_state.Value;

        return new STriggerTargetModeUpdateEvent(gameEvent, m_abilCmdIndex, m_abilLink, m_state);
    }

    private static STriggerTransmissionCompleteEvent GetSTriggerTransmissionCompleteEvent(GameSTriggerTransmissionCompleteEvent gameSTriggerTransmissionCompleteEvent , GameEvent gameEvent)
    {
        long transmissionId = gameSTriggerTransmissionCompleteEvent.m_transmissionId.Value;

        return new STriggerTransmissionCompleteEvent(gameEvent, transmissionId);
    }

    private static SAchievementAwardedEvent GetSAchievementAwardedEvent(GameSAchievementAwardedEvent gameSAchievementAwardedEvent, GameEvent gameEvent)
    {
        int m_achievementLink = (int)gameSAchievementAwardedEvent.m_achievementLink.Value.Value;
        return new SAchievementAwardedEvent(gameEvent, m_achievementLink);
    }

    private static STriggerTransmissionOffsetEvent GetSTriggerTransmissionOffsetEvent(GameSTriggerTransmissionOffsetEvent gameSTriggerTransmissionOffsetEvent, GameEvent gameEvent)
    {
        long m_transmissionId = (int)gameSTriggerTransmissionOffsetEvent.m_transmissionId.Value;
        long m_thread_tag = (int)gameSTriggerTransmissionOffsetEvent.m_thread.Value.Value;

        return new STriggerTransmissionOffsetEvent(gameEvent, m_transmissionId, m_thread_tag);
    }

    private static STriggerButtonPressedEvent GetSTriggerButtonPressedEvent(GameSTriggerButtonPressedEvent gameSTriggerButtonPressedEvent, GameEvent gameEvent)
    {
        int button = (int)gameSTriggerButtonPressedEvent.m_button.Value.Value;

        return new STriggerButtonPressedEvent(gameEvent, button);
    }

    private static STriggerGameMenuItemSelectedEvent GetSTriggerGameMenuItemSelectedEvent(GameSTriggerGameMenuItemSelectedEvent gameSTriggerGameMenuItemSelectedEvent, GameEvent gameEvent)
    {
        long m_gameMenuItemIndex = gameSTriggerGameMenuItemSelectedEvent.m_gameMenuItemIndex.Value;

        return new STriggerGameMenuItemSelectedEvent(gameEvent, m_gameMenuItemIndex);
    }

    private static STriggerMouseMovedEvent GetSTriggerMouseMovedEvent(GameSTriggerMouseMovedEvent gameSTriggerMouseMovedEvent, GameEvent gameEvent)
    {
        int m_flags = (int)gameSTriggerMouseMovedEvent.m_flags.Value;

        (long x, long y) = GetSTriggerMouseMovedEventPos(gameSTriggerMouseMovedEvent);
        return new STriggerMouseMovedEvent(gameEvent, m_flags, x, y);
    }

    private static (long x, long y) GetSTriggerMouseMovedEventPos(GameSTriggerMouseMovedEvent gameSTriggerMouseMovedEvent)
    {
        if (gameSTriggerMouseMovedEvent.m_posWorld is { })
        {
            var posWorld = gameSTriggerMouseMovedEvent.m_posWorld;

            if (posWorld is { })
            {
                return (posWorld.x.Value, posWorld.y.Value);
            }
        }
        return (0, 0);
    }
}

