using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using Microsoft.Extensions.Logging;

namespace CS2_Admin;

public partial class CS2_Admin
{
    
    [GameEventHandler]
    public HookResult OnPlayerConnect(EventPlayerConnect @event, GameEventInfo info)
    {
        // Userid will give you a reference to a CCSPlayerController class
        // Logger.LogInformation("Player {Name} has connected!", @event.Userid.PlayerName);

        return HookResult.Continue;
    }

    // 玩家到齐
    [GameEventHandler]
    public HookResult OnPlayerConnectFull(EventPlayerConnectFull @event, GameEventInfo info)
    {
        
        return HookResult.Continue;
    }
    
    // 回合结束
    [GameEventHandler]
    public HookResult OnRoundEnd(EventRoundEnd @event, GameEventInfo info)
    {
        
        Logger.LogInformation("fffffffffffffffffffff");
        
        // EventPlayerHurt playerHurt = new EventPlayerHurt(true);
        
        // Logger.LogInformation($"{playerHurt.Userid}\t{playerHurt.Attacker}");
        
        return HookResult.Continue;
    }
}