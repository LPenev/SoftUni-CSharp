using Medicines.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Medicines.Common.ValidationConstants;

namespace Medicines.DataProcessor.ImportDtos;

[XmlType(nameof(Pharmacy))]
public class ImportPharmaciesDto
{
    [Required]
    [MinLength(PharmacyNameMinLength)]
    [MaxLength(PharmacyNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [RegularExpression(PharmacyPhoneNumberRegEx)]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    [XmlAttribute(PharmacyIsNonStop)]
    [RegularExpression(PharmacyIsBooleanRegEx)]
    public string IsNonStop { get; set; } = null!;

    [Required]
    public ImportMedicineDto[] Medicines { get; set; } = null!;

}
