using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pixel_zombies.Zombo;

namespace Pixel_zombies
{
    public static class ZomboFoodManager
    {

        public static readonly Dictionary<ZomboType, int> FoodToCopy = new Dictionary<ZomboType, int>()
        {
            {ZomboType.Zombie, 10 },
            {ZomboType.Ranged, 3 }
        };

        public static readonly Dictionary<ZomboType, int> PassiveFood = new Dictionary<ZomboType, int>()
        {
            {ZomboType.Zombie, 1 },
            {ZomboType.Ranged, 0 }
        };

        public static void ManageFoodFor(Zombo manageFor)
        {
            PassiveFoodCheck(manageFor);
            DuplicateCheck(manageFor);
        }

        static void PassiveFoodCheck(Zombo check)
        {
            IncrementFoodFor(check, PassiveFood[check.zomboType]);
        }

        static void DuplicateCheck(Zombo check)
        {
            if(check.FoodCount >= FoodToCopy[check.zomboType])
            {
                var possiblePoints = PointHelper.EmptyPointsAroundPoint(check.location);
                if (possiblePoints.Count() == 8)
                {
                    EntityControl.DuplicateZomboAt(check, ListHelper.RandomElementInEnumerable(possiblePoints));
                    check.FoodCount -= FoodToCopy[check.zomboType];
                }
            }
        }

        public static void IncrementFoodFor(Zombo incrementFor, int by) => incrementFor.FoodCount += by;
        
      
    }
}
