using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Enums;

namespace TacticsGame.Logic.Models.Actors
{
    public class NonHumanoid : Actor
    {
        public NonHumanoidClass Class { get; set; }
    }
}
