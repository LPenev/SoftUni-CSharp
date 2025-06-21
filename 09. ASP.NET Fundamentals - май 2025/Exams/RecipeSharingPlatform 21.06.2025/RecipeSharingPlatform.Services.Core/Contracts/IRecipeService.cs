using RecipeSharingPlatform.ViewModels.Recipe;

namespace RecipeSharingPlatform.Services.Core.Contracts
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeViewModel>> GetAllRecipesAsync(string? userId);
        Task<RecipeDetailsViewModel?> GetDestinationDetailsAsync(int? id, string? userId);
        Task<IEnumerable<RecipeFavoritesViewModel>?> GetRecipeUserFavoritesViewModelAsync(string userId);
        Task<bool> AddRecipeToUserFavoriteListAsync(string userId, int RecipeId);
    }
}
