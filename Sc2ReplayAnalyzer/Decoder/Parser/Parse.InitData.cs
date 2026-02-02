using Sc2ReplayAnalyzer.Decoder.Events.InitEvents;
using Sc2ReplayAnalyzer.Decoder.Models.InitData;
using Sc2ReplayAnalyzer.Json.BitPackedProtocolDefinitions;


namespace Sc2ReplayAnalyzer.Decoder.Parser;

internal static partial class Parse
{
    internal static InitData? InitData(ReplaySInitData initData)
    {
        if (initData.m_syncLobbyState is { } syncLobbyState)
        {
            List<UserInitialData> userInitialDatas = GetUserInitialData(syncLobbyState);
            LobbyState lobbyState = GetLobbyState(syncLobbyState);
            GameDescription gameDescription = GetGameDescription(syncLobbyState);
            return new InitData(userInitialDatas, lobbyState, gameDescription);
        }

        return null;
    }

    private static GameDescription GetGameDescription(GameSLobbySyncState syncLobbyState)
    {
        if (syncLobbyState.m_gameDescription is { } gameDescription)
        {
            int maxRaces = (int)gameDescription.m_maxRaces.Value;
            int maxTeams = (int)gameDescription.m_maxTeams.Value;
            bool hasExtensionMod = gameDescription.m_hasExtensionMod;
            int maxColors = (int)gameDescription.m_maxColors.Value;
            bool isBlizzardMap = gameDescription.m_isBlizzardMap;
            GameOptions gameOptions = GetGameOptions(gameDescription);
            int defaultDifficulty = (int)gameDescription.m_defaultDifficulty.Value;
            bool isCoopMode = gameDescription.m_isCoopMode;
            string mapFileName = gameDescription.m_mapFileName.Value.ReadStringBytes();
            int defaultAIBuild = (int)gameDescription.m_defaultAIBuild.Value;
            string gameType = gameDescription.m_gameType.GetKind();
            bool hasNonBlizzardExtensionMod = gameDescription.m_hasNonBlizzardExtensionMod;
            long randomValue = gameDescription.m_randomValue.Value;
            int maxObservers = (int)gameDescription.m_maxObservers.Value;
            bool isRealtimeMode = gameDescription.m_isRealtimeMode;
            int maxUsers = (int)gameDescription.m_maxUsers.Value;
            long modFileSyncChecksum = gameDescription.m_modFileSyncChecksum.Value.Value;
            long mapFileSyncChecksum = gameDescription.m_mapFileSyncChecksum.Value.Value;
            int maxPlayers = (int)gameDescription.m_maxPlayers.Value;
            List<string> cacheHandles = gameDescription.m_cacheHandles.Value.Select(x => x.Value.ReadStringBytes()).ToList();
            string gameSpeed = gameDescription.m_gameSpeed.GetKind();
            int maxControls = (int)gameDescription.m_maxControls.Value;
            string gameCacheName = gameDescription.m_gameCacheName.Value.ReadStringBytes();
            string mapAuthorName = gameDescription.m_mapAuthorName.Value.ReadStringBytes();
            List<SlotDescription> slotDescriptions = GetSlotDescriptions(gameDescription);
            int mapSizeY = (int)gameDescription.m_mapSizeY.Value;
            int mapSizeX = (int)gameDescription.m_mapSizeX.Value;
            bool isPremadeFFA = gameDescription.m_isPremadeFFA;
            return new GameDescription(
                maxRaces,
                maxTeams,
                hasExtensionMod,
                maxColors,
                isBlizzardMap,
                gameOptions,
                defaultDifficulty,
                isCoopMode,
                mapFileName,
                defaultAIBuild,
                gameType,
                hasNonBlizzardExtensionMod,
                randomValue,
                maxObservers,
                isRealtimeMode,
                maxUsers,
                modFileSyncChecksum,
                mapFileSyncChecksum,
                maxPlayers,
                cacheHandles,
                gameSpeed,
                maxControls,
                gameCacheName,
                mapAuthorName,
                slotDescriptions,
                mapSizeY,
                mapSizeX,
                isPremadeFFA
            );
        }

        throw new NotSupportedException("There must be a game description.");
    }

