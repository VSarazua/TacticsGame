using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Enums;
using TacticsGame.Logic.Models.Maps;
using TacticsGame.Logic.Models.Actors;

namespace TacticsGame.Logic.Models.Maps
{
    public class Node
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public TileType TileType { get; set; }
        public Actor ActorOnNode { get; set; }
        //public List<TileAttributes> Attributes { get; set; }

        public Node(int coordinateX, int coordinateY, TileType tileType)
        {
            CoordinateX = coordinateX;
            CoordinateY = coordinateY;
            TileType = tileType;
            //Attributes = new List<TileAttributes>();
        }

        public override string ToString()
        {
            return CoordinateX + "," + CoordinateY;
        }
    }
}
