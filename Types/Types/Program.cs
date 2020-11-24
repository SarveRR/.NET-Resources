using System;

namespace Types
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            string name = "Name";
            string surname = "Surname";
            int age = 20;
            long pesel = 12345678901;
            long number = 3333333333;

            Console.WriteLine(name);
            Console.WriteLine(surname);
            Console.WriteLine(age);
            Console.WriteLine(Sex.m);
            Console.WriteLine(pesel);
            Console.WriteLine(number);

            //2
            char first = 'a';
            char second = 'b';
            char third = 'c';

            Console.WriteLine($"{ third }{ second }{ first }");

            //3
            Console.WriteLine("height: ");
            string height = Console.ReadLine();
            Console.WriteLine("width: ");
            string width = Console.ReadLine();

            double parsedHeight, parsedWidth;

            double.TryParse(height, out parsedHeight);
            double.TryParse(width, out parsedWidth);

            parsedHeight = Math.Pow(parsedHeight, 2);
            parsedWidth = Math.Pow(parsedWidth, 2);

            double diagonal = Math.Sqrt(parsedHeight + parsedWidth);

            Console.WriteLine("diagonal = " + diagonal);

            //4
            Console.WriteLine("Int: ");
            string intType = Console.ReadLine();
            Console.WriteLine("String: ");
            string stringType = Console.ReadLine();
            Console.WriteLine("Float: ");
            string floatType = Console.ReadLine();

            int intTypeParsed;
            float floatTypeParsed;

            Int32.TryParse(intType, out intTypeParsed);
            float.TryParse(floatType, out floatTypeParsed);

            Console.WriteLine("Int = " + intTypeParsed);
            Console.WriteLine("String = " + stringType);
            Console.WriteLine("Float = " + floatTypeParsed);

        }

        enum Sex
        {
            m,
            k
        }
        
    }
}
