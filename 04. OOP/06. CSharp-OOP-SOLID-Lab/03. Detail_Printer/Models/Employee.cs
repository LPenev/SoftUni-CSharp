using System;
using P03.Detail_Printer.Models.Interfaces;

namespace Models
{
    public class Employee : IEmployee
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public virtual void Print()
        {
            Console.WriteLine(Name);
        }
    }
}
