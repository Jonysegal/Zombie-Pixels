using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using static Pixel_zombies.Zombo;
using static Pixel_zombies.Entity;

namespace Pixel_zombies
{
    public static class EntityControl
    {

        static List<Zombo> zombos = new List<Zombo>();

        static EntityControl()
        {
            MakeZomboAt(ZomboType.Zombie, Alliance.Red, new Point(500, 500));
        }

        public static void AddEntityAt(EntityType type, Point addAt)
        {
            var entity = new Entity(type, addAt);
            FullMap.SetAt(entity);
        }

        public static void MakeZomboAt(ZomboType type, Alliance alliance, Point at)
        {
            var zombo = new Zombo(type, alliance, at);
            FullMap.SetAt(zombo);
            zombos.Add(zombo);
        }

        public static void DuplicateZomboAt(Zombo toDuplicate, Point duplicateAt) => MakeZomboAt(toDuplicate.zomboType, toDuplicate.alliance, duplicateAt);

        public static void MoveZomboTo(Zombo zombo, Point moveTo)
        {
            FullMap.ResetAt(zombo.location);
            zombo.location = moveTo;
            FullMap.SetAt(zombo);
        }

        public static void Loop()
        {
            ManageAllZombos();
        }

        static void ManageAllZombos()
        {
            var allZombosAtStart = new List<Zombo>(zombos);

            foreach(var entity in allZombosAtStart)
            {
                ManageZombo(entity);
            }
        }

        static void CullCheck()
        {
            if (StaticRandom.Next(0, 100) == 6)
            {

                Console.WriteLine("CULLING");
                if (zombos.Count > 1000)
                {
                    Cull();
                }
            }
        }

        static void Cull()
        {
            for (int i = zombos.Count - 1; i >= 0; i--)
            {
                if (i % 10 != 0)
                    Kill(zombos[i]);
            }
        }

        public static void Kill(Zombo toKill)
        {
            FullMap.ResetAt(toKill.location);
            zombos.Remove(toKill);
        }

        //TODO: add some killed flag to the zombo killed above to indicate that it shouldn't execute. also affects below

        static void ManageZombo(Zombo toManage)
        {
            ZomboRandomWalker.RandomWalkZombo(toManage);
            ZomboFighter.FightForZombo(toManage);
            ZomboFoodManager.ManageFoodFor(toManage);
        }
    }
}