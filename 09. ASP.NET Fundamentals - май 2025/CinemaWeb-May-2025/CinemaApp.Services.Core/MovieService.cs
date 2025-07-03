using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static CinemaApp.Data.Common.EntityConstants.Movie;

namespace CinemaApp.Services.Core;

public class MovieService : IMovieService
{
    private readonly CinemaAppDbContext context;
    public MovieService(CinemaAppDbContext context)
    {
        this.context = context;
    }

    public async Task AddAsync(MovieFormViewModel model)
    {
        var movie = new Movie 
        {
            Title = model.Title,
            Genre = model.Genre,
            Director = model.Director,
            Description = model.Description,
            Duration = model.Duration,
            ReleaseDate = DateTime.ParseExact(model.ReleaseDate, ReleaseDateFormat, CultureInfo.InvariantCulture),
            ImageUrl = model.ImageUrl,
        };

        await context.Movies.AddAsync(movie);
        await context.SaveChangesAsync();
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

    public async Task<MovieDetailsViewModel> GetByIdAsync(string id)
    {
        var movie = await context.Movies
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id.ToString() == id && !m.IsDeleted);

        if (movie == null)
        {
            return null;
        }

        var movieDetails = new MovieDetailsViewModel
        {
            Id = movie.Id.ToString(),
            Title = movie.Title,
            Genre = movie.Genre,
            Director = movie.Director,
            Description = movie.Description,
            Duration = movie.Duration,
            ReleaseDate = movie.ReleaseDate.ToString("yyyy-MM-dd"),
            ImageUrl = movie.ImageUrl
        };

        return movieDetails;
    }
}
