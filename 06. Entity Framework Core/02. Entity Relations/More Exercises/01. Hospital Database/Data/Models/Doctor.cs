using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models;
public class Doctor
{
    public Doctor()
    {
        var Visitations = new HashSet<Visitation>();
    }

    [Key]
    public int DoctorId { get; set; }

    [MaxLength(100), Required]
    public string Name { get; set; } = null!;

    [MaxLength(100), Required]
    public string Specialty { get; set; } = null!;

    public virtual ICollection<Visitation> Visitations { get; set; } = null!;
}
