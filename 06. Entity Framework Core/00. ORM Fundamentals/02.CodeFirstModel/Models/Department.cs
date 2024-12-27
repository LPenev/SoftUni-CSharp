using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstModel.Models
{
    public class Department
    {
        [ForeignKey(nameof(Employee))]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
