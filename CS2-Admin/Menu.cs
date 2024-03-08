using System.Security.Cryptography;
using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Entities.Constants;
using CounterStrikeSharp.API.Modules.Menu;
using CounterStrikeSharp.API.Modules.Utils;
using CS2_Admin.Models;

namespace CS2_Admin;


public partial class CS2_Admin{
    private int totalVotes = 0;
    private int yesVotes = 0;
    private void friendlyFireMenu(){
        var menu = new ConsoleMenu("开启友伤");

        var handleFriendlyFire = (CCSPlayerController player,ChatMenuOption option) => {
            totalVotes++;
            if (option.Text == "Yes")
            {
                yesVotes++;
                Server.PrintToChatAll($"{player.PlayerName} 选择 {ChatColors.Red}开启友伤");
            } else {
                Server.PrintToChatAll($"{player.PlayerName} 选择 {ChatColors.Red}关闭友伤");
            }
        };

        menu.AddMenuOption("Yes",handleFriendlyFire,false);
        menu.AddMenuOption("No",handleFriendlyFire,false);
 
        CS2_Admin.Instance!.AddTimer(30f,()=>{
            foreach (UserInfo player in gameInfo.PlayerTeamInfo){
                MenuManager.OpenConsoleMenu(player.Name,menu);
            }
        });

        double yesPercentage = (double)yesVotes / totalVotes * 100;
        if (yesPercentage > 60)
        {
            Server.PrintToChatAll($" {ChatColors.Red}本局游戏开启友伤");
            friendlyFireSettings(true);
        }
        else
        {
            Server.PrintToChatAll($" {ChatColors.Red}本局游戏关闭友伤");
            friendlyFireSettings(false);
        }
    }

    
}