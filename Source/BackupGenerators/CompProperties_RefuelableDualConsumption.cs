/*
 * Created by SharpDevelop.
 * User: DamnationLtd
 * Date: 4/4/2017
 * Time: 9:10 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using Verse;

namespace DLTD;

/// <summary>
///     Description of CompProperties_RefuelableDualConsumption.
/// </summary>
public class CompProperties_RefuelableDualConsumption : CompProperties
{
    public readonly float fuelHighConsumptionRate = 1f;
    public readonly float fuelLowConsumptionRate = 1f;
    public float highPowerThreshold = 1000f;
    public float lowPowerThreshold = 200f;

    public CompProperties_RefuelableDualConsumption()
    {
        compClass = typeof(CompRefuelableDualConsumption);
    }
}