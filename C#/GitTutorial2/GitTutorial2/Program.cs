using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTutorial2
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteHello();
            Adding(1, 3);
        }

        static void WriteHello()
        {
            Console.WriteLine("Hello");
        }

        static void Adding(int firstInt, int secondInt)
        {
            int equals = firstInt + secondInt;
            Console.WriteLine(equals);
        }
    }
}
