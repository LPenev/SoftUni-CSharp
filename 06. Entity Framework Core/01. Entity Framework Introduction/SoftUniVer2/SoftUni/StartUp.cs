using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni;
public class StartUp
{
    public static void Main()
    {
        var context = new SoftUniContext();
        var output = string.Empty;

        // 03. Employees Full Information
        //output = GetEmployeesFullInformation(context);

        //04. Employees with Salary Over 50,000
        //output = GetEmployeesWithSalaryOver50000(context);

        // 05. Employees from Research and Development
        //output = GetEmployeesFromResearchAndDevelopment(context);

        //06. Adding a New Address and Updating Employee
        output = AddNewAddressToEmployee(context);


        Console.WriteLine(output);
    }

    // 03. Employees Full Information
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        if (context == null)
        {
            return string.Empty;
        }

        var employees = context.Employees
                                .Select(e => new { e.FirstName, e.LastName, e.MiddleName, e.JobTitle, e.Salary })
                                .ToList();

        if (employees == null)
        {
            return string.Empty;
        }

        var sb = new StringBuilder();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    // 04. Employees with Salary Over 50,000
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        var employees = context.Employees
            .Select(e => new { e.FirstName, e.Salary })
            .Where(e => e.Salary > 50000)
            .OrderBy(e => e.FirstName)
            .ToList();

        var sb = new StringBuilder();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    // 05. Employees from Research and Development
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        var employees = context.Employees
            .Where(e => e.Department.Name == "Research and Development")
            .Select(e => new { e.FirstName, e.LastName, e.Department, e.Salary })
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .ToList();

        var sb = new StringBuilder();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:f2}");
        }
        return sb.ToString().TrimEnd();
    }

    // 06. Adding a New Address and Updating Employee
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        string newAddress = "Vitoshka 15";
        //var checkNewAddress = context.Employees.Where(e => e.Address.AddressText == newAddress).FirstOrDefault();

        //if (checkNewAddress != null)
        //{
        //    return "The address already exists.";
        //}

        // set new address
        Address address = new Address();
        address.TownId = 4;
        address.AddressText = newAddress;

        // add address into Database and save changes
        context.Addresses.Add(address);
        context.SaveChanges();

        // search for employee per LastName
        string employeeName = "Nakov";
        var SearchedEmployee = context.Employees.Where(e => e.LastName == employeeName).FirstOrDefault();

        if (SearchedEmployee == null)
        {
            return "Employee not found...";
        }

        // if employee found set new address and save changes
        SearchedEmployee.Address = address;
        context.SaveChanges();

        // get first 10 employees orderd by addressId
        var sorted10Employees = context.Employees
            .Select(e => new { e.AddressId, e.Address })
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .ToList();

        var sb = new StringBuilder();
        foreach (var employee in sorted10Employees)
        {
            sb.AppendLine($"{employee.Address.AddressText}");
        }

        return sb.ToString().TrimEnd(); ;
    }

}
