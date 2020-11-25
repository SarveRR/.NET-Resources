using System;

namespace Conditions
{
    class Program
    {
        static void Main(string[] args)
        {
            Compare compare = new Compare();
            Calculator calculator = new Calculator();

            //1
            compare.ComparisonInt(); 
            Console.WriteLine("//////////////////////////////////////");

            //2
            compare.EvenNumber(3);
            Console.WriteLine("//////////////////////////////////////");

            //3
            compare.PositiveNegativeNumber(3);
            Console.WriteLine("//////////////////////////////////////");

            //4
            compare.LeapYear(2016);
            Console.WriteLine("//////////////////////////////////////");

            //5
            compare.RequiredAge(32);
            Console.WriteLine("//////////////////////////////////////");

            //6
            compare.Height(171);
            Console.WriteLine("//////////////////////////////////////");

            //7
            compare.ComparisionThreeInts(10,9,8);
            Console.WriteLine("//////////////////////////////////////");

            //8
            compare.Recruitment(80, 71, 0);
            Console.WriteLine("//////////////////////////////////////");

            //9
            compare.Temperature(32);
            Console.WriteLine("//////////////////////////////////////");

            //10
            compare.Triange(5,6,7);
            Console.WriteLine("//////////////////////////////////////");

            //11
            compare.Grade(5);
            Console.WriteLine("//////////////////////////////////////");

            //12
            compare.ShowDay(3);
            Console.WriteLine("//////////////////////////////////////");

            //13
            calculator.Start();
        }
    }
}
