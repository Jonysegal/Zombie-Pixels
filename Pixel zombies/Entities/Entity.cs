using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    public class Entity
    {
        public Point location;

        public enum EntityType {Wall, Zombo};

        public EntityType entityType = EntityType.Wall;

        public bool overridesColor = false;

        public Color overrideColor;

        public Entity(EntityType type, Point point)
        {
            entityType = type;
            location = point;
        }

        public bool IsZombo() => entityType == EntityType.Zombo;

        public bool IsWall() => entityType == EntityType.Wall;

    }
}