    private static GameOptions GetGameOptions(GameSGameDescription gameSGameDescription)
    {
        if (gameSGameDescription.m_gameOptions is { } gameOptions)
        {
            bool competitive = gameOptions.m_competitive;
            bool practice = gameOptions.m_practice;
            bool lockTeams = gameOptions.m_lockTeams;
            bool amm = gameOptions.m_amm;
            bool battleNet = gameOptions.m_battleNet;
            string fog = gameOptions.m_fog.GetKind();
            bool noVictoryOrDefeat = gameOptions.m_noVictoryOrDefeat;
            bool heroDuplicatesAllowed = gameOptions.m_heroDuplicatesAllowed;
            string userDifficulty = gameOptions.m_userDifficulty.GetKind();
            bool advancedSharedControl = gameOptions.m_advancedSharedControl;
            bool cooperative = gameOptions.m_cooperative;
            long clientDebugFlags = gameOptions.m_clientDebugFlags.Value;
            string observers = gameOptions.m_observers.GetKind();
            bool teamsTogether = gameOptions.m_teamsTogether;
            bool randomRaces = gameOptions.m_randomRaces;
            bool buildCoachEnabled = gameOptions.m_buildCoachEnabled;
            return new GameOptions(
                competitive,
                practice,
                lockTeams,
                amm,
                battleNet,
                fog,
                noVictoryOrDefeat,
                heroDuplicatesAllowed,
                userDifficulty,
                advancedSharedControl,
                cooperative,
                clientDebugFlags,
                observers,
                teamsTogether,
                randomRaces,
                buildCoachEnabled
            );
        }
        return new GameOptions(false, false, false, false, false, string.Empty, false, false, string.Empty, false, false, 0, string.Empty, false, false, false);
    }

    private static List<SlotDescription> GetSlotDescriptions(GameSGameDescription gameSGameDescription)
    {
        List<SlotDescription> slotDescscitions = new();
        if (gameSGameDescription.m_slotDescriptions is { } slotDescriptions)
        {
            foreach (var slotDesc in slotDescriptions.Value)
            {
                var allowedRaces = slotDesc.m_allowedRaces.Value.ReadStringBytes();
                var allowedColors = slotDesc.m_allowedColors.Value.ReadStringBytes();
                var allowedAIBuilds = slotDesc.m_allowedAIBuilds.Value.ReadStringBytes();
                var allowedDifficulty = slotDesc.m_allowedDifficulty.Value.ReadStringBytes();
                var allowedObserveTypes = slotDesc.m_allowedObserveTypes.Value.ReadStringBytes();
                var allowedControls = slotDesc.m_allowedControls.Value.ReadStringBytes();

                slotDescscitions.Add(new SlotDescription(
                    allowedRaces,
                    allowedColors,
                    allowedAIBuilds,
                    allowedDifficulty,
                    allowedObserveTypes,
                    allowedControls
                ));
            }
        }
        return slotDescscitions;
    }

    private static LobbyState GetLobbyState(GameSLobbySyncState gameSLobbySyncState)
    {
        if (gameSLobbySyncState.m_lobbyState is { } lobbyState)
        {
            int maxUser = (int)lobbyState.m_maxUsers.Value;
            List<Slot> slots = GetSlots(lobbyState);
            int defaultDifficulty = (int)lobbyState.m_defaultDifficulty.Value;
            bool isSinglePlayer = lobbyState.m_isSinglePlayer;
            string phase = lobbyState.m_phase.GetKind();
            int? hostUserId = (int?)(lobbyState.m_hostUserId.DefaultIfNone()?.Value);
            int maxObs = (int)lobbyState.m_maxObservers.Value;
            int defaultAIBuild = (int)lobbyState.m_defaultAIBuild.Value;
            int pickedMapTag = (int)lobbyState.m_pickedMapTag.Value;
            long randomSeed = lobbyState.m_randomSeed.Value;
            int gameDuration = (int)lobbyState.m_gameDuration.Value;
            return new LobbyState(maxUser,
                                  slots,
                                  defaultDifficulty,
                                  isSinglePlayer,
                                  phase,
                                  hostUserId,
                                  maxObs,
                                  defaultAIBuild,
                                  pickedMapTag,
                                  randomSeed,
                                  gameDuration);
        }
        return new LobbyState(0, new List<Slot>(), 0, false, string.Empty, 0, 0, 0, 0, 0, 0);
    }

