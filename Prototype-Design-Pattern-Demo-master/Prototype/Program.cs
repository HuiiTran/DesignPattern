using System;

namespace DesignPatterns.Prototype.Conceptual
{
    public class Person
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;

        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person clone = (Person)this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = String.Copy(Name);
            return clone;
        }
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();
            p1.Age = 42;
            p1.BirthDate = Convert.ToDateTime("1977-01-01");
            p1.Name = "Jack";
            p1.IdInfo = new IdInfo(001);

            Person p2 = p1.ShallowCopy();

            Person p3 = p1.DeepCopy();

            Console.WriteLine("Original values of person 1, person 2, person 3:");
            Console.WriteLine("Person 1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("Person 2 instance values:");
            DisplayValues(p2);
            Console.WriteLine("Person 3 instance values:");
            DisplayValues(p3);

            p1.Age = 32;
            p1.BirthDate = Convert.ToDateTime("1900-01-01");
            p1.Name = "Frank";
            p1.IdInfo.IdNumber = 777;

            Console.WriteLine("\nValues of person 1, person 2 and person 3 after changes to person 1:");
            Console.WriteLine("Person 1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("Person 2 instance values (reference values have changed):");
            DisplayValues(p2);
            Console.WriteLine("Person 3 instance values (everything was kept the same):");
            DisplayValues(p3);
        }

        public static void DisplayValues(Person p)
        {
            Console.WriteLine($"Name: {p.Name}, Age: {p.Age}, BirthDate: {p.BirthDate}");
            Console.WriteLine($"ID: {p.IdInfo.IdNumber}");
        }
    }
}