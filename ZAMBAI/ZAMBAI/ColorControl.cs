using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pixel_zombies.Zombo;

namespace Pixel_zombies
{
    public static class ColorControl
    {
        public static readonly Color FloorColor = Color.Black;

        public static readonly Dictionary<Entity.EntityType, Color> TypeColorTable = new Dictionary<Entity.EntityType, Color>()
        {
            {Entity.EntityType.Wall, Color.Magenta },
            {Entity.EntityType.Zombo, Color.Red }
        };

        public static readonly Dictionary<Alliance, Color> AllianceColorMap = new Dictionary<Alliance, Color>()
    {
        {Alliance.Red, Color.Red },
        {Alliance.Blue, Color.Blue },
        {Alliance.Green, Color.Green }
    };

        public static Color ColorOf(Entity check)
        {
            if (check.overridesColor)
                return check.overrideColor;
            else
                return TypeColorTable[check.entityType];
        }

        public static void OverrideColorFor(Entity overrideFor, Color color)
        {
            overrideFor.overridesColor = true;
            overrideFor.overrideColor = color;
        }

        public static void OverrideColorForZombo(Zombo overrideFor) => OverrideColorFor(overrideFor, AllianceColorMap[overrideFor.alliance]);

        public static Color ColorAtPoint(Point point)
        {
            if (FullMap.HasEntityAt(point))
                return ColorOf(FullMap.GetAt(point));
            else
                return FloorColor;

        }
    }
}
