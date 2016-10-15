using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Models.Abilities.Conditions;
using TacticsGame.Logic.Models.Actors;

namespace TacticsGame.Logic.Models.Abilities
{
    public static class AbilityHelpers
    {
        /// <summary>
        /// A method to check an actor for avaiable abilitites is availbe to use
        /// </summary>
        /// <param name="actor"></param>
        public static string AvailableAbilites(Actor actor)
        {
            string availableAbilities = string.Empty;
            foreach (Ability ability in actor.LearnedAbilities)
            {
                if (Condition.CheckCondtitions(ability, actor, true))
                {
                    availableAbilities += ability.Name;
                }
            }
            return availableAbilities;
        }//End CheckAbilities
    }
}
