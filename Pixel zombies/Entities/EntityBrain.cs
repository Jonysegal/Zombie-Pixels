using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    public static class EntityBrain
    {
        public static List<Point> PointsAroundPoint(Point point, int rad) => PointHelper.PointsInSquareAround(point, rad);

        public static IEnumerable<PointTyle> PointTylesAroundPoint(Point point, int rad) => PointHelper.PointTylesFrom(PointsAroundPoint(point, rad));

        public static IEnumerable<PointTyle> EmptyPointTylesAroundPoint(Point point) => PointTylesAroundPoint(point, 1).Where(x => x.tile.type == Tile.Type.Floor);

        public static IEnumerable<PointTyle> SoldierPointTylesAroundPoint(Point point, int rad) => PointTylesAroundPoint(point, rad).Where(x => x.tile.type == Tile.Type.Soldier);

    }
}
