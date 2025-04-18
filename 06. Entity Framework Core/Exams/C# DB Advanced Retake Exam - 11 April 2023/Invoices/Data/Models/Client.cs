using Invoices.Common;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Data.Models;

public class Client
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(ValidationConstants.ClientNameMaxLenght)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(ValidationConstants.ClientNumberVatMaxLenght)]
    public string NumberVat { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    public virtual ICollection<Invoice> Invoices { get; set; } = new HashSet<Invoice>();
    public virtual ICollection<ProductClient> ProductsClients { get; set; } = new HashSet<ProductClient>();

}
