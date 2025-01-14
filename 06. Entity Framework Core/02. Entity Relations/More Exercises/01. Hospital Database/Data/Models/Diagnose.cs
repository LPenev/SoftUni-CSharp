using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_HospitalDatabase.Data.Models;
public class Diagnose
{
    [Key]
    public int DiagnoseId { get; set; }

    [MaxLength(50)]
    public string DiagnoseName { get; set; } = null!;

    [MaxLength(250)]
    public string Comments { get; set; } = null!;

    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;
}
