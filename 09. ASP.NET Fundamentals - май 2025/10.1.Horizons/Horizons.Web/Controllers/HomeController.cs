namespace Horizons.Web.Controllers
{
    using System.Diagnostics;

    using ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    public class HomeController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            try
            {
                if (this.IsUserAuthenticated())
                {

                    return this.RedirectToAction(nameof(Index),"Destination");
                }

                return View();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return this.RedirectToAction(nameof(Index),"Home");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
