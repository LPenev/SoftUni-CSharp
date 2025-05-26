using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TravelAgency.Data.Models;
using static TravelAgency.Common.ValidationConstants;

namespace TravelAgency.DataProcessor.ImportDtos;

[XmlType(nameof(Customer))]
public class ImportCustomerDto
{
    [XmlAttribute(nameof(PhoneNumber))]
    [Required]
    [MinLength(CustomerPhoneNumberLength)]
    [MaxLength(CustomerPhoneNumberLength)]
    public string PhoneNumber { get; set; } = null!;

    [XmlElement(nameof(FullName))]
    [Required]
    [MinLength(CustomerFullNameMinLength)]
    [MaxLength(CustomerFullNameMaxLength)]
    public string FullName { get; set; } = null!;

    [XmlElement(nameof(Email))]
    [Required]
    [MinLength(CustomerEmailMinLength)]
    [MaxLength(CustomerEmailMaxLength)]
    public string Email { get; set; } = null!;
}
