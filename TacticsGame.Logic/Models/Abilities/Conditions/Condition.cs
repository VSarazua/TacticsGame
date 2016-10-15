using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Enums;
using TacticsGame.Logic.Models.Actors;

namespace TacticsGame.Logic.Models.Abilities.Conditions
{
    /// <summary>
    /// Condition class represents a requirement that must be met in order for an ability or action
    /// to be used/completed.
    /// </summary>
    public abstract class Condition
    {
        public virtual bool EvaluateCompareCondition(int valOne, Evaluation eval, int valTwo)
        {
            bool output = false;
            switch (eval)
            {
                case Evaluation.Less:
                    output = valOne < valTwo;
                    break;
                case Evaluation.Greater:
                    output = valOne > valTwo;
                    break;
                case Evaluation.LessEqual:
                    output = valOne <= valTwo;
                    break;
                case Evaluation.GreaterEqual:
                    output = valOne >= valTwo;
                    break;
                case Evaluation.Equal:
                    output = valOne == valTwo;
                    break;
                default:
                    break;
            }
            return output;
        }

        /// <summary>
        /// Takes an ability and checks its conditions against an actor. Will need to specify if actor is Caster
        /// </summary>
        /// <param name="ability"></param>
        /// <param name="actor"></param>
        /// <param name="targetIsCaster"></param>
        /// <returns></returns>
        public static bool CheckCondtitions(Ability ability, Actor actor, bool targetIsCaster)
        {
            bool allConditionsPassed = false;
            if (targetIsCaster)
            {
                allConditionsPassed = CheckCasterConditions(ability, actor);
            }
            else
            {
                allConditionsPassed = CheckTargetConditions(ability, actor);
            }
            return allConditionsPassed;
        }//Check All Condtions

        //Methods to check different types of conditions if actor is caster or target
        private static bool CheckCasterConditions(Ability ability, Actor caster)
        {
            bool allConditionsPassed = false;
            int conditionsCount = ability.CasterConditions.Count;
            int conditionsPassed = 0;

            #region Stat Condtions
            foreach (StatCondition condition in ability.CasterConditions)
            {
                bool conditionPassed = StatCondition.EvaluateCondition(caster, condition);
                if (conditionPassed == true)
                {
                    conditionsPassed += 1;
                }
            }

            if (conditionsPassed == conditionsCount)
            {
                allConditionsPassed = true;
            }
            return allConditionsPassed;
            #endregion
        }//end Caster Check
        private static bool CheckTargetConditions(Ability ability, Actor target)
        {
            bool allConditionsPassed = false;
            int conditionsCount = ability.CasterConditions.Count;
            int conditionsPassed = 0;

            #region Stat Condtions
            foreach (StatCondition condition in ability.TargetConditions)
            {
                bool conditionPassed = StatCondition.EvaluateCondition(target, condition);
                if (conditionPassed == true)
                {
                    conditionsPassed += 1;
                }
            }

            if (conditionsPassed == conditionsCount)
            {
                allConditionsPassed = true;
            }
            return allConditionsPassed;
            #endregion
        }//end Target Check
    }
}
