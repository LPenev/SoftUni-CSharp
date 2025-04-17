using Invoices.Common;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Data.Models;

public class Client
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(ValidationConstants.ClientNameMaxLenght)]
    public string Name { get; set; }

    [Required]
    [MaxLength(ValidationConstants.ClientNumberVatMaxLenght)]
    public string NumberVat {  get; set; }

    public ICollection<Invoice> Invoices { get; set; } = new HashSet<Invoice>();
    public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    public ICollection<ProductClient> ProductClients { get; set; } = new HashSet<ProductClient>();

}
