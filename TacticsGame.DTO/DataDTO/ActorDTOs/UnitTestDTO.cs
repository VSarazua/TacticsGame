using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TacticsGame.Logic.Models.Abilities;
using TacticsGame.Logic.Models.Actors;

namespace TacticsGame.DTO.DataDTO.ActorDTOs
{
    [Serializable()]
    public class UnitTestDTO
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Nickname")]
        public string Nickname { get; set; }
        [XmlElement("MaxHealthPoints")]
        public int MaxHealthPoints { get; set; }
        [XmlElement("HealthPoints")]
        public int HealthPoints { get; set; }
        [XmlElement("MaxManaPoints")]
        public int MaxManaPoints { get; set; }
        [XmlElement("Manapoints")]
        public int ManaPoints { get; set; }
        [XmlElement("Strength")]
        public int Strength { get; set; }
        [XmlElement("Dexterity")]
        public int Dexterity { get; set; }
        [XmlElement("Defense")]
        public int Defense { get; set; }
        [XmlElement("MagicPower")]
        public int MagicPower { get; set; }
        [XmlElement("MagicDefense")]
        public int MagicDefense { get; set; }
        [XmlElement("ActorLevel")]
        public int ActorLevel { get; set; }
        [XmlElement("ExperiencePoints")]
        public int ExperiencePoints { get; set; }
        [XmlElement("isPalyerControlled")]
        public bool isPlayerControlled { get; set; }
        [XmlElement("LearnedAbilities")]
        public List<Ability> LearnedAbilities { get; set; }
    }
}
