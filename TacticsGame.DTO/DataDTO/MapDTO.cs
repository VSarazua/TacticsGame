using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TacticsGame.Logic.Models.Maps;

namespace TacticsGame.DTO.DataDTO
{
    [Serializable]
    public class MapDTO
    {
        [XmlElement("Columns")]
        public int MapX { get; set; }
        [XmlElement("Rows")]
        public int MapY { get; set; }

        public static MapDTO ParseDTO(Map map)
        {
            MapDTO dto = new MapDTO() { };
            dto.MapX = map.MapX;
            dto.MapY = map.MapY;
            return dto; 
        }
    }
}
