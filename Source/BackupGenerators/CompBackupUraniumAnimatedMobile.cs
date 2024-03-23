using RimWorld;
using Verse;

namespace DLTD;

[StaticConstructorOnStartup]
internal class CompBackupUraniumAnimatedMobile : Building
{
    private const int arraySize = 12; // Turn animation off => set to 1

    // This is the graphics container:
    public static Graphic[] graphic;

    private readonly string
        graphicPathAdditionWoNumber = "_Frame"; // everything before this will be used for the other file names

    private readonly int
        updateAnimationEveryXTicks = 5; // => 60 ticks per second / 12 graphic frames = 5 ticks per frame

    private int activeGraphicFrame;

    protected CompBackupPower powerComp;
    private int ticksSinceUpdateGraphic;

    public override Graphic Graphic
    {
        get
        {
            try
            {
                if (!powerComp.recharging)
                {
                    return base.Graphic;
                }

                if (graphic?[0] != null)
                {
                    return graphic[activeGraphicFrame] ?? base.Graphic;
                }

                UpdateGraphics();
                // Graphic couldn't be loaded? (Happends after load for a while)
                if (graphic?[0] == null)
                {
                    return base.Graphic;
                }

                return graphic[activeGraphicFrame] ?? base.Graphic;
            }
            catch
            {
                return base.Graphic;
            }
        }
    }

    public override void SpawnSetup(Map map, bool respawningAfterLoad)
    {
        base.SpawnSetup(map, respawningAfterLoad);

        powerComp = GetComp<CompBackupPower>();
    }

    /// <summary>
    ///     Import the graphics
    /// </summary>
    private void UpdateGraphics()
    {
        // Check if graphic is already filled
        if (graphic is { Length: > 0 } && graphic[0] != null)
        {
            return;
        }

        // resize the graphic array
        graphic = new Graphic[arraySize];

        // fill the graphic array
        for (var i = 0; i < arraySize; i++)
        {
            var graphicRealPath = def.graphicData.texPath + graphicPathAdditionWoNumber + (i + 1);

            // Set the graphic, use additional info from the xml data
            graphic[i] = GraphicDatabase.Get<Graphic_Single>(graphicRealPath, def.graphic.Shader,
                def.graphic.drawSize, def.graphic.Color, def.graphic.ColorTwo);
        }
    }

    public override void Tick()
    {
        // Call work function
        DoTickerWork(1);

        base.Tick();
    }


    // Here is the main decision work of this building done
    private void DoTickerWork(int ticks)
    {
        if (Map == null)
        {
            return;
        }

        // Graphic update
        if (powerComp.recharging)
        {
            ticksSinceUpdateGraphic += ticks;
            if (ticksSinceUpdateGraphic < updateAnimationEveryXTicks)
            {
                return;
            }

            ticksSinceUpdateGraphic = 0;
            activeGraphicFrame++;
            if (activeGraphicFrame >= arraySize)
            {
                activeGraphicFrame = 0;
            }

            // Tell the MapDrawer that here is something that's changed
            Map.mapDrawer.MapMeshDirty(Position, MapMeshFlagDefOf.Things, true, false);
        }
        else
        {
            activeGraphicFrame = 0;
        }
    }
}