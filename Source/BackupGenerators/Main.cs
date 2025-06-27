using System.Reflection;
using HarmonyLib;
using Verse;

namespace BackupGenerators;

[StaticConstructorOnStartup]
internal class Main
{
    static Main()
    {
        new Harmony("com.backupgenerators.rimworld.mod").PatchAll(Assembly.GetExecutingAssembly());
    }
}