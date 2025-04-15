using Invoices.Common;
using Invoices.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Data.Models;

public class Product
{
    public Product()
    {
        this.ProductClients = new HashSet<ProductClient>();
    }

    [Key]
    public int Id { get; set; }
    [Required]
    [MinLength(ValidationConstants.ProductNameMinLenght)]
    [MaxLength(ValidationConstants.ProcuctNameMaxLenght)]
    public string Name { get; set; }
    [Required]
    [Range(typeof(decimal),ValidationConstants.ProductPriceMinValue,ValidationConstants.ProductPriceMaxValue)]
    public decimal Price { get; set; }
    [Required]
    public CategoryType CategoryType { get; set; }

    public ICollection<ProductClient> ProductClients { get; set; }
}
