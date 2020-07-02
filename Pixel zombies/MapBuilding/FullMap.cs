using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    public static class FullMap
    {
        public static List<Point> modifiedPoints = new List<Point>();

        static GenericLocalMap<Entity> map = new GenericLocalMap<Entity>();

        static Dictionary<int, Dictionary<int, bool>> hasEntityMap = new Dictionary<int, Dictionary<int, bool>>();

        static FullMap()
        {
            for(int i=0; i < Drawer.WindowSize; i++)
            {
                hasEntityMap[i] = new Dictionary<int, bool>();
                for(int j= 0; j < Drawer.WindowSize; j++)
                {
                    hasEntityMap[i][j] = false;
                }
            }
        }

        public static bool DoesNotHaveEntityAt(Point at) => !HasEntityAt(at);

        public static bool HasEntityAt(Point at) => hasEntityMap[at.x][at.y];

        /// <summary>
        /// Not dictionary safe. if getAt doesn't actually have an entity this will do bad icky things.
        /// </summary>
        /// <param name="getAt"></param>
        /// <returns></returns>
        public static Entity GetAt(Point getAt) => map.ForceValueAt(getAt);

        public static void SetAt(Entity toSet)
        {
            hasEntityMap[toSet.location.x][toSet.location.y] = true;
            map.AddAt(toSet, toSet.location);
        }

        static void NotifyOfModification(Point notifyAt) => modifiedPoints.Add(notifyAt);

        public static void ResetAt(Point resetAt)
        {
            if(HasEntityAt(resetAt))
            {
                hasEntityMap[resetAt.x][resetAt.y] = false;
                NotifyOfModification(resetAt);
            }
        }

        public static void Loop()
        {
            modifiedPoints.Clear();
        }
    }
}
