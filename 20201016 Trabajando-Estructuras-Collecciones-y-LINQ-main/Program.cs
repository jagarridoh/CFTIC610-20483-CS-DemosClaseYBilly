using System;

namespace EstructsEnumsDataCollectionEvents
{
    class Program
    {
        enum Day { Sunday = 3, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };
        static void Main01(string[] args)
        {
            Day favoriteDay = Day.Monday;
            favoriteDay = (Day)4;
            Console.WriteLine(favoriteDay);
            favoriteDay = (Day)4;
            Console.WriteLine(favoriteDay);
            Console.WriteLine((int)favoriteDay);

            //Coffee colombia = new Coffee();
            //Coffee brasil = new Coffee();

            Coffee coffee1 = new Coffee();
            coffee1.Strength = 8;
            coffee1.Bean = "Arabica";
            coffee1.CountryOfOrigin = "Kenya";

            // Call the custom constructor by providing arguments for the three required parameters.
            Coffee coffee2 = new Coffee(4, "Arabica", "Columbia");

            Console.WriteLine(coffee1.Strength);

            int[] arrayNumeros = new int[3];
            //Coffee[] beverages = new Coffee[3];

            // La creación de una structura con un campo tipo array en invocando a su constructor
            Menu myMenu = new Menu("string1");
            string firstDrink = myMenu.beverages[0]; // Esto se resolvera con el indexer => myMenu[0];
            Console.WriteLine(firstDrink);
            firstDrink = myMenu[0];
            Console.WriteLine(firstDrink);
            Console.WriteLine(myMenu.Length);

            // Ejemplo de uso del struct de temperatura
            TempRecord temps1; // Se puede crear una instancia de estructura sin utilizar el operador nuevo
            temps1.City = "Manila";
            Console.WriteLine($"Uso de la variable tipo structura TempRecord sin new:{temps1.City}");

            TempRecord temps = new TempRecord("Miami");
            // 
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine($"Temperatura 1{temps[i]:N2} ºF");
            }

            // Structure Location
            Location a = new Location(20, 20);
            Location b = a; //new Location(50,50);
            //b=a;
            a.x = 100;
            Console.WriteLine($"Uso de Location b.x:{b.x}");
            Console.WriteLine($"Uso de Location a.x:{a.x}");
            Console.WriteLine($"Los valores de a.x y a.y:{a.ToString()}");
        }
    }
    #region No1
    internal struct Coffee
    {
        private int strength;
        public string Bean;
        public string CountryOfOrigin;
        // Other methods, fields, properties, and events.
        internal Coffee(int strength, string bean, string countryOfOrigin)
        {
            this.strength = strength;
            this.Bean = bean;
            this.CountryOfOrigin = countryOfOrigin;
        }

        internal void Preparacion()
        {
            this.Strength = 23;
        }
        //public int Strength {get; set;} // Forma minima de declarar la propiedad
        //public int Strength {get;}      // Forma minima de solo lectura
        public int Strength // Declaración de la propiedad extendida
        {
            //set { strength = value;}
            // Antes de pasar el valor a mi field puedo 
            // tener reglas de negocio que validar
            set
            {
                if (value < 1)
                { strength = 1; }
                else if (value > 5)
                { strength = 5; }
                else
                { strength = value; }
            }

            get { return strength; }
        }
    }

    public struct Menu
    {
        public string[] beverages;
        /*public string[] comidas;*/
        public Menu(string dummy)
        {
            beverages = new string[] { "Americano", "Café au Lait", "Café Macchiato", "Cappuccino", "Espresso" };
            //comidas = new string[] {"filete","sardinas"};
        }
        // This is the indexer.
        public string this[int index]
        {
            get { return this.beverages[index]; }
            set { this.beverages[index] = value; }
        }
        // No puede haber si no un indexer por estructura
        /*public string this[int index]
        {
            get {return this.comidas[index];}
            set { this.comidas[index] = value; }
        }*/
        // Enable client code to determine the size of the collection.
        public int Length
        {
            get { return beverages.Length; }
        }
    }

    public struct TempRecord
    {
        // Array of temperature values
        /*float[] temps = new float[10]
        {
        56.2F, 56.7F, 56.5F, 56.9F, 58.8F,
        61.3F, 65.9F, 62.1F, 59.2F, 57.5F
        };*/
        float[] temps;
        public string City;

        // To enable client code to validate input
        // when accessing your indexer.
        public int Length => temps.Length;

        // Indexer declaration.
        // If index is out of range, the temps array will throw the exception.
        public float this[int index]
        {
            get => temps[index];
            set => temps[index] = value;
            //get { return temps[index]; }
            //set {temps[index]=value;}

        }

        public TempRecord(string city) // Esto se hace porque el constructor de la estructura no puede ser sin parametros
        {
            temps = new float[10]
                    {
                        56.2F, 56.7F, 56.5F, 56.9F, 58.8F,
                        61.3F, 65.9F, 62.1F, 59.2F, 57.5F
                    };
            City = city;
        }
    }
    #endregion
    //struct Location
    class Location
    {
        public int x, y;
        /*public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }*/
        public Location(int x, int y) => (this.x, this.y) = (x, y);

        public override string ToString() => $"({x}, {y})"; //Sobre escribe el método string 
    }
}

