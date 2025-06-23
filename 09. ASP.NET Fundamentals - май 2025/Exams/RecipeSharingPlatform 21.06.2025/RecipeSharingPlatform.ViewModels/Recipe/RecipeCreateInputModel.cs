using System.ComponentModel.DataAnnotations;
using static RecipeSharingPlatform.GCommon.ValidationConstants.Recipe;

namespace RecipeSharingPlatform.ViewModels.Recipe;

public class RecipeCreateInputModel
{
    public int id {  get; set; }
    
    [Required]
    [MinLength(TitleMinLength)]
    [MaxLength(TitleMaxLength)]
    public string Title { get; set; } = null;
    public int CategoryId { get; set; }
    [Required]
    [MinLength(InstructionsMinLength)]
    [MaxLength(InstructionsMaxLength)]
    public string Instructions { get; set; } = null!;
    public string? ImageUrl { get; set; }
    [Required]
    public string CreatedOn { get; set; } = null!;

    public IEnumerable<CategoriesViewModel> Categories { get; set; } = Enumerable.Empty<CategoriesViewModel>();

}
