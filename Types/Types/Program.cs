using System;

namespace Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string Name = "Name";
            string Surname = "Surname";
            int Age = 20;
            long Pesel = 12345678901;
            long Number = 3333333333;

            Console.WriteLine(Name);
            Console.WriteLine(Surname);
            Console.WriteLine(Age);
            Console.WriteLine(Sex.m);
            Console.WriteLine(Pesel);
            Console.WriteLine(Number);
        }

        enum Sex
        {
            m,
            k
        }
        
    }
}
