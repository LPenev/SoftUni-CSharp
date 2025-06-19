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
                DestinationAddViewModel inputModel = new DestinationAddViewModel()
                {
                    PublishedOn = DateTime.UtcNow.ToString(PublishedOnDateFormat),
                    Terrains = await this.terrainService.GetAllTerrainsAsync(),
                };

                return View(inputModel);
            
            } catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }

            
        }

        [HttpPost]
        public async Task<IActionResult> Add(DestinationAddViewModel inputModel)
        {
            try 
            {
                if (!this.ModelState.IsValid)
                {
                    return this.RedirectToAction(nameof(Add));
                }

                bool addResult = await this.destinationService.AddDestinationAsync(this.GetUserId()!, inputModel);

                if (!addResult)
                {
                    ModelState.AddModelError(string.Empty, "Fatal error occurred while adding destination");
                    return this.RedirectToAction(nameof(Add));
                }

                return this.RedirectToAction(nameof(Index));

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction(nameof(Index));
            }
        }
    }
}
