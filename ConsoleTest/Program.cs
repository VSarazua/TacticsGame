using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic;
using TacticsGame.Logic.Enums;
using TacticsGame.Logic.Models.Abilities;
using TacticsGame.Logic.Models.Abilities.Conditions;
using TacticsGame.Logic.Models.Actors;
using TacticsGame.Logic.Models.Managers;
using TacticsGame.Logic.Models.Maps;
using TacticsGame.Logic.Models.Equipment;
using TacticsGame.Presentation;
using TacticsGame.Presentation.GameLoops;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             * Test Abilities:
             *  -- General --
             *  Move: actor moves
             *  Interact: actor interacts with stuff
             *  UseItem: actor uses item
             *  Wait: actor skipps turn
             *  Attack: actor uses base attack
             *  
             *  -- Class Specific --
             *  Warrior
             *      Warriors' Shout: Target a mighty warcry at an enemy to paralyze them in fear for one turn 3 turn cooldown
             *      
             *          Effects: Target = Change ActorStatus to paralyzed
             *          
             *          Conditions: Caster = Cooldown not in effect Within 3 tiles in any direction
             *      
             *      Enrage: When health dips below 20% user gets a boost to attack damage and agility.
             *
             *          Effects: Caster = Agility=10% AtkDmg=10% 
             *  
             *          Conditions: Caster = health below 20% 
             *  
             *  Wizard
             *      Magic Projectile: Shoot a ball of magic damage towards an enemy
             *      
             *          Effects: Target = Damage an enemy or object with magic damage
             *          
             *          Conditions: Caster = Must have enough mana 
             *          
             *      Possesion: Gain control of a fallen enemy or ally and gain accces to most of thier abilities. While using posession
             *          caster may not move or use abilities or they will break the link between them and the target. Using possesed units abilities
             *          or moving them will cost caster mana.
             *      
             *          Effects: Target = Toggle control over to player of casted unit
             *      
             *          Conditions: Target = must be in dead status | Caster = Most not use actions, must have mana
             *          
             *      Power Overwhelming: Once per match When your mana reserves hit 0 cast 1 free spell for double its normal damage 
             *          IF possesion is used or already in use target of possesion will create an explosion of magic damage.
             *          
             *          Effects: Caster = Clear mana check for 1 spell, double damage special effect on other spell
             *          
             *          Conditions: Caster = mana must be 0, can only be used once per battle
             *      
             *  Rouge
             *      Poison Dart: Throw a poison dart at a target to poison them. Poisoned targets get small reduction to their 
             *          agility, dexterity 
             *      
             *          Effects: Target = Change status of actor to poisoned inflicting a small amount of damage overtime, if target
             *          is already poisoned no effect will be applied
             *          
             *          Conditions: NONE
             *       
             *      Feign Death: The rouge fakes its own death making it untargetable by enmies for as long as they do not move max of 2 turns
             *          any enemies targeting this character before hand will not longer target it, NOTE any target area skill will 
             *          still affect actor
             *      
             *          Effects: Caster = deaggro enemies & make actor unselectable by targeted skills
             *          
             *          Conditions: Caster = NONE
             *      
             */

            #region ConditionsList
            StatCondition healthDip = new StatCondition(ActorStats.HealthPoints, Evaluation.Less, 20, true);
            #endregion

            #region EffectsList
            StatModifier agilBuff = new StatModifier(ActorStats.Agility, 10, false, true);
            StatModifier damageBuff = new StatModifier(ActorStats.Strength, 10, false, true);
            StatModifier damage = new StatModifier(ActorStats.HealthPoints, 5, true, false);
            #endregion

            #region AbilitiesList
            #region Enrage Creation Code
            PassiveAbility enrage = new PassiveAbility("Enrage", "User explodes with anger", 0, 0, 9999);
            enrage.InitializeAbility();
            enrage.AddEffect(agilBuff, true);
            enrage.AddEffect(damageBuff, true);
            enrage.AddEffect(damage, false);
            enrage.AddCondition(healthDip, true);
            #endregion
            #region Warrior's Shout
             
            #endregion
            #endregion

            Humanoid test = new Humanoid("A", "A", 40, 20, true);
            test.Class = HumaniodClass.Warrior;
            test.AssignBaseStats();
            test.Agility = 10;
            test.Strength = 10;
            test.LearnedAbilities.Add(enrage);

            #region TEST CODE
            string availableAbilities = "";
            foreach (var item in test.GetAvailableAbilites())
            {
                int casterConditions = item.CasterConditions.Count;
                int targetConditions = item.TargetConditions.Count;
                availableAbilities += (item.Name + ": Conditions -- Caster =" + casterConditions + " Target = " + targetConditions + "\n" );
            }
            Console.WriteLine("===== {0} =====\n* Available Abilitites: {1}", test.Name, availableAbilities);
            Console.WriteLine("Press any key to continue");
            Console.Read();
            test.HealthPoints = 7;
            foreach (var item in test.GetAvailableAbilites())
            {
                int casterConditions = item.CasterConditions.Count;
                int targetConditions = item.TargetConditions.Count;
                availableAbilities += (item.Name + ": Conditions -- Caster =" + casterConditions + " Target = " + targetConditions + "\n");
            }
            Console.WriteLine("===== {0} =====\n* Available Abilitites: {1}", test.Name, availableAbilities);
            #endregion
        }
    }//program
}//namespace
