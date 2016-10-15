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
    public class Weapon
    {
        //TODO: Move the logic to properties instead of fields check armor class aswell
        private int _weaponStrength
        {
            get { return _weaponStrength; }
            set
            {
                if (value < 0)
                {
                    _weaponStrength = 0;
                }
                else if (value > 999)
                {
                    _weaponStrength = value;
                }
                else
                {
                    _weaponStrength = value;
                }
            }
        }
        private int _durability
        {
            get { return _durability; }
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
        private int _maxDurability { get { return _maxDurability; }
        set
            {
                if (value < 0)
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

        public string Name { get; set; }
        public int WeaponStrength { get; set; }
        public int Durability { get; set; }
        public int MaxDurability { get; set; }
        public List<Ability> GrantedEffects { get; set; }
        public WeaponType Type { get; set; }
        public WeaponSlot Slot { get; set; }
        public MaterialType Material { get; set; }

        //This method is very simplistic now but i created it in aticipation of it increasing in complexity
        public int GetAttackValue()
        {
            int attackValue;
            attackValue = WeaponStrength;
            return attackValue;
        }

        //TODO: Figure out how to implement weapon buffs to character
    }
}
