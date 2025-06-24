using RecipeSharingPlatform.ViewModels.Recipe;

namespace RecipeSharingPlatform.Services.Core.Contracts;

public interface IRecipeService
{
    Task<IEnumerable<RecipeViewModel>> GetAllRecipesAsync(string? userId);
    Task<RecipeDetailsViewModel?> GetReceptDetailsAsync(int? id, string? userId);
    Task<IEnumerable<RecipeFavoritesViewModel>?> GetRecipeUserFavoritesViewModelAsync(string userId);
    Task<bool> AddRecipeToUserFavoriteListAsync(string userId, int RecipeId);
    Task <RecipeDeleteViewModel> RemoveRecipeFromUserFavoriteListAsync(string? userId, int? recipeId);
    Task<bool> ConfirmRemoveRecipeFromUserFavoriteListAsync(string? userId, int? recipeId);
    Task<RecipeDeleteViewModel> GetRecipeToDelete(string? userId, int? id);
    Task<bool> ConfirmRecipeDelete(string? userId, int? recipeId);
    Task<bool> AddRecipeAsync(string? userId, RecipeCreateInputModel model);
    Task<RecipeEditInputModel> GetRecipeForEditAsync(string? userId, int? id);
    Task<bool> UpdateRecipeAsync(string? userId, RecipeEditInputModel model);

}
