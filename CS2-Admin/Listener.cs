using CounterStrikeSharp.API.Core;

namespace CS2_Admin;

public partial class CS2_Admin
{
    void registryListener()
    {
        AddCommandListener("jointeam", (player, info) =>
        {
            if (roundInfo.WarmUpRound == false)
            {
                foreach (var user in gameInfo.PlayerTeamInfo)
                {
                    if (user.Name.Equals(player))
                    {
                        if (!player.Team.Equals(user.Team))
                        {
                            player.ChangeTeam((CounterStrikeSharp.API.Modules.Utils.CsTeam)user.Team);
                        }
                    }
                }
            }
            return HookResult.Continue;
        });
    }
}