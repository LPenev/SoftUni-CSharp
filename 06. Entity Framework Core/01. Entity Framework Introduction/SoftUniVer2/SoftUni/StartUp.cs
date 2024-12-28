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
        output = GetEmployeesFullInformation(context);


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

}
