using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstModel.Models
{
    public class Project
    {
        [ForeignKey(nameof(EmployeeProject))]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
