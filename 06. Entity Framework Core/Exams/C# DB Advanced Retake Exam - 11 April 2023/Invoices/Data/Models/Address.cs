using Invoices.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoices.Data.Models;

public class Address
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MinLength(ValidationConstants.AddressStreetNameMinLenght)]
    [MaxLength(ValidationConstants.AddressStreetNameMaxLenght)]
    public string StreetName { get; set; }
    [Required]
    public int StreetNumber { get; set; }
    [Required]
    public String PostCode { get; set; }
    [Required]
    [MinLength(ValidationConstants.AddressCityMinLenght)]
    [MaxLength(ValidationConstants.AddressCityMaxLenght)]
    public string City { get; set; }
    [Required]
    [MinLength(ValidationConstants.AddressCountryMinLenght)]
    [MaxLength(ValidationConstants.AddressCountryMaxLenght)]
    public string Country { get; set; }

    [ForeignKey(nameof(Client))]
    [Required]
    public int ClientId { get; set; }
    public Client Client { get; set; }
}
