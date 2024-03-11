using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using CounterStrikeSharp.API.Modules.Entities;
using CounterStrikeSharp.API.Modules.Menu;
using CS2_Admin.Models;
using Microsoft.Extensions.Logging;
using System.Numerics;


namespace CS2_Admin;

public partial class CS2_Admin : BasePlugin
{

    public override string ModuleName => "CS2 Admin";

    public override string ModuleVersion => "0.0.1";

    public override string ModuleAuthor => "Yxnt";

    public override string ModuleDescription => "CS2 Admin Plugin";

    private string _warmUpTimeSeconds = "600";
    private string _warmUpEndUserCount = "10";

    public override void Load(bool hotReload)
    {
        Logger.LogInformation("Plugin loaded successfully!");
        registryListener();
    }

    private GameInfo gameInfo = new GameInfo();
    private RoundInfo roundInfo = new RoundInfo();

    
}
