using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Enums;
using TacticsGame.Logic.Models.Actors;

namespace TacticsGame.Logic.Models.Abilities
{
    public class StatModifier : Effect
    {
        public ActorStats Stat { get; set; }
        public int Modifier { get; set; }
        public bool Percentage { get; set; } 
        public bool Buff { get; set; }

        public StatModifier(ActorStats stat, int modifier, bool isPercentage, bool isBuff)
        {
            Stat = stat;
            Modifier = modifier;
            Percentage = isPercentage;
            Buff = isBuff;
        }

        public static void ApplyEffect(Actor a, StatModifier mod)
        {
            int modValue = mod.Modifier;
            //Finds the percentage value if necessary
            if (mod.Percentage == true)
            {
                modValue = LogicHelpers.CalculatePercentage(a.GetStatValue(mod.Stat), mod.Modifier);
            }
            //MUST find the percentage value before converting it to a nerf
            //Will Create a nerf if necessary
            if (mod.Buff == false)
            {
                modValue = modValue * (-1);
            }

            a.ApplyStatChange(mod.Stat, modValue);
        }

        public static void ReverseEffect(Actor a, StatModifier mod)
        {
            int modValue = mod.Modifier;
            //Finds the percentage value if necessary
            if (mod.Percentage == true)
            {
                modValue = LogicHelpers.CalculatePercentage(a.GetStatValue(mod.Stat), mod.Modifier);
            }
            //MUST find the percentage value before converting it to a nerf
            //Will Create a nerf if necessary
            if (mod.Buff == true)
            {
                modValue = modValue * (-1);
            }

            a.ApplyStatChange(mod.Stat, modValue);
        }

    }
}
