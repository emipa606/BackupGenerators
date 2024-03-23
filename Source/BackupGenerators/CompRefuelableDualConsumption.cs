/*
 * Created by SharpDevelop.
 * User: DamnationLtd
 * Date: 4/4/2017
 * Time: 9:15 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using RimWorld;
using Verse;

namespace DLTD;

/// <summary>
///     Description of CompRefuelableDualConsumption.
/// </summary>
[StaticConstructorOnStartup]
public class CompRefuelableDualConsumption : ThingComp
{
    protected CompRefuelable refuelableComp;

    public bool LowPowerMode { get; set; }

    public CompProperties_RefuelableDualConsumption Props => (CompProperties_RefuelableDualConsumption)props;

    private float CurrentConsumptionRate =>
        LowPowerMode ? Props.fuelLowConsumptionRate : Props.fuelHighConsumptionRate;

    public override void PostSpawnSetup(bool respawningAfterLoad)
    {
        base.PostSpawnSetup(respawningAfterLoad);
        refuelableComp = parent.GetComp<CompRefuelable>();
    }

    public override void CompTick()
    {
        refuelableComp.Props.fuelConsumptionRate = CurrentConsumptionRate;
        base.CompTick();
    }
}