// dotnet ef dbcontext scaffold "Server=localhost;User Id=demo;Password=Demo1234;Initial Catalog=Projects;Persist Security Info=True;Encrypt=False;" Microsoft.EntityFrameworkCore.SqlServer -o Models
using Database_First_model.Models;

var db = new ProjectsContext();
var numberOfEmployees = db.Employees.Count();
Console.WriteLine("Number of current employees is: " + numberOfEmployees.ToString());

