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

        //6
        public void Height(int height)
        {
            if (height >= 170)
            {
                Console.WriteLine("You are tall");
            }
            else
            {
                Console.WriteLine("You are short");
            }
        }

        //7
        public void ComparisionThreeInts(int first, int second, int third)
        {
            if(first>second && first>third)
            {     
                 Console.WriteLine(first);               
            }
            else if(second>first && second>third)
            {
                Console.WriteLine(second);
            }
            else if(third>first && third>second)
            {
                Console.WriteLine(third);
            }
            else
            {
                Console.WriteLine("Something goes wrong");
            }
        }

        //8
        public void Recruitment(int maths, int chemistry, int physics)
        {
            int all = maths + chemistry + physics;
            int mathsChemistry = maths + chemistry;
            int mathsPhysics = maths + physics;

            if((maths>=70 && chemistry>=55 && physics>=45)||(all>=180)||(mathsChemistry>=150 || mathsPhysics>=150))
            {
                Console.WriteLine("Accepted");
            }
            else
            {
                Console.WriteLine("Rejected");
            }
        }

        //9
        public void Temperature(int temperature)
        {
            if(temperature<0)
            {
                Console.WriteLine("very cold");
            }
            else if(temperature>=0 && temperature<10)
            {
                Console.WriteLine("cold");
            }
            else if(temperature>=10 && temperature<20)
            {
                Console.WriteLine("chilly");
            }
            else if(temperature>=20 && temperature<30)
            {
                Console.WriteLine("heat");
            }
            else if(temperature>=30 && temperature<40)
            {
                Console.WriteLine("hot");
            }
            else
            {
                Console.WriteLine("very hot");
            }
        }

        //10
    }
}
