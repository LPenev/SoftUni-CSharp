using Invoices.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Invoices.Common.ValidationConstants;

namespace Invoices.DataProcessor.ImportDto;

[XmlType(nameof(Address))]
public class ImportAddressDto
{
    [Required]
    [MinLength(AddressStreetNameMinLenght)]
    [MaxLength(AddressStreetNameMaxLenght)]
    [XmlElement(nameof(StreetName))]
    public string StreetName { get; set; } = null!;

    [XmlElement(nameof(StreetNumber))]
    public int StreetNumber { get; set;}

    [Required]
    [XmlElement(nameof(PostCode))]
    public string PostCode { get; set; } = null!;

    [Required]
    [MinLength(AddressCityMinLenght)]
    [MaxLength(AddressCityMaxLenght)]
    [XmlElement(nameof(City))]
    public string City { get; set; } = null!;

    [Required]
    [MinLength(AddressCountryMinLenght)]
    [MaxLength(AddressCountryMaxLenght)]
    [XmlElement(nameof(Country))]
    public string Country { get; set; } = null!;
}
