using System;
using System.Collections;
using System.Collections.Specialized;

namespace SpecializedCollectionClasses
{
    public class Program
    {
        static void Main777()
        {

            //new Program().ListDictionaryCollection();
            new Program().StringCollectionExample();
        }

        #region ListDictionary Specialized Collection Class
        public void ListDictionaryCollection()
        {
            // Creates and initializes a new ListDictionary.
            ListDictionary myCol = new ListDictionary();
            myCol.Add("Braeburn Apples", "1.49");
            myCol.Add("Fuji Apples", "1.29");
            myCol.Add("Gala Apples", "1.49");
            myCol.Add("Golden Delicious Apples", "1.29");
            myCol.Add("Granny Smith Apples", "0.89");
            myCol.Add("Red Delicious Apples", "0.99");

//if (false) {
            // Display the contents of the collection using foreach. This is the preferred method.
            Console.WriteLine("Displays the elements using foreach:");
            PrintKeysAndValues1(myCol);

            // Display the contents of the collection using the enumerator.
            Console.WriteLine("Displays the elements using the IDictionaryEnumerator:");
            PrintKeysAndValues2(myCol);

            // Display the contents of the collection using the Keys, Values, Count, and Item properties.
            Console.WriteLine("Displays the elements using the Keys, Values, Count, and Item properties:");
            PrintKeysAndValues3(myCol);
//}
            // Copies the ListDictionary to an array with DictionaryEntry elements.
            DictionaryEntry[] myArr = new DictionaryEntry[myCol.Count];
            myCol.CopyTo(myArr, 0);

            // Displays the values in the array.
            Console.WriteLine("Displays the elements in the array:");
            Console.WriteLine("   KEY                       VALUE");
            for (int i = 0; i < myArr.Length; i++)
                Console.WriteLine("   {0,-25} {1}", myArr[i].Key, myArr[i].Value);
            Console.WriteLine();

            // Searches for a key.
            if (myCol.Contains("Kiwis"))
                Console.WriteLine("The collection contains the key \"Kiwis\".");
            else
                Console.WriteLine("The collection does not contain the key \"Kiwis\".");
            Console.WriteLine();

            // Deletes a key.
            myCol.Remove("Plums");
            Console.WriteLine("The collection contains the following elements after removing \"Plums\":");
            PrintKeysAndValues1(myCol);

            // Clears the entire collection.
            myCol.Clear();
            Console.WriteLine("The collection contains the following elements after it is cleared:");
            PrintKeysAndValues1(myCol);
        }
        // Uses the foreach statement which hides the complexity of the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public static void PrintKeysAndValues1(IDictionary myCol)
        {
            Console.WriteLine("   KEY                       VALUE");
            foreach (DictionaryEntry de in myCol)
                Console.WriteLine("   {0,-25} {1}", de.Key, de.Value);
            Console.WriteLine();
        }

        // Uses the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public static void PrintKeysAndValues2(IDictionary myCol)
        {
            IDictionaryEnumerator myEnumerator = myCol.GetEnumerator();
            Console.WriteLine("   KEY                       VALUE");
            while (myEnumerator.MoveNext())
                Console.WriteLine("   {0,-25} {1}", myEnumerator.Key, myEnumerator.Value);
            Console.WriteLine();
        }

        // Uses the Keys, Values, Count, and Item properties.
        public static void PrintKeysAndValues3(ListDictionary myCol)
        {
            String[] myKeys = new String[myCol.Count];
            myCol.Keys.CopyTo(myKeys, 0);

            Console.WriteLine("   INDEX KEY                       VALUE");
            for (int i = 0; i < myCol.Count; i++)
                Console.WriteLine("   {0,-5} {1,-25} {2}", i, myKeys[i], myCol[myKeys[i]]);
            Console.WriteLine();
        }
        #endregion
    
