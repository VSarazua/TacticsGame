using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Models.Maps;

namespace TacticsGame.Presentation
{
    public class MapPresets
    {
        /// <summary>
        /// Creates a 5x5 forest themed environment.
        /// </summary>
        /// <returns></returns>
        public static Map ForestPreset()
        {
            Map map = new Map(5, 5, 10);
            TileType defaultTileType = new TileType("Grassland", "Gra", 0);

            map.GenerateMapArray(defaultTileType);

            //blackout lower lefthand corner
            map.MapNodes[0, 0].TileType = TileType.Nothing();
            map.MapNodes[0, 1].TileType = TileType.Nothing();
            map.MapNodes[1, 0].TileType = TileType.Nothing();

            //blackout upper righthand corner
            map.MapNodes[4, 4].TileType = TileType.Nothing();
            map.MapNodes[4, 3].TileType = TileType.Nothing();
            map.MapNodes[3, 4].TileType = TileType.Nothing();

            //Stylistic black spaces
            map.MapNodes[1, 3].TileType = TileType.Nothing();
            map.MapNodes[4, 0].TileType = TileType.Nothing();

            //Random trees
            map.MapNodes[2, 3].TileType = TileType.Tree();
            map.MapNodes[1, 1].TileType = TileType.Tree();
            map.MapNodes[0, 4].TileType = TileType.Tree();
            map.MapNodes[4, 1].TileType = TileType.Tree();
            map.MapNodes[2, 0].TileType = TileType.Tree();

            return map;
        }

        public static Map BigPreset()
        {
            Map map = new Map(15, 15, 10);
            TileType defaultTileType = new TileType("Grassland", "Gra", 0);

            map.GenerateMapArray(defaultTileType);

            //blackout lower lefthand corner
            map.MapNodes[0, 0].TileType = TileType.Nothing();
            map.MapNodes[0, 1].TileType = TileType.Nothing();
            map.MapNodes[1, 0].TileType = TileType.Nothing();

            //blackout upper righthand corner
            map.MapNodes[4, 4].TileType = TileType.Nothing();
            map.MapNodes[4, 3].TileType = TileType.Nothing();
            map.MapNodes[3, 4].TileType = TileType.Nothing();

            return map;
        }

        /// <summary>
        /// Creates a 8x3 dungeon themed environment. Narrow corridors, locked doors and ladders.
        /// </summary>
        /// <returns></returns>
        public static Map DungeonPreset()
        {
            Map map = new Map(8, 3, 10);
            TileType defaultTileType = new TileType("Plain", "Pln", 0);
            map.GenerateMapArray(defaultTileType);

            //blackout lower lefthand corner
            map.MapNodes[0, 0].TileType = TileType.Nothing();
            map.MapNodes[7, 0].TileType = TileType.Nothing();
            map.MapNodes[7, 2].TileType = TileType.Nothing();
            map.MapNodes[6, 0].TileType = TileType.Nothing();
            map.MapNodes[5, 1].TileType = TileType.Nothing();
            map.MapNodes[5, 0].TileType = TileType.Nothing();
            map.MapNodes[2, 2].TileType = TileType.Nothing();
            map.MapNodes[2, 0].TileType = TileType.Nothing();
            map.MapNodes[1, 0].TileType = TileType.Nothing();

            //Ladders to different floors
            map.MapNodes[4, 0].TileType = TileType.Ladder();
            map.MapNodes[0, 2].TileType = TileType.Ladder();

            //Locked Doors
            map.MapNodes[2, 1].TileType = TileType.LockedDoor();


            return map;
        }

    }
}
