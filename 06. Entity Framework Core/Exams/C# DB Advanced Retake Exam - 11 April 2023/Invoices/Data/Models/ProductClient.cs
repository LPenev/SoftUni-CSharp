using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoices.Data.Models;

public class ProductClient
{
    [Key]
    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;

    [Key]
    [ForeignKey(nameof(Client))]
    public int ClientId { get; set; }
    public virtual Client Client { get; set; } = null!;
}
