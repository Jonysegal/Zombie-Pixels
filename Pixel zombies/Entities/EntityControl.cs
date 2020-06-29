using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace Pixel_zombies
{
    public static class EntityControl
    {
        public static GenericLocalMap<Entity> Entities = new GenericLocalMap<Entity>();

        static EntityControl()
        {
            MakeEntityAt(new Tile(Tile.Type.Soldier, Tile.Alliance.Blue), new Point(100, 100));
            MakeEntityAt(new Tile(Tile.Type.Soldier, Tile.Alliance.Red), new Point(105, 100));
            MakeEntityAt(new Tile(Tile.Type.Soldier, Tile.Alliance.Blue), new Point(110, 100));
            MakeEntityAt(new Tile(Tile.Type.Soldier, Tile.Alliance.Red), new Point(115, 100));
        }

        static void MakeEntityAt(Tile values, Point addAt)
        {
            var newEntity = new Entity(values, addAt);
            Entities.AddAt(newEntity, addAt);
            FullMap.SetAt(values, addAt);
        }

        public static void Loop()
        {
            Console.WriteLine(Entities.All().Count);
            ManageAllEntities();
        }

        static void ManageAllEntities()
        {
            var AllEntitiesAtStart = new List<Entity>(Entities.All());

            foreach(var entity in AllEntitiesAtStart)
            {
                ManageEntity(entity);
            }
        }

        public static void Kill(PointTyle kill)
        {
            Console.WriteLine("killing ");
            FullMap.ResetAt(kill.point);
            Entities.ValueAt(kill.point).pointTile.tile.type = Tile.Type.Floor;
            Entities.map[kill.point.x].Remove(kill.point.y);
        }

        static void ManageEntity(Entity toManage)
        {
            //Can be set to floor when the entity is killed
            if (toManage.pointTile.tile.type == Tile.Type.Floor)
                return;
            var startPoint = toManage.pointTile.point;
            Entities.map[startPoint.x].Remove(startPoint.y);
            EntityRandomWalker.RandomWalkEntity(toManage);
            EntityFighter.FightForEntity(toManage);
            Entities.AddAt(toManage, toManage.pointTile.point);
        }
    }
}
