using System;
using System.Collections.Generic;
using System.Linq;
namespace _11Collection
{
    public class YieldClass
    {
        public void Consumer()
        {
            Console.WriteLine("En un foreach normal:");
            foreach (int i in Integers())
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine("En un instrucción LINQ normal:");
            var resultado =
                from int enteros in Integers()
                where enteros > 5
                select enteros;
            foreach (var i in resultado)
            {
                Console.WriteLine(i.ToString());
            }
        }

        public IEnumerable<int> Integers()
        {
            yield return 1;
            yield return 2;
            yield return 4;
            yield return 8;
            yield return 16;
            yield return 16777216;
        }
    }
}