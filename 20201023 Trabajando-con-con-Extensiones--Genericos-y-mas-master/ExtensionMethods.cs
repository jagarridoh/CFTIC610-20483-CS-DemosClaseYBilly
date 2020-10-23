using System;
using static System.Console;
using System.Text.RegularExpressions;
namespace ExtensionsMethods
{
    public enum Grades { F = 0, D = 1, C = 2, B = 3, A = 4 };

    public static class ExtensionsClass
    {
        public static bool ContainsNumbers(this String s)
        {
            // Use regular expressions to determine whether the string contains any numerical digits.
            return Regex.IsMatch(s, @"\d");
        }
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static bool IsNumeric(this string inputString)
        {
            return decimal.TryParse(inputString, out decimal result);
        }

        public static Grades minPassing = Grades.D;
        public static bool Passing(this Grades grade)
        {
            return grade >= minPassing;
        }

        public static bool IsGreatThatFIve(this int s)
        {
            return s > 5;
        }

        public static void ListaDescendente(this EjemploExtension eE)
        {
            for (int i = 10; i > 0; i--)
            {
                WriteLine($"i:{i}");
            }
        }
    }
    public struct EjemploExtension
    {

        public void ListaNumeros()
        {
            for (int i = 0; i < 10; i++)
            {
                WriteLine($"i:{i}");
            }
        }
    }
}