using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    public static class EntityBrain
    {
        public static List<Point> PointsAroundEntity(PointTyle entity, int rad) => PointHelper.PointsInSquareAround(entity.point, rad);

        public static IEnumerable<PointTyle> PointTylesAroundEntity(PointTyle entity, int rad) => PointHelper.PointTylesFrom(PointsAroundEntity(entity, rad));

        public static IEnumerable<PointTyle> EmptyPointTylesAroundEntity(PointTyle entity) => PointTylesAroundEntity(entity, 1).Where(x => x.tile.type == Tile.Type.Floor);

        public static IEnumerable<PointTyle> SoldierPointTylesAroundEntity(PointTyle entity, int rad) => PointTylesAroundEntity(entity, rad).Where(x => x.tile.type == Tile.Type.Soldier);

    }
}
