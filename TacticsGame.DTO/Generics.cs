using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacticsGame.DTO
{
    public class Generics
    {
        public static void AddToList<T>(T item, List<T> list)
        {
            list.Add(item);
        }

        public static void RemoveFromList<T>(T item, List<T> list)
        {
            list.Remove(item);
        }

        public static void ClearList<T>(T item, List<T> list)
        {
            list.Clear();
        }

        public static string PrintList<T>(List<T> list)
        {
            string output = "";
            foreach (var item in list)
            {
                output += item + " ";
            }
            return output;
        }
    }
}
