using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers;

public class CinemaController : BaseController
{
    private readonly ILogger<HomeController> _logger;

    public CinemaController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        var model = Enumerable.Empty<UsersCinemaIndexViewModel>();
        return View(model);
    }

    [AllowAnonymous]
    public IActionResult Program()
    {
        var model = Enumerable.Empty<MovieUserProgramViewModel>();
        return View(model);
    }

    [AllowAnonymous]
    public IActionResult Details()
    {
        return View();
    }
}

