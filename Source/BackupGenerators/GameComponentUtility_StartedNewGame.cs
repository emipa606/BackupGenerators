using HarmonyLib;
using Verse;

namespace BackupGenerators;

[HarmonyPatch(typeof(GameComponentUtility), nameof(GameComponentUtility.StartedNewGame))]
internal static class GameComponentUtility_StartedNewGame
{
    public static void Postfix()
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