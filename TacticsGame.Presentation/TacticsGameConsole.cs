using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.DTO;
using TacticsGame.Logic.Models.Actors;
using TacticsGame.DTO.DataDTO.ActorDTOs;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using TacticsGame.Logic.Enums;
using TacticsGame.Logic;

using TacticsGame.Logic.Models.Managers;
using TacticsGame.Logic.Models.GameUI.Menus;

namespace TacticsGame.Presentation
{
    class TacticsGameConsole
    {
        static void Main(string[] args)
        {
            {
                #region MenusMockDatabase 
                #region MainMenu
                MenuItem newGame = new MenuItem("N", MenuItemActions.NewGame);
                MenuItem loadGame = new MenuItem("L", MenuItemActions.LoadGame);
                MenuItem customGame = new MenuItem("C", MenuItemActions.CustomGame);
                MenuItem exitGame = new MenuItem("X", MenuItemActions.ExitGame);
                MenuItem optionsMenu = new MenuItem("O", MenuItemActions.GoToOptionsMenu);

                Menu mainMenu = new Menu("Main Menu");
                mainMenu.MenuItems.Add(newGame);
                mainMenu.MenuItems.Add(loadGame);
                mainMenu.MenuItems.Add(customGame);
                mainMenu.MenuItems.Add(exitGame);
                mainMenu.MenuItems.Add(optionsMenu);
                #endregion
                #endregion

                ApplicationController appController = new ApplicationController();
                Console.WriteLine(appController.GameState);
                do
                {

                    //title

                    PresentationHelpers.DisplayOptions(mainMenu);
                    Menu.CompareToUserInput(PresentationHelpers.AcceptPlayerInput(), mainMenu, appController);
                    Console.WriteLine("AfterMenu, {0}", appController.GameState.ToString());


                } while (appController.GameState == GameState.MainMenu);

                //GameManager gameManager = new GameManager();
                //gameManager.Test = 1;
                //PresentationHelpers.LoopRedirect(gameManager);
                
                //TODO: move this shit to its proper location sarazua
                //GameLoops game = new GameLoops();
                //game.RunGameLoop(game);
                //var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\TacticsGameTestsss";

                //Humanoid testUnitOne = new Humanoid("BLAh", "SRZ", 40, 10, 40, 10, 10, 40, 40, true);
                //var unitToSave = XMLHelper.ActorParser(testUnitOne);

                //System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(UnitTestDTO));
                //System.IO.Directory.CreateDirectory(folderPath);
                //var filePath = folderPath + "//" + unitToSave.Name;
                //System.IO.FileStream file = System.IO.File.Create(filePath);


                //XMLHelper.SaveToFile<UnitTestDTO>(unitToSave, unitToSave.Name, FolderName.Units);
                //writer.Serialize(file, unitToSave);
                //file.Close();

                //XMLSaver.SaveToFile<UnitTestDTO>(unitToSave, unitToSave.Name, "Units");

                //var dto = XMLHelper.ReadFromFile<UnitTestDTO>("BLAh", FolderName.Units);
                //Console.WriteLine(dto.Name);
                //Console.WriteLine(dto.Dexterity);
                //Console.WriteLine(dto.LearnedAbilities);
            }
        }
    }//testConsole 

    public class GameManager
    {
    }
}
