using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Enums;

namespace TacticsGame.Logic.Models.Maps
{
    public class TileType
    {
        private int _moveCost;

        public string Name { get; set; }
        public string Nickname { get; set; }
        public int MoveCost
        {
            get { return _moveCost; }
            set
            {
                if (value <= 0)
                {
                    //TODO: change this back to a regular number after everythin gis set place
                    _moveCost = 9999;
                }
                else
                {
                    _moveCost = value;
                }
            }
        }


        public TileType()
        {
            Name = "";
            Nickname = "";
            MoveCost = 0;
        }

        public TileType(string name, string nickname, int moveCost)
        {
            Name = name;
            Nickname = nickname;
            MoveCost = moveCost;
        }

        public static TileType Nothing()
        {
            TileType tileType = new TileType();
            tileType.Name = "Nothing";
            tileType.Nickname = "Non";
            tileType.MoveCost = 10;
            return tileType;
        }

        public static TileType Ladder()
        {
            TileType tileType = new TileType();
            tileType.Name = "Ladder";
            tileType.Nickname = "Lad";
            tileType.MoveCost = 1;
            return tileType;
        }

        public static TileType LockedDoor()
        {
            TileType tileType = new TileType();
            tileType.Name = "LockedDoor";
            tileType.Nickname = "LDr";
            tileType.MoveCost = 1;
            return tileType;
        }

        public static TileType Plains()
        {
            TileType tileType = new TileType();
            tileType.Name = "Plains";
            tileType.Nickname = "Pln";
            tileType.MoveCost = 1;
            return tileType;
        }

        public static TileType Wall()
        {
            TileType tileType = new TileType();
            tileType.Name = "Wall";
            tileType.Nickname = "Wal";
            tileType.MoveCost = 10;
            return tileType;
        }

        public static TileType Grassland()
        {
            TileType tileType = new TileType();
            tileType.Name = "Grassland";
            tileType.Nickname = "Gra";
            tileType.MoveCost = 1;
            return tileType;
        }

        public static TileType Tree()
        {
            TileType tileType = new TileType();
            tileType.Name = "Tree";
            tileType.Nickname = "Tre";
            tileType.MoveCost = 10;
            return tileType;
        }

        //public static void Grassland(TileType tileType)
        //{
        //    tileType.Name = "Grassland";
        //    tileType.Nickname = "Gra";
        //    tileType.MoveCost = 1;
        //}

        //public static void Tree(TileType tileType)
        //{
        //    tileType.Name = "Tree";
        //    tileType.Nickname = "Tre";
        //    tileType.MoveCost = 10;
        //}

        //public static void Mountain(TileType tileType)
        //{
        //    tileType.Name = "Mountain";
        //    tileType.Nickname = "Mnt";
        //    tileType.MoveCost = 1;
        //}

        //public static void Wall(TileType tileType)
        //{
        //    tileType.Name = "Wall";
        //    tileType.Nickname = "Wal";
        //    tileType.MoveCost = 10;
        //}



        public override string ToString()
        {
            return Name;
        }
    }
}
