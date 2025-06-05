using System.ComponentModel.DataAnnotations;
using static Medicines.Common.ValidationConstants;

namespace Medicines.DataProcessor.ImportDtos;

public class ImportPatientDto
{
    [Required]
    [MinLength(PatientFullNameMinLength)]
    [MaxLength(PatientFullNameMaxLength)]
    public string FullName { get; set; }

    [Range(PatientAgeGroupMin, PatientAgeGroupMax)]
    public int AgeGroup { get; set; }

    [Range(PatientGenderMin, PatientGenderMax)]
    public int Gender { get; set; }
    public int[] Medicines { get; set; } = null!;
}
