using System;
using System.Collections;
using EstructsEnumsDataCollectionEvents;
using System.Linq;
namespace StandardCollectionClasses
{
    class Program
    {

        static void Main2345()
        {
            //new Program().ArrayListCollection();
            //new Program().HashTableCollection();
            new Program().UsingLinQToQueryCollection();

        }

        public void ArrayListCollection()
        {

            // Adding and Retrieving Items from an ArrayList 

            // Create a new ArrayList collection.
            ArrayList beverages = new ArrayList();
            //ArrayList beverages = new ArrayList();
            // Create some items to add to the collection.
            Coffee coffee1 = new Coffee(4, "Arabica", "Columbia");
            Coffee coffee2 = new Coffee(3, "Arabica", "Vietnam");
            Coffee coffee3 = new Coffee(4, "Robusta", "Indonesia");
            Coffee coffee4 = new Coffee(5, "Robusta", "Kenia");
           // TempRecord 
            // Add the items to the collection.
            // Items are implicitly cast to the Object type when you add them.
            beverages.Add(coffee1);
            beverages.Add(coffee2);
            beverages.Add(coffee3);
            // Retrieve items from the collection.
            // Items must be explicitly cast back to their original type.
            Coffee firstCoffee = (Coffee)beverages[0];
            Coffee secondCoffee = (Coffee)beverages[1];
            //TempRecord firstTemp = 
            Console.WriteLine("--->");
            Console.WriteLine(coffee4);
            // Iterating Over a List Collection 

            foreach (Coffee coffee in beverages)
            {
                Console.WriteLine("Bean type: {0}", coffee.Bean);
                Console.WriteLine("Country of origin: {0}", coffee.CountryOfOrigin);
                Console.WriteLine("Strength (1-5): {0}", coffee.Strength);
            }

            Console.WriteLine(beverages[0]);

        }

        public void HashTableCollection()
        {

            // Adding and Retrieving Items from a Hashtable 

            // Create a new Hashtable collection.
            Hashtable ingredients = new Hashtable();
            // Add some key/value pairs to the collection.
            ingredients.Add("Café au Lait", "Coffee, Milk");
            ingredients.Add("Café Mocha", "Coffee, Milk, Chocolate");
            ingredients.Add("Cappuccino", "Coffee, Milk, Foam");
            ingredients.Add("Irish Coffee", "Coffee, Whiskey, Cream, Sugar");
            ingredients.Add("Macchiato", "Coffee, Milk, Foam");
            // Check whether a key exists.
            if (ingredients.ContainsKey("Café Mocha"))
            {
                // Retrieve the value associated with a key.
                Console.WriteLine("The ingredients of a Café Mocha are: {0}", ingredients["Café Mocha"]);
            }

            // Iterating Over a Dictionary Collection 
            foreach (string key in ingredients.Keys)
            {
                // For each key in turn, retrieve the value associated with the key.
                Console.WriteLine("The ingredients of a {0} are {1}", key, ingredients[key]);
            }



        }

        public void UsingLinQToQueryCollection()
        {
            // Create a new Hashtable and add some drinks with prices.
            Hashtable prices = new Hashtable();
            prices.Add("Café au Lait", 1.99M);
            prices.Add("Caffe Americano", 1.89M);
            prices.Add("Café Mocha", 2.99M);
            prices.Add("Cappuccino", 2.49M);
            prices.Add("Espresso", 1.49M);
            prices.Add("Espresso Romano", 1.59M);
            prices.Add("English Tea", 1.69M);
            prices.Add("Juice", 2.89M);
            // Select all the drinks that cost less than $2.00, and order them by cost.
            var bargains =
             from string drink in prices.Keys
             where (Decimal)prices[drink] < 2.00M
             orderby prices[drink] ascending
             select drink;
            // Display the results.
            Console.WriteLine("Select all the drinks that cost less than $2.00, and order them by cost.");
            foreach (string bargain in bargains)
            {
                Console.WriteLine($"{bargain},{prices[bargain]:C}");
            }
            Console.Write("Press any key...");
            Console.ReadLine();
            //Select all drinks start with letter C
            Console.WriteLine("Select all drinks start with letter C");
            var bargainsQ2 =
                from string drinkName in prices.Keys
                where drinkName.StartsWith("C")
                select drinkName;
            foreach (string bargain in bargainsQ2)
            {
                Console.WriteLine($"{bargain},{prices[bargain]:C}");
            }
            Console.Write("Press any key...");
            Console.ReadLine();
            // Select all the drinks that cost between $1.50 and $2.00 order by name
            Console.WriteLine("Select all the drinks that cost between $1.50 and $2.00 order by name");
            var bargainsQ3 =
                from string drinkCost in prices.Keys
                where (Decimal)prices[drinkCost] >= 1.50M && (Decimal)prices[drinkCost] <= 2.00M
                orderby drinkCost
                select drinkCost;
            foreach (string bargain in bargainsQ3)
            {
                Console.WriteLine($"{bargain},{prices[bargain]:C}");
            }
            Console.Write("Press any key...");
            Console.ReadLine();
            // Select the sum total of all baverages
            Console.WriteLine("Select the sum total of all baverages");
            var bargainsQ4 =
                (from decimal drinkCostSum in prices.Values
                 select drinkCostSum).Sum();
            Console.WriteLine($"The sum of beverages are:{bargainsQ4:C}");


        }

        public void UsingLinQFirstOrDefaultAndLastMethods()
        {
            // Create a new Hashtable and add some drinks with prices.
            Hashtable prices = new Hashtable();
            prices.Add("Café au Lait", 1.99M);
            prices.Add("Caffe Americano", 1.89M);
            prices.Add("Café Mocha", 2.99M);
            prices.Add("Cappuccino", 2.49M);
            prices.Add("Espresso", 1.49M);
            prices.Add("Espresso Romano", 1.59M);
            prices.Add("English Tea", 1.69M);
            prices.Add("Juice", 2.89M);
            // Query the Hashtable to order drinks by cost.
            var drinks =
             from string drink in prices.Keys
             orderby prices[drink] ascending
             select drink;
            Console.WriteLine("The cheapest drink is {0}: ", drinks.FirstOrDefault());
            // Output: "The cheapest drink is Espresso"
            Console.WriteLine("The most expensive drink is {0}: ", drinks.Last());
            // Output: "The most expensive drink is Café Mocha"
            Console.WriteLine("The maximum is {0}: ", drinks.Max());
            // Output: "The maximum is Juice"
            // "Juice" is the largest value in the collection when ordered alphabetically.
            Console.WriteLine("The minimum is {0}: ", drinks.Min());
            // Output: "The minimum is Café au Lait"
            // "Café au Lait" is the smallest value in the collection when ordered alphabetically.
        }
    }

}