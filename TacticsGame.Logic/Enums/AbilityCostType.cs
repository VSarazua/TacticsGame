using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacticsGame.Logic.Enums
{
    public enum AbilityCostType
    {
        None,
        MaxHP,
        HP,
        MaxMP,
        MP,
        //str, //Interesting costs? Do an ability and it lowers your str 
             //afterward? Probably not, effects do that better...
        //Gold, //Abilities like Gil Toss from Final Fantasy, where you 
              //throw money at enemies and kill em.
        //InventoryItem, //like arrows and bombs.
    }
}
