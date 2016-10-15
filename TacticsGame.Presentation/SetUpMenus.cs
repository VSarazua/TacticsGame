using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic;
using TacticsGame.Logic.Enums;
using TacticsGame.Logic.Models.Maps;

namespace TacticsGame.Presentation
{
    public class SetupMenus
    {
        //PresentationHelpers helper = new PresentationHelpers();

        public void MapSetup(GameLoop game, out GameLoop setupOutGame, out Map setupOutMap)
        {
            Map map = new Map(0, 0, 0);
            TileType grassland = new TileType("Grassland", "Gra", 1);
            TileType nothing = new TileType("Nothing", "Non", 10);
            bool setupComplete = false;
            do
            {
                Console.Clear();
                PresentationHelpers.TitleMessage("MAP SETUP");
                DisplayMapSettings(map);
                Console.WriteLine("Please Select an option:\n(C). Set Columns\t(R). Set Rows\t(U). Set Unit Limit\t(X). Done\t(P)Load Preset\t(D). Display Map");
                try
                {
                    PresentationHelpers.DisplayMap(map);
                }
                catch (Exception)
                {
                    //swallow the exceptions. They'd just be NullReference
                    //and IndexOutOfRange anyway.
                }
                var userInput = Console.ReadLine().ToUpper();
                switch (userInput)
                {
                    case "C":
                        SetupMapX(map);
                        break;
                    case "R":
                        SetupMapY(map);
                        break;
                    case "U":
                        SetUpUnitLimit(map);
                        break;
                    case "D":
                        map.GenerateMapArray(grassland);
                        //map.MapNodes[0, 0].TileType = nothing;
                        //PresentationHelpers.DisplayMap(map);
                        //Console.ReadLine();
                        break;
                    case "P":
                        //I'm hardcoding it now, but we could easily create a method
                        //like SelectPreset() that offers a list of all the 
                        //stuff in our MapPresets class.
                        map = MapPresets.DungeonPreset();
                        //PresentationHelpers.DisplayMap(map);
                        //Console.ReadLine();
                        break;
                    case "X":
                        //game.GameState = GameState.InGameField;
                        setupComplete = true;
                        break;
                    default:
                        PresentationHelpers.InvalidSelectionMessage();
                        break;
                }
            } while (!setupComplete);
            setupOutGame = game;
            setupOutMap = map;

        }//end MapSetup

        public void SetupMapX(Map map)
        {
            bool setupComplete = false;

            do
            {
                Console.WriteLine("Input the Map Size X");
                string userInput = Console.ReadLine();

                try
                {
                    map.MapX = int.Parse(userInput);
                    Console.WriteLine(map.MapX);
                    setupComplete = true;
                }
                catch (FormatException)
                {
                    PresentationHelpers.InvalidSelectionMessage();
                }
            } while (!setupComplete);
        }
        public void SetupMapY(Map map)
        {
            bool setupComplete = false;

            do
            {
                Console.WriteLine("Input the Map Size Y");
                string userInput = Console.ReadLine();

                try
                {
                    map.MapY = int.Parse(userInput);
                    Console.WriteLine(map.MapY);
                    setupComplete = true;
                }
                catch (FormatException)
                {
                    PresentationHelpers.InvalidSelectionMessage();
                }
            } while (!setupComplete);
        }
        public void SetUpUnitLimit(Map map)
        {
            bool setupComplete = false;
            do
            {
                Console.WriteLine("Set Unit Limit\n(the limit on map must be less than half of the total number of spaces available)");
                string userInput = Console.ReadLine();

                try
                {
                    map.MapUnitLimit = int.Parse(userInput);
                    Console.WriteLine(map.MapUnitLimit);
                    setupComplete = true;
                }
                catch (FormatException)
                {
                    PresentationHelpers.InvalidSelectionMessage();
                }
            } while (!setupComplete);
        }

        public void Settings()
        {

        }

        public void DisplayMapSettings(Map map)
        {
            Console.WriteLine("-=Rows=-: {0}\t-=Columns=-: {1}\n-=Spaces Available=-: {2}\n-=Unit Limit=-: {3}",
                map.MapY,
                map.MapX,
               (map.MapX * map.MapY),
                map.MapUnitLimit);
        }
    }
}


