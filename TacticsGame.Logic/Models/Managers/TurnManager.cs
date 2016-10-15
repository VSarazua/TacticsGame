using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Models.Actors;
using TacticsGame.Logic.Models.Maps;

namespace TacticsGame.Logic.Models.Managers
{
    public static class TurnManager
    {
        

        //How CT works:
        //So when combat begins, each actor on the map starts with 0 out of
        //1000 CT. TurnOrderManager or maybe a CombatManager will keep 
        //"ticking". During each tick, each actor's CT stat goes up based on
        //their Agility. If they have 58 Agility, then their CT goes up by
        //58 each tick. When any actors' CT is equal to or greater than 1000
        //after a tick, then they get a turn. If two actors break 1000 CT at
        //the same time, then one of them gets a turn (not sure how to break
        //ties meaningfully) and the other gets a turn immediately after-
        //no "tick" will occur. 

        //After an actor's turn, their CT resets based on how many action 
        //points that actor has left when they end their turn, 200 for each 
        //AP. 

        //In order to prevent characters from being absurdly slow, as in 
        //other actors getting 3-8 turns in before the actor gets 1, we 
        //might need to add a minimum cap. If an actor's Agility is 0, they'll 
        //never get a chance to act at all. I want the average agility for
        //actors to be around 50. If we have characters with heavy armor
        //end up with 10 Agility, then we'll get that undesirable scenario
        //where an actor gets 5 turns over another. We'll just have to be
        //very careful when we're dealing with equipment and abilities that
        //increase or decrease Agility. 

        //Abilities like that Delay Attack that I mentioned from FFX would 
        //likely attack CT instead of Agility. We can have effects that the 
        //at the beginning of combat; if the actor has the effect, then they 
        //start with more CT. A sort of First Strike/Swiftness thing
        //that gives the actor a headstart on each encounter.



        //Old Goals:
        //1: sort the map's list of actors to create a repeating turn order.
        //-Sorting can be done here.
        //-Displaying the repeating turn order can probably be done in the
        //  Presenation layer.

        //2: limit the turn order to only show the next 5-10 turns. 
        //For example,
        //***TURN ORDER***
        //Sarazua
        //Enemy B
        //Enemy A
        //Sarazua
        //Enemy B
        //-This can be done in the Presentation layer.

        //3: find a way to create a projected turn order that automatically 
        //updates when you're targeting an actor with an ability that affects 
        //agility/CT. 
        //For example, Sarazua is TARGETING (player hasn't confirmed casting yet)
        //Enemy B with an ability that lowers agility/CT. The turn order updates,
        //moving Enemy B's position, highlighting in COLOR where it was and where 
        //it will be after. To demonstrate in comments: ---before---, ***after***
        //***TURN ORDER***
        //Sarazua
        //---Enemy B---
        //Enemy A
        //Sarazua
        //***Enemy B***
        //-A lot of this has to be done in the Presentation layer.
        //-I think all I need in this class is a method to calculate and perform
        //  operations on each actor's CT.



        //Notes: 
        //I realize a lot of this stuff will have to be done in the presentation
        //layer. But I'll still have to do a lot here.

        public static void CalculateTurnOrder(Map map)
        {
            //

            //Alright, this should should sort the map's list of actors based on 
            //their strength stat. (doing strength for ease of testing)
            try
            {
                map.ActorsOnMap = SortActorsOnMapByStrength(map);
            }
            catch (Exception)
            {
                Console.WriteLine("Error in CaluculateTurnOrder, calling SortActorsOnMapByStrength.");
            }
           
            




        }//end UpdateTurnOrder(map)

        public static List<Actor> SortActorsOnMapByStrength(Map map)
        {
            try
            {
                map.ActorsOnMap.Sort((Actor x, Actor y) => x.Strength.CompareTo(y.Strength));
            }
            catch (Exception)
            {
                Console.WriteLine("Error in SortActorsOnMapByStrength");
            }
            return map.ActorsOnMap;
        }
        
    }//end TurnOrderManager.cs
}
