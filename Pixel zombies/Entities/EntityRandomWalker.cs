using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    public static class EntityRandomWalker
    {
        public static void RandomWalkEntity(Entity toWalk)
        {
            var options = EntityBrain.EmptyPointTylesAroundEntity(toWalk.pointTile);
            
            if(options.Count() > 0)
            {
                var moveTo = ListHelper.RandomElementInEnumerable(options).point;
                FullMap.MoveFromTo(toWalk.pointTile.point, moveTo);
                toWalk.pointTile.point = moveTo;
            }
        }
    }
}
