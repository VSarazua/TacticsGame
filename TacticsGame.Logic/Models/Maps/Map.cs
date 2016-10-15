using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Models.Actors;
using TacticsGame.Logic.Models.Maps;

namespace TacticsGame.Logic.Models.Maps
{
    public class Map
    {
        private int _mapX;
        private int _mapY;
        private int _mapUnitLimit;

        public Node[,] MapNodes { get; set; }
        //JON: I added this as a framework for turn order and determining
        //when the player is forced to engage in combat. 
        public List<Actor> ActorsOnMap { get; set; }

        public int MapX
        {
            get
            {
                return _mapX;
            }
            set
            {
                if (value >= 0)
                {
                    _mapX = value;
                }
                else
                {
                    _mapX = 4;
                }
            }
        }
        public int MapY
        {
            get { return _mapY; }
            set
            {
                if (value >= 0)
                {
                    _mapY = value;
                }
                else
                {
                    _mapY = 4;
                }
            }
        }
        public int MapUnitLimit
        {
            get { return _mapUnitLimit; }
            //Added unit limit to map to prevent overpopulation
            set
            {
                if (value < (MapY * MapX)/2 )
                {
                    _mapUnitLimit = value;
                }
                else
                {
                    _mapUnitLimit = 0;
                }
            }
        }
        

        public Map(int sizeX, int sizeY, int unitLimit)
        {
            MapX = sizeX;
            MapY = sizeY;
            MapUnitLimit = unitLimit;
        }

        public Map()
        {
            MapX = 0;
            MapY = 0;
            MapUnitLimit = 1;
            ActorsOnMap = new List<Actor>();
        }

        public void GenerateMapArray(TileType tileType)
        {
            MapNodes = new Node[MapX, MapY];

            for (int y = 0; y < MapY; y++)
            {
                for (int x = 0; x < MapX; x++)
                {
                    Node node = new Node(x, y, tileType);
                    
                    MapNodes[x, y] = node;
                }
            }
        }

        /// <summary>
        /// Goes through each node, collects all actors on the map, then adds them to an unsorted list.
        /// </summary>
        /// <param name="map"></param>
        public void UpdateActorsOnMap()
        {
            //testing if initializing the list is required.
            ActorsOnMap.Clear();
            for (int y = 0; y < MapY; y++)
            {
                for (int x = 0; x < MapX; x++)
                {
                    try
                    {
                        //Simply tries to add all the actors on each node (should only be one, if any) to the 
                        //list. There's potential for null values, hence the need for a try catch.

                        //Apparently you can add null values to a List<> as a new item. I had to write this 
                        //if statement to make sure it wasn't adding a new null item to the list for each 
                        //node that didn't have an actor on it.
                        if (MapNodes[x, y].ActorOnNode != null)
                        {
                            ActorsOnMap.Add(MapNodes[x, y].ActorOnNode);
                        }//end if
                    }//end try
                    catch (Exception)
                    {
                        //swallow the error, because exceptions will most likely only occur if MapNodes[x, y]
                        //is null. If it is, we're not adding anything to the list anyway.
                        Console.Write("Error in Map.cs, UpdateActorsOnMap(map)");
                        //TODO: JON: We'll actually have to go through near the end of development and 
                        //implement logging to each of our try catches. And probably work more on creating
                        //other trycatches to help with debugging. Also we'll need to make sure each trycatch
                        //is checking for exceptions that are specific as possible, instead of checking
                        //for any exception.

                    }//end catch
                }//end for x
            }//end for y
        }//end UpdateActorsOnMap(Map)

        //Gonna have this be in the TurnOrderManager later.
        //public void SortActorsOnMapByAgility()
        //{
        //    //Used to create the turn order. Since there's potential for null values, we'll need a trycatch again.
        //    try
        //    {
        //        ActorsOnMap.Sort((x, y) => x.Strength.CompareTo(y.Strength));
        //    }
        //    catch (Exception)
        //    {
        //        //swallow the error again.
        //    }

        //}

        public void CalculateMapSettings()
        {
            //Console.WriteLine("-=Rows=-: {0}\t-=Columns=-: {1}\n-=Spaces Available=-: {2}\n-=Unit Limit=-: {3}",
            //    MapY,
            //    MapX,
            //   (MapX * MapY),
            //    MapUnitLimit);
        }

    }
}
