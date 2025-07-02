using CinemaApp.Services.Core.Interfaces;
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
}
