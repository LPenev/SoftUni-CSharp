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
        private readonly ICategoryService categoryService;

        public RecipeService(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, ICategoryService categoryService)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException($"Missing dbContext: {nameof(dbContext)}");
            this.userManager = userManager;
            this.categoryService = categoryService;
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
                    IsSaved = isUserIdValid ? x.UsersRecipes.Any(ur => ur.UserId.ToLower() == userId!.ToLower()) : false,
                }).ToArrayAsync();


            return allRecipes;
        }

        public async Task<RecipeDetailsViewModel?> GetReceptDetailsAsync(int? id, string? userId)
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
                        ImageUrl = recipe.ImageUrl,
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

        public async Task<RecipeDeleteViewModel> RemoveRecipeFromUserFavoriteListAsync(string? userId, int? recipeId)
        {
            RecipeDeleteViewModel? viewModel = null;
            IdentityUser? user = await this.userManager.FindByIdAsync(userId);

            if (user != null)
            {
                UserRecipe? userRecipe = await this.dbContext
                    .UserRecipes
                    .Include(d => d.Recipe)
                    .SingleOrDefaultAsync(x => x.RecipeId == recipeId && x.UserId.ToLower() == userId.ToLower());

                if (userRecipe != null)
                {
                    viewModel = new RecipeDeleteViewModel()
                    {
                        Id = userRecipe.RecipeId,
                        Title = userRecipe.Recipe.Title,
                        AuthorId = userRecipe.Recipe.AuthorId,
                        Author = user.UserName!,
                        ImageUrl = userRecipe.Recipe.ImageUrl,
                    };
                }
                else
                {
                    throw new ArgumentNullException("Recipe data not found");
                }
            }

            return viewModel;
        }

        public async Task<bool> ConfirmRemoveRecipeFromUserFavoriteListAsync(string? userId, int? recipeId)
        {
            bool operationResult = false;

            if (string.IsNullOrWhiteSpace(userId) || recipeId == null)
            {
                return false;
            }

            try
            {
                var deletedCount = await this.dbContext.UserRecipes
                   .Where(ur => ur.UserId == userId && ur.RecipeId == recipeId).ExecuteDeleteAsync();

                operationResult = deletedCount > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                operationResult = false;
            }

            return operationResult;
        }

        public async Task<RecipeDeleteViewModel> GetRecipeToDelete(string? userId, int? id)
        {
            RecipeDeleteViewModel viewModel = null;

            if (id.HasValue)
            {
                bool isUserNameValid = userId != null;

                Recipe? recipe = await this.dbContext
                    .Recipes
                    .Include(x => x.Author)
                    .SingleOrDefaultAsync(x => x.Id == id && x.AuthorId == userId);

                if (recipe != null)
                {
                    viewModel = new RecipeDeleteViewModel
                    {
                        Id = id.Value,
                        Title = recipe.Title,
                        AuthorId = recipe.AuthorId,
                        Author = recipe.Author.UserName!,
                        ImageUrl = recipe.ImageUrl,
                    };
                }
            }
            return viewModel;
        }

        public async Task<bool> ConfirmRecipeDelete(string? userId, int? recipeId)
        {
            bool operationResult = false;

            if (string.IsNullOrWhiteSpace(userId) || recipeId == null)
            {
                return false;
            }

            try
            {
                var favDeletedCount = await this.dbContext
                   .UserRecipes
                   .Where(ur => ur.UserId == userId && ur.RecipeId == recipeId)
                   .ExecuteDeleteAsync();

                var deletedCount = await this.dbContext
                    .Recipes
                    .Where(x => x.AuthorId == userId && x.Id == recipeId)
                    .ExecuteDeleteAsync();

                operationResult = deletedCount > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                operationResult = false;
            }

            return operationResult;
        }
        public async Task<bool> AddRecipeAsync(string? userId, RecipeCreateInputModel model)
        {
            IdentityUser? user = await this.userManager.FindByIdAsync(userId);
            Category? categoryRef = await this.dbContext.Categories.FindAsync(model.CategoryId);
            bool isCreatedOnDateValid = DateTime.TryParseExact(model.CreatedOn,
            "yyyy-mm-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime CreatedOnDate);

            if (user != null && categoryRef != null)
            {
                try
                {
                    Recipe newRecipe = new Recipe()
                    {
                        Title = model.Title,
                        Instructions = model.Instructions,
                        ImageUrl = model.ImageUrl,
                        CreatedOn = CreatedOnDate,
                        AuthorId = userId,
                        Author = user,
                        CategoryId = model.CategoryId,
                    };

                    await this.dbContext.Recipes.AddAsync(newRecipe);
                    await this.dbContext.SaveChangesAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }

        public async Task<RecipeEditInputModel> GetRecipeForEditAsync(string? userId, int? id)
        {
            RecipeEditInputModel? inputModel = null;

            if (id.HasValue && !String.IsNullOrEmpty(userId))
            {
                Recipe? recipe = await this.dbContext
                    .Recipes
                    .Include(x => x.Category)
                    .Include(x => x.Author)
                    .SingleOrDefaultAsync(r => r.Id == id && r.AuthorId == userId);

                if (recipe == null)
                {
                    return null;
                }

                inputModel = new RecipeEditInputModel()
                {
                    Id = recipe.Id,
                    ImageUrl = recipe.ImageUrl,
                    Title = recipe.Title,
                    Instructions = recipe.Instructions,
                    CategoryId = recipe.CategoryId,
                    Categories = await this.categoryService.GetCategoriesAsync(),
                };

                return inputModel;
            }
            return null;
        }

        public async Task<bool> UpdateRecipeAsync(string? userId, RecipeEditInputModel model)
        {
            if(userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            IdentityUser? user = await this.userManager.FindByIdAsync(userId);

            if (userId != user.Id) 
            {
                throw new ArgumentNullException(nameof(userId));
            }


            Recipe updateRecipe = new Recipe()
            {
                Id =model.Id,
                Title = model.Title,
                Instructions = model.Instructions,
                ImageUrl = model.ImageUrl,
                AuthorId = userId,
                Author = user,
                CategoryId = model.CategoryId,
            };

            if (updateRecipe == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            this.dbContext.Update(updateRecipe);
            await this.dbContext.SaveChangesAsync();
            return true;
        }
    }
}
