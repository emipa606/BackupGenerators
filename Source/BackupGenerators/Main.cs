using System.Reflection;
using HarmonyLib;
using Verse;

namespace BackupGenerators;

[StaticConstructorOnStartup]
internal class Main
{
    static Main()
    {
        var harmony = new Harmony("com.backupgenerators.rimworld.mod");
        harmony.PatchAll(Assembly.GetExecutingAssembly());

        Log.Message("BackupGenerators: Adding Harmony Postfix to GameComponentUtility.StartedNewGame");
        Log.Message("BackupGenerators: Adding Harmony Postfix to GameComponentUtility.LoadedGame");
    }
}