using System;
using static System.Console;
namespace Heritage05
{
    class A
    {
        protected int x = 123;
    }

    class B : A
    {
        static void Main01()
        {
            var a = new A();
            var b = new B();

            // Error CS1540, because x can only be accessed by
            // classes derived from A.
            // a.x = 10;

            // OK, because this class derives from A.
            b.x = 10;
        }
        void otherMethod()
        {
            var a = new A();
            var b = new B();
            //a.x = 15;
            b.x = 10;
        }

    }
    class C
    {
    }
}