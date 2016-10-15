using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Enums;
using TacticsGame.Logic.Models.Abilities;
using TacticsGame.Logic.Models.Abilities.Conditions;
using TacticsGame.Logic.Models.Equipment;

namespace TacticsGame.Logic.Models.Actors
{
    public abstract class Actor
    {
        private int _maxHealthPoints;
        private int _healthPoints;
        private int _maxManaPoints;
        private int _manaPoints;
        //v- Remove this is if we find a better way to implement attack power -v
        //private int _attackPower;
        private int _strength;
        private int _dexterity;
        private int _defense;
        private int _magicPower;
        private int _magicDefense;
        //These next two props are used to determine turn order.
        private int _agility;
        private int _chargeTime;
        //These next two props are resources used as costs for movement and abiliities. 
        //moving costs one action point. Certain abilities only cost one action point, 
        //but end the actor's turn immediately after the ability is casted. This is 
        //relevant because I plan on carrying over the actor's remaining action points 
        //to make their next turn come by faster. 
        private int _maxActionPoints;
        private int _actionPoints;
        private int _actorLevel;
        private int _experiencePoints;
        //probably will no longer use movementRange, in favor of using ActionPoints 
        //to perform movements and abilities.
        //private int _movementRange;

        public string Name { get; set; }
        public string Nickname { get; set; }
        public ActorFaction Faction { get; set; }
        public int MaxHealthPoints
        {
            get { return _maxHealthPoints; }
            set
            {
                if (value <= 0 || value > 99)
                {
                    _maxHealthPoints = 1;
                }
                else
                {
                    _maxHealthPoints = value;
                }
            }
        }
        public int HealthPoints
        {
            get { return _healthPoints; }
            set
            {
                if (value < 0)
                {
                    _healthPoints = 0;
                }
                else if (value > _maxHealthPoints)
                {
                    _healthPoints = _maxHealthPoints;
                }
                else
                {
                    _healthPoints = value;
                }
            }
        }
        public int MaxManaPoints
        {
            get { return _maxManaPoints; }
            set
            {
                if (value < 0 || value > 99)
                {
                    _maxManaPoints = 1;
                }
                else
                {
                    _maxManaPoints = value;
                }
            }
        }
        public int ManaPoints
        {
            get { return _manaPoints; }
            set
            {
                if (value < 0)
                {
                    _manaPoints = 0;
                }
                else if (value > _maxManaPoints)
                {
                    _manaPoints = _maxManaPoints;
                }
                else
                {
                    _manaPoints = value;
                }

            }
        }
        public int Strength
        {
            get { return _strength; }
            set
            {
                if (value > 999)
                {
                    _strength = 999;
                }
                else
                {
                    _strength = value;
                }
            }
        }
        public int Dexterity
        {
            get { return _dexterity; }
            set
            {
                if (value > 999)
                {
                    _dexterity = 999;
                }
                else
                {
                    _dexterity = value;
                }
            }

        }
        public int Agility
        {
            get { return _agility; }
            set
            {
                if (value > 999)
                {
                    _agility = 999;
                }
                else
                {
                    _agility = value;
                }
            }
        }
        public int Defense
        {
            get { return _defense; }
            set
            {
                if (value > 999)
                {
                    _defense = 999;
                }
                else
                {
                    _defense = value;
                }
            }
        }
        public int MagicPower
        {
            get { return _magicPower; }
            set
            {
                if (value > 999)
                {
                    _magicPower = 999;
                }
                else
                {
                    _magicPower = value;
                }
            }
        }
        public int MagicDefense
        {
            get { return _magicDefense; }
            set
            {
                if (value > 999)
                {
                    _magicDefense = 999;
                }
                else
                {
                    _magicDefense = value;
                }
            }
        }
        public int ActorLevel
        {
            get { return _actorLevel; }
            set
            {
                if (value < 0)
                {
                    _actorLevel = 0;
                }
                else if (value > 99)
                {
                    _actorLevel = 99;
                }
                else
                {
                    _actorLevel = value;
                }
            }
        }
        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                if (value < 0)
                {
                    _experiencePoints = 0;
                }
                else
                {
                    _experiencePoints = value;
                }
            }
        }
        public bool isPlayerControlled { get; set; }
        public List<Ability> LearnedAbilities { get; set; }

        public List<Weapon> EquippedWeapon { get; set; }
        public List<Armor> EquippedArmor { get; set; }

        public int GetStatValue(ActorStats stat)
        {
            int output = 0;
            switch (stat)
            {
                case ActorStats.MaxHealthPoints:
                    output = MaxHealthPoints;
                    break;
                case ActorStats.HealthPoints:
                    output = HealthPoints;
                    break;
                case ActorStats.MaxManaPoints:
                    output = MaxManaPoints;
                    break;
                case ActorStats.ManaPoints:
                    output = ManaPoints;
                    break;
                case ActorStats.Strength:
                    output = Strength;
                    break;
                case ActorStats.Dexterity:
                    output = Dexterity;
                    break;
                case ActorStats.Defense:
                    output = Defense;
                    break;
                case ActorStats.MagicPower:
                    output = MagicPower;
                    break;
                case ActorStats.MagicDefense:
                    output = MagicDefense;
                    break;
                case ActorStats.ActorLevel:
                    output = ActorLevel;
                    break;
                case ActorStats.ExperiencePoints:
                    output = ExperiencePoints;
                    break;
                default:
                    break;
            }
            return output;
        }

        public void ApplyStatChange(ActorStats stat, int modifier)
        {
            switch (stat)
            {
                case ActorStats.MaxHealthPoints:
                    MaxHealthPoints += modifier;
                    break;
                case ActorStats.HealthPoints:
                    HealthPoints += modifier;
                    break;
                case ActorStats.MaxManaPoints:
                    MaxManaPoints += modifier;
                    break;
                case ActorStats.ManaPoints:
                    ManaPoints += modifier;
                    break;
                case ActorStats.Strength:
                    Strength += modifier;
                    break;
                case ActorStats.Dexterity:
                    Dexterity += modifier;
                    break;
                case ActorStats.Agility:
                    Agility += modifier;
                    break;
                case ActorStats.Defense:
                    Defense += modifier;
                    break;
                case ActorStats.MagicPower:
                    MagicPower += modifier;
                    break;
                case ActorStats.MagicDefense:
                    MagicDefense += modifier;
                    break;
                case ActorStats.ActorLevel:
                    ActorLevel += modifier;
                    break;
                case ActorStats.ExperiencePoints:
                    ExperiencePoints += modifier;
                    break;
                default:
                    break;
            }
        }

        public virtual int CalculateAttackValue()
        {
            int attackValue;
            attackValue = Strength;
            foreach (Weapon item in EquippedWeapon)
            {
                attackValue += item.GetAttackValue();
            }
            return attackValue;
        }

        public virtual int CalculateDefenseValue()
        {
            int defenseValue;
            defenseValue = Defense;
            foreach (Armor item in EquippedArmor)
            {
                defenseValue += item.GetDefenseValue();
            }
            return defenseValue;
        }

        public List<Ability> GetAvailableAbilites()
        {
            List<Ability> availableAbilities = new List<Ability>();
            foreach (Ability ability in LearnedAbilities)
            {
                if (Condition.CheckCondtitions(ability, this, true))
                {
                    availableAbilities.Add(ability);
                }
            }
            return availableAbilities;
        }//End CheckAbilities


    }//actor
}
