using Invoices.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoices.Data.Models;

public class Address
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(ValidationConstants.AddressStreetNameMaxLenght)]
    public string StreetName { get; set; } = null!;
    [Required]
    public int StreetNumber { get; set; }
    [Required]
    public String PostCode { get; set; } = null!;
    [Required]
    [MaxLength(ValidationConstants.AddressCityMaxLenght)]
    public string City { get; set; } = null!;
    [Required]
    [MaxLength(ValidationConstants.AddressCountryMaxLenght)]
    public string Country { get; set; } = null!;

    [ForeignKey(nameof(Client))]
    [Required]
    public int ClientId { get; set; }
    public Client Client { get; set; } = null!;
}
