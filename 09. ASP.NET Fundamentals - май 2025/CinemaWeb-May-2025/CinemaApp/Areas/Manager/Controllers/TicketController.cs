using CinemaApp.Web.ViewModels.Cinema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            var models = Enumerable.Empty<CinemaIndexViewModel>();
            return View(models); // -> Areas/Manager/Views/Ticket/Index.cshtml
        }
    }
}
