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
            return View(); // -> Areas/Manager/Views/ShowtimeSetup/Index.cshtml
        }
    }
}
