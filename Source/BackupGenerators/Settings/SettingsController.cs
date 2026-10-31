using Mlie;
using RimWorld;
using UnityEngine;
using Verse;

namespace BackupGenerators;

public class SettingsController : Mod
{
    private static string currentVersion;

    public SettingsController(ModContentPack content) : base(content)
    {
        GetSettings<Settings>();
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public override string SettingsCategory()
    {
        return "BackupGenerators";
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(inRect);

        Settings.LowPowerThresh.AsString =
            listingStandard.TextEntryLabeled("BaGe.LowPower".Translate(), Settings.LowPowerThresh.AsString);
        Settings.HighPowerThresh.AsString =
            listingStandard.TextEntryLabeled("BaGe.HighPower".Translate(), Settings.HighPowerThresh.AsString);

        if (listingStandard.ButtonText("BaGe.Apply".Translate()) && Settings.LowPowerThresh.ValidateInput() &&
            Settings.HighPowerThresh.ValidateInput())
        {
            GetSettings<Settings>().Write();
            Messages.Message("BaGe.Applied".Translate(), MessageTypeDefOf.PositiveEvent);
        }

        listingStandard.Label("BaGe.Value".Translate());
        if (Current.Game != null)
        {
            BackupGeneratorsSettingsUtil.ApplyFactor(Settings.LowPowerThresh.AsFloat,
                Settings.HighPowerThresh.AsFloat);
        }

        if (currentVersion != null)
        {
            GUI.contentColor = Color.gray;
            listingStandard.Label("BaGe.ModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        GUI.EndGroup();
    }
}