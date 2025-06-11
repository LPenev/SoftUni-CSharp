using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingListApp.Data.Models;

[Comment("Product Note")]
public class ProductNote
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    [Comment("Note Content")]
    public string Content { get; set; } = string.Empty;

    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}
