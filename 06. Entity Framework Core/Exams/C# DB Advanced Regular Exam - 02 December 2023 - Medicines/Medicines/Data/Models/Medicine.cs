using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Medicines.Common.ValidationConstants;

namespace Medicines.Data.Models;

public class Medicine
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(MedicineNameMaxLength)]
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public Category Category { get; set; }
    public DateTime ProductionDate { get; set; }
    public DateTime ExpiryDate { get; set; }

    [Required]
    [MaxLength(MedicineProducerMaxLength)]
    public string Producer { get; set; } = null!;

    [ForeignKey(nameof(Pharmacy))]
    public int PharmacyId { get; set; }
    public Pharmacy Pharmacy { get; set; } = null!;

    public ICollection<PatientMedicine> PatientsMedicines { get; set; } = new HashSet<PatientMedicine>();
}
