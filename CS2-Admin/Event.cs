using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using Microsoft.Extensions.Logging;
using CS2_Admin.Models;
using CS2_Admin.Utils;
using Serilog;
using CounterStrikeSharp.API.Modules.Utils;
using System;
using CounterStrikeSharp.API.Modules.Entities;
using CounterStrikeSharp.API;
namespace CS2_Admin;

public partial class CS2_Admin
{

    [GameEventHandler]
    public HookResult OnPlayerConnect(EventPlayerConnect @event, GameEventInfo info)
    {
        // Userid will give you a reference to a CCSPlayerController class.
        // Before accessing any of its fields, you must first check if the Userid
        // handle is actually valid, otherwise you may run into runtime exceptions.
        // See the documentation section on Referencing Players for details.
        if (@event.Userid.IsValid)
        {
            Logger.LogInformation("Player {Name} has connected!", @event.Userid.PlayerName);
        }

        return HookResult.Continue;
    }

    //游戏开始
    [GameEventHandler]
    public HookResult OnGameStart(EventGameStart @event, GameEventInfo info)
    {
        initGameSettings();
        return HookResult.Continue;
    }

    // 回合结束
    [GameEventHandler]
    public HookResult OnRoundEnd(EventRoundEnd @event, GameEventInfo info)
    {

        // 热身回合结束
        if (roundInfo.RoundNumber == 0 && roundInfo.WarmUpRound == true)
        {
            roundInfo.WarmUpRound = false;
            return HookResult.Continue;
        }


        // // 更新结果数据
        // foreach (var attack in roundInfo.AttackInfo)
        // {
        //     var attackUser = attack.AttackUser;
        //     var user = attack.User;
        //     var hp = attack.Hp;
        //     var attackUserTeam = gameInfo.PlayerTeamInfo.First(player => player.Name == attackUser).Team.ToString();
        //     var userTeam = gameInfo.PlayerTeamInfo.First(player => player.Name == user).Team.ToString();

        //     // 更新所有玩家对被攻击玩家的剩余 HP 视图
        //     foreach (var player in result.Values)
        //     {
        //         foreach (var team in player.Values)
        //         {
        //             if (team.ContainsKey(user.PlayerName))
        //             {
        //                 team[user.PlayerName]["remainingHp"] -= hp;
        //                 if (team[user.PlayerName]["remainingHp"] < 0)
        //                 {
        //                     team[user.PlayerName]["remainingHp"] = 0;
        //                 }
        //             }
        //         }
        //     }

        //     // 如果 attackUser 和 user 相同，跳过此次循环
        //     if (attackUser == user)
        //     {
        //         continue;
        //     }
        //     result[attackUser][userTeam][user.PlayerName]["attackToHp"] += hp;

        //     if (result[attackUser][userTeam][user.PlayerName]["attackToHp"] >= 100)
        //     {
        //         result[attackUser][userTeam][user.PlayerName]["attackToHp"] = 100;
        //     }

        //     result[user][attackUserTeam][attackUser.PlayerName]["attackFromHp"] += hp;

        //     if (result[user][attackUserTeam][attackUser.PlayerName]["attackFromHp"] >= 100)
        //     {
        //         result[user][attackUserTeam][attackUser.PlayerName]["attackFromHp"] = 100;
        //     }

        //     result[attackUser][userTeam][user.PlayerName]["attackToCount"] += 1;
        //     result[user][attackUserTeam][attackUser.PlayerName]["attackFromCount"] += 1;
        // }



        // foreach (var player in result)
        // {
        //     player.Key.PrintToChat($"[上一回合伤害统计]");

        //     var friendlyFire = player.Value
        //         .Where(team => team.ToString() == gameInfo.PlayerTeamInfo.First(p => p.Name == player.Key).Team.ToString())
        //         .SelectMany(team => team.Value)
        //         .Where(otherPlayer => otherPlayer.Value["attackFromCount"] > 0)
        //         .ToList();

        //     if (friendlyFire.Any())
        //     {
        //         player.Key.PrintToChat("友军伤害如下:");
        //         foreach (var otherPlayer in friendlyFire)
        //         {
        //             player.Key.PrintToChat($"被玩家{otherPlayer.Key}攻击 {otherPlayer.Value["attackFromCount"]} 次, 受到 {otherPlayer.Value["attackFromHp"]} HP 伤害");
        //         }
        //     }

        //     player.Key.PrintToChat("\n对敌军伤害:");
        //     foreach (var team in player.Value)
        //     {
        //         if (team.Key != gameInfo.PlayerTeamInfo.First(p => p.Name == player.Key).Team.ToString())
        //         {
        //             foreach (var otherPlayer in team.Value)
        //             {
        //                 player.Key.PrintToChat($"攻击 {otherPlayer.Value["attackToCount"]} 次 {otherPlayer.Value["attackToHp"]} HP 伤害 被攻击 {otherPlayer.Value["attackFromCount"]} 次 受到 {otherPlayer.Value["attackFromHp"]} HP 伤害 {otherPlayer.Key} 剩余 {otherPlayer.Value["remainingHp"]} HP");
        //             }
        //         }
        //     }

        // }
        // result.Clear();
        roundInfo.AttackInfo.Clear();

        return HookResult.Continue;
    }

