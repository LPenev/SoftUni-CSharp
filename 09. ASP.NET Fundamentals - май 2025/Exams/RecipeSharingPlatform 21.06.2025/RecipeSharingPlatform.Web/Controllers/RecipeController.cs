using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeSharingPlatform.Services.Core;
using RecipeSharingPlatform.Services.Core.Contracts;
using RecipeSharingPlatform.ViewModels.Recipe;

namespace RecipeSharingPlatform.Web.Controllers
{
    public class RecipeController : BaseController
    {
        private readonly ICategoryService categoryService;
        private readonly IRecipeService recipeService;

        public RecipeController(IRecipeService recipeService, ICategoryService categoryService)
        {
            this.categoryService = categoryService;
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

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            RecipeDetailsViewModel? recipeDetails = null;

            try
            {
                string? userId = this.GetUserId();

                recipeDetails = await this.recipeService
                    .GetReceptDetailsAsync(id, userId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.RedirectToAction(nameof(Index), "Home");
            }

            return View(recipeDetails);
        }

        [HttpGet]
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

        [HttpPost]
        public async Task<IActionResult> Remove(int? id)
        {
            RecipeDeleteViewModel? viewModel = new RecipeDeleteViewModel();

            try
            {
                string? userId = this.GetUserId();
                viewModel = await this.recipeService.RemoveRecipeFromUserFavoriteListAsync(userId, id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmRemove(int? id)
        {
            try
            {
                if (id == null)
                {
                    this.RedirectToAction(nameof(Index));
                }

                string userId = GetUserId()!;

                bool favRemoveResult = await this.recipeService.ConfirmRemoveRecipeFromUserFavoriteListAsync(userId, id.Value);

                if (!favRemoveResult)
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

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            RecipeDeleteViewModel? model = null;
            try
            {
                if (id == null)
                {
                    this.RedirectToAction(nameof(Index));
                }

                string userId = GetUserId()!;

                model = await this.recipeService.GetRecipeToDelete(userId, id);

                if (model == null)
                {
                    this.RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            try
            {
                if (id == null)
                {
                    this.RedirectToAction(nameof(Index));
                }

                string userId = GetUserId()!;

                bool deleteResult = await this.recipeService.ConfirmRecipeDelete(userId, id.Value);

                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                RecipeCreateInputModel inputModel = new RecipeCreateInputModel()
                {
                    Categories = await this.categoryService.GetCategoriesAsync(),
                };

                return View(inputModel);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecipeCreateInputModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await this.categoryService.GetCategoriesAsync();
                return View(model);
            }

            bool addResult = await this.recipeService.AddRecipeAsync(this.GetUserId()!, model);

            if (!addResult)
            {
                ModelState.AddModelError(string.Empty, "Fatal error occurred while adding destination");
                model.Categories = await this.categoryService.GetCategoriesAsync();
                return this.View(model);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                string userId = GetUserId()!;

                RecipeEditInputModel? editInputModel = await this.recipeService.GetRecipeForEditAsync(userId, id);

                if (editInputModel == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(editInputModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RecipeEditInputModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    model.Categories = await this.categoryService.GetCategoriesAsync();
                    return View(model);
                }

                bool addResult = await this.recipeService.UpdateRecipeAsync(this.GetUserId()!, model);

                if (!addResult) 
                {
                    ModelState.AddModelError(string.Empty, "Fatal error occurred while adding destination");
                    model.Categories = await this.categoryService.GetCategoriesAsync();
                    return this.View(model);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}