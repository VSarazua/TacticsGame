using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Enums;
using TacticsGame.Logic.Models.Abilities;
using TacticsGame.Logic.Models.Actors;

namespace TacticsGame.Logic.Models.Equipment
{
    public class Armor
    {
        //TODO: Fix the logic here too
        private int _durability { get { return _durability; }
        set
            {
                if (value < 0 )
                {
                    _durability = 0;
                }
                else if(value > _maxDurability)
                {
                    _durability = _maxDurability;
                }
                else
                {
                    _durability = value;
                }
            }
        }
        private int _maxDurability
        {
            get { return _maxDurability; }
            set
            {
                if (value < 0 )
                {
                    _maxDurability = 1;
                }
                else if(value > 99)
                {
                    _maxDurability = 99;
                }
                else
                {
                    _maxDurability = value;
                }
            }
        }
        private int _armorStrength
        {
            get { return _armorStrength; }
            set
            {
                if (value < 0)
                {
                    _armorStrength = 0;
                }
                else if (value > 999)
                {
                    _armorStrength = 999;
                }
                else
                {
                    _armorStrength = value;
                }
            }
        }

        public string Name { get; set; }
        public int Durability { get; set; }
        public int MaxDurability { get; set; }
        public int ArmorStrength { get; set; }
        public List<Ability> GrantedEffects { get; set; }
        public ArmorType Type { get; set; }
        public ArmorSlot Slot { get; set; }
        public MaterialType Material { get; set; }

        //Again i created this method anticipating an increase in complexity
        public int GetDefenseValue()
        {
            int defenseValue;
            defenseValue = ArmorStrength;
            return defenseValue;
        }
        //TODO: Figure out how to implement weapon buffs to character
    }
}
