using CinemaApp.Data;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Services.Core;

public class MovieService : IMovieService
{
    private readonly CinemaAppDbContext context;
    public MovieService(CinemaAppDbContext context)
    {
        this.context = context;
    }

    public async Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesAsync()
    {
        return await context.Movies
            .Where(m => !m.IsDeleted)
            .AsNoTracking()
            .Select(m => new AllMoviesIndexViewModel
            {
                Id = m.Id.ToString(),
                Title = m.Title,
                Genre = m.Genre,
                Director = m.Director,
                ReleaseDate = m.ReleaseDate.ToString("yyyy-MM-dd"),
                ImageUrl = m.ImageUrl,
            })
            .ToArrayAsync();
    }
}
