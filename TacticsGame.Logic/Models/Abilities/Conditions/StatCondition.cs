using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Enums;
using TacticsGame.Logic.Models.Actors;

namespace TacticsGame.Logic.Models.Abilities.Conditions
{
    public class StatCondition: Condition
    {
        public ActorStats Stat { get; set; }
        public Evaluation Evaluator { get; set; }
        public int ComparisonValue { get; set; }
        public bool Percetage { get; set; }

        /// <summary>
        /// Constructor for a stat based condition
        /// </summary>
        /// <param name="stat"></param>
        /// <param name="evaluation"></param>
        /// <param name="rule"></param>
        public StatCondition(ActorStats stat, Evaluation evaluation, int value, bool isPercetage)
        {
            Stat = stat;
            Evaluator = evaluation;
            ComparisonValue = value;
            Percetage = isPercetage;
        }

        public static bool EvaluateCondition(Actor actor, StatCondition condition)
        {
            bool output = false;
            int compareValue = GetComparisonValue(actor, condition);

            //Taking the final comparison value and performing a check based on the evaluator for the condition
            switch (condition.Evaluator)
            {
                case Evaluation.Less:
                    output = actor.GetStatValue(condition.Stat) < compareValue;
                    break;
                case Evaluation.Greater:
                    output = actor.GetStatValue(condition.Stat) > compareValue;
                    break;
                case Evaluation.LessEqual:
                    output = actor.GetStatValue(condition.Stat) <= compareValue;
                    break;
                case Evaluation.GreaterEqual:
                    output = actor.GetStatValue(condition.Stat) >= compareValue;
                    break;
                case Evaluation.Equal:
                    output = actor.GetStatValue(condition.Stat) == compareValue;
                    break;
                default:
                    break;
            }
            return output;
        }//EvalCondition

        private static int GetComparisonValue(Actor actor, StatCondition condition)
        {
            int compareValue;
            //Checking for percent value
            if (condition.Percetage)
            {
                //A switch statement is needed in order to properly compare MaxHp to HP or MaxMana to Mana
                switch (condition.Stat)
                {
                    case ActorStats.MaxHealthPoints:
                        //TODO if any abilitites decrease MaxHP value then this formula might not work anymore
                        compareValue = LogicHelpers.CalculatePercentage(actor.MaxManaPoints, condition.ComparisonValue);
                        break;
                    case ActorStats.HealthPoints:
                        compareValue = LogicHelpers.CalculatePercentage(actor.MaxHealthPoints, condition.ComparisonValue);
                        break;
                    case ActorStats.MaxManaPoints:
                        compareValue = LogicHelpers.CalculatePercentage(actor.MaxManaPoints, condition.ComparisonValue);
                        break;
                    case ActorStats.ManaPoints:
                        compareValue = LogicHelpers.CalculatePercentage(actor.MaxManaPoints, condition.ComparisonValue);
                        break;
                    default:
                        compareValue = LogicHelpers.CalculatePercentage(actor.GetStatValue(condition.Stat), condition.ComparisonValue);
                        break;
                }//end switch
            }//if
            else
            {
                compareValue = condition.ComparisonValue;
            }//else
            return compareValue;
        }//GetCompareValue
    }
}
