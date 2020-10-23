using System;
using System.Reflection;
using System.Collections.Generic;
using ExtensionsMethods;
using static System.Console;

namespace _20201022_Extending06
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // new Program().UsingReflection();
            // new Program().UsingExtendedList();
            
            // try
            // {
            //     Console.WriteLine("antes del trhow");
            //     throw new LoyaltyCardNotFoundException("Este es el mensaje de error.");
            //     Console.WriteLine("despues del trhow");
            // }
            // catch (LoyaltyCardNotFoundException ex)
            // {
            //     Console.WriteLine(ex.Message);
            // }
            // finally
            // {
            //     Console.WriteLine("ESto es el finally.");
            // }

            new Program().UsingExtensionMethod();

        }


        public void UsingExtensionMethod()
        {
            Console.WriteLine("Please type some text that contains numbers and then press Enter");
            string text = Console.ReadLine();
            if (text.ContainsNumbers())
            {
                Console.WriteLine("Your text contains numbers. Well done!");
            }
            else
            {
                Console.WriteLine("Your text does not contain numbers. Please try again.");
            }
            Console.WriteLine($"El numero de palabras del texto es:{text.WordCount()}");
            EjemploExtension eE = new EjemploExtension();
            eE.ListaNumeros();
            eE.ListaDescendente();

            Grades g1 = Grades.D;
            Grades g2 = Grades.F;
            Console.WriteLine("First {0} a passing grade.", g1.Passing() ? "is" : "is not");
            Console.WriteLine("First {0} a passing grade.", g2.Passing() ? "is" : "is not");

            ExtensionsClass.minPassing  = Grades.C;
            Console.WriteLine("\r\nRaising the bar!");
            Console.WriteLine("First {0} a passing grade.", g1.Passing() ? "is" : "is not");
            Console.WriteLine("First {0} a passing grade.", g2.Passing() ? "is" : "is not");

            int Numero = 3;
            WriteLine($"{Numero} Es mayor que cinco? {Numero.IsGreaterThanFive()}");
            Numero = 6;
            WriteLine($"{Numero} Es mayor que cinco? {(Numero.IsGreaterThanFive() ? "Si" : "No")}");

        }

        public void UsingReflection()
        {
            Type t = typeof(SimpleClass);
            BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
                                 BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
            MemberInfo[] members = t.GetMembers(flags);
            Console.WriteLine($"Type {t.Name} has {members.Length} members: ");
            foreach (var member in members)
            {
                string access = "";
                string stat = "";
                var method = member as MethodBase;
                if (method != null)
                {
                    if (method.IsPublic)
                        access = " Public";
                    else if (method.IsPrivate)
                        access = " Private";
                    else if (method.IsFamily)
                        access = " Protected";
                    else if (method.IsAssembly)
                        access = " Internal";
                    else if (method.IsFamilyOrAssembly)
                        access = " Protected Internal ";
                    if (method.IsStatic)
                        stat = " Static";
                }
                var output = $"{member.Name} ({member.MemberType}): {access}{stat}, Declared by {member.DeclaringType}";
                Console.WriteLine(output);
            }
        }
        public void UsingExtendedList()
        {
            UniqueList<string> listaUnica = new UniqueList<string>();
            listaUnica.Add("AA");
            listaUnica.Add("CC");
            listaUnica.Add("BB");
            listaUnica.Add("BB");
            listaUnica.Add("BB");
            listaUnica.Add("CC");
            listaUnica.Add("ZZ");
            foreach (var lista in listaUnica)
            {
                Console.WriteLine(lista);
            }
            listaUnica.RemoveDuplicates();
            Console.WriteLine("- - - - - - ");
            foreach (var lista in listaUnica)
            {
                Console.WriteLine(lista);
            }
        }
    }

    public class SimpleClass
    {
        public SimpleClass(string simpleOtherProperty)
        {
            this.simpleOtherProperty = simpleOtherProperty;
        }

        public SimpleClass() { }

        private void SimpleMethod() { }

        private int simpleProperty;

        private string simpleOtherProperty;

        public int SimpleProperty { get => simpleProperty; set => simpleProperty = value; }
        public string SimpleOtherProperty { get { return simpleOtherProperty; } set { simpleOtherProperty = value; } }
    }

    public class UniqueList<T> : List<T>
    {
        public void RemoveDuplicates()
        {
            base.Sort();
            for (int i = this.Count - 1; i > 0; i--)
            {
                if (this[i].Equals(this[i - 1]))
                {
                    this.RemoveAt(i);
                }
            }
        }
    }

    public class LoyaltyCardNotFoundException : Exception
    {
        public LoyaltyCardNotFoundException()
        {
            // This implicitly calls the base class constructor.
        }
        public LoyaltyCardNotFoundException(string message) : base(message)
        {
        }
        public LoyaltyCardNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