        #region StringCollection Specialized Collection Class
        public void StringCollectionExample()
        {

            // Create and initializes a new StringCollection.
            StringCollection myCol = new StringCollection();

            // Add a range of elements from an array to the end of the StringCollection.
            String[] myArr = new String[] { "RED", "orange", "yellow", "RED", "green", "blue", "RED", "indigo", "violet", "RED" };
            myCol.AddRange(myArr);

            // Display the contents of the collection using foreach. This is the preferred method.
            Console.WriteLine("Displays the elements using foreach:");
            PrintValues1(myCol);
//if (false) {
            // Display the contents of the collection using the enumerator.
            Console.WriteLine("Displays the elements using the IEnumerator:");
            PrintValues2(myCol);

            // Display the contents of the collection using the Count and Item properties.
            Console.WriteLine("Displays the elements using the Count and Item properties:");
            PrintValues3(myCol);

            // Add one element to the end of the StringCollection and insert another at index 3.
            myCol.Add("* white");
            myCol.Insert(3, "* gray");

            Console.WriteLine("After adding \"* white\" to the end and inserting \"* gray\" at index 3:");
            PrintValues1(myCol);

            // Remove one element from the StringCollection.
            myCol.Remove("yellow");

            Console.WriteLine("After removing \"yellow\":");
            PrintValues1(myCol);

            // Remove all occurrences of a value from the StringCollection.
            int i = myCol.IndexOf("RED");
            while (i > -1)
            {
                myCol.RemoveAt(i);
                i = myCol.IndexOf("RED");
            }

            // Verify that all occurrences of "RED" are gone.
            if (myCol.Contains("RED"))
                Console.WriteLine("*** The collection still contains \"RED\".");

            Console.WriteLine("After removing all occurrences of \"RED\":");
            PrintValues1(myCol);

            // Copy the collection to a new array starting at index 0.
            String[] myArr2 = new String[myCol.Count];
            myCol.CopyTo(myArr2, 0);

            Console.WriteLine("The new array contains:");
            for (i = 0; i < myArr2.Length; i++)
            {
                Console.WriteLine("   [{0}] {1}", i, myArr2[i]);
            }
            Console.WriteLine();

            // Clears the entire collection.
            myCol.Clear();
//}
            Console.WriteLine("After clearing the collection:");
            PrintValues1(myCol);
        }

        // Uses the foreach statement which hides the complexity of the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public static void PrintValues1(StringCollection myCol)
        {
            foreach (Object obj in myCol)
                Console.WriteLine("   {0}", obj);
            Console.WriteLine();
        }

        // Uses the enumerator.
        // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
        public static void PrintValues2(StringCollection myCol)
        {
            StringEnumerator myEnumerator = myCol.GetEnumerator();
            while (myEnumerator.MoveNext())
                Console.WriteLine("   {0}", myEnumerator.Current);
            Console.WriteLine();
        }

        // Uses the Count and Item properties.
        public static void PrintValues3(StringCollection myCol)
        {
            for (int i = 0; i < myCol.Count; i++)
                Console.WriteLine("   {0}", myCol[i]);
            Console.WriteLine();
        }

        #endregion
    }

    /*
    This code produces the following output.

    Displays the elements using foreach:
       RED
       orange
       yellow
       RED
       green
       blue
       RED
       indigo
       violet
       RED

    Displays the elements using the IEnumerator:
       RED
       orange
       yellow
       RED
       green
       blue
       RED
       indigo
       violet
       RED

    Displays the elements using the Count and Item properties:
       RED
       orange
       yellow
       RED
       green
       blue
       RED
       indigo
       violet
       RED

    After adding "* white" to the end and inserting "* gray" at index 3:
       RED
       orange
       yellow
       * gray
       RED
       green
       blue
       RED
       indigo
       violet
       RED
       * white

    After removing "yellow":
       RED
       orange
       * gray
       RED
       green
       blue
       RED
       indigo
       violet
       RED
       * white

    After removing all occurrences of "RED":
       orange
       * gray
       green
       blue
       indigo
       violet
       * white

    The new array contains:
       [0] orange
       [1] * gray
       [2] green
       [3] blue
       [4] indigo
       [5] violet
       [6] * white

    After clearing the collection:

    */
}
