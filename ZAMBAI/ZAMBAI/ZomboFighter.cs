using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    public static class ZomboFighter
    {
        public static void FightForZombo(Zombo fightFor)
        {
            if (fightFor.IsZombie())
                FightForMelee(fightFor);
            else if (fightFor.IsRanged())
                FightForRanged(fightFor);
        }
        static void FightForMelee(Zombo fightFor)
        {
            var killTargets = PointHelper.ZombosAroundPoint(fightFor.location).Where(x => x.alliance != fightFor.alliance);
            if (killTargets.Any())
                EntityControl.Kill(ListHelper.RandomElementInEnumerable(killTargets));

        }
        static void FightForRanged(Zombo fightFor)
        {
            for (int i = 0; i < 1; i++)
            {
                var killTargets = PointHelper.ZombosAroundPoint(fightFor.location, 3).Where(x => x.alliance != fightFor.alliance);
                if (killTargets.Any())
                {
                    EntityControl.Kill(ListHelper.RandomElementInEnumerable(killTargets));
                    ZomboFoodManager.IncrementFoodFor(fightFor, 1);
                }
            }
        }
    }
}
