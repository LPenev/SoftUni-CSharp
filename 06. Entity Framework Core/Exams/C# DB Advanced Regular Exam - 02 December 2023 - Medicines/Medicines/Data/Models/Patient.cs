using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using static Medicines.Common.ValidationConstants;

namespace Medicines.Data.Models;
public class Patient
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(PatientFullNameMaxLength)]
    public string FullName { get; set; } = null!;
    public AgeGroup AgeGroup { get; set; }
    public Gender Genger { get; set; }

    public ICollection<PatientMedicine> PatientsMedicines { get; set; } = new HashSet<PatientMedicine>();
    
}
