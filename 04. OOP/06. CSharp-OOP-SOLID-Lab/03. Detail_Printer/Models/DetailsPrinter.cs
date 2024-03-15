using System.Collections.Generic;

namespace Models
{
    public class DetailsPrinter
    {
        private IList<Employee> employees;

        public DetailsPrinter(IList<Employee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (Employee employee in employees)
            {
                Print(employee);
            }
        }

        private void Print(Employee employee)
        {
            employee.Print();
        }
    }
}
