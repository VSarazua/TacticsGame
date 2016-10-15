using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Enums;
using TacticsGame.Logic.Models.Actors;
using TacticsGame.Logic.Models.Maps;


namespace TacticsGame.Logic.Models.Managers
{
    public class ApplicationController
    {
        public GameState GameState { get; set; }
        

        public ApplicationController()
        {
            GameState = GameState.MainMenu;
        }
    }
}
