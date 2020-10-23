using System;
using System.Reflection;
using static System.Console;
using ExtensionsMethods;
namespace Extending06
{
    class Program
    {
        static void Main(string[] args)
        {

            //new Program().UsingReflection();
            //new Program().UsingExtendingList();
            //new Program().UsingCustomException(true);
            //new UsingDateTime().UsingDateTimes();
            new UsingDateTime().UsingDateTimeTwo();
            //new Program().UsingExtensionMethod();
        }

        public void UsingReflection()
        {
            Type t = typeof(SimpleClass);
            BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
                                 BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
            MemberInfo[] members = t.GetMembers(flags);
            WriteLine($"Type {t.Name} has {members.Length} members: ");
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
                WriteLine(output);

            }
        }

        public void UsingExtendingList()
        {
            UniqueList<string> listaUnica = new UniqueList<string>();

            listaUnica.Add("peras");
            listaUnica.Add("manzanas");
            listaUnica.Add("uvas");
            listaUnica.Add("bananas");
            listaUnica.Add("platanos");
            listaUnica.Add("peras");
            listaUnica.Add("uvas");
            listaUnica.Add("peras");

            foreach (var lista in listaUnica)
            {
                WriteLine(lista);
            }
            WriteLine(new String('=', 80));
            listaUnica.RemoveDuplicates();
            foreach (var lista in listaUnica)
            {
                WriteLine(lista);
            }
        }

        public void UsingCustomException(bool generaException)
        {
            try
            {
                WriteLine("Paso linea 78");
                if (generaException)
                {
                    WriteLine("Paso linea antes del throw");
                    throw new LoyaltyCardNotFoundException("The card number provided was not found");
                }
                WriteLine("Paso Linea 84");
            }
            catch (LoyaltyCardNotFoundException ex)
            {
                WriteLine("Paso Linea Catch");
                WriteLine(ex.Message);
            }
            finally
            {
                WriteLine("Paso Linea Finally");
            }
        }

        public void UsingExtensionMethod()
        {
            WriteLine("Please type some text that contains numbers and then press Enter");
            string text = ReadLine();
            if (text.ContainsNumbers())
            {
                WriteLine("Your text contains numbers. Well done!");
            }
            else
            {
                WriteLine("Your text does not contain numbers. Please try again.");
            }
            WriteLine($"\n\nEl numero de palabras en el texto es de:{text.WordCount()}");

            EjemploExtension eE = new EjemploExtension();
            eE.ListaNumeros();
            eE.ListaDescendente();

            // Define Extension Method applying a enums
            Grades g1 = Grades.D;
            Grades g2 = Grades.F;
            WriteLine("First {0} a passing grade.", g1.Passing() ? "is" : "is not");
            WriteLine("Second {0} a passing grade.", g2.Passing() ? "is" : "is not");

            ExtensionsClass.minPassing = Grades.C;
            WriteLine("\r\nRaising the bar!\r\n");
            WriteLine("First {0} a passing grade.", g1.Passing() ? "is" : "is not");
            WriteLine("Second {0} a passing grade.", g2.Passing() ? "is" : "is not");

            int Numero = 3;
            WriteLine($"Es {Numero} mayor que cinco?{(Numero.IsGreatThatFIve() ? "Si": "No")}");
            Numero = 23;
            WriteLine($"Es {Numero} mayor que cinco?{(Numero.IsGreatThatFIve() ? "Si": "No")}");


        }
    }

    public class SimpleClass
    {
        public SimpleClass(string simpleOtherProperty)
        {
            this.simpleOtherProperty = simpleOtherProperty;
        }

        public SimpleClass() { }

        public SimpleClass(string sop, int sp)
        {
            this.simpleProperty = sp;
            this.simpleOtherProperty = sop;
        }

        private void SimpleMethod() { }

        private int simpleProperty;

        public int SimpleProperty { get { return simpleProperty; } set { simpleProperty = value; } }

        private string simpleOtherProperty;

        public string SimpleOtherProperty { get => simpleOtherProperty; set => simpleOtherProperty = value; }
    }

 
}
