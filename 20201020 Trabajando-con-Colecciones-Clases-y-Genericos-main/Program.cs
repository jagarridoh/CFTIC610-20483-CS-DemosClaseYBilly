using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace _11Collection
{
    class WorkingWithCollections
    {
        static void Main()
        {
            //new WorkingWithCollections().UsingCustomCollection();
            //MetodosGenericos.TestSwap();
            //new WorkingWithCollections().UsingCollection();
            //Entendiendo Yield
            //new YieldClass().Consumer();
            //new WorkingWithCollections().UsingMethodsGenerics();
            //new UsingLinkedListTClass().UsingLinkedListT();
            //new UsingQueueT().UsingQueueTList();
            new DictionaryGeneric().UsingDictionaryGeneric();
        }
        public void UsingCollection()
        {
            var car1 = new Car();
            car1.Make = "Oldsmobile";
            car1.Model = "Cutlas Supreme";
            car1.VIN = "A1";
            var car3 = new Car
            {
                Make = "GMC",
                Model = "Grand Voyager",
                VIN = "C1"
            };
            var car2 = new Car
            {
                Make = "Geo",
                Model = "Prism",
                VIN = "B2"
            };
            var b1 = new Book();
            b1.Author = "Robert Tabor";
            b1.Title = "Microsoft .NET XML Web Services";
            b1.ISBN = "0-000-00000-0";

            //ArrayLists are dynamically sized,
            //cool features sorting, remove items
            var myArrayList2 = new ArrayList
            {
                car1,
                car2,
                b1
            };
            var myArrayList = new ArrayList
            {
                car1,
                car2,
                b1
            };
            try
            {
                foreach (Car car in myArrayList)
                {
                    WriteLine(car.Make);
                }
            }
            catch (InvalidCastException e)
            {
                WriteLine($"{e.Message} -no property was found");
            }
            myArrayList.Remove(b1);
            //color antes de la invocación;
            var preColor = (int)ForegroundColor;
            //color antes de la invocación;
            ForegroundColor = ConsoleColor.White;
            myArrayList.Add(car3);
            foreach (Car car in myArrayList)
            {
                WriteLine(car.Make);
            }
            ForegroundColor = (ConsoleColor)preColor;
            //Esto puesde ser igual que las lineas después de lo comentado List<Car> myList = new List<Car>();
            //myList.Add(car1);
            //myList.Add(car2);

            //List<T> Esto es equivalente a lo anterior y mucho mas eficiente
            var myList = new List<Car>
            {
                car1,
                car2
            };
            //Esto genera un error myList.Add(b1);
            foreach (Car car in myList)
            {
                WriteLine(car.Model);
            }
            //Esto es una colleccion generica especializad Dictionary<TKey, TValue>
            var myDictionary = new Dictionary<string, Car>
            {
                { car1.VIN, car1 },
                { car2.VIN, car2 }
            };
            WriteLine(myDictionary["B2"].Make);
            if (myDictionary.TryGetValue("B2", out Car mdvalue))
            {
                Write(mdvalue.Make);

            }
            else WriteLine("Car not found");
            //string[] names = { "Bob", "Steve", "Brian", "Chuck" };
            // Object initializer
            // No need for a Constructor
            //Car 
            car1 = new Car { Make = "BMW", Model = "750li", VIN = "C3" };
            //Car 
            car2 = new Car { Make = "Toyota", Model = "4Runner", VIN = "D4" };
            // Collection initializer
            //List<Car> 
            myList = new List<Car> {
                new Car { Make = "Oldsmobile", Model = "Cutlas Supreme", VIN = "E5" },
                new Car { Make = "Nissan", Model = "Altima", VIN = "F6" }
            };
            WriteLine("\nPress any key to continue...");
            ReadKey();
        }
        class Car
        {
            public string VIN { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public double StickerPrice { get; set; }
        }
        class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string ISBN { get; set; }
            public string Make { get; set; }
        }

        public void UsingCustomCollection()
        {
            GenericList<Employee> empleadoList = new GenericList<Employee>();
            //GenericList<EmployeeOfMonth> empleadoListMonth = new GenericList<EmployeeOfMonth>();
            GenericList<EmployeeOfYear> empleadoListYear = new GenericList<EmployeeOfYear>();

            Employee employee = new Employee("Javier", 23);
            empleadoList.AddHead(employee);
            empleadoList.AddHead(new Employee("Carlos", 25));
            empleadoList.AddHead(new Employee("JuanJo", 29));
            empleadoList.AddHead(new Employee("JVicente", 25));

            foreach (var empleado in empleadoList)
            {
                WriteLine($"{empleado.Name}, {empleado.ID}");
            }
            string firstEmpleado;
            string empleadoABuscar=default;    
            string salir = "*";

            do
            {
                try
                {
                    lecturaTeclado($"Entre el empleado a buscar y pulse ENTER (Salir con {salir}):>",out empleadoABuscar);
                    if(!empleadoABuscar.StartsWith("*"))
                    {
                        firstEmpleado = empleadoList.FindFirstOccurrence(empleadoABuscar).Name;
                        WriteLine($"Empleado encontrado en la lista:{firstEmpleado}");
                    }
                }
                catch (NullReferenceException e)
                {
                    WriteLine($"El empleado no existe:\"{e.ToString().Substring(0,29)}\"");
                }
            } while (true && empleadoABuscar!=salir);
        }
        public void lecturaTeclado(string mensaje, out string lectura)
        {
            Write(mensaje);
            lectura = ReadLine();
        }
 
        public void UsingMethodsGenerics()
        {
            Animal vacaGenerica = new Animal("No Country");
            vacaGenerica.Name = "vaca Generica";
            Cow vacaEstructurada = new Cow("Estructurada");
            //vacaEstructurada.Name = "Holstein";
            CowHolstein vacaHolstein = new CowHolstein("Marina","No Country");
            Dog germanShepherd = new Dog("Germany");
            germanShepherd.Name = "Rex";
            Specie otherKind = new Specie();
            Animal.Save<Animal>(vacaGenerica);
            //Animal.Save<Cow>(vacaEstructurada);
            Animal.Save<Dog>(germanShepherd);
            //Animal.Save<CowHolstein>(vacaHolstein);
            //Animal.Save<Specie>(otherKind);

        }
    }
}