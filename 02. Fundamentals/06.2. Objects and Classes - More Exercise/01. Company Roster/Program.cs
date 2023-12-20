using System.Text;

namespace _20._01._Company_Roster
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>();

            int countOfEmployer = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfEmployer; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                double salary = double.Parse(input[1]);
                string department = input[2];

                if(!departments.Any(x=> x.Name == department))
                {
                    Department currentDepartament = new Department(department);
                    departments.Add(currentDepartament);
                }
                departments.Find(x => x.Name == department).AddEmployee(name,salary);
            }

            Department bestDepartment = departments.OrderByDescending(x => x.SumOfSalary / x.Employees.Count()).First();
            Console.WriteLine($"Highest Average Salary: {bestDepartment.Name}");
            var result = bestDepartment.Employees.OrderByDescending(x => x.Salary).ToList();
            result.ForEach(x => Console.WriteLine(x));
        }
    }

    public class Employee
    {
        public Employee(string name, double salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        public string Name { get; set; }
        public double Salary { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} {this.Salary:f2}");
            return sb.ToString().TrimEnd('\n');
        }
    }
    public class Department
    {
        public List<Employee> Employees = new List<Employee>();
        public string Name { get; set; }
        public double SumOfSalary { get; set; }
        public Department(string name)
        {
            this.Name = name;
        }

        public void AddEmployee(string employerName,double employerSalary)
        {
            Employee employee = new Employee(employerName,employerSalary);
            this.Employees.Add(employee);
            this.SumOfSalary += employerSalary;
        }
    }
}