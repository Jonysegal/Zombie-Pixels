using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    public static class EntityFoodManager
    {
        public static void ManageFoodFor(Entity manageFor)
        {
            PassiveFoodCheck(manageFor);
            DuplicateCheck(manageFor);
        }

        static void PassiveFoodCheck(Entity check)
        {
            IncrementFoodFor(check, Entity.PassiveFood[check.SoldierType]);
        }

        static void DuplicateCheck(Entity check)
        {
            if(check.FoodCount >= Entity.FoodToCopy[check.SoldierType])
            {
                var possiblePoints = EntityBrain.EmptyPointTylesAroundPoint(check.pointTile.point);
                if (possiblePoints.Count() == 8)
                {
                    EntityControl.MakeEntityAt(new Tile(Tile.Type.Soldier, check.Alliance, check.SoldierType), ListHelper.RandomElementInEnumerable(possiblePoints).point);
                    check.FoodCount -= Entity.FoodToCopy[check.SoldierType];
                }
            }
        }

        public static void IncrementFoodFor(Entity incrementFor, int by) => incrementFor.FoodCount += by;
        
      
    }
}
