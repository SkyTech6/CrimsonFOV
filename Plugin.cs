using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Bloodstone.API;
using ProjectM;
using UnityEngine;
using CrimsonFOV.Structs;
using BepInEx.Logging;

namespace CrimsonFOV;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency("gg.deca.Bloodstone")]
[Bloodstone.API.Reloadable]
public class Plugin : BasePlugin
{
    Harmony _harmony;
    public static Settings Settings { get; private set; }
    public static ManualLogSource Logger { get; private set; }

    public override void Load()
    {
        Settings = new(Config);

        Logger = Log;

        // Plugin startup logic
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} version {MyPluginInfo.PLUGIN_VERSION} is loaded!");

        // Harmony patching
        _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        _harmony.PatchAll(System.Reflection.Assembly.GetExecutingAssembly());
    }

    public override bool Unload()
    {
        _harmony?.UnpatchSelf();
        return true;
    }

}
