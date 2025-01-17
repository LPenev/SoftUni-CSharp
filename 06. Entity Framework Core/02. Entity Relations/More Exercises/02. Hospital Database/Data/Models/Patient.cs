namespace P01_HospitalDatabase.Data.Models;
public class Patient
{
    public Patient()
    {
        var Diagnoses = new HashSet<Diagnose>();
        var Visitations = new HashSet<Visitation>();
        var Prescriptions = new HashSet<PatientMedicament>();
    }

    public int PatientId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Email { get; set; } = null!;
    public bool HasInsurance { get; set; }

    public virtual ICollection<Diagnose> Diagnoses { get; set; } = null!;
    public virtual ICollection<Visitation> Visitations { get; set; } = null!;
    public virtual ICollection<PatientMedicament> Prescriptions { get; set;} = null!;
}
