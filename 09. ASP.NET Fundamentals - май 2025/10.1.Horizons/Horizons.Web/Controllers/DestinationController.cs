using Horizons.Services.Core.Contracts;
using Horizons.Web.ViewModels.Destination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Horizons.GCommon.ValidationConstants.Destination;

namespace Horizons.Web.Controllers
{
    public class DestinationController : BaseController
    {
        private readonly IDestinationService destinationService;
        private readonly ITerrainService terrainService;

        public DestinationController(IDestinationService destinationService, ITerrainService terrainService)
        {
            this.destinationService = destinationService;
            this.terrainService = terrainService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            try
            {
                string? userId = this.GetUserId();

                IEnumerable<DestinationViewModel> allDestinations = await
                    this.destinationService.GetAllDestinationsAsync(userId);

                return View(allDestinations);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.RedirectToAction(nameof(Index), "Home");
                return null;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            DestinationDetailsViewModel? destinationsDetails = null;

            try
            {
                string? userId = this.GetUserId();

                destinationsDetails = await this.destinationService
                    .GetDestinationDetailsAsync(id, userId);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.RedirectToAction(nameof(Index), "Home");
            }

            return View(destinationsDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                DestinationAddInputModel inputModel = new DestinationAddInputModel()
                {
                    PublishedOn = DateTime.UtcNow.ToString(PublishedOnDateFormat),
                    Terrains = await this.terrainService.GetAllTerrainsAsync(),
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
        public async Task<IActionResult> Add(DestinationAddInputModel inputModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(inputModel);
                }

                bool addResult = await this.destinationService.AddDestinationAsync(this.GetUserId()!, inputModel);

                if (!addResult)
                {
                    ModelState.AddModelError(string.Empty, "Fatal error occurred while adding destination");
                    return this.View(inputModel);
                }

                return this.RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                string userId = GetUserId()!;

                DestinationEditInputModel? editInputModel = await this.destinationService.GetDestinationForEditAsync(userId, id);

                if (editInputModel == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                editInputModel!.Terrains = await this.terrainService.GetAllTerrainsAsync();

                return this.View(editInputModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DestinationEditInputModel inputModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(inputModel);
                }

                bool editResult = await this.destinationService.PersistUpdateDestinationAsync(this.GetUserId(), inputModel);
                if (editResult == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Fatal error occurred while updating the destination");
                    return this.View(inputModel);
                }

                return this.RedirectToAction(nameof(Details), new { id = inputModel.Id});
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
            try
            {
                string userId = GetUserId()!;

                DestinationDeleteInputModel? deleteInputModel = await this.destinationService.GetDestinationForDeletingAsync(userId, id);

                if (deleteInputModel == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(deleteInputModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DestinationDeleteInputModel inputModel)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "You cannot delete the destination.");
                    return this.View(inputModel);
                }

                bool deleteResult = await this.destinationService.SoftDeleteDestinationAsync(this.GetUserId()!, inputModel);
                if (deleteResult == false)
                {
                    this.ModelState.AddModelError(string.Empty, "Fatal error occurred while deleting the destination");
                    return this.View(inputModel);
                }

                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            try
            {
                string userId = GetUserId()!;
                IEnumerable<DestinationFavoriteViewModel>? favDestinations =
                    await this.destinationService.GetDestinationUserFavoriteViewModelAsync(userId);

                if (favDestinations == null)
                {
                    return this.RedirectToAction(nameof(Index));
                }

                return this.View(favDestinations);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorites(int? id)
        {
            try
            {
                string userId = GetUserId()!;

                if (id == null)
                {
                    this.RedirectToAction(nameof(Index));
                }

                bool favAddResult = await this.destinationService.AddDestinationToUserFavoriteListAsync(userId, id.Value);

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
