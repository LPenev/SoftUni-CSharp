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
        if (User?.Identity?.IsAuthenticated ?? true)
        {
            return RedirectToAction("Index");
        }

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

    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        var movie = await movieService.GetByIdAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var movie = await movieService.GetByIdToEditAsync(id);
        return View(movie);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(MovieFormViewModel model)
    {
        if (!ModelState.IsValid) 
        {
            return View(model);
        }

        try
        {
            await movieService.UpdateAsync(model);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "Възникна грешка при записа.");
            return View(model);
        }

        return RedirectToAction(nameof(Details));
    }
}
