using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SFML.Window;

namespace Pixel_zombies
{
    public static class EntityControl
    {
        public static GenericLocalMap<Entity> Entities = new GenericLocalMap<Entity>();

        static EntityControl()
        {
            MakeEntityAt(new Tile(Tile.Type.Soldier, Tile.Alliance.Blue, Tile.SoldierType.Ranged), new Point(488, 512));
            MakeEntityAt(new Tile(Tile.Type.Soldier, Tile.Alliance.Blue, Tile.SoldierType.Ranged), new Point(500, 512));
            MakeEntityAt(new Tile(Tile.Type.Soldier, Tile.Alliance.Blue, Tile.SoldierType.Ranged), new Point(512, 512));
            MakeEntityAt(new Tile(Tile.Type.Soldier, Tile.Alliance.Blue, Tile.SoldierType.Ranged), new Point(488, 500));
            MakeEntityAt(new Tile(Tile.Type.Soldier, Tile.Alliance.Blue, Tile.SoldierType.Ranged), new Point(512, 500));
            MakeEntityAt(new Tile(Tile.Type.Soldier, Tile.Alliance.Blue, Tile.SoldierType.Ranged), new Point(488, 488));
            MakeEntityAt(new Tile(Tile.Type.Soldier, Tile.Alliance.Blue, Tile.SoldierType.Ranged), new Point(500, 488));
            MakeEntityAt(new Tile(Tile.Type.Soldier, Tile.Alliance.Blue, Tile.SoldierType.Ranged), new Point(512, 488));
            MakeEntityAt(new Tile(Tile.Type.Soldier, Tile.Alliance.Red, Tile.SoldierType.Zombie), new Point(500, 500));
        }

        public static void MakeEntityAt(Tile values, Point addAt)
        {
            var newEntity = new Entity(values, addAt);
            Entities.AddAt(newEntity, addAt);
            FullMap.SetAt(values, addAt);
        }

        public static void Loop()
        {
            var all = Entities.All();
            var redCount = all.Where(x => x.Alliance == Tile.Alliance.Red).Count();
            Console.WriteLine(all.Count + " red " + (redCount) + " blue " + (all.Count - redCount));
            ManageAllEntities();
            if (Keyboard.IsKeyPressed(Keyboard.Key.P))
                Entity.FoodToCopy[Tile.SoldierType.Zombie] = 1000000000;
        }

        static void ManageAllEntities()
        {
            var AllEntitiesAtStart = new List<Entity>(Entities.All());

            foreach(var entity in AllEntitiesAtStart)
            {
                ManageEntity(entity);
            }

          
        }

        static void CullCheck()
        {
            if (StaticRandom.Next(0, 100) == 6)
            {

                Console.WriteLine("CULLING");
                var allCount = Entities.All().Count();
                var all = Entities.All();
                if (allCount > 1000)
                {

                    for (int i = allCount - 1; i >= 0; i--)
                    {
                        if (i % 10 != 0)
                            Kill(all[i].pointTile);
                    }
                }
            }
        }

        public static void Kill(PointTyle kill)
        {
            FullMap.ResetAt(kill.point);
            Entities.ValueAt(kill.point).pointTile.tile.type = Tile.Type.Floor;
            Entities.map[kill.point.x].Remove(kill.point.y);
        }

        //TODO: fucking fix the map and entity movement

        static void ManageEntity(Entity toManage)
        {
            //Can be set to floor when the entity is killed
            if (toManage.pointTile.tile.type == Tile.Type.Floor)
                return;
            var startPoint = toManage.pointTile.point;
            Entities.map[startPoint.x].Remove(startPoint.y);

            EntityRandomWalker.RandomWalkEntity(toManage);
            EntityFighter.FightForEntity(toManage);
            EntityFoodManager.ManageFoodFor(toManage);

            Entities.AddAt(toManage, toManage.pointTile.point);
        }
    }
}
