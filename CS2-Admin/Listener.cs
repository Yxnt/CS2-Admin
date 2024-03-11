using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Entities;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CS2_Admin;

public partial class CS2_Admin
{
    void registryListener()
    {
        AddCommandListener("jointeam", (player, info) =>
            {
                // 选定阵营后不可手动切换队伍
                foreach (var user in gameInfo.PlayerTeamInfo.Keys)
                {
                    if (user == player)
                    {
                        user.PrintToChat("不可切换队伍,如需请联系管理员");
                        return HookResult.Handled;
                    }
                }
                return HookResult.Continue;
            });

    }
}