using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    public static class FullMap
    {
        static Tile genericFloorTile = new Tile(Tile.Type.Floor);

        public static List<Point> modifiedPoints = new List<Point>();

        static GenericLocalMap<Tile> map = new GenericLocalMap<Tile>();

        static Dictionary<int, Dictionary<int, bool>> secondMap = new Dictionary<int, Dictionary<int, bool>>();

        static FullMap()
        {
            for(int i=0; i < Drawer.WindowSize; i++)
            {
                secondMap[i] = new Dictionary<int, bool>();
                for(int j= 0; j < Drawer.WindowSize; j++)
                {
                    secondMap[i][j] = false;
                }
            }
        }

        static bool HasValueAt(Point at) => secondMap[at.x][at.y];

        public static Tile GetAt(Point getAt)
        {
            if (HasValueAt(getAt))
                return map.ForceValueAt(getAt);
            else
            {
                var toSet = new Tile(Tile.Type.Floor);
                SetAt(toSet, getAt);
                return toSet;
            }
        }

        public static void SetAt(Tile toSet, Point setAt)
        {
            secondMap[setAt.x][setAt.y] = true;
            map.AddAt(toSet, setAt);
        }

        public static void ModifyAt(Tile toSet, Point modifyAt)
        {
            SetAt(toSet, modifyAt);
            modifiedPoints.Add(modifyAt);
        }

        public static void ResetAt(Point resetAt)
        {
            if (GetAt(resetAt).type != Tile.Type.Floor)
            {
                ModifyAt(new Tile(Tile.Type.Floor), resetAt);
            }
        }

        public static void MoveFromTo(Point from, Point to)
        {
            var original = GetAt(from);
            var overriding = GetAt(to);
            if (!original.EquivelentForDrawing(overriding))
                ModifyAt(original, to);
            ResetAt(from);
        }

        public static void Loop()
        {
            modifiedPoints.Clear();
        }
    }
}
