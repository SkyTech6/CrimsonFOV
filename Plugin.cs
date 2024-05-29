﻿using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Bloodstone.API;
using ProjectM;
using UnityEngine;
using CrimsonFOV.Structs;

namespace CrimsonFOV;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency("gg.deca.Bloodstone")]
[Bloodstone.API.Reloadable]
public class Plugin : BasePlugin, IRunOnInitialized
{
    Harmony _harmony;
    public static Settings Settings { get; private set; }

    public override void Load()
    {
        Settings = new(Config);

        // Plugin startup logic
        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} version {MyPluginInfo.PLUGIN_VERSION} is loaded!");

        // Harmony patching
        _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        _harmony.PatchAll(System.Reflection.Assembly.GetExecutingAssembly());

    }

    public void OnGameInitialized()
    {
        if (Application.productName == "VRisingServer")
        {
            Log.LogWarning($"This is a client-only mod.");
            return;
        }

        Camera cam = CameraManager.GetCamera();
        cam.fieldOfView = Settings.FIELD_OF_VIEW.Value;
    }

    public override bool Unload()
    {
        _harmony?.UnpatchSelf();
        return true;
    }

}
