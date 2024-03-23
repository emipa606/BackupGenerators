using Verse;

namespace BackupGenerators;

internal class Settings : ModSettings
{
    public static readonly FloatInput LowPowerThresh = new FloatInput("Low Power Threshold", 200f);
    public static readonly FloatInput HighPowerThresh = new FloatInput("High Power Threshold", 1000f);

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref LowPowerThresh.AsString, "BackupGenerators.LowPowerThresh", "200");
        Scribe_Values.Look(ref HighPowerThresh.AsString, "BackupGenerators.HighPowerThresh", "1000");
    }
}