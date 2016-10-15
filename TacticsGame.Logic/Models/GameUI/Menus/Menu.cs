using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Models.Managers;

namespace TacticsGame.Logic.Models.GameUI.Menus
{
    public class Menu
    {
        public string MenuName { get; set; }
        public List<MenuItem> MenuItems { get; set; }


        public Menu(string name)
        {
            MenuName = name;
            MenuItems = new List<MenuItem>();
        }

        public static void CompareToUserInput(string input, Menu menu, ApplicationController appController)
        {
            foreach (MenuItem menuItem in menu.MenuItems)
            {
                if (input == menuItem.KeyBinding)
                {
                    MenuItem.CheckAction(menuItem, appController);
                }
            }
        }


    }


}
