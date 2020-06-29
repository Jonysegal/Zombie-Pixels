using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    public static class EntityControl
    {
        public static List<Entity> Entities = new List<Entity>();

        static EntityControl()
        {
            MakeEntityAt(new Tile(Tile.Type.Soldier, Tile.Alliance.Blue), new Point(100, 100));
        }

        static void MakeEntityAt(Tile values, Point addAt)
        {
            var newEntity = new Entity(values, addAt);
            Entities.Add(newEntity);
            FullMap.SetAt(values, addAt);
        }

        public static void Loop()
        {
            ManageAllEntities();
        }

        static void ManageAllEntities()
        {
            var AllEntitiesAtStart = new List<Entity>(Entities);

            foreach(var entity in AllEntitiesAtStart)
            {
                ManageEntity(entity);
            }
        }

        static void ManageEntity(Entity toManage)
        {
            EntityRandomWalker.RandomWalkEntity(toManage);
        }
    }
}
