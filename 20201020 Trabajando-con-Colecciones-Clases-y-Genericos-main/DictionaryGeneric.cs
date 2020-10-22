using System;
using static System.Console;
using System.Collections.Generic;

namespace _11Collection
{

    public class DictionaryGeneric
    {

        public void UsingDictionaryGeneric()
        {
            // Create a new dictionary of strings with string keys.
            var coffeeCodes = new Dictionary<String, String>();
            // Add some entries to the dictionary.
            coffeeCodes.Add("CAL", "Café Au Lait");
            coffeeCodes.Add("CSM", "Cinammon Spice Mocha");
            coffeeCodes.Add("ER", "Espresso Romano");
            coffeeCodes.Add("RM", "Raspberry Mocha");
            coffeeCodes.Add("IC", "Iced Coffee");
            // This statement would result in an ArgumentException because the key already exists.
            // coffeeCodes.Add("IC", "Instant Coffee");
            // To retrieve the value associated with a key, you can use the indexer.
            // This will throw a KeyNotFoundException if the key does not exist.
            WriteLine("The value associated with the key \"CAL\" is {0}",
            coffeeCodes["CAL"]);
            // Alternatively, you can use the TryGetValue method.
            // This returns true if the key exists and false if the key does not exist.
            string csmValue = "";
            if (coffeeCodes.TryGetValue("CSM", out csmValue))
            {
                WriteLine("The value associated with the key \"CSM\" is {0}", csmValue);
            }
            else
            {
                WriteLine("The key \"CSM\" was not found");
            }
            // You can also use the indexer to change the value associated with a key.
            coffeeCodes["IC"] = "Instant Coffee";
            foreach(var coffeeCode in coffeeCodes) {
                WriteLine($"Key: {coffeeCode.Key}, value: {coffeeCode.Value}");
            }
        }
    }
}