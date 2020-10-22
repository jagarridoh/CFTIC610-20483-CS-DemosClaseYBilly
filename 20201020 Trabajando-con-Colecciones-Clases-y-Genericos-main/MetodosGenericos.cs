using System.Collections.Generic;
using System;
using static System.Console;
namespace _11Collection
{
    public class MetodosGenericos
    {

        public static void TestSwap()
        {
            int a = 1;
            int b = 2;
            Swap<int>(ref a, ref b);
            WriteLine(a + " " + b);

            string pAmerica="Honduras";
            string pEuropa = "Portugal";
            Swap<string>(ref pAmerica, ref pEuropa);   
            WriteLine($"pAmerica:{pAmerica},pEuropa:{pEuropa}");
        }

        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }

    public class Animal : IAnimal
    {
        public string Name { get; set; }
        private string countryOfOrigin;
        public Animal() => Name = "Generic Animal";  // Si la condicion es new()
        public Animal(string CountryOfOrigin) => CountryOfOrigin = countryOfOrigin;

        // new()
        // Animal, new()
        // struct
        // IAnimal
        public static void Save<T>(T target) where T : Animal, new()
        {
            Animal animal = new Animal("No Country");
            IAnimal Ianimal = new Animal("No Country");
            if (target is Animal)
            {
                animal = (Animal)(object)target;
                WriteLine(animal.Name);
            }
            else if (target is IAnimal)
            {
                Ianimal = (IAnimal)(object)target;
                WriteLine(Ianimal.Name);
            }
            else
                WriteLine("Invalid animal");
        }

        public static T ConvertValue<T>(T value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }

    public struct Cow : IAnimal
    {
        public string Name { get; set; }
        public Cow(string name) => Name = name;
    }

    public class CowHolstein : Animal
    {
        //public string Name { get; set; }

        public string CountryOfOrigin { get; set; }
        public CowHolstein(string name, string CountryOfOrigin) : base(CountryOfOrigin)
        {
            Name = name;
            //CountryOfOrigin = "No country";
        }
    }

    public class Dog : Animal
    {
        public Dog(string CountryOfOrigin) : base(CountryOfOrigin) { }
        public Dog() : base() {}
        public string CountryOfOrigin = "No Country";
    }

    public class Specie
    {

    }

    public interface IAnimal
    {
        string Name { get; set; }
    }
}