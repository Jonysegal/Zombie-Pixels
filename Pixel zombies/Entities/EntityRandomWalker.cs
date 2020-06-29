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
            var options = EntityBrain.EmptyPointTylesAroundEntity(toWalk.location);
            
            if(options.Count > 0)
            {
                var moveTo = ListHelper.RandomElementInList(options).point;
                FullMap.MoveFromTo(toWalk.location.point, moveTo);
                toWalk.location.point = moveTo;
            }
        }
    }
}
