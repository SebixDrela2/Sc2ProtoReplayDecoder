using Sc2ReplayAnalyzer.Decoder.Models.Details;
using Sc2ReplayAnalyzer.Global;
using Sc2ReplayAnalyzer.Json.VersionedProtocolDefinitions;

using GameSDetails = Sc2ReplayAnalyzer.Json.VersionedProtocolDefinitions.GameSDetails;

namespace Sc2ReplayAnalyzer.Decoder.Parser;

internal static partial class Parse
{
    public static Details Details(GameSDetails details)
    {
        var campaignIndex = details.m_campaignIndex;
        var defaultDiff = details.m_defaultDifficulty;
        var desc = details.m_description.ReadStringBytes();
        var diff = details.m_difficulty.ReadStringBytes();
        var disableRec = details.m_disableRecoverGame;
        var speed = details.m_gameSpeed;
        var image = details.m_imageFilePath.ReadStringBytes();
        var isBlizzard = details.m_isBlizzardMap;
        var mapName = details.m_mapFileName.ReadStringBytes();
        var mini = details.m_miniSave;
        var restart = details.m_restartAsTransitionMap.ReadBool();
        var offset = details.m_timeLocalOffset;
        var time = details.m_timeUTC;
        var title = details.m_title.ReadStringBytes();

        var players = GetDetailsPlayers(details.m_playerList);

        return new Details(campaignIndex,
                           defaultDiff,
                           desc,
                           diff,
                           disableRec,
                           speed.GetKind(),
                           image,
                           isBlizzard,
                           mapName,
                           mini,
                           restart,
                           offset,
                           time,
                           title,
                           players);
    }

    private static List<DetailsPlayer> GetDetailsPlayers(Option<GameSPlayerDetails[]> option)
    {
        List<DetailsPlayer> players = [];

        if (!option.HasValue)
        {
            return players;
        }

        foreach (var playerObj in option.Value)
        {
            var color = GetColor(playerObj.m_color);
            var control = playerObj.m_control;
            var handicap = playerObj.m_handicap;
            var hero = playerObj.m_hero.ReadStringBytes();
            var name = playerObj.m_name.ReadStringBytes();
            var observe = playerObj.m_observe;
            var race = playerObj.m_race.ReadStringBytes();
            var result = playerObj.m_result;
            var team = playerObj.m_teamId;
            var toon = GetToon(playerObj.m_toon);
            var slot = playerObj.m_workingSetSlotId.Value;

            players.Add(new DetailsPlayer(color, control, handicap, hero, name, observe.GetKind(), race, result.GetKind(), team, toon, slot));
        }

        return players;
    }

    private static Toon GetToon(GameSToonNameDetails toon) 
        => new((int)toon.m_id, toon.m_programId.ToString(), (int)toon.m_realm, toon.m_region);

    private static PlayerColor GetColor(GameSColor color) 
        => new(color.m_a, color.m_b, color.m_g, color.m_r);
}
