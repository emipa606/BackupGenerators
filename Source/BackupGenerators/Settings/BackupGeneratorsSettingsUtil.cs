using System.Collections.Generic;
using DLTD;
using Verse;

namespace BackupGenerators;

internal static class BackupGeneratorsSettingsUtil
{
    static BackupGeneratorsSettingsUtil()
    {
        LowPower = null;
        HighPower = null;
    }

    public static Dictionary<string, float> LowPower { get; set; }
    public static Dictionary<string, float> HighPower { get; set; }
    public static Dictionary<string, ThingDef> BackupGeneratorsDefLow { get; set; }
    public static Dictionary<string, ThingDef> BackupGeneratorsDefHigh { get; set; }

    private static void CreateLowPowerMap()
    {
        if (LowPower != null)
        {
            return;
        }

        LowPower = new Dictionary<string, float>();
        BackupGeneratorsDefLow = new Dictionary<string, ThingDef>();
        foreach (var def in DefDatabase<ThingDef>.AllDefsListForReading)
        {
            var checkComps = new List<string>();
            foreach (var x in def.comps)
            {
                checkComps.Add(x.ToString());
            }

            if (!checkComps.Contains("DLTD.CompProperties_RefuelableDualConsumption"))
            {
                continue;
            }

            var lowPowerThresh = def.GetCompProperties<CompProperties_RefuelableDualConsumption>();
            if (LowPower == null)
            {
                continue;
            }

            LowPower.Add(def.defName, lowPowerThresh.lowPowerThreshold);
            BackupGeneratorsDefLow.Add(def.defName, def);
        }
    }

    private static void CreateHighPowerMap()
    {
        if (HighPower != null)
        {
            return;
        }

        HighPower = new Dictionary<string, float>();
        BackupGeneratorsDefHigh = new Dictionary<string, ThingDef>();
        foreach (var def in DefDatabase<ThingDef>.AllDefsListForReading)
        {
            var checkComps = new List<string>();
            foreach (var x in def.comps)
            {
                checkComps.Add(x.ToString());
            }

            if (!checkComps.Contains("DLTD.CompProperties_RefuelableDualConsumption"))
            {
                continue;
            }

            var highPowerThresh = def.GetCompProperties<CompProperties_RefuelableDualConsumption>();
            if (HighPower == null)
            {
                continue;
            }

            HighPower.Add(def.defName, highPowerThresh.highPowerThreshold);
            BackupGeneratorsDefHigh.Add(def.defName, def);
        }
    }

    public static void ApplyFactor(float newValueLow, float newValueHigh)
    {
        CreateLowPowerMap();
        CreateHighPowerMap();

        foreach (var low in LowPower)
        {
            var def = BackupGeneratorsDefLow[low.Key];
            var lowThresh = def.GetCompProperties<CompProperties_RefuelableDualConsumption>();
            lowThresh.lowPowerThreshold = newValueLow;
        }

        foreach (var high in HighPower)
        {
            var def = BackupGeneratorsDefHigh[high.Key];
            var highThresh = def.GetCompProperties<CompProperties_RefuelableDualConsumption>();
            highThresh.highPowerThreshold = newValueHigh;
        }
    }
}