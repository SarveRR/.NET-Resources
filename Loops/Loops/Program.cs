using System;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            Loops loops = new Loops();

            //1
            loops.ShowPrimeNumbers();
            Console.WriteLine("\n");

            //2
            loops.EvenNumbers();
            Console.WriteLine("\n");

            //3
            loops.ShowFibonacci();
            Console.WriteLine("\n");

            //4
            loops.PyramidInts(4);
            Console.WriteLine("\n");

            //5
            loops.PowerInts();
            Console.WriteLine("\n");

            //6
            loops.Addition();
            Console.WriteLine("\n");

            //7
            loops.Stars(4);
            Console.WriteLine("\n");

            //8
            loops.RiverseOrder(12345);
            Console.WriteLine("\n");

            //9
            loops.IntToBinary(20);
            Console.WriteLine("\n");

            //10
            loops.LCM(4,5);
        }
    }
}
