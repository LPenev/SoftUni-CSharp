using System.Text;

namespace _20._01._1_Company_Roster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            int countOfEmployer = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfEmployer; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                double salary = double.Parse(input[1]);
                string department = input[2];
                Employee currentEmployee = new Employee(name, salary, department);
                employees.Add(currentEmployee);
            }

            string[] departments = employees.Select(e => e.Department).Distinct().ToArray();

            string bestDepartment = string.Empty;
            double bestAvg = 0;
            foreach (string currentDepartment in departments)
            {
                double currentAvg = employees.Where(x => x.Department == currentDepartment).Select(x => x.Salary).Average();
                if (currentAvg > bestAvg)
                {
                    bestDepartment = currentDepartment;
                    bestAvg = currentAvg;
                }
                
            }

            Console.WriteLine($"Highest Average Salary: {bestDepartment}");
            var orderedResult = employees.Where(x => x.Department == bestDepartment).OrderByDescending(x => x.Salary);
            foreach (var current in orderedResult)
            {
                Console.WriteLine($"{current.Name} {current.Salary:f2}");
            }
        }
    }
    public class Employee
    {
        public Employee(string name, double salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }

        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} {this.Salary:f2}");
            return sb.ToString().TrimEnd('\n');
        }
    }
}