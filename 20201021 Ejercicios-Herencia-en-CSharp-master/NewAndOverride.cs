using System;
using static System.Console;
namespace Heritage05
{
    class BaseClass
    {
        //public void Method1()
        public virtual void Method1()
        {
            WriteLine("Base - Method1");
        }

        //(2)
        //public void Method2()
        public virtual void Method2()
        {
            Console.WriteLine("Base - Method2");
        }
    }

    class DerivedClass : BaseClass
    {
        public new void Method2()
        // public new void Method2()
        {
            WriteLine("Derived - Method2");
        }
        public override void Method1()
        {
            WriteLine("Derived - Method1");
        }
    }
}