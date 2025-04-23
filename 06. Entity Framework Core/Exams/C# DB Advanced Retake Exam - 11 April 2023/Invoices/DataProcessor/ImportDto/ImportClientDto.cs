using Invoices.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Invoices.Common.ValidationConstants;

namespace Invoices.DataProcessor.ImportDto;

[XmlType(nameof(Client))]
public class ImportClientDto
{
    [Required]
    [MinLength(ClientNameMinLenght)]
    [MaxLength(ClientNameMaxLenght)]
    [XmlElement(nameof(Name))]
    public string Name { get; set; } = null!;

    [Required]
    [XmlElement(nameof(NumberVat))]
    public string NumberVat { get; set; } = null!;

    [XmlArray(nameof(Addresses))]
    public ImportAddressDto[] Addresses { get; set;} = null!;
}
