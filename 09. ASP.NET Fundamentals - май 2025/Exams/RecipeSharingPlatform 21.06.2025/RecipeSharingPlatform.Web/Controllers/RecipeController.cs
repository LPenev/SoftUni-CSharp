using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeSharingPlatform.Services.Core.Contracts;
using RecipeSharingPlatform.ViewModels.Recipe;
using static RecipeSharingPlatform.GCommon.ValidationConstants.Recipe;

namespace RecipeSharingPlatform.Web.Controllers
{
    public class RecipeController : BaseController
    {
        private readonly IRecipeService recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            try
            {
                string? userId = this.GetUserId();

                IEnumerable<RecipeViewModel> allRecipes = await
                    this.recipeService.GetAllRecipesAsync(userId);

                return View(allRecipes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index), "Home");
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            RecipeDetailsViewModel? recipeDetails = null;

            try
            {
                string? userId = this.GetUserId();

                recipeDetails = await this.recipeService
                    .GetDestinationDetailsAsync(id, userId);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.RedirectToAction(nameof(Index), "Home");
            }

            return View(recipeDetails);
        }

        public async Task<IActionResult> Favorites()
        {
            try
            {
                string userId = GetUserId()!;
                IEnumerable<RecipeFavoritesViewModel>? favRecipes =
                    await this.recipeService.GetRecipeUserFavoritesViewModelAsync(userId);

                if (favRecipes == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(favRecipes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(int? id) // Add to Favorites
        {
            try
            {
                string userId = GetUserId()!;

                if (id == null)
                {
                    this.RedirectToAction(nameof(Index));
                }

                bool favAddResult = await this.recipeService.AddRecipeToUserFavoriteListAsync(userId, id.Value);

                if (!favAddResult)
                {
                    this.RedirectToAction(nameof(Index));
                }

                return this.RedirectToAction(nameof(Favorites));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }

        }
    }
}