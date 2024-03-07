using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Admin;
using CounterStrikeSharp.API.Modules.Commands;
using Microsoft.Extensions.Logging;

namespace CS2_Admin
{
    public partial class CS2_Admin
    {
        [ConsoleCommand("css_map", "切换比赛地图")]
        [CommandHelper(minArgs: 1, usage: "[map_code]", whoCanExecute: CommandUsage.CLIENT_AND_SERVER)]
        [RequiresPermissions("@css/changemap")]
        public void OnCommand(CCSPlayerController? player, CommandInfo command)
        {
            Logger.LogInformation(command.ArgByIndex(1));
            if (Entity.Map.MapCode.Contains(command.ArgByIndex(1)))
            {
                Server.ExecuteCommand($"changelevel {command.ArgByIndex(1)}");
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
    }
}
