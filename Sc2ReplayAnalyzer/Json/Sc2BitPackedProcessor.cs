using System.Text.Json.Nodes;

namespace Sc2ReplayAnalyzer.Json;

using static Sc2JsonType;

internal class Sc2BitPackedProcessor
{
    public IReadOnlyList<JsonNode> ProcessBitPacked(JsonNode rootModule)
    {
        var result = new List<JsonNode>();
        var moduleDeclarations = rootModule[Declaration].AsArray();

        foreach(var moduleDecleration in moduleDeclarations)
        {
            var fullName = moduleDecleration[FullName].ToString();

            if (fullName.StartsWith("NNet.uint") || fullName.StartsWith("NNet.int"))
            {
                result.Add(moduleDecleration);
                continue;
            }

            switch(fullName)
            {
                case "NNet.SVarUint32":
                case "NNet.TUserId":
                case "NNet.ELeaveReason":
                case "NNet.CToonHandle":
                case "NNet.CFilePath":
                case "NNet.EObserve":
                case "NNet.CUserName":
                case "NNet.CClanTag":
                case "NNet.CUserInitialDataArray":
                case "NNet.EReconnectStatus":
                case "NNet.TUserCount":
                case "NNet.CCommanderHandle":
                case "NNet.CMountHandle":
                case "NNet.CSkinHandle":
                case "NNet.CHeroHandle":
                case "NNet.TRacePreference":
                case "NNet.CArtifactHandle":
                case "NNet.TRaceCount":
                case "NNet.TRaceId":
                case "NNet.SUserInitialData":
                case "NNet.CAllowedObserveTypes":
                case "NNet.CAllowedRaces":
                case "NNet.CCacheHandle":
                case "NNet.TTeamPreference":
                case "NNet.SVersion":
                case "NNet.SMD5":
                    result.Add(moduleDecleration);
                    break;
                case "NNet.Replay":
                    ProcessReplay(result, moduleDecleration);
                    break;
                case "NNet.Game":
                    ProcessGame(result, moduleDecleration);
                    break;
            }

        }

        return result;
    }

    private void ProcessGame(List<JsonNode> result, JsonNode moduleDecleration)
    {
        var gameDeclarations = moduleDecleration[Declaration].AsArray();

        foreach (var gameDeclaration in gameDeclarations)
        {
            var gameFullName = gameDeclaration[FullName].ToString();

            if (gameFullName is "NNet.Game.ESenders")
            {
                continue;
            }

            result.Add(gameDeclaration);

            if (gameFullName is "NNet.Game.STriggerDialogControlEvent")
            {
                var controlEventFields = gameDeclaration[TypeInfo][Fields].AsArray();

                foreach (var controlEventField in controlEventFields)
                {
                    if (controlEventField[Name].ToString() is "m_eventData")
                    {
                        result.Add(controlEventField);
                    }
                }
            }
        }
    }

    private void ProcessReplay(List<JsonNode> result, JsonNode moduleDecleration)
    {
        var replayDeclarations = moduleDecleration[Declaration].AsArray();

        foreach (var replayDecleration in replayDeclarations)
        {
            var replayFullName = replayDecleration[FullName].ToString();

            if (replayFullName is "NNet.Replay.SGameUserId" or "NNet.Replay.SInitData")
            {
                result.Add(replayDecleration);
            }
        }
    }
}
