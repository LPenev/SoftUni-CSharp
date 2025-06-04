using Medicines.Data.Models;
using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Medicines.Common.ValidationConstants;

namespace Medicines.DataProcessor.ImportDtos;

[XmlType(nameof(Medicine))]
public class ImportMedicineDto
{
    [Required]
    [MinLength(MedicineNameMinLength)]
    [MaxLength(MedicineNameMaxLength)]
    public string Name { get; set; } = null!;

    [Range(typeof(decimal), MedicinePriceMin, MedicinePriceMax)]
    public decimal Price { get; set; }

    [Required]
    public string ProductionDate { get; set; } = null!;

    [Required]
    public string ExpiryDate { get; set; } = null!;

    [Required]
    [MinLength(MedicineProducerMinLength)]
    [MaxLength(MedicineProducerMaxLength)]
    public string Producer { get; set; } = null!;

    [XmlAttribute(MedicineAttributeCategory)]
    [Range(MedicineCategoryMin, MedicineCategoryMax)]
    public int Category { get; set; }
}
