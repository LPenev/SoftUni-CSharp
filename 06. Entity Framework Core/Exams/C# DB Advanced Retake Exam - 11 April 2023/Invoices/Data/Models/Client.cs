using Invoices.Common;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Data.Models;

public class Client
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MinLength(ValidationConstants.ClientNameMinLenght)]
    [MaxLength(ValidationConstants.ClientNameMaxLenght)]
    public string Name { get; set; }

    [Required]
    [MinLength(ValidationConstants.ClientNumberVatMinLenght)]
    [MaxLength(ValidationConstants.ClientNumberVatMaxLenght)]
    public string NumberVat {  get; set; }

    public ICollection<Invoice> Invoices { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public ICollection<ProductClient> ProductClients { get; set; }

}
