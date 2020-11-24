using System;

namespace Types
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();

            //1
            person.DisplayUserInfo();

            //2
            DisplayChar();

            //3
            DiagonalRectangle();

            //4
            DisplayTypes();

            //5
            person.TakeAndDisplayUserInfo();

            

            void DisplayChar()
            {
                Console.WriteLine("\n2.Program\n");

                char first = 'a';
                char second = 'b';
                char third = 'c';

                Console.WriteLine($"{ third }{ second }{ first }");
            }

            void DiagonalRectangle()
            {
                Console.WriteLine("\n3.Program\n");

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
            }

            void DisplayTypes()
            {
                Console.WriteLine("\n4.Program\n");

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
        }   
    }
}
