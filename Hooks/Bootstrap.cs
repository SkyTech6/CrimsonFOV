using HarmonyLib;
using ProjectM;
using UnityEngine;

namespace CrimsonFOV.Hooks;

[HarmonyPatch]
public class Bootstrap
{
    [HarmonyPatch(typeof(GameBootstrap), nameof(GameBootstrap.Start))]
    [HarmonyPostfix]
    public static void Postfix(GameBootstrap __instance)
    {
        if (Application.productName == "VRisingServer")
        {
            Plugin.Logger.LogWarning($"This is a client-only mod.");
            return;
        }

        Camera cam = CameraManager.GetCamera();
        cam.fieldOfView = Plugin.Settings.FIELD_OF_VIEW.Value;
    }
}
