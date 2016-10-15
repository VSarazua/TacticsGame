using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Enums;
using TacticsGame.Logic.Models.Actors;

namespace TacticsGame.Logic.Models.Abilities
{
    //TODO: JON'S NOTES 9/16/16: I wasn't really sure what the best way to implement casted 
    //abilities would be, and I confused the hell out of myself trying to figure out wether
    //things would belong in the Presentation layer or not. I ended up figuring most of the
    //Domain's side of casting abilities. Hopefully this is enough of a framework to move
    //forward. It probably needs to be fixed up a little first.  
    public class CastedAbility : Ability
    {
        public int CastRange { get; set; }
        public AbilityTargetType TargetType { get; set; }

        public CastedAbility(string name, string description, int cost, int coolDown, int duration, int castRange, AbilityTargetType type) 
            : base(name, description, cost, coolDown, duration)
        {
            CastRange = castRange;
            TargetType = type;
        }

    }
}
