using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Models.Abilities.Conditions;
using TacticsGame.Logic.Enums;
using TacticsGame.Logic.Models.Actors;

namespace TacticsGame.Logic.Models.Abilities
{
    public abstract class Ability
    {
        private int _cost;
        private int _cooldownTime;
        private int _cooldownTimer;
        private int _duration;

        public string Name { get; set; }
        public string Description { get; set; }
        public AbilityCostType CostType { get; set; }
        public int Cost
        {
            get { return _cost; }
            set
            {
                if (value < 0)
                {
                    _cost = 0;
                }
                else if (value > 99)
                {
                    _cost = 99;
                }
                else
                {
                    _cost = value;
                }
            }
        }
        public int CooldownTime
        {
            get { return _cooldownTime; }
            set
            {
                if (value < 0)
                {
                    _cooldownTime = 0;
                }
                else if (value > 99)
                {
                    _cooldownTime = 99;
                }
                else
                {
                    _cooldownTime = value;
                }
            }
        }
        public int CooldownTimer
        {
            get { return _cooldownTimer; }
            set
            {
                if (value > CooldownTime) { _cooldownTimer = CooldownTime; }
                else if (value < 0) { _cooldownTimer = 0; }
                else { _cooldownTimer = value; }
            }
        }
        public int Duration
        {
            get { return _duration; }
            set
            {
                if (value < 0)
                {
                    _duration = 1;
                }
                else if (value > 999)
                {
                    _duration = 999;
                }
                else
                {
                    _duration = value;
                }
            }
        }
        public List<Effect> CasterEffects { get; set; }
        public List<Condition> CasterConditions { get; set; }
        public List<Effect> TargetEffects { get; set; }
        public List<Condition> TargetConditions { get; set; }

        public Ability(string name, string description, int cost, int coolDown, int duration)
        {
            Name = name;
            Description = description;
            Cost = cost;
            CooldownTime = coolDown;
            Duration = duration;
            CasterEffects = new List<Effect>();
            CasterConditions = new List<Condition>();
            TargetEffects = new List<Effect>();
            TargetConditions = new List<Condition>();
        }


        /// <summary>
        /// Adds an effect to the corresponding list for caster or target
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="casterEffect"></param>
        public void AddEffect(Effect e, bool casterEffect)
        {
            if (casterEffect)
            {
                CasterEffects.Add(e);
            }
            else
            {
                TargetEffects.Add(e);
            }
        }
        /// <summary>
        /// Removes an effect to the corresponding list for caster or target
        /// </summary>
        /// <param name="effect"></param>
        /// <param name="casterEffect"></param>
        public void RemoveEffect(Effect e, bool casterEffect)
        {
            if (casterEffect)
            {
                CasterEffects.Remove(e);
            }
            else
            {
                TargetEffects.Remove(e);
            }
        }
        /// <summary>
        /// Adds a condition to the corresponding list for caster or target
        /// </summary>
        /// <param name="c"></param>
        public void AddCondition(Condition c, bool casterCondition)
        {
            if (casterCondition)
            {
                CasterConditions.Add(c);
            }
            else
            {
                TargetConditions.Add(c);
            }
        }
        /// <summary>
        /// Removes a condition to the corresponding list for caster or target
        /// </summary>
        /// <param name="c"></param>
        public void RemoveCondition(Condition c, bool casterCondition)
        {
            if (casterCondition)
            {
                CasterConditions.Remove(c);
            }
            else
            {
                TargetConditions.Remove(c);
            }
        }

        /// <summary>
        /// A method that Applies all ability effects to a target
        /// </summary>
        /// <param name="ability"></param>
        /// <param name="target"></param>
        public static void ApplyAllEffects(Ability ability, Actor actor, bool isCaster)
        {
            if (isCaster)
            {
                ApplyCasterEffects(ability, actor);
            }
            else
            {
                ApplyTargetEffects(ability, actor);
            }
        }

        private static void ApplyCasterEffects(Ability ability, Actor caster)
        {
            foreach (StatModifier effect in ability.CasterEffects)
            {
                StatModifier.ApplyEffect(caster, effect);
            }
        }
        private static void ApplyTargetEffects(Ability ability, Actor target)
        {
            foreach (StatModifier effect in ability.TargetEffects)
            {
                StatModifier.ApplyEffect(target, effect);
            }
        }

        public void InitializeAbility()
        {
            CasterConditions.Add(CreateCostCondition());
            CasterEffects.Add(CreateCostModifier());
        }
        private StatCondition CreateCostCondition()
        {
            StatCondition costCheck;
            switch (CostType)
            {
                case AbilityCostType.MaxHP:
                    costCheck = new StatCondition(ActorStats.MaxHealthPoints, Evaluation.GreaterEqual, Cost, false);
                    break;
                case AbilityCostType.HP:
                    costCheck = new StatCondition(ActorStats.HealthPoints, Evaluation.GreaterEqual, Cost, false);
                    break;
                case AbilityCostType.MaxMP:
                    costCheck = new StatCondition(ActorStats.MaxManaPoints, Evaluation.GreaterEqual, Cost, false);
                    break;
                case AbilityCostType.MP:
                    costCheck = new StatCondition(ActorStats.ManaPoints, Evaluation.GreaterEqual, Cost, false);
                    break;
                default:
                    costCheck = new StatCondition(ActorStats.ManaPoints, Evaluation.GreaterEqual, Cost, false);
                    break;
            }
            return costCheck;
        }
        private StatModifier CreateCostModifier()
        {
            StatModifier abilityCost;
            switch (CostType)
            {
                case AbilityCostType.None:
                    abilityCost = new StatModifier(ActorStats.ManaPoints, 0, false, false);
                    break;
                case AbilityCostType.MaxHP:
                    abilityCost = new StatModifier(ActorStats.MaxHealthPoints, Cost, false, false);
                    break;
                case AbilityCostType.HP:
                    abilityCost = new StatModifier(ActorStats.HealthPoints, Cost, false, false);
                    break;
                case AbilityCostType.MaxMP:
                    abilityCost = new StatModifier(ActorStats.MaxManaPoints, Cost, false, false);
                    break;
                case AbilityCostType.MP:
                    abilityCost = new StatModifier(ActorStats.ManaPoints, Cost, false, false);
                    break;
                default:
                    abilityCost = new StatModifier(ActorStats.ManaPoints, Cost, false, false);
                    break;
            }
            return abilityCost;
        }

    }//end Ability
}
