using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Enums;
using TacticsGame.Logic.Models.Actors;

namespace TacticsGame.Logic.Models.Abilities
{
    //Didn't spend very much time with this. The goal would probably be to have 3 damage formulae,
    //one for each damage type, and then pass in a bunch of shit to give abilities some diversity.
    
    //So, with that said, this isn't quite what I was intending.
    //TODO: JON: Tinker with this...
    public class AbilityFormulae
    {
        public static int Damage(Actor attacker, Actor defender, AbilityDamageType damageType)
        {
            int damage = 0;
            switch (damageType)
            {
                case AbilityDamageType.Physical:
                    damage = (attacker.Strength * 2) - defender.Defense;
                    break;
                case AbilityDamageType.Magical:
                    damage = (attacker.MagicPower * 2) - defender.MagicDefense;
                    break;
                case AbilityDamageType.Healing:
                    damage = (attacker.MagicPower * 2);
                    break;
                default:
                    break;
            }
            return damage;
        }
    }


}
