using RimWorld;
using Verse;

namespace BackupGenerators;

internal class FloatInput(string name, float initialValue = 1f)
{
    public string AsString = initialValue.ToString();

    public float AsFloat
    {
        get => ValidateInput() ? float.Parse(AsString) : 1f;
        set => AsString = value.ToString();
    }

    public bool ValidateInput()
    {
        if (float.TryParse(AsString, out var f))
        {
            if (!(f <= 0))
            {
                return true;
            }

            Messages.Message($"{name} cannot be less than or equal to 0.", MessageTypeDefOf.RejectInput);
            return false;
        }

        Messages.Message($"Unable to parse {name} to a number.", MessageTypeDefOf.RejectInput);
        return false;
    }

    public void Copy(FloatInput fi)
    {
        AsString = fi.AsString;
    }
}