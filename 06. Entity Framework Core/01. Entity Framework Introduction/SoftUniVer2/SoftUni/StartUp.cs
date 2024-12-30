using SoftUni.Data;
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
        output = GetEmployeesFromResearchAndDevelopment(context);


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

}
