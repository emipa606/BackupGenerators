using HarmonyLib;
using Verse;

namespace BackupGenerators;

[HarmonyPatch(typeof(GameComponentUtility), "StartedNewGame")]
internal static class Patch_GameComponentUtility_StartedNewGame
{
    private static void Postfix()
    {
        if (Settings.LowPowerThresh.AsFloat == 1 && Settings.HighPowerThresh.AsFloat == 1)
        {
            BackupGeneratorsSettingsUtil.ApplyFactor(200, 1000);
        }
        else
        {
            BackupGeneratorsSettingsUtil.ApplyFactor(Settings.LowPowerThresh.AsFloat,
                Settings.HighPowerThresh.AsFloat);
        }
    }
}