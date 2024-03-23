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

    public override void DoSettingsWindowContents(Rect rect)
    {
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);

        Settings.LowPowerThresh.AsString =
            listing_Standard.TextEntryLabeled("BaGe.LowPower".Translate(), Settings.LowPowerThresh.AsString);
        Settings.HighPowerThresh.AsString =
            listing_Standard.TextEntryLabeled("BaGe.HighPower".Translate(), Settings.HighPowerThresh.AsString);

        if (listing_Standard.ButtonText("BaGe.Apply".Translate()))
        {
            if (Settings.LowPowerThresh.ValidateInput() && Settings.HighPowerThresh.ValidateInput())
            {
                GetSettings<Settings>().Write();
                Messages.Message("BaGe.Applied".Translate(), MessageTypeDefOf.PositiveEvent);
            }
        }

        listing_Standard.Label("BaGe.Value".Translate());
        if (Current.Game != null)
        {
            BackupGeneratorsSettingsUtil.ApplyFactor(Settings.LowPowerThresh.AsFloat,
                Settings.HighPowerThresh.AsFloat);
        }

        if (currentVersion != null)
        {
            GUI.contentColor = Color.gray;
            listing_Standard.Label("BaGe.ModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        GUI.EndGroup();
    }
}