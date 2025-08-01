using CinemaApp.Web.ViewModels.Cinema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class ShowtimeSetupController : Controller
    {
        public IActionResult Index()
        {
            var cinemas = Enumerable.Empty<CinemaIndexViewModel>();
            return View(cinemas); // -> Areas/Manager/Views/ShowtimeSetup/Index.cshtml
        }
    }
}
