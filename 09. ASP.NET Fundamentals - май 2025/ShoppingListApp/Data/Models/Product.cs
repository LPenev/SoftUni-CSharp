using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Data.Models;

[Comment("List of Products")]
public class Product
{
    [Key]
    public int Id { get; set; }

    [Comment("Product Name")]
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    [Comment("Product Description")]
    public string? Description { get; set; }
    public ICollection<ProductNote> ProductNotes { get; set; } = new HashSet<ProductNote>();
}
