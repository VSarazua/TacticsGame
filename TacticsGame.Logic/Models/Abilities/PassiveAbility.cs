using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Models.Abilities.Conditions;

namespace TacticsGame.Logic.Models.Abilities
{
    public class PassiveAbility : Ability
    {
        /// <summary>
        /// Constructor for ability \nNOTE: All abilities are created as un available and inActive
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="cost"></param>
        /// <param name="coolDown"></param>
        /// <param name="duration"></param>
        public PassiveAbility(string name, string description, int cost, int coolDown, int duration) : base(name, description, cost, coolDown, duration)
        {
        }
    }
}
