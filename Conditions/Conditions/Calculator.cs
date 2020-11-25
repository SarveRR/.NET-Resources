using System;
using System.Collections.Generic;
using System.Text;

namespace Conditions
{
    class Calculator
    {
        public void Start()
        {
            Console.WriteLine("Enter first number");
            string first = Console.ReadLine();
            Console.WriteLine("Enter second number");
            string second = Console.ReadLine();


            Console.WriteLine("1.Addition \n2.Subtraction \n3.Multiplication \n4.Division");
            string option = Console.ReadLine();

            int parsedOption, firstParsed, secondParsed, result;

            Int32.TryParse(first, out firstParsed);
            Int32.TryParse(second, out secondParsed);
            Int32.TryParse(option, out parsedOption);

            switch(parsedOption)
            {
                case 1:
                    result = firstParsed + secondParsed;
                    Console.WriteLine("Addition result: " + result);
                    break;
                case 2:
                    result = firstParsed - secondParsed;
                    Console.WriteLine("Subtraction result: " + result);
                    break;
                case 3:
                    result = firstParsed * secondParsed;
                    Console.WriteLine("Multiplication result: " + result);
                    break;
                case 4:
                    result = firstParsed / secondParsed;
                    Console.WriteLine("Division result: " + result);
                    break;
                default:
                    Console.WriteLine("Wrong option");
                    break;
            }
        }
    }
}
