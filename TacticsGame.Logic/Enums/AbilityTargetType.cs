using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacticsGame.Logic.Enums
{
    public enum AbilityTargetType
    {
        //I feel like the two dead types are unecessary because dead is most likely a status and a
        //condition for an ability which ... well ... there might be an argument for this for an actual 
        //complete game with UI and everything
        Enemy,
        Ally,
        DeadEnemy,
        DeadAlly,
        Self,
        Area
    }
}
