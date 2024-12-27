using CodeFirstModel.Models;

using (var db = new ApplicationDbContext())
{
    db.Database.EnsureCreated();

    //Check whether data already exists
    if (!db.Departments.Any())
    {
        //create new data
        var departments = new List<Department>
                    {
                        new Department { Name = "IT" },
                        new Department { Name = "Finance" },
                        new Department { Name = "Logistic" },
                        new Department { Name = "Security" },
                        new Department { Name = "Productions" }
                    };

        // Add Data into Databank 
        db.Departments.AddRange(departments);
    }

    if (!db.Projects.Any())
    {
        var projects = new List<Project>
        {
            new Project {Name = "Bildung Prog"},
            new Project {Name = "Turbo Charger"},
            new Project {Name = "Chalga Killer"}
        };
        db.Projects.AddRange(projects);
    }

    if (!db.Employees.Any())
    {
        var employees = new List<Employee>
        {
            new Employee {  FirstName = "Ivo",
                            MiddleName = "M",
                            LastName = "Stanovski",
                            IsEmployed = 1,
                            DepartmentId = 1 },

            new Employee {  FirstName = "Kalin",
                            MiddleName = "K",
                            LastName = "Indjiski",
                            IsEmployed = 1,
                            DepartmentId = 1 },

            new Employee {  FirstName = "Samuil",
                            MiddleName = "P",
                            LastName = "Kirovski",
                            IsEmployed = 1,
                            DepartmentId = 1 },

            new Employee {  FirstName = "Mihaela",
                            MiddleName = "E",
                            LastName = "Tupalska",
                            IsEmployed = 1,
                            DepartmentId = 1 },

            new Employee {  FirstName = "Georgi",
                            MiddleName = "G",
                            LastName = "Georgiev",
                            IsEmployed = 1,
                            DepartmentId = 1 },

            new Employee {  FirstName = "Milina",
                            MiddleName = "A",
                            LastName = "Ivanova",
                            IsEmployed = 1,
                            DepartmentId = 1 },
        };
        db.Employees.AddRange(employees);
    }
    // Save changes
    db.SaveChanges();

    if (!db.EmployeesProjects.Any())
    {

        var employeesProjects = new List<EmployeeProject>();
        employeesProjects.Add(new EmployeeProject { ProjectId = 1, EmployeeId = 1 });
        employeesProjects.Add(new EmployeeProject { ProjectId = 2, EmployeeId = 2 });
        employeesProjects.Add(new EmployeeProject { ProjectId = 3, EmployeeId = 3 });
        employeesProjects.Add(new EmployeeProject { ProjectId = 3, EmployeeId = 4 });
        employeesProjects.Add(new EmployeeProject { ProjectId = 2, EmployeeId = 5 });
        employeesProjects.Add(new EmployeeProject { ProjectId = 1, EmployeeId = 6 });
        db.AddRange(employeesProjects);
        //Save changes
        db.SaveChanges();
    }

    Console.WriteLine("Alle tables are loaded...");
}

Console.WriteLine("Done");