    // 回合开始
    [GameEventHandler]
    public HookResult OnRoundStart(EventRoundStart @event, GameEventInfo info)
    {
        roundInfo.RoundNumber++;
        Logger.LogInformation($"Round {roundInfo.RoundNumber} Start");

        if (roundInfo.RoundNumber == 1) { return HookResult.Continue; }
        if (gameInfo.PlayerTeamInfo.Count <= 1) { return HookResult.Continue; }

        // 初始化结果数据
        // var result = new Dictionary<CCSPlayerController, Dictionary<string, Dictionary<string, Dictionary<string, int>>>>();
        // foreach (var player in gameInfo.PlayerTeamInfo)
        // {

        //     result[player.Name] = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();

        //     foreach (var otherPlayer in gameInfo.PlayerTeamInfo)
        //     {

        //         if (player.Name != otherPlayer.Name)
        //         {
        //             result[player.Name].TryAdd(otherPlayer.Team.ToString(), new Dictionary<string, Dictionary<string, int>>());
        //             result[player.Name][otherPlayer.Team.ToString()].TryAdd(otherPlayer.Name.PlayerName, new Dictionary<string, int>
        //             {
        //                 {"attackFromHp", 0},
        //                 {"attackFromCount", 0},
        //                 {"attackToHp", 0},
        //                 {"attackToCount", 0},
        //                 {"remainingHp", otherPlayer.Hp}
        //             });
        //         }
        //     }

        // }
        return HookResult.Continue;
    }

    // 热身开始
    [GameEventHandler]
    public HookResult OnRoundWarmUp(EventRoundAnnounceWarmup @event, GameEventInfo info)
    {
        Logger.LogInformation($"Round WarmUp");
        roundInfo.RoundNumber = 0;
        roundInfo.WarmUpRound = true;
        friendlyFireMenu();
        return HookResult.Continue;
    }

    // 玩家被攻击
    [GameEventHandler]
    public HookResult OnPlayerHurt(EventPlayerHurt @event, GameEventInfo info)
    {

        var userInfo = @event.Userid;
        var attackerUserInfo = @event.Attacker;
        var hp = @event.DmgHealth;

        if (attackerUserInfo.UserId == 65535) return HookResult.Continue;
        if (roundInfo.WarmUpRound) return HookResult.Continue;
        if (attackerUserInfo.UserId == userInfo.UserId) return HookResult.Continue;
        // 自己对自己造成伤害忽略
        if (attackerUserInfo.IsBot || userInfo.IsBot) return HookResult.Continue;

        UserAttack userAttack = new UserAttack();
        UserAttackInfo attackInfo = userAttack.Damage(attackerUserInfo, userInfo, hp);

        roundInfo.AttackInfo.Add(attackInfo);

        return HookResult.Continue;
    }

    [GameEventHandler]
    public HookResult OnPlayerChangeTeam(EventPlayerTeam @event, GameEventInfo info)
    {
        if (@event.Isbot) return HookResult.Continue;

        gameInfo.PlayerTeamInfo.Add(new UserInfo()
        {
            Name = @event.Userid,
            Hp = 100,
            Team = @event.Team
        });

        // if (roundInfo.RoundNumber == 0)
        // {
            // 玩家10人结束热身
            // int tUserCount = gameInfo.PlayerTeamInfo.Count(user => user.Team == (int)CsTeam.Terrorist);
            // int ctUserCount = gameInfo.PlayerTeamInfo.Count(user => user.Team == (int)CsTeam.CounterTerrorist);

            // if (tUserCount == 5 && ctUserCount == 5)
            // {
            //     friendlyFireMenu();
            //     endWarmUpRound();
            // }
        // }


        return HookResult.Continue;
    }
}