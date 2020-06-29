using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    public class Entity
    {
        public PointTyle pointTile;
        
        public Entity(Tile values, Point location)
        {
            pointTile = new PointTyle(location, values);
        }
    }
}
