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
            string? userId = this.GetUserId();

            IEnumerable<DestinationViewModel> allDestinations = await
                this.destinationService.GetAllDestinationsAsync(userId);
            
            return View(allDestinations);
        }
    }
}
