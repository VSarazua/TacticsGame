using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacticsGame.Logic
{
    public class LogicHelpers
    {
        public static int CalculatePercentage(int fullValue, int percentValue)
        {
            int output;
            output = (fullValue * percentValue) / 100;
            return output;
        }
    }
}
