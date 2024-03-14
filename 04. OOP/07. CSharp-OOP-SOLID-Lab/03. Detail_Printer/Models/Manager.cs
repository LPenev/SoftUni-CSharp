using System;
using System.Collections.Generic;

namespace Models
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            Documents = new List<string>(documents);
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine(string.Join(Environment.NewLine, Documents));
        }

        public IReadOnlyCollection<string> Documents { get; set; }
    }
}
