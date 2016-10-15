using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Enums;
using TacticsGame.Logic.Models.Managers;

namespace TacticsGame.Logic.Models.GameUI.Menus
{
    public class MenuItem
    {
        public string Name { get; set; }
        public string KeyBinding { get; set; }
        public MenuItemActions Action { get; set; }
        
        

        public MenuItem(string keyBinding, MenuItemActions action)
        {
            Name = action.ToString();
            KeyBinding = keyBinding;
            Action = action;
        }

        public MenuItem(string name, string keyBinding, MenuItemActions action)
        {
            Name = name;
            KeyBinding = keyBinding;
            Action = action;
        }

        public static void CheckAction(MenuItem menuItem, ApplicationController appController)
        {
            switch (menuItem.Action)
            {
                case MenuItemActions.ActorAbility:
                    PerformActorAbility();
                    break;
                case MenuItemActions.GoToPartyScreen:
                    PerformGoToPartyScreen();
                    break;
                case MenuItemActions.NewGame:
                    PerformNewGame();
                    appController.GameState = GameState.InGame;
                    break;
                case MenuItemActions.LoadGame:
                    PerformNewGame();
                    appController.GameState = GameState.InGame;
                    break;
                case MenuItemActions.CustomGame:
                    PerformNewGame();
                    appController.GameState = GameState.InGame;
                    break;
                case MenuItemActions.ExitGame:
                    PerformExitGame();
                    break;
                case MenuItemActions.GoToOptionsMenu:
                    PerformGoToOptionsMenu();
                    break;
                default:
                    //TODO: throw Exception;
                    break;
            }
        }
        public static void PerformActorAbility()
        {

        }

        private static void PerformGoToPartyScreen()
        {
            
        }

        private static void PerformNewGame()
        {
            Console.WriteLine("Performing Play Game stuff.");
        }

        private static void PerformLoadGame()
        {
            Console.WriteLine("Performing Load Game stuff.");
        }

        private static void PerformCustomGame()
        {
            Console.WriteLine("Performing Custom Game stuff.");
        }

        private static void PerformExitGame()
        {

            Environment.Exit(0);
        }

        private static void PerformGoToOptionsMenu()
        {
            Console.WriteLine("Performing options menu stuff.");
        }



        

        

        

    }
}
