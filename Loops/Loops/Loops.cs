using System;
using System.Collections.Generic;
using System.Text;

namespace Loops
{
    class Loops
    {
        //1
        public bool PrimeNumbers(int a)
        {
            for (int i = 2; i < a; i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void ShowPrimeNumbers()
        {
            for (int i = 2; i <= 100; i++)
            {
                if (PrimeNumbers(i) == true)
                {
                    Console.WriteLine(i);
                }
            }
        }

        //2
        public void EvenNumbers()
        {
            int i = 1;
            do
            {
                if(i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
                i++;
            }
            while (i <= 100);
        }

        //3
        public int Fibonacci(int n)
        {
            if ((n == 1) || (n == 2))
                return 1;
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public void ShowFibonacci()
        {
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine(Fibonacci(i));
            }
        }

        //4
        public void PyramidInts(int number)
        {
            int k = 1;

            for (int i = 1; i <= number; i++)
            {     
                for (int j = 1; j <= i; j++)
                    Console.Write(k++);
                    Console.Write("\n");
            }
        }
        
        //5
        public void PowerInts()
        {
            int result;

            for(int i=1; i<=20; i++)
            {
                result = i * i * i;
                Console.WriteLine(result);
            }
        }

        //6
        public void Addition()
        {
            float result = 0;

            for(float i=0;i<=20;i++)
            {
                for(float j=1;j<=4;j++)
                {
                    result += i / j; 
                }
                Console.WriteLine(result);
                result = 0;
            }
        }

        //7
        public void Stars(int number)
        {
            for (int i = 0; i <= number; i++)
            {
                for (int j = 1; j <= number - i; j++)
                    Console.Write(" ");
                for (int j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.Write("\n");
            }

            for (int i = number - 1; i >= 1; i--)
            {
                for (int j = 1; j <= number - i; j++)
                    Console.Write(" ");
                for (int j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.Write("\n");
            }
        }

        //8
        public void RiverseOrder(int number)
        {
            int sum = 0, r;

            for (int i = number; i != 0; i = i / 10)
            {
                r = i % 10;
                sum = sum * 10 + r;
            }
            Console.Write("The number in reverse order is : "+ sum);
        }

        //9
        public void IntToBinary(int number)
        {
            int n, i, j, binno = 0, dn;
            dn = number;
            i = 1;
            for (j = number; j > 0; j = j / 2)
            {
                binno = binno + (number % 2) * i;
                i = i * 10;
                number = number / 2;
            }
            Console.Write(dn + "\n"+binno);
        }

        //10
        public void LCM(int first, int second)
        {
            int i, j, hcf = 1, lcm;

            j = (first < second) ? first : second;

            for (i = 1; i <= j; i++)
            {

                if (first % i == 0 && second % i == 0)
                {
                    hcf = i;
                }
            }
            lcm = (first * second) / hcf;
            Console.Write("The LCM of {0} and {1} is : {2}", first, second, lcm);
        }
    }
}
