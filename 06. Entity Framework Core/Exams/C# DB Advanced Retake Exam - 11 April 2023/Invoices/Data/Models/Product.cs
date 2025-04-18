using Invoices.Common;
using Invoices.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Data.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(ValidationConstants.ProcuctNameMaxLenght)]
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    [Required]
    public CategoryType CategoryType { get; set; }

    public virtual ICollection<ProductClient> ProductsClients { get; set; } = new HashSet<ProductClient>();
}
