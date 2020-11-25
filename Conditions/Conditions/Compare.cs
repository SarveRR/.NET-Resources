using System;
using System.Collections.Generic;
using System.Text;

namespace Conditions
{
    class Compare
    {
        //1
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

        //2
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

        //3
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

        //4
        public void LeapYear(int year)
        {
            if(year % 4 == 0)
            {
                Console.WriteLine(year+"is leap year");
            }
            else
            {
                Console.WriteLine(year + "isn't leap year");
            }
        }

        //5
        public void RequiredAge(int age)
        {
            if(age>=21 && age<30)
            {
                Console.WriteLine("envoy");
            }
            else if(age>=30 && age<35)
            {
                Console.WriteLine("envoy, senator, prime minister");
            }
            else if(age>=35)
            {
                Console.WriteLine("envoy, senator, prime minister, president");
            }
            else
            {
                Console.WriteLine("you are to young");
            }
        }
    }
}
