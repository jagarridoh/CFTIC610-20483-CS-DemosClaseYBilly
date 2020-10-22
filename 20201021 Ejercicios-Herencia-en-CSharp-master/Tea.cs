using System;
using static System.Console;
namespace Heritage05
{
    public sealed class Tea : ABeverage
    {
        public override int GetServingTemperature()
        {
            return 78;
        }

    }
}