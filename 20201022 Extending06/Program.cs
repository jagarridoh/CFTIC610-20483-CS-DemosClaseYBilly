using System;
using System.Reflection;
using System.Collections.Generic;

namespace _20201022_Extending06
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // new Program().UsingReflection();
            // new Program().UsingExtendedList();
            try {
                Console.WriteLine("antes del trhow");
                throw new LoyaltyCardNotFoundException("Este es el mensaje de error.");
                Console.WriteLine("despues del trhow");
            } catch(LoyaltyCardNotFoundException ex) {
                Console.WriteLine(ex.Message);
            } finally {
                Console.WriteLine("ESto es el finally.");
            }
            

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
