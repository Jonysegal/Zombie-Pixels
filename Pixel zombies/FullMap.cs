using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    public static class FullMap
    {
        public static List<Point> modifiedPoints = new List<Point>();

        static GenericLocalMap<Tile> map = new GenericLocalMap<Tile>();

        public static Tile ValueAtPoint(Point at) => map.ValueAt(at);

    }
}
