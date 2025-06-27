using CinemaApp.Data;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Web;

public class MovieController : Controller
{
    private readonly ApplicationDbContext context;

    public MovieController(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<IActionResult> Index()
    {
        var movies = await this.context
            .Movies
            .Select(m => new AllMoviesIndexViewModel()
            {
                Id = m.Id.ToString(),
                Title = m.Title,
                Genre = m.Genre,
                Director = m.Director,
                ReleaseDate = m.ReleaseDate.ToString("yyyy-MM-dd"),
                ImageUrl = m.ImageUrl,
            })
            .ToArrayAsync();
        return View(movies);
    }
}
