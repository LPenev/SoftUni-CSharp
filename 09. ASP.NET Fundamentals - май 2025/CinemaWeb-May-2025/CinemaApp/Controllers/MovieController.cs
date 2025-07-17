using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers;

public class MovieController : BaseController
{
    private readonly IMovieService movieService;
    public MovieController(IMovieService movieService)
    {
        this.movieService = movieService;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var movies = await movieService.GetAllMoviesAsync();    
        return View(movies);
    }

    [HttpGet]
    public IActionResult Add()
    {
        if (!User?.Identity?.IsAuthenticated ?? false)
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

    [AllowAnonymous]
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
    public async Task<IActionResult> Edit(string id,MovieFormViewModel model)
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
            ModelState.AddModelError(string.Empty, "Error by save data.");
            return View(model);
        }

        return RedirectToAction(nameof(Details), new {id});
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        var movie = await movieService.GetByIdAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        await movieService.SoftDeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
