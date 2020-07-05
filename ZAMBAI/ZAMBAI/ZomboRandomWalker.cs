using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    public static class ZomboRandomWalker
    {
        public static void RandomWalkZombo(Zombo toWalk)
        {
            var options = PointHelper.EmptyPointsAroundPoint(toWalk.location);
            
            if(options.Any())
            {
                var moveTo = ListHelper.RandomElementInEnumerable(options);
                EntityControl.MoveZomboTo(toWalk, moveTo);
            }
        }

      
    }
}
