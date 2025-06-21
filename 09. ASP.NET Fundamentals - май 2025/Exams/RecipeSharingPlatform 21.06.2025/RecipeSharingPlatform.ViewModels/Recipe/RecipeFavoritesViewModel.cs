namespace RecipeSharingPlatform.ViewModels.Recipe;

public class RecipeFavoritesViewModel
{
    public string? ImageUrl { get; set; }
    public string Title { get; set; } = null!;
    public string Category { get; set; } = null!;
    public int? Id { get; set; }
}
