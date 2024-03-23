/*
 * Created by SharpDevelop.
 * User: DamnationLtd
 * Date: 4/4/2017
 * Time: 10:10 AM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using RimWorld;

namespace DLTD;

public class CompBackupPower : CompPowerTrader
{
    protected CompBreakdownable breakdownableComp;

    public bool recharging;
    protected CompRefuelable refuelableComp;

    protected CompRefuelableDualConsumption refuelableDualConsumptionComp;

    protected virtual float DesiredPowerOutput => -Props.PowerConsumption;

    protected virtual bool IsCharging
    {
        get
        {
            // if connected to a network...
            if (transNet != null)
            {
                // and batteries are connected
                if (transNet.batteryComps.Count > 0)
                {
                    if (recharging && transNet.CurrentStoredEnergy() >=
                        refuelableDualConsumptionComp.Props.highPowerThreshold)
                    {
                        // turn back off when we fill one battery's worth of charge
                        recharging = false;
                    }
                    else if (transNet.CurrentStoredEnergy() <=
                             refuelableDualConsumptionComp.Props.lowPowerThreshold)
                    {
                        // turn on when we drop below 200Wd stored
                        recharging = true;
                    }
                }
                else
                {
                    // without batteries connected, always produce power
                    recharging = true;
                }
            }
            else
            {
                // don't produce power if not connected to a network
                recharging = false;
            }

            return recharging;
        }
    }

    public override void PostSpawnSetup(bool respawningAfterLoad)
    {
        base.PostSpawnSetup(respawningAfterLoad);
        refuelableComp = parent.GetComp<CompRefuelable>();
        refuelableDualConsumptionComp = parent.GetComp<CompRefuelableDualConsumption>();
        breakdownableComp = parent.GetComp<CompBreakdownable>();
        if (Props.PowerConsumption < 0f && !parent.IsBrokenDown())
        {
            PowerOn = true;
        }
    }

    public override void CompTick()
    {
        base.CompTick();

        if (breakdownableComp is { BrokenDown: true } ||
            refuelableComp is { HasFuel: false } ||
            flickableComp is { SwitchIsOn: false } ||
            !IsCharging ||
            !PowerOn)
        {
            PowerOutput = 0f;
            refuelableDualConsumptionComp.LowPowerMode = true;
            recharging = false;
        }
        else
        {
            PowerOutput = DesiredPowerOutput;
            refuelableDualConsumptionComp.LowPowerMode = false;
        }
    }
}