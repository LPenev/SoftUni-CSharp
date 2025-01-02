using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
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
        //output = AddNewAddressToEmployee(context);

        // 07. Employees and Projects
        //output = GetEmployeesInPeriod(context);

        // 08. Addresses by Town
        //output = GetAddressesByTown(context);

        // 09. Employee 147
        //output = GetEmployee147(context);

        // 10. Departments with More Than 5 Employees
        //output = GetDepartmentsWithMoreThan5Employees(context);

        //11.Find Latest 10 Projects
        //output = GetLatestProjects(context);

        //12. Increase Salaries
        //output = IncreaseSalaries(context);

        // 13. Find Employees by First Name Starting With Sa
        //output = GetEmployeesByFirstNameStartingWithSa(context);

        // 14. Delete Project by Id
        //output = DeleteProjectById(context);

        // 15. Remove Town
        output = RemoveTown(context);

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
                                .OrderBy(e => e.EmployeeId)
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

    // 07. Employees and Projects
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        var employees = context.Employees
            .Take(10)
            .Select(e => new {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager!.FirstName,
                ManagerLastName = e.Manager!.LastName,
                Projects = e.EmployeesProjects
                    .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                    .Select(p => new
                    {
                        Name = p.Project.Name,
                        StartDate = p.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = p.Project.EndDate.HasValue 
                            ? p.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) 
                            : "not finished"
                    }).ToList()
            })
            .ToList();


        var sb = new StringBuilder();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");
            
            foreach (var project in employee.Projects) {
                sb.AppendLine($"--{project.Name} - {project.StartDate} - {project.EndDate}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    // 08. Addresses by Town
    public static string GetAddressesByTown(SoftUniContext context)
    {
        var addressesInfo = context.Addresses
            .OrderByDescending(a => a.Employees.Count())
            .ThenBy(a => a.Town.Name)
            .ThenBy(a => a.AddressText)
            .Take(10)
            .Select(a => $"{a.AddressText}, {a.Town.Name} - {a.Employees.Count} employees")
        .ToArray();

        return String.Join(Environment.NewLine, addressesInfo);
    }

    // 09. Employee 147
    public static string GetEmployee147(SoftUniContext context)
    {
        var employee147Info = context.Employees
            .Where(e => e.EmployeeId == 147)
            .Select(e => new {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Projects = e.EmployeesProjects.Select(p => new { ProjectName = p.Project.Name })
                    .OrderBy(p => p.ProjectName)
                    .ToArray()
            })
            .ToArray();

        var employee147 = employee147Info[0]; 

        var sb = new StringBuilder();
        sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");
        sb.AppendLine(string.Join(Environment.NewLine, employee147.Projects.Select(p => p.ProjectName)));
        
        return sb.ToString().TrimEnd();
    }

    // 10. Departments with More Than 5 Employees
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        var departmentsWithMore5Employee = context.Departments
            .Where(d => d.Employees.Count > 5)
            .OrderBy (d => d.Employees.Count)
            .ThenBy(d => d.Name)
            .Select(d => new { 
                DepartmentName = d.Name,
                ManagerName = $"{d.Manager.FirstName} {d.Manager.LastName}",
                Employees = d.Employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy (e => e.LastName)
                    .Select(e => new { e.FirstName, e.LastName, e.JobTitle })
                
            })
            .ToArray();

        var sb = new StringBuilder();
        foreach( var department in departmentsWithMore5Employee)
        {
            sb.AppendLine($"{department.DepartmentName} - {department.ManagerName}");

            foreach( var employee in department.Employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    // 11. Find Latest 10 Projects
    public static string GetLatestProjects(SoftUniContext context)
    {
        var lastest10Projects = context.Projects
            .OrderByDescending(p => p.StartDate)
            .Take(10)
            .OrderBy(p => p.Name)
            .Select(p => new { 
                p.Name,
                p.Description,
                StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
            })
            .ToList();

        var sb = new StringBuilder();
        foreach( var project in lastest10Projects)
        {
            sb.AppendLine(project.Name);
            sb.AppendLine(project.Description);
            sb.AppendLine(project.StartDate);
        }

        return sb.ToString().TrimEnd();
    }

    // 12. Increase Salaries
    public static string IncreaseSalaries(SoftUniContext context)
    {
        decimal salartModifer = 1.12m;
        var departmentNames = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

        var EmployeesForSalaryIncreace = context.Employees
            .Where(e => departmentNames.Contains(e.Department.Name))
            .ToArray();

        foreach (var employee in EmployeesForSalaryIncreace)
        {
            employee.Salary *= salartModifer;
        }

        context.SaveChanges();

        var employeeInfoText = context.Employees
            .Where(e => departmentNames.Contains(e.Department.Name))
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .Select(e => new { e.FirstName, e.LastName, e.Salary })
            .ToArray();

        var sb = new StringBuilder();

        foreach( var employee in employeeInfoText)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
        }
        
        return sb.ToString().TrimEnd();
    }

    // 13. Find Employees by First Name Starting With Sa
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        var employees = context.Employees
            .Where(e => e.FirstName.StartsWith("Sa"))
            .OrderBy (e => e.FirstName)
            .ThenBy(e => e.LastName)
            .Select(e => new { e.FirstName, e.LastName, e.JobTitle, e.Salary})
            .ToArray();
        
        var sb = new StringBuilder();
        foreach (var empl in employees)
        {
            sb.AppendLine($"{empl.FirstName} {empl.LastName} - {empl.JobTitle} - (${empl.Salary:f2})");
        }

        return sb.ToString().TrimEnd();
    }

    // 14. Delete Project by Id
    public static string DeleteProjectById(SoftUniContext context)
    {
        var employeesProjectsToDelete = context.EmployeesProjects.Where(ep => ep.ProjectId == 2);
        context.EmployeesProjects.RemoveRange(employeesProjectsToDelete);

        var projectToDelete = context.Projects.Find(2);
        context.Projects.Remove(projectToDelete);

        context.SaveChanges();

        var projectsNameFirst10 = context.Projects
            .Take(10)
            .Select(p => p.Name)
            .ToArray();

        return string.Join(Environment.NewLine, projectsNameFirst10);
    }

    // 15. Remove Town
    public static string RemoveTown(SoftUniContext context)
    {
        Town townToDelete = context.Towns
            .Where(t => t.Name == "Seattle")
            .FirstOrDefault();

        Address[] adressesToDelete = context.Addresses
            .Where(a => a.TownId == townToDelete.TownId)
            .ToArray();

        Employee[] employeesAdressToDelete = context.Employees
            .Where(e => adressesToDelete.Contains(e.Address))
            .ToArray();

       foreach (Employee e in employeesAdressToDelete)
        {
            e.AddressId = null;
        }

        context.RemoveRange(adressesToDelete);
        context.RemoveRange(townToDelete);
        context.SaveChanges();

        return $"{adressesToDelete.Count()} addresses in Seattle were deleted";
    }
}
