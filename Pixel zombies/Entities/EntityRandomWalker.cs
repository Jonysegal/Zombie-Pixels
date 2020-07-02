﻿using System;
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
            var options = EntityBrain.EmptyPointTylesAroundPoint(toWalk.pointTile.point);
            
            if(options.Any())
            {
                var moveTo = ListHelper.RandomElementInEnumerable(options).point;
                FullMap.MoveFromTo(toWalk.pointTile.point, moveTo);
                toWalk.pointTile.point = moveTo;
            }
        }
    }
}
