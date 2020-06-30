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
                check.FoodCount -= Entity.FoodToCopy[check.SoldierType];
                Duplicate(check);
            }
        }

        public static void IncrementFoodFor(Entity incrementFor, int by) => incrementFor.FoodCount += by;
        
        static void Duplicate(Entity duplicateFor)
        {
            var possiblePoints = EntityBrain.EmptyPointTylesAroundEntity(duplicateFor.pointTile);
            if (possiblePoints.Any())
                EntityControl.MakeEntityAt(new Tile(Tile.Type.Soldier, duplicateFor.Alliance, duplicateFor.SoldierType), ListHelper.RandomElementInEnumerable(possiblePoints).point);
            

        }
    }
}
