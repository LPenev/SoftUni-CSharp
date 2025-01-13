using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models;
public class Diagnose
{
    [Key]
    public int DiagnoseId { get; set; }

    [MaxLength(50)]
    public string DiagnoseName { get; set; }

    [MaxLength(250)]
    public string Comments { get; set; }

    public int PatientId { get; set; }
}
