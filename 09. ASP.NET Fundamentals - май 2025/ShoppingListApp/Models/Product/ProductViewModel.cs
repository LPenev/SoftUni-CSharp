using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Models.Product;
public class ProductViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Field {0} is required.")]
    [Display(Name = "Product Name")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Field {0} must be between {2} and {1} sybols")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Product Description")]
    [StringLength(500, ErrorMessage = "Field {0} must not be longer than {1} charsters")]
    public string? Description { get; set; }
}

