using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    public class Entity
    {
        public PointTyle location;
        
        public Entity()
        {
            location = new PointTyle(new Point(0, 0), new Tile(Tile.Type.Soldier, Tile.Alliance.Blue));
        }
    }
}
