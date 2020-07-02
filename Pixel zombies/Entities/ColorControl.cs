using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    public static class ColorControl
    {
        public static readonly Color FloorColor = Color.Black;

        public static readonly Dictionary<Entity.Type, Color> TypeColorTable = new Dictionary<Entity.Type, Color>()
        {
            {Entity.Type.Wall, Color.Magenta },
            {Entity.Type.Zombo, Color.Red }
        };

        public static Color ColorOf(Entity check)
        {
            if (check.overridesColor)
                return check.overrideColor;
            else
                return TypeColorTable[check.type];
        }

        public static void OverrideColorFor(Entity overrideFor, Color color)
        {
            overrideFor.overridesColor = true;
            overrideFor.overrideColor = color;
        }

        public static Color ColorAtPoint(Point point)
        {
            if (FullMap.HasValueAt(point))
                return ColorOf(FullMap.GetAtSecond(point));
            else
                return FloorColor;

        }
    }
}
