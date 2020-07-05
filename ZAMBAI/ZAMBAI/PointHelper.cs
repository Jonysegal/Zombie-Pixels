using System;
using System.Collections.Generic;
using System.Linq;

namespace Pixel_zombies
{
    public static class PointHelper
    {
        public static readonly Point ZeroPoint = new Point(0, 0);

        public static Point PointOffsetBy(Point p, Point offset) => new Point(p.x + offset.x, p.y + offset.y);

        public static Point PointExbandedBy(Point p, int expandBy) => new Point(p.x * expandBy, p.y * expandBy);

        public static Point PointInDirectionBy(Point point, Direct.Direction direction, int moveBy) => PointOffsetBy(point, PointExbandedBy(Direct.DirectionPointMap[direction], moveBy));

        public static Point PointInDirection(Point point, Direct.Direction direction) => PointInDirectionBy(point, direction, 1);

        public static List<Point> PointsInSquareAround(Point origin, int radius)
        {
            List<Point> toReturn = new List<Point>();

            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    toReturn.Add(PointOffsetBy(origin, new Point(i, j)));
                }
            }
            return toReturn;
        }
        public static IEnumerable<Point> PointsInDirections(Point start, List<Direct.Direction> directions) => directions.Select(x => PointInDirection(start, x));

        public static IEnumerable<Point> PointsInCardinalDirections(Point start) => PointsInDirections(start, Direct.CardinalDirections);

        public static IEnumerable<Point> PointsInDiagonalDirections(Point start) => PointsInDirections(start, Direct.DiagonalDirections);

        public static Point MidpointOf(Point a, Point b) => new Point((a.x + b.x) / 2, (a.y + b.y) / 2);

        //Goes from lower left of the definied rectangle to upper right of the defined rectangle
        //Eg a = (-1, 1) b = (1, -1) would go (-1, -1), (0, -1), (1, -1), (-1, 0), (0, 0), (1, 0), (-1, 1), (0, 1), (1, 1)
        public static List<Point> PointsInRegionBetween(Point a, Point b)
        {
            var toReturn = new List<Point>();
            for(int yPos = Math.Min(a.y, b.y); yPos <= Math.Max(a.y, b.y); yPos++) {
                for (int xPos = Math.Min(a.x, b.x); xPos <= Math.Max(a.x, b.x); xPos++)
                {
                    toReturn.Add(new Point(xPos, yPos));
                }
            }
            return toReturn;
        }

        public static List<Point> PointsAroundPoint(Point point, int rad) => PointHelper.PointsInSquareAround(point, rad);

        public static IEnumerable<Point> EmptyPointsAroundPoint(Point point, int rad = 1) => PointsAroundPoint(point, rad).Where(FullMap.DoesNotHaveEntityAt);

        public static IEnumerable<Point> OccupiedPointsAroundPoint(Point point, int rad = 1) => PointsAroundPoint(point, rad).Where(FullMap.HasEntityAt);

        public static IEnumerable<Point> SoldierPointsAroundPoint(Point point, int rad = 1) => OccupiedPointsAroundPoint(point, rad).Where(x => FullMap.GetAt(x).IsZombo());

        public static IEnumerable<Zombo> ZombosFromPoints(IEnumerable<Point> points) => points.Select(x => (Zombo)FullMap.GetAt(x));

        //TODO: will this cast keep the valus that it had when put into the fullmap or defualt like as a new zombo?

        public static IEnumerable<Zombo> ZombosAroundPoint(Point point, int rad = 1) => ZombosFromPoints(SoldierPointsAroundPoint(point, rad));

    }

}
