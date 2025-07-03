using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers;

public class MovieController : Controller
{
    private readonly IMovieService movieService;
    public MovieController(IMovieService movieService)
    {
        this.movieService = movieService;
    }

    public async Task<IActionResult> Index()
    {
        var movies = await movieService.GetAllMoviesAsync();
        return View(movies);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(MovieFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        await movieService.AddAsync(model);
        return RedirectToAction(nameof(Index));
    }
}
