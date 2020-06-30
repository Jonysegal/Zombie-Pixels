using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    public static class EntityBrain
    {
        public static List<Point> PointsAroundEntity(PointTyle entity) => PointHelper.PointsInSquareAround(entity.point, 1);

        public static IEnumerable<PointTyle> PointTylesAroundEntity(PointTyle entity) => PointHelper.PointTylesFrom(PointsAroundEntity(entity));

        public static IEnumerable<PointTyle> EmptyPointTylesAroundEntity(PointTyle entity) => PointTylesAroundEntity(entity).Where(x => x.tile.type == Tile.Type.Floor);

        public static IEnumerable<PointTyle> SoldierPointTylesAroundEntity(PointTyle entity) => PointTylesAroundEntity(entity).Where(x => x.tile.type == Tile.Type.Soldier);

    }
}
