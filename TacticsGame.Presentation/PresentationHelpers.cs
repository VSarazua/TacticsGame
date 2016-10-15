using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic;
using TacticsGame.Logic.Models.Maps;
using TacticsGame.DTO;
using TacticsGame.Logic.Models.GameUI;
using TacticsGame.Logic.Enums;
using TacticsGame.Logic.Models.Managers;
using TacticsGame.Presentation.GameLoops;
using TacticsGame.Logic.Models.GameUI.Menus;

namespace TacticsGame.Presentation
{


    //TODO: Look over display map() and see if we can simplify
    /// <summary>
    /// A class full of helpful templates and predetermined messages to save you keystrokes and sanity :D 
    /// </summary>
    public class PresentationHelpers
    {
        /// <summary>
        /// Adds some decorations to the title as well as some blank lines underneath
        /// </summary>
        /// <param name="m"></param>
        public static void TitleMessage(string m)
        {
            string decorativeText = "---======= " + m + " =======---";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + decorativeText.Length / 2) + "}", decorativeText);
            Console.Write("\n\n\n\n");
        }

        /// <summary>
        /// Shoots a line to the console asking user to try again
        /// </summary>
        public static void InvalidSelectionMessage()
        {
            Console.WriteLine("Invalid selection please try again");
        }

        /// <summary>
        /// A method that creates a centered menu for you. 
        /// </summary>
        /// <param name="menuItems"></param>
        /// <param name="menuTitle"></param>
        public static void CenteredMenu(List<MenuItem> menuItems, string menuTitle)
        {
            Console.Clear();
            TitleMessage(menuTitle);
            foreach (var i in menuItems)
            {
                string menuText = "(" + i.KeyBinding + "). " + i.Name;
                int currentLength = menuText.Length;

                Console.WriteLine("{0," + ((Console.WindowWidth / 2) + i.Name.Length / 2) + "}",
                    menuText);
                Console.Write("\n");
            }
        }

        public static void DisplayOptions(Menu menu)
        {
            foreach (MenuItem menuItem in menu.MenuItems)
            {
                Console.Write("({0}): {1}\t", menuItem.KeyBinding, menuItem.Name);
            }
        }

        public static string AcceptPlayerInput()
        {
            string userInput = "";
            Console.WriteLine("please select an option");
            userInput = Console.ReadLine().ToUpper();

            return userInput;
        }

        public static void DisplayMap(Map map)
        {
            //MAP GRID
            int displayPart = 0;

            //This just creates a row of equal signs to function as the top border.

            for (int y = map.MapY - 1; y >= 0; y--)
            {
                for (int x = 0; x < map.MapX; x++)
                {
                    if (displayPart == 0)
                    {
                        DisplayTilesBorder(map, x, y);
                        if (x == (map.MapX - 1))
                        {
                            Console.WriteLine("");
                            displayPart++;
                            x = 0 - 1;
                        }
                    }
                        else if (displayPart == 1)
                    {
                        DisplayTilesPart1(map, x, y);
                        if (x == (map.MapX - 1))
                        {
                            Console.WriteLine("");
                            displayPart++;
                            x = 0 - 1;
                        }
                    }
                    else if (displayPart == 2)
                    {
                        DisplayTilesPart2(map, x, y);
                        if (x == (map.MapX - 1))
                        {
                            Console.WriteLine("");
                            displayPart++;
                            x = 0 - 1;
                        }
                    }
                    else if (displayPart == 3)
                    {
                        DisplayTilesPart3(map, x, y);
                        if (x == (map.MapX - 1))
                        {
                            Console.WriteLine("");
                            displayPart++;
                            x = 0 - 1;
                        }
                    }
                    else if (displayPart == 4)
                    {
                        DisplayTilesBorder(map, x, y);
                        if (x == (map.MapX - 1))
                        {
                            Console.WriteLine("");
                            displayPart = 0;
                        }
                    }
                    else
                        Console.WriteLine("Something went wrong!");

                }
            }

            //    //Map KEY
            //    for (int y = 0; y < map.MapY; y++)
            //    {
            //        for (int x = 0; x < map.MapX; x++)
            //        {

            //            //Console.WriteLine(map.MapNodes[x,y].ToString());
            //            string output = string.Format("|Cordiantes:{0},{1} =-= TileInfo:{2},{3} ActorID:| ",
            //                map.MapNodes[x, y].CoordinateX,
            //                map.MapNodes[x, y].CoordinateY);
            //                //Generics.PrintList(map.MapNodes[x, y].Attributes),
            //                //Generics.PrintList(map.MapNodes[x, y].TileList));
            //            //map.MapNodes[x,y].ActorID);
            //            Console.WriteLine(output);
            //        }
            //    }
        }

        /// <summary>
        /// In this part, we're going to display the x,y coords and the TileType's 3 letter name.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void DisplayTilesPart1(Map map, int x, int y)
        {
            TileForegroundColorFormatting(map, x, y);
            TileBackgroundColorFormatting(map, x, y);
            Console.Write("|" + map.MapNodes[x, y] + "   " + TryCatchTileNickname(map, x, y) + "|");
            Console.ResetColor();
        }

        /// <summary>
        /// In this part, we're going to display the character's 3 letter nickname.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void DisplayTilesPart2(Map map, int x, int y)
        {
            bool actorOnNode = TryCatchActorOnNode(map, x, y);
            TileForegroundColorFormatting(map, x, y);
            TileBackgroundColorFormatting(map, x, y);

            if (actorOnNode == true)
            {
                
                Console.Write("|" + "char: " + TryCatchActorNickname(map, x, y) + "|");
            }
            else
            {
                Console.Write("|char:    |");
            }
            Console.ResetColor();

        }

        /// <summary>
        /// In this part, we're going to display the character's HP and MP.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void DisplayTilesPart3(Map map, int x, int y)
        {
            bool actorOnNode = TryCatchActorOnNode(map, x, y);
            TileForegroundColorFormatting(map, x, y);
            TileBackgroundColorFormatting(map, x, y);
            if (actorOnNode == true)
            {
                Console.Write("|HP"
                    + HPMPFormatting(TryCatchActorHP(map, x, y))
                    + " "
                    + "MP"
                    + HPMPFormatting(TryCatchActorMP(map, x, y))
                    + "|");
            }
            else
            {
                Console.Write("|         |");
            }
            Console.ResetColor();
        }

        public static void DisplayTilesBorder(Map map, int x, int y)
        {
            TileForegroundColorFormatting(map, x, y);
            TileBackgroundColorFormatting(map, x, y);
            Console.Write("===========");
            Console.ResetColor();
        }

        /// <summary>
        /// Creates a line of equal signs that is proportional to the map's size.
        /// </summary>
        /// <param name="map"></param>
        /// <returns></returns>
        //public static string DisplayTileDecoration(Map map, int x, int y)
        //{
        //    string decoration = "";

        //    TileColorFormatting(map, x, y);
        //    Console.Write("===========");
        //    Console.ResetColor();
        //    //for (int i = 0; i <= map.MapX - 1; i++)
        //    //{
        //    //    decoration += "===========";
        //    //}

        //    return decoration;
        //}

        //------====== LOOP HELPER METHODS ======------
        /// <summary>
        /// Opens a new loop based on the current GameManager's GameState property. Usually called when no loops are open OR immediately after a loop is broken.
        /// </summary>
        public static void LoopRedirect(ApplicationController gameManager)
        {
            switch (gameManager.GameState)
            {
                case GameState.MainMenu:
                    MainMenuLoop.MainMenu(gameManager);
                    break;
                case GameState.InGame:
                    InGameLoop.InGame(gameManager);
                    break;
                default:
                    //Send error? The GameManager should always have a GameState prop
                    //set to something. And since it's a glorious Enum, there wouldn't be
                    //any mix-ups. But for now, let's just set the default to MainMenu, too.
                    MainMenuLoop.MainMenu(gameManager);
                    break;
            }
        }


        //------====== END LOOP HELPER METHODS ======------


        /// <summary>
        /// This is supposed to make sure the actors health/mana is two digits (for display purposes), then convert it into a string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string HPMPFormatting(int input)
        {
            string output = "";

            if (input < 10)
            {
                output += "0";
                output += input.ToString();
            }
            else
            {
                output += input.ToString();
            }
            return output;
        }//end HPMPFormatting

        /// <summary>
        /// Must be called BEFORE TileForegroundColorFormatting(). Sets the text's background to a certain color based on the faction of the actor on the node, if any.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void TileBackgroundColorFormatting(Map map, int x, int y)
        {
            //TODO: JON: Go over with Sarazua. This is rather nitpicky, so we can skip it.
            //Right now, the coloring is based off the actor's faction
            //so that the player can easily see where their characters and enemies are without having
            //to read any text. Additional options (that maaaay be better(?) but harder to do) would be to 
            //have the background reflect who's turn it is currently. So when it's an enemy's turn and the
            //game redraws the map, have their tile appear in DarkRed, then have text at the bottom 
            //describe what he's doing while waiting for the user to press a button to continue. I don't 
            //think we can do both effectively, since colors are very limited. We also don't want the map
            //to be too visually busy, since that defeats the point, so we need to be careful when we're 
            //assigning different background and foreground colors. Perhaps making all points of interest
            //Yellow (or some other color), instead of using yellow for ladders, red for doors, etc.
            try
            {
                if (TryCatchActorFaction(map, x, y))
                {
                    ActorFaction actorFaction = map.MapNodes[x, y].ActorOnNode.Faction;
                    switch (actorFaction)
                    {
                        case ActorFaction.Ally:
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            break;
                        case ActorFaction.Enemy:
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            break;
                        case ActorFaction.Monster:
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                //swallow execption;
            }
            catch (NullReferenceException)
            {
                //swallow execption;
            }
        }

        /// <summary>
        /// Must be called AFTER TileBackgroundColorFormatting(). Set's the text's color based on the node's TileType.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void TileForegroundColorFormatting(Map map, int x, int y)
        {
            if (TryCatchTileNickname(map, x, y) == "Non")
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (TryCatchTileNickname(map, x, y) == "Gra")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else if (TryCatchTileNickname(map, x, y) == "Tre")
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            else if (TryCatchTileNickname(map, x, y) == "Lad")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (TryCatchTileNickname(map, x, y) == "LDr")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ResetColor();
            }
        }


        //I don't know if we really need ANY of these TryCatch methods. We can just
        //have on for TryCatchActor to see if there's an actor there or not. If there
        //is, then we can have other methods calling the trycatch, THEN checking for 
        //stats/factions.
        public static bool TryCatchActorOnNode(Map map, int x, int y)
        {
            string actorNickname = "";
            try
            {
                //Just a way to test if there's an actor on the node.
                actorNickname = map.MapNodes[x, y].ActorOnNode.Name;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            catch (NullReferenceException)
            {
                return false;
            }
            return true;
        }

        public static bool TryCatchActorFaction(Map map, int x, int y)
        {
            bool actorHasFaction = false;
            try
            {
                //Just a way to test if the actor on the node has a faction assigned.
                ActorFaction actorFaction = map.MapNodes[x, y].ActorOnNode.Faction;
                actorHasFaction = true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
            catch (NullReferenceException)
            {
                return false;
            }
            return actorHasFaction;
        }//end TryCatchActorOnNode

        public static string TryCatchActorNickname(Map map, int x, int y)
        {
            string actorNickname = "";
            string exceptionOutput = "   ";
            try
            {
                actorNickname = map.MapNodes[x, y].ActorOnNode.Nickname;
            }
            //catch (IndexOutOfRangeException)
            //{
            //    return exceptionOutput;
            //}
            catch (NullReferenceException)
            {
                return exceptionOutput;
            }

            return actorNickname;
        }//end TryCatchActorNickname

        public static int TryCatchActorHP(Map map, int x, int y)
        {
            int actorHP = 0;
            try
            {
                actorHP = map.MapNodes[x, y].ActorOnNode.HealthPoints;
            }
            catch (IndexOutOfRangeException)
            {
                actorHP = 0;
            }
            catch (NullReferenceException)
            {
                actorHP = 0;
            }
            return actorHP;
        }//end TryCatchActorHP

        public static int TryCatchActorMP(Map map, int x, int y)
        {
            int actorMP = 0;
            try
            {
                actorMP = map.MapNodes[x, y].ActorOnNode.ManaPoints;
            }
            catch (IndexOutOfRangeException)
            {
                actorMP = 0;
            }
            catch (NullReferenceException)
            {
                actorMP = 0;
            }

            return actorMP;
        }//end TryCatchActorMP

        public static string TryCatchTileNickname(Map map, int x, int y)
        {
            string tileNickname = "";
            try
            {
                tileNickname = map.MapNodes[x, y].TileType.Nickname;
            }
            catch (ArgumentOutOfRangeException)
            {
                tileNickname = "Non";
            }
            catch (NullReferenceException)
            {
                tileNickname = "Non";
            }

            return tileNickname;
        }//end TryCatchTileList

        //TODO: JON: Trying to create some generic presentation methods. Unfinished.
        public static void UserInputYesNo()
        {
            Console.WriteLine("(Y)  Yes.");
            Console.WriteLine("(N)  No.");
            string input = Console.ReadLine().ToUpper();

        }

        public static void CheckUserYesNo(string input)
        {
            if (input == "Y")
            {

            }
        }
    }//end PresentationHelpers




    /// <summary>
    /// an Option to be used inside a menu
    /// </summary>


}
