using System;
using System.Web;

namespace _20201015_enum
{
    class Program
    {
        enum Day { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Day favorito = Day.Monday;
            Console.WriteLine(favorito);
            Console.WriteLine((int)favorito);
            Day favorito2 = (Day)4;
            Console.WriteLine(favorito2);
            Console.WriteLine((int)favorito2);

            Coffee colombia = new Coffee();
            colombia.Strength = 1;
            colombia.Bean = "Grano";
            colombia.CountryOfOrigin = "Colombia";
            Coffee brasil = new Coffee();
            Console.WriteLine(colombia);
            Console.WriteLine(colombia.ToString2());
            Console.WriteLine(brasil);
            
        }

    }

    internal struct Coffee
    {
        // This is the custom constructor.
        public Coffee(int strength, string bean, string countryOfOrigin)
        {
            this.Strength = strength;
            this.Bean = bean;
            this.CountryOfOrigin = countryOfOrigin;
        }
        public string ToString2() {
            return $"Strngth={this.Strength}, Bena={this.Bean}";
        }
        // These statements declare the struct fields and set the default values.
        public int Strength;
        public string Bean;
        public string CountryOfOrigin;
        // Other methods, fields, properties, and events.
    }
}