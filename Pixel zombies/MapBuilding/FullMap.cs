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

        public static Tile ValueAtPoint(Point at) => map.ValueAt(at);

        public static Tile GetAt(Point getAt)
        {
            var value = map.ValueAt(getAt);
            if (value == null)
            {
                var adding = new Tile(Tile.Type.Floor);
                map.AddAt(adding, getAt);
                return adding;
            }
            else
                return value;
        }

        public static void SetAt(Tile toSet, Point setAt) => map.AddAt(toSet, setAt);

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

        public static List<PointTyle> PointTylesFrom(List<Point> selectFrom) => selectFrom.Select(x => new PointTyle(x, ValueAtPoint(x))).ToList();

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
