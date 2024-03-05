using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Commands;
using Microsoft.Extensions.Logging;


namespace CS2_Admin;

public partial class CS2_Admin : BasePlugin
{
    public override string ModuleName => "CS2 Admin";

    public override string ModuleVersion => "0.0.1";

    public override string ModuleAuthor => "Yxnt";

    public override string ModuleDescription => "CS2 Admin Plugin";

    public override void Load(bool hotReload)
    {
        Logger.LogInformation("Plugin loaded successfully!");
    }

    
}
