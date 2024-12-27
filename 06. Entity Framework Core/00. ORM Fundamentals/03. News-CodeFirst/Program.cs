using _03._News_CodeFirst.Models;

using (var db = new ApplicationDbContent())
{
    db.Database.EnsureCreated();
}

Console.WriteLine("Done...");