    private static List<Slot> GetSlots(GameSLobbyState lobbyState)
    {
        List<Slot> slots = [];

        if (lobbyState.m_slots is { })
        {
            foreach (var lobbySlot in lobbyState.m_slots.Value)
            {
                int aCEnemyRace = (int)lobbySlot.m_aCEnemyRace.Value;
                string toonHandle = lobbySlot.m_toonHandle.Value.ReadStringBytes();
                List<RewardOverdrive> rewardOverrides = [.. lobbySlot.m_rewardOverrides.Value.Select(x => new RewardOverdrive(x.m_key.Value, x.m_rewards.Value.Select(x => x.Value.Value).ToList()))];
                int? userId = (int?)(lobbySlot.m_userId.DefaultIfNone()?.Value);
                string skin = lobbySlot.m_skin.Value.ReadStringBytes();
                List<int> commanderMasteryTalents = lobbySlot.m_commanderMasteryTalents.Value.Select(x => (int)x.Value).ToList();
                int aiBuild = (int)lobbySlot.m_aiBuild.Value;
                int teamId = (int)lobbySlot.m_teamId.Value;
                List<int> rewards = [.. lobbySlot.m_rewards.Value.Select(x => (int)x.Value.Value)];
                int commanderLevel = (int)lobbySlot.m_commanderLevel.Value;
                int logoIndex = (int)lobbySlot.m_logoIndex.Value.Value;
                List<string> artifacts = [.. lobbySlot.m_artifacts.Value.Select(x => x.Value.ReadStringBytes())];
                int difficulty = (int)lobbySlot.m_difficulty.Value;
                int? tandemLeaderId = (int?)(lobbySlot.m_tandemLeaderId.DefaultIfNone()?.Value);
                int commanderMasteryLevel = (int)lobbySlot.m_commanderMasteryLevel.Value;
                int trophyId = (int)lobbySlot.m_trophyId.Value;
                int brutalPlusDifficulty = (int)lobbySlot.m_brutalPlusDifficulty.Value;
                int? racePref = (int?)(lobbySlot.m_racePref.m_race.DefaultIfNone()?.Value);
                int? tandemId = (int?)(lobbySlot.m_tandemId.DefaultIfNone()?.Value);
                string hero = lobbySlot.m_hero.Value.ReadStringBytes();
                string commander = lobbySlot.m_commander.Value.ReadStringBytes();
                string mount = lobbySlot.m_mount.Value.ReadStringBytes();
                int handicap = (int)lobbySlot.m_handicap.Value.Value;
                string observe = lobbySlot.m_observe.GetKind();
                int aCEnemyWaveType = (int)lobbySlot.m_aCEnemyWaveType.Value;
                int control = (int)lobbySlot.m_control.Value;
                List<int> licenses = [.. lobbySlot.m_licenses.Value.Select(x => (int)x.Value.Value)];
                int? colorPref = GetColorPreference(lobbySlot);
                bool hasSilencePenalty = lobbySlot.m_hasSilencePenalty;
                int workingSetSlotId = (int)(lobbySlot.m_workingSetSlotId.DefaultIfNone()?.Value);
                List<int> retryMutationIndexes = [.. lobbySlot.m_retryMutationIndexes.Value.Select(x => (int)x.Value)];
                int? selectedCommanderPrestige = (int?)lobbySlot.m_selectedCommanderPrestige?.Value;

                slots.Add(new Slot(
                    aCEnemyRace,
                    toonHandle,
                    rewardOverrides,
                    userId,
                    skin,
                    commanderMasteryTalents,
                    aiBuild,
                    teamId,
                    rewards,
                    commanderLevel,
                    logoIndex,
                    artifacts,
                    difficulty,
                    tandemLeaderId,
                    commanderMasteryLevel,
                    trophyId,
                    brutalPlusDifficulty,
                    racePref,
                    tandemId,
                    hero,
                    commander,
                    mount,
                    handicap,
                    observe,
                    aCEnemyWaveType,
                    control,
                    licenses,
                    colorPref,
                    hasSilencePenalty,
                    workingSetSlotId,
                    retryMutationIndexes,
                    selectedCommanderPrestige
                ));
            }
        }

        return slots;
    }

