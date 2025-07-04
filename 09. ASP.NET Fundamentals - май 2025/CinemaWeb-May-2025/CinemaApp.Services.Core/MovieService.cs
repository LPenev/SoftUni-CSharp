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
            ImageUrl = movie.ImageUrl,
        };

        return movieDetails;
    }

    public async Task<MovieFormViewModel> GetByIdToEditAsync(string id)
    {
        var movie = await context.Movies
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id.ToString() == id && !m.IsDeleted);

        if (movie == null)
        {
            return null;
        }

        var movieToEdit = new MovieFormViewModel
        {
            Title = movie.Title,
            Genre = movie.Genre,
            ReleaseDate = movie.ReleaseDate.ToString("yyyy-MM-dd"),
            Duration = movie.Duration,
            Director = movie.Director,
            Description = movie.Description,
            ImageUrl = movie.ImageUrl,
            Id = id,
        };

        return movieToEdit;
    }

    public async Task UpdateAsync(MovieFormViewModel model)
    {
        if (!Guid.TryParse(model.Id, out Guid id))
        {
            Console.WriteLine("Невалиден GUID");
        }

        var movie = await context.Movies.FindAsync(id);
        if (movie == null)
            throw new ArgumentException("Movie not found");

        if (!DateTime.TryParseExact(model.ReleaseDate, "yyyy-MM-dd",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out var releaseDate))
        {
            throw new Exception("Невалидна дата.");
        }

        movie.Title = model.Title;
        movie.Genre = model.Genre;
        movie.ReleaseDate = releaseDate;
        movie.Duration = model.Duration;
        movie.Director = model.Director;
        movie.Description = model.Description;
        movie.ImageUrl = model.ImageUrl;

        await context.SaveChangesAsync();
    }
}
