﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixel_zombies
{
    public class Entity
    {
        public PointTyle pointTile;

        public int FoodCount = 0;

        public static readonly Dictionary<Tile.SoldierType, int> FoodToCopy = new Dictionary<Tile.SoldierType, int>()
        {
            {Tile.SoldierType.Zombie, 15 },
            {Tile.SoldierType.Ranged, 7 }
        };
        
        public static readonly Dictionary<Tile.SoldierType, int> PassiveFood = new Dictionary<Tile.SoldierType, int>()
        {
            {Tile.SoldierType.Zombie, 1 },
            {Tile.SoldierType.Ranged, 0 }
        };
        
        public Entity(Tile values, Point location)
        {
            pointTile = new PointTyle(location, values);
        }

        public Tile.SoldierType SoldierType
        {
            get => pointTile.tile.soldierType;
        }

        public Tile.Alliance Alliance
        {
            get => pointTile.tile.alliance;
        }

    }
}
