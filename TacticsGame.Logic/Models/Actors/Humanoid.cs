using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Enums;
using TacticsGame.Logic.Models.Abilities;
using TacticsGame.Logic.Models.Equipment;

namespace TacticsGame.Logic.Models.Actors
{
    public class Humanoid : Actor
    {
        //public List<Weapon> EquippedWeapon { get; set; }
        //public List<Armor> EquippedArmor { get; set; }
        public HumaniodClass Class { get; set; }

        //In an effort to reduce the complexity of creating a new character base stats will be assigned based on class
        public Humanoid(string name, string nickName, int maxHealthPoints, int maxManaPoints, bool isPlayable)
        {
            Name = name;
            Nickname = nickName;
            MaxHealthPoints = maxHealthPoints;
            HealthPoints = maxHealthPoints;
            MaxManaPoints = maxManaPoints;
            ManaPoints = maxManaPoints;
            ActorLevel = 0;
            ExperiencePoints = 0;
            isPlayerControlled = isPlayable;
            LearnedAbilities = new List<Ability>();
        }
        public Humanoid() { }

        public void AssignBaseStats()
        {
            switch (Class)
            {
                case HumaniodClass.Warrior:
                    Strength = 3;
                    Dexterity = 1;
                    Defense = 3;
                    MagicPower = 1;
                    MagicDefense = 2;
                    break;
                case HumaniodClass.Rogue:
                    Strength = 2;
                    Dexterity = 3;
                    Defense = 2;
                    MagicPower = 2;
                    MagicDefense = 1;
                    break;
                case HumaniodClass.Wizard:
                    Strength = 1;
                    Dexterity = 2;
                    Defense = 1;
                    MagicPower = 3;
                    MagicDefense = 3;
                    break;
                default:
                    Strength = 1;
                    Dexterity = 1;
                    Defense = 1;
                    MagicPower = 1;
                    MagicDefense = 1;
                    break;
            }
        }
    }
}
