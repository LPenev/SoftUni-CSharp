using Horizons.Services.Core.Contracts;
using Horizons.Web.ViewModels.Destination;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Horizons.Web.Controllers
{
    public class DestinationController : BaseController
    {
        private readonly IDestinationService destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            this.destinationService = destinationService;
        }

        [HttpGet]
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


    }
}
