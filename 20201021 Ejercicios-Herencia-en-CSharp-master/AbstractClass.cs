
using System;
using static System.Console;
namespace Heritage05
{


    // The abstract keyword indicates that the class cannot be instantiated directly; 
    // it exists solely to define or implement members for derived classes.
    public abstract class ABeverage
    {
        // Non-abstract members.
        // Derived classes can use these members without modifying them.
        public string Name { get; set; }
        public bool IsFairTrade { get; set; }
        // Abstract members.
        // Derived classes must override and implement these members.
        public abstract int GetServingTemperature();
    }
}