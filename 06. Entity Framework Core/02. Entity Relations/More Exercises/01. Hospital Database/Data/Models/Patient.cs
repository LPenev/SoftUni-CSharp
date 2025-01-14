using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models;
public class Patient
{
    public Patient()
    {
        var Diagnoses = new HashSet<Diagnose>();
        var Visitations = new HashSet<Visitation>();
        var Prescriptions = new HashSet<PatientMedicament>();
    }

    [Key]
    public int PatientId { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [MaxLength(50)]
    public string LastName { get; set; } = null!;

    [MaxLength(250)]
    public string Address { get; set; } = null!;

    [MaxLength(80), Unicode(false)]
    public string Email { get; set; } = null!;
    public bool HasInsurance { get; set; }

    public virtual ICollection<Diagnose> Diagnoses { get; set; } = null!;
    public virtual ICollection<Visitation> Visitations { get; set; } = null!;
    public virtual ICollection<PatientMedicament> Prescriptions { get; set;} = null!;
}
