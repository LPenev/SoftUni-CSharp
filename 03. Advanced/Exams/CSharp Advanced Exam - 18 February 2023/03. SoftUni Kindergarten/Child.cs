﻿using System.Text;

namespace SoftUniKindergarten
{
    public class Child
    {
        public Child(string firstName, string lastName, int age, string parentName, string contactNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.ParentName = parentName;
            this.ContactNumber = contactNumber;
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string ParentName { get; set; }

        public string ContactNumber { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Child: {this.FirstName} {this.LastName}, Age: {this.Age}, Contact info: {this.ParentName} - {this.ContactNumber}");

            return sb.ToString().TrimEnd();
        }
    }
}
