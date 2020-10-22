using System;
using static System.Console;
using System.Collections.Generic;
namespace _11Collection
{
    public class ListT
    {

        public void usingListT()
        {
            string s1 = "Latte";
            string s2 = "Espresso";
            string s3 = "Americano";
            string s4 = "Cappuccino";
            string s5 = "Mocha";
            // Add the items to a strongly-typed collection.
            var coffeeBeverages = new List<String>();
            coffeeBeverages.Add(s1);
            coffeeBeverages.Add(s2);
            coffeeBeverages.Add(s3);
            coffeeBeverages.Add(s4);
            coffeeBeverages.Add(s5);
            // Sort the items using the default comparer.
            // For objects of type String, the default comparer sorts the items alphabetically.
            coffeeBeverages.Sort();
            // Write the collection to a console window.
            foreach (String coffeeBeverage in coffeeBeverages)
            {
                WriteLine(coffeeBeverage);
            }
            WriteLine("Press Enter to continue");
            ReadLine();
        }
    }
}
