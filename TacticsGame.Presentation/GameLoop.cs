using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Enums;
using TacticsGame.Logic.Models.GameUI;
using TacticsGame.Logic.Models.GameUI.Menus;
using TacticsGame.Logic.Models.Maps;

namespace TacticsGame.Presentation
{
    
    public class GameLoop
    {
        public bool GameRunning { get; set; }
        public GameState GameState { get; set; }

        public void RunGameLoop(GameLoop game)
        {
            SetupMenus setup = new SetupMenus();
            //InGame inGame = new InGame();
            Map map = new Map();
            GameRunning = true;
            do
            {
                switch (GameState)
                {
                    case GameState.MainMenu:
                        break;
                    //case GameState.MapSetupMenu:
                    //    setup.MapSetup(game, out game, out map);
                    //    break;
                    //case GameState.OptionsMenu:
                    //    SettingsMenu();
                    //    break;
                    //case GameState.InGameField:
                    //    //here: new class that handles the InGame loop.
                    //    //inGame.InGameField(game, map);
                    //    break;
                    default:
                        break;
                }
                MainMenu();
            } while (GameRunning);
        }//AppRunLoop

        //Moved MainMenu to its own method
        public void MainMenu()
        {
            //Creating some instances of the custom class MenuItem for presentation helper scaffolding
            //MenuItem itemOne = new MenuItem("Start a game", "P");
            //MenuItem itemTwo = new MenuItem("Settings", "S");
            //MenuItem itemThree = new MenuItem("Exit", "X");
            bool choiceMade = false;

            //Since the CenteredMenu method takes a List of MenuItems we add our chosen items to a list 
            List<MenuItem> menuItems = new List<MenuItem>();
            //menuItems.Add(itemOne);
            //menuItems.Add(itemThree);
            //menuItems.Add(itemTwo);

            //Here we are calling the CenteredMenu() which takes as explained above
            //Takes a list of MenuItems and a string to use as the menu title
            PresentationHelpers.CenteredMenu(menuItems, "Main Menu");

            do
            {
                string userInput = System.Console.ReadLine().ToUpper();
                switch (userInput)
                {
                    //case "P":
                    //    GameState = GameState.MapSetupMenu;
                    //    choiceMade = true;
                    //    break;
                    //case "S":
                    //    GameState = GameState.OptionsMenu;
                    //    choiceMade = true;
                    //    break;
                    case "X":
                        System.Console.WriteLine("Thanks for playing!");
                        GameRunning = false;
                        choiceMade = true;
                        break;
                    default:
                        PresentationHelpers.InvalidSelectionMessage();
                        break;
                }
            } while (!choiceMade);
        }//end Main Menu

        public void SettingsMenu()
        {
            //MenuItem item1 = new MenuItem("Stuff", "S");
            //MenuItem item2 = new MenuItem("Exit", "X");
            bool exit = false;

            List<MenuItem> items = new List<MenuItem>();
            //items.Add(item1);
            //items.Add(item2);
            PresentationHelpers.CenteredMenu(items, "Settings");

            do
            {
                string userInput = System.Console.ReadLine().ToUpper();
                switch (userInput)
                {
                    case "S":
                        System.Console.WriteLine("Stuff happens");
                        break;
                    case "X":
                        System.Console.WriteLine("Bye");
                        exit = true;
                        break;
                    default:
                        PresentationHelpers.InvalidSelectionMessage();
                        break;
                }
            } while (!exit);
        }
    }
}
