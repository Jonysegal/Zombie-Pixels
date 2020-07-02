using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    public static class EntityFighter
    {
        public static void FightForEntity(Entity entity)
        {
            if (entity.SoldierType == Tile.SoldierType.Zombie)
                FightForMelee(entity);
            else if (entity.SoldierType == Tile.SoldierType.Ranged)
                FightForRanged(entity);
        }
        static void FightForMelee(Entity entity)
        {
            var killTargets = EntityBrain.SoldierPointTylesAroundPoint(entity.pointTile.point, 1).Where(x => x.tile.alliance != entity.Alliance);
            if (killTargets.Any())
                EntityControl.Kill(ListHelper.RandomElementInEnumerable(killTargets));

        }
        static void FightForRanged(Entity entity)
        {
            for (int i = 0; i < 1; i++)
            {
                var killTargets = EntityBrain.SoldierPointTylesAroundPoint(entity.pointTile.point, 3).Where(x => x.tile.alliance != entity.Alliance);
                if (killTargets.Any())
                {
                    EntityControl.Kill(ListHelper.RandomElementInEnumerable(killTargets));
                    EntityFoodManager.IncrementFoodFor(entity, 1);
                }
            }
        }
    }
}
