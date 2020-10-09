using System;

namespace _20201009_calculo_media
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] num = new double[10];
            double suma = 0;
            int cont = default;
            string message = "The average of ";
            for (cont=0; cont<10; cont++) {
                string entrada = "";
                double? valor = null;
                do {
                    Console.Write("Enter the number #{cont} (or empty to end): ");
                    entrada = Console.ReadLine();
                    if (entrada=="") break;
                    try {
                        valor = Convert.ToDouble(entrada);
                    } catch(e) {}
                } while (valor == null);
                if (entrada!="") {
                    num[cont] = (double) valor;
                    message += entrada + " ";
                    suma += (double) valor;
                }
            }
            Console.WriteLine($"{message} is: {suma/cont}");
        }
    }
}