    private static List<UserInitialData> GetUserInitialData(GameSLobbySyncState synclobbyState)
    {
        List<UserInitialData> initDatas = new List<UserInitialData>();

        if (synclobbyState.m_userInitialData is { } initialData)
        {
            foreach (var userInitialData in initialData.Value)
            {
                string mount = userInitialData.m_mount.Value.ReadStringBytes();
                string skin = userInitialData.m_skin.Value.ReadStringBytes();
                string observe = userInitialData.m_observe.GetKind();
                int? teamPref = GetTeamPreference(userInitialData);
                string toonHandle = userInitialData.m_toonHandle.Value.ReadStringBytes();
                long combinedRaceLevels = userInitialData.m_combinedRaceLevels.Value.Value;
                int highestLeague = (int)userInitialData.m_highestLeague.Value.Value;
                string clanTag = userInitialData.m_clanTag.DefaultIfNone()?.Value.ReadStringBytes();
                bool testMap = userInitialData.m_testMap;
                bool testAuto = userInitialData.m_testAuto;
                bool examine = userInitialData.m_examine;
                int testType = (int)userInitialData.m_testType.Value;
                bool customInterface = userInitialData.m_customInterface;
                string clanLogo = userInitialData.m_clanLogo.DefaultIfNone()?.Value.ReadStringBytes();
                string name = userInitialData.m_name.Value.ReadStringBytes();
                int? racePreference = GetRacePreference(userInitialData);
                int randomSeed = (int)userInitialData.m_randomSeed.Value;
                string hero = userInitialData.m_hero.Value.ReadStringBytes();
                long? scaledRating = userInitialData.m_scaledRating.DefaultIfNone()?.Value;

                UserInitialData initData = new UserInitialData(
                    mount,
                    skin,
                    observe,
                    teamPref,
                    toonHandle,
                    combinedRaceLevels,
                    highestLeague,
                    clanTag,
                    testMap,
                    testAuto,
                    examine,
                    testType,
                    customInterface,
                    clanLogo,
                    name,
                    racePreference,
                    randomSeed,
                    hero,
                    scaledRating
                );

                initDatas.Add(initData);
            }
        }

        return initDatas;
    }

    private static int? GetTeamPreference(SUserInitialData initialData)
    {
        if (initialData.m_teamPreference is { } teamPreference)
        {
            return (int?)teamPreference.m_team.DefaultIfNone()?.Value;
        }

        return null;
    }

    private static int? GetRacePreference(SUserInitialData initialData)
    {
        if (initialData.m_racePreference is { } racePreference)
        {
            return (int?)(racePreference.m_race.DefaultIfNone()?.Value);
        }

        return null;
    }

    private static int? GetColorPreference(GameSLobbySlot lobbySlot)
    {
        if (lobbySlot.m_colorPref is { } colorPref)
        {
            return (int?)(colorPref.m_color.DefaultIfNone()?.Value);
        }

        return null;
    }
}
