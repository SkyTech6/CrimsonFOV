using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimsonFOV.Structs;

public readonly struct Settings
{
    internal readonly ConfigFile CONFIG;
    internal readonly ConfigEntry<bool> ENABLE_MOD;
    internal readonly ConfigEntry<float> FIELD_OF_VIEW;

    public Settings(ConfigFile config)
    {
        CONFIG = config;
        ENABLE_MOD = config.Bind("Config", "EnableMod", true, "Enable or disable the mod");
        FIELD_OF_VIEW = config.Bind("Config", "FieldOfView", 90f, "The desired field of view");
    }
}
