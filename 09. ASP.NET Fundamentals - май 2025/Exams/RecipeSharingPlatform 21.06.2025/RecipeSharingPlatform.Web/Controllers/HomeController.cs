using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeSharingPlatform.ViewModels;
using RecipeSharingPlatform.Web.Controllers;
using System.Diagnostics;

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

                return this.RedirectToAction(nameof(Index), "Recipe");
            }

            return View();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return this.RedirectToAction(nameof(Index), "Home");
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}