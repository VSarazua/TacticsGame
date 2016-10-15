using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Models.Maps;
using TacticsGame.Logic.Models.Managers;
using TacticsGame.Logic.Enums;
using TacticsGame.Logic.Models.GameUI;
using TacticsGame.Logic.Models.GameUI.Menus;

namespace TacticsGame.Presentation.GameLoops
{
    public static class InGameLoop
    {
        //Let's just start with my goal for the Loop classes. I've been banging my head against
        //it for a while now and haven't had the best luck. I can't find a way to implement the
        //loops without violating the DRY principle and having a lot of hard-coded switch 
        //statements.

        //Additionally, I can't write a block of code in these loops without running into a 
        //game design concern. Just ahead is the InGame() that determines whether or not the 
        //player is considered "in combat". That alone is a pretty big deal, since it's the 
        //basis for any sort of stealth system or conditions for being forced into combat.

        //Just having a split between "Exploration Mode" and "Combat Mode" is significant. 
        //F


        public static void InGame(ApplicationController gameManager)
        {
            //So this class is a simple decider. There's going to be a fork in the road, and
            //this class choses the path. If the player is "in combat", then it'll enter the
            //InGameCombat loop. If not, then it'll enter the InGameExplorationLoop.

            do
            {
                //As it stands now, the game's asking, "Are there any enemies on the map AT ALL?"
                //if so, combat. if not, exploration. Simple, but we'll have to revisit this
                //code if we have any sort of complexity when it comes to initiating encounters.
                //if (CheckForEnemiesOnMap(gameManager))
                //{
                //    InGameCombat(gameManager);
                //}
                //else
                //{
                //    InGameExploration(gameManager);
                //}

                //***Notes*** We don't need any presentation formatting within InGame(), since
                //it just points to either InGameCombat() or InGameExploration(). All the 
                //formatting and presentation logic can be positioned there.
                
            } while (gameManager.GameState == GameState.InGame );//end dowhile
        }//end InGame()

        public static void InGameExploration(ApplicationController gameManager)
        {
            do
            {
                //check to break loop? The CheckInGameLoop method checks the gameManager's
                //GameState prop. If it == InGame, then it returns true. The if statement
                //is checking if the GameState is NOT InGame, and if it's not, it'll break
                //out of the exploration loop. This could definitely use some refactoring.
                if (!CheckInGameLoop(gameManager))
                {
                    break;
                }

                //Things that need to be done in the loop:
                //clear the window.
                Console.Clear();

                //Display "header" that tells you that you're not in combat.

                //display the map
                //PresentationHelpers.DisplayMap(gameManager.CurrentMap);

                //display list of actors on map

                //display appropriate options for the player while exploring.
                //This was my attempt at an Object Oriented approach. I'm not happy with it,
                //but it lead me to an idea. I was thinking we'd have a list of PlayerOptions
                //in the database/xml files based on a class similar to your MenuItems class,
                //with a name, hotkey, and maybe more (like what action it's supposed to take,
                //or conditions to be able to use the ability or whatever).
                //For example: "Interact", "I", Interact(Object target) or something.
                DisplayPlayerOptions_Exploraton();
                //I think that we don't really need a
                //gameManager at all if we just have the presentation layer refer to the data
                //layer's xml to find out what the current map/gameState/whatever is, right?
                

                //***Big Problem***
                //This is where all the loops can't be object oriented. They each use a switch
                //switch statement in order to check for user input. Then they have to use that 
                //input to redirect the player to the intended state. If we go with my idea for
                //DisplayPlayerOptions, then we'd just need a for each loop, right? Send a list
                //of all the player's options based on the gameState and conditions, then 
                //iterate through to put them on screen. Then save the next user input, and check
                //it against the name/hotkey of each item in the list of available options, then,
                //if there's a match, call the action associated with that item.
                bool choiceMade = false;
                do
                {
                    string userInput = System.Console.ReadLine().ToUpper();
                    switch (userInput)
                    {
                        case "X":
                            System.Console.WriteLine("Thanks for playing!");
                            choiceMade = true;
                            break;
                        default:
                            PresentationHelpers.InvalidSelectionMessage();
                            break;
                    }
                } while (!choiceMade);
            } while (true);//end dowhile
        }//end InGameExploration

        public static void DisplayPlayerOptions_Exploraton()
        {
            //MenuItem interact = new MenuItem("Interact", "I");
            //MenuItem move = new MenuItem("Move", "M");
            //MenuItem partyMenu = new MenuItem("Party Menu", "P");

            List<MenuItem> menuItems = new List<MenuItem>();
            //menuItems.Add(interact);
            //menuItems.Add(move);
            //menuItems.Add(partyMenu);

            //PresentationHelpers.DisplayOptions(menuItems);
            
        }

        public static void InGameCombat(ApplicationController gameManager)
        {
            do
            {
                //check to break loop.
                if (!CheckInGameLoop(gameManager))
                {
                    break;
                }
                //clear the window.
                Console.Clear();
                //Display "header" that tells you that you're in combat.
                //display the map
                //PresentationHelpers.DisplayMap(gameManager.CurrentMap);
                //display list of actors on map
                //display appropriate options for the player while in combat.

            } while (true);//end dowhile
        }//end InGameCombat

        private static bool CheckInGameLoop(ApplicationController gameManager)
        {
            if (gameManager.GameState == GameState.InGame)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public static bool CheckForEnemiesOnMap(ApplicationController gameManager)
        //{
        //    //gameManager.UpdateEnemiesOnMap();
        //    //if (gameManager.MapHasEnemies)
        //    //{
        //    //    return true;
        //    //}
        //    //else
        //    //{
        //    //    return false;
        //    //}
        //}
    }//end InGameLoop.cs
}//namespace
