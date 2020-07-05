using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    public class Zombo : Entity
    {
        public enum Alliance { Red, Blue, Green };

        public int FoodCount = 0;

        public enum ZomboType { Zombie, Ranged }

        public Alliance alliance;

        public ZomboType zomboType;

        public Zombo(ZomboType type, Alliance alliance, Point point) : base(EntityType.Zombo, point)
        {
            this.alliance = alliance;
            zomboType = type;
            ColorControl.OverrideColorForZombo(this);
        }

        public bool IsZombie() => zomboType == ZomboType.Zombie;

        public bool IsRanged() => zomboType == ZomboType.Ranged;
    }
}
