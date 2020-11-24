using System;
using System.Collections.Generic;
using System.Text;

namespace Types
{
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Age { get; set; }
        public string Height { get; set; }
        public string PhoneNumber { get; set; }
        public string Weight { get; set; }
        public string Email { get; set; }

        public void DisplayUserInfo()
        {
            Console.WriteLine("1.Program\n");

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
        }

        enum Sex
        {
            m,
            k
        }

        public void TakeAndDisplayUserInfo()
        {
            Console.WriteLine("\n5.Program\n");

            Person person = new Person();

            Console.WriteLine("Name: ");
            person.Name = Console.ReadLine();
            Console.WriteLine("Surname: ");
            person.Surname = Console.ReadLine();
            Console.WriteLine("Age: ");
            person.Age = Console.ReadLine();
            Console.WriteLine("Height: ");
            person.Height = Console.ReadLine();
            Console.WriteLine("PhoneNumber: ");
            person.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Weight: ");
            person.Weight = Console.ReadLine();
            Console.WriteLine("Email: ");
            person.Email = Console.ReadLine();

            int personAge, personHeight, personPhoneNumber;
            float personWeight;

            Int32.TryParse(person.Age, out personAge);
            Int32.TryParse(person.Height, out personHeight);
            Int32.TryParse(person.PhoneNumber, out personPhoneNumber);
            float.TryParse(person.Weight, out personWeight);

            Console.WriteLine("Name: " + person.Name);
            Console.WriteLine("Surname: " + person.Surname);
            Console.WriteLine("Age: " + personAge);
            Console.WriteLine("Height: " + personHeight);
            Console.WriteLine("PhoneNumber: " + personPhoneNumber);
            Console.WriteLine("Weight: " + personWeight);
            Console.WriteLine("Email: " + person.Email);
        }
    }
}
