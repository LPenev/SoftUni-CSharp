using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipeSharingPlatform.Data;
using RecipeSharingPlatform.Data.Models;
using RecipeSharingPlatform.Services.Core.Contracts;
using RecipeSharingPlatform.ViewModels.Recipe;
using System.Globalization;

using static RecipeSharingPlatform.GCommon.ValidationConstants.Recipe;

namespace RecipeSharingPlatform.Services.Core
{
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<IdentityUser> userManager;

        public RecipeService(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException($"Missing dbContext: {nameof(dbContext)}");
            this.userManager = userManager;
        }

        public async Task<bool> AddRecipeToUserFavoriteListAsync(string userId, int recipeId)
        {
            bool operationResult = false;

            IdentityUser? user = await this.userManager.FindByIdAsync(userId);

            Recipe? favRecipe = await this.dbContext
                .Recipes
                .FindAsync(recipeId);

            if (user != null && favRecipe != null && favRecipe.AuthorId.ToLower() != userId.ToLower())
            {
                UserRecipe? userFavRecipe = await this.dbContext
                    .UserRecipes
                    .SingleOrDefaultAsync(x => x.UserId.ToLower() == userId.ToLower() && x.RecipeId == recipeId);

                if (userFavRecipe == null)
                {
                    userFavRecipe = new UserRecipe()
                    {
                        UserId = userId,
                        RecipeId = recipeId,
                    };

                    await this.dbContext.UserRecipes.AddAsync(userFavRecipe);
                    await this.dbContext.SaveChangesAsync();
                    operationResult = true;
                }
            }

            return operationResult;
        }

        public async Task<IEnumerable<RecipeViewModel>> GetAllRecipesAsync(string? userId)
        {
            bool isUserIdValid = !string.IsNullOrEmpty(userId);

            IEnumerable<RecipeViewModel> allRecipes = await dbContext
                .Recipes
                .Include(x => x.Category)
                .Include(x => x.UsersRecipes)
                .AsNoTracking()
                .Select(x => new RecipeViewModel()
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Title = x.Title,
                    Category = x.Category.Name,
                    SavedCount = x.UsersRecipes.Count(),
                    IsAuthor = isUserIdValid ? x.AuthorId.ToLower() == userId : false,
                    IsSaved  = isUserIdValid ? x.UsersRecipes.Any(ur => ur.UserId.ToLower() == userId!.ToLower()) : false,
                }).ToArrayAsync();


            return allRecipes;
        }

        public async Task<RecipeDetailsViewModel?> GetDestinationDetailsAsync(int? id, string? userId)
        {
            RecipeDetailsViewModel recipeDetailsVM = null;

            if (id.HasValue)
            {
                bool isUserIdValid = userId != null;

                Recipe? recipe = await this.dbContext
                    .Recipes
                    .Include(x => x.UsersRecipes)
                    .Include(x => x.Category)
                    .Include(x => x.Author)
                    .SingleOrDefaultAsync(x => x.Id == id.Value);

                if (recipe != null)
                {
                    recipeDetailsVM = new RecipeDetailsViewModel()
                    {
                        Id = recipe.Id,
                        ImageUrl= recipe.ImageUrl,
                        Title = recipe.Title,
                        Instructions = recipe.Instructions,
                        Category = recipe.Category.Name,
                        CreatedOn = recipe.CreatedOn.ToString(CreatedOnDateTimeFormat),
                        Author = recipe.Author.UserName,
                        IsAuthor = isUserIdValid ? recipe.AuthorId.ToLower() == userId!.ToLower() : false,
                        IsSaved = isUserIdValid ? recipe.UsersRecipes.Any(ud => ud.UserId.ToLower() == userId.ToLower()) : false,
                    };
                }
            }
                return recipeDetailsVM;
        }

        public async Task<IEnumerable<RecipeFavoritesViewModel>?> GetRecipeUserFavoritesViewModelAsync(string userId)
        {
            IEnumerable<RecipeFavoritesViewModel?> favRecipes = null;
            IdentityUser? user = await this.userManager.FindByIdAsync(userId);

            if (user != null)
            {
                favRecipes = await this.dbContext
                    .UserRecipes
                    .Include(d => d.Recipe)
                    .ThenInclude(d => d.Category)
                    .Where(ud => ud.UserId.ToLower() == userId.ToLower())
                    .Select(ud => new RecipeFavoritesViewModel()
                    {
                        Id = ud.RecipeId,
                        ImageUrl = ud.Recipe.ImageUrl,
                        Title = ud.Recipe.Title,
                        Category = ud.Recipe.Category.Name,
                    }).ToArrayAsync();
            }
            return favRecipes;
        }
    }
}
