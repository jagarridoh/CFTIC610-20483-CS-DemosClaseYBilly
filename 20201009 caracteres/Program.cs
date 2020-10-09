using System;

namespace _20201009_caracteres
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] letra = genera('Q');
            imprime(letra);
            Console.WriteLine("\n");
            letra = genera('M');
            imprime(letra);
        }

        static public char[,] genera(char letra) {
            char[,] matr = new char[7,7];
            switch(letra) {
                case 'Q':
                    matr = new char[7,7] {  {' ','*','*','*','*','*',' '},
                                            {'*',' ',' ',' ',' ',' ','*'},
                                            {'*',' ',' ',' ',' ',' ','*'},
                                            {'*',' ',' ',' ',' ',' ','*'},
                                            {'*',' ',' ',' ',' ',' ','*'},
                                            {'*',' ',' ',' ',' ','*',' '},
                                            {' ','*','*','*','*',' ','*'}
                    };
                    break;
                case 'M':
                    matr = new char[7,7] {  {'*',' ',' ',' ',' ',' ','*'},
                                            {'*','*',' ',' ',' ','*','*'},
                                            {'*',' ','*',' ','*',' ','*'},
                                            {'*',' ',' ','*',' ',' ','*'},
                                            {'*',' ',' ',' ',' ',' ','*'},
                                            {'*',' ',' ',' ',' ',' ','*'},
                                            {'*',' ',' ',' ',' ',' ','*'}
                    };
                    break;
               // default:

            }
            return matr;
        }

        static public void imprime(char[,] matr) {
            for (int fila=0; fila < 7; fila++) {
                for (int colu=0; colu<7; colu++) {
                    Console.Write(matr[fila,colu]);
                }
                Console.WriteLine("");
            }
        }
    }
}
