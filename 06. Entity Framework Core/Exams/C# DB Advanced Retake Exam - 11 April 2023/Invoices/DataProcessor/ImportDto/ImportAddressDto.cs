using Invoices.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Invoices.Common.ValidationConstants;

namespace Invoices.DataProcessor.ImportDto;

[XmlType(nameof(Address))]
public class ImportAddressDto
{
    [XmlElement(nameof(StreetName))]
    [Required]
    [MinLength(AddressStreetNameMinLenght)]
    [MaxLength(AddressStreetNameMaxLenght)]
    public string StreetName { get; set; } = null!;

    [XmlElement(nameof(StreetNumber))]
    public int StreetNumber { get; set;}

    [XmlElement(nameof(PostCode))]
    [Required]
    public string PostCode { get; set; } = null!;

    [XmlElement(nameof(City))]
    [Required]
    [MinLength(AddressCityMinLenght)]
    [MaxLength(AddressCityMaxLenght)]
    public string City { get; set; } = null!;

    [XmlElement(nameof(Country))]
    [Required]
    [MinLength(AddressCountryMinLenght)]
    [MaxLength(AddressCountryMaxLenght)]
    public string Country { get; set; } = null!;
}
