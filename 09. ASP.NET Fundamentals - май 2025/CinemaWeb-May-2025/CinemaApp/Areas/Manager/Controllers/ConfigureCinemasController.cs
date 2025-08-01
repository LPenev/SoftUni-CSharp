using CinemaApp.Web.ViewModels.Cinema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class ConfigureCinemasController : Controller
    {
        public IActionResult Index()
        {
            var cinemas = new List<ConfigureCinemasViewModel>();
            return View(cinemas); // -> Areas/Manager/Views/ConfigureCinemas/Index.cshtml
        }
    }
}