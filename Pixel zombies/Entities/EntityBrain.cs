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

        public static List<PointTyle> PointTylesAroundEntity(PointTyle entity) => PointHelper.PointTylesFrom(PointsAroundEntity(entity));

        public static List<PointTyle> EmptyPointTylesAroundEntity(PointTyle entity) => PointTylesAroundEntity(entity).Where(x => x.tile.type == Tile.Type.Floor).ToList();

        public static List<PointTyle> SoldierPointTylesAroundEntity(PointTyle entity) => PointTylesAroundEntity(entity).Where(x => x.tile.type == Tile.Type.Soldier).ToList();

    }
}
