using System;
using System.Collections.Generic;
using System.Text;

namespace Conditions
{
    class Compare
    {
        public void ComparisonInt()
        {
            int first = 5;
            int second = 5;

            if(first == second)
            {
                Console.WriteLine("Same value");
            }
            else
            {
                Console.WriteLine("Different value");
            }
        }

        public void EvenNumber(int number)
        {
            if(number % 2 == 0)
            {
                Console.WriteLine("Even number");
            }
            else
            {
                Console.WriteLine("Odd number");
            }
        }

        public void PositiveNegativeNumber(int number)
        {
            if(number<0)
            {
                Console.WriteLine("Negative number");
            }
            else
            {
                Console.WriteLine("Positive number");
            }
        }
    }
}
