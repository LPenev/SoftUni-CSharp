using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using NetPay.Data.Models;
using static NetPay.Common.ValidationConstants;

namespace NetPay.DataProcessor.ImportDtos;

[XmlType(nameof(Household))]
public class ImportHausholdXmlDto
{
    [Required]
    [XmlElement(nameof(ContactPerson))]
    [MinLength(HouseholdContactPersonMinLength)]
    [MaxLength(HouseholdContactPersonMaxLength)]
    public string ContactPerson { get; set; } = null!;

    [XmlElement(nameof(Email))]
    [MinLength(HouseholdEmailMinLength)]
    [MaxLength(HouseholdEmailMaxLength)]
    public string? Email { get; set; }

    [XmlAttribute(HouseholdXmlPhoneAttribute)]
    [Required]
    [StringLength(HouseholdPhoneNumberLength)]
    [RegularExpression(HouseholdPhoneNumberPattern)]
    public string PhoneNumber { get; set; } = null!;
}
