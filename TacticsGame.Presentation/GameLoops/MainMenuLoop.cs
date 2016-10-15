using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Enums;
using TacticsGame.Logic.Models.Managers;

namespace TacticsGame.Presentation.GameLoops
{
    
    public static class MainMenuLoop
    {
        public static void MainMenu(ApplicationController gameManager)
        {
            do
            {
                //THINGS TO DISPLAY IN THE MAIN MENU:
                //Title
                //MainMenuOptions
                //CheckUserInput


            } while (gameManager.GameState == GameState.MainMenu); //end dowhile loop
            PresentationHelpers.LoopRedirect(gameManager);
        }//end Main Menu



        
    }//end MainMenuLoop
}//end namespace
