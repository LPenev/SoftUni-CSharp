using Invoices.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Invoices.Common.ValidationConstants;

namespace Invoices.DataProcessor.ImportDto;

[XmlType(nameof(Client))]
public class ImportClientDto
{
    [XmlElement(nameof(Name))]
    [Required]
    [MinLength(ClientNameMinLenght)]
    [MaxLength(ClientNameMaxLenght)]
    public string Name { get; set; } = null!;

    [XmlElement(nameof(NumberVat))]
    [Required]
    [MinLength(ClientNumberVatMinLenght)]
    [MaxLength(ClientNumberVatMaxLenght)]
    public string NumberVat { get; set; } = null!;

    [XmlArray(nameof(Addresses))]
    public ImportAddressDto[] Addresses { get; set;} = null!;
}
