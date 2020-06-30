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
            var killTargets = EntityBrain.SoldierPointTylesAroundEntity(entity.pointTile).Where(x => x.tile.alliance != entity.Alliance);
            if (killTargets.Count() > 0)
                EntityControl.Kill(ListHelper.RandomElementInEnumerable(killTargets));

        }
        static void FightForRanged(Entity entity)
        {

        }
    }
}
