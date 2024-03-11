using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Admin;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Entities.Constants;
using CounterStrikeSharp.API.Modules.Utils;
using CS2_Admin.Models;
using Microsoft.Extensions.Logging;

namespace CS2_Admin
{
    public partial class CS2_Admin
    {
        
        void initGameSettings()
        {
            // 设置热身时间
            Server.ExecuteCommand($"mp_warmuptime {_warmUpTimeSeconds}");
            Server.ExecuteCommand("mp_autokick 0");
            // Server.ExecuteCommand($"mp_endwarmup_player_count {_warmUpEndUserCount}");
        }

        void friendlyFireSettings(bool enable){
            if (enable){
                Server.ExecuteCommand("mp_friendlyfire 1");
            } else {
                Server.ExecuteCommand("mp_friendlyfire 0");
            }
        }

        // Change Game Map
        [ConsoleCommand("css_map", "切换比赛地图")]
        [CommandHelper(minArgs: 1, usage: "[map_code]", whoCanExecute: CommandUsage.CLIENT_AND_SERVER)]
        [RequiresPermissions("@css/changemap")]
        public void ChangeMap(CCSPlayerController? player, CommandInfo command)
        {
            if (Entity.Map.MapCode.Contains(command.GetArg(1)))
            {
                Server.ExecuteCommand($"changelevel {command.GetArg(1)}");
            } else
            {
                command.ReplyToCommand($"参数错误,从下面的地图列表中选择: ");
                foreach (var map in  Entity.Map.MapCode)
                {
                    command.ReplyToCommand($"{map}");
                }
                command.ReplyToCommand("请输入 !map <map_code>");
            }
        }

        [ConsoleCommand("css_weapon_to_all","给所有玩家相同的武器")]
        [CommandHelper(minArgs: 1, usage: "[wapon_code]", whoCanExecute: CommandUsage.CLIENT_AND_SERVER)]
        [RequiresPermissions("@css/generic")]
        public void GiveWeaponToAllUser(CCSPlayerController? player, CommandInfo command){
            string weaponId = command.GetArg(1);
            Server.PrintToChatAll($" {ChatColors.Red}[通知] {ChatColors.Default}: 已经给所有玩家提供了 {ChatColors.Green}{weaponId}");
            foreach(CCSPlayerController user in gameInfo.PlayerTeamInfo.Keys){
                user.GiveNamedItem(weaponId);
            }
        }
    }
}
