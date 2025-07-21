using CinemaApp.Data.Models;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Movie;
using System.Globalization;
using CinemaApp.Data.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using static CinemaApp.Data.Common.EntityConstants.Movie;

namespace CinemaApp.Services.Core;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
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

        await _movieRepository.AddAsync(movie);
    }

    public async Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesAsync()
    {
        var movies = await _movieRepository.GetAllAttached()
            .AsNoTracking()
            .Select(m => new AllMoviesIndexViewModel
            {
                Id = m.Id.ToString(),
                Title = m.Title,
                Genre = m.Genre,
                Director = m.Director,
                ReleaseDate = m.ReleaseDate.ToString(WebDateFormat),
                ImageUrl = m.ImageUrl
            })
            .ToListAsync();

        return movies;
    }

    public async Task<MovieDetailsViewModel> GetByIdAsync(string id)
    {
        if (!Guid.TryParse(id, out Guid guid))
            return null;

        var movie = await _movieRepository.GetByIdAsync(guid);

        if (movie == null || movie.IsDeleted)
            return null;

        return new MovieDetailsViewModel
        {
            Id = movie.Id.ToString(),
            Title = movie.Title,
            Genre = movie.Genre,
            Director = movie.Director,
            Description = movie.Description,
            Duration = movie.Duration,
            ReleaseDate = movie.ReleaseDate.ToString(WebDateFormat),
            ImageUrl = movie.ImageUrl,
        };
    }

    public async Task<MovieFormViewModel> GetByIdToEditAsync(string id)
    {
        if (!Guid.TryParse(id, out Guid guid))
            return null;

        var movie = await _movieRepository.GetByIdAsync(guid);

        if (movie == null || movie.IsDeleted)
            return null;

        return new MovieFormViewModel
        {
            Id = movie.Id.ToString(),
            Title = movie.Title,
            Genre = movie.Genre,
            ReleaseDate = movie.ReleaseDate.ToString(ReleaseDateFormat),
            Duration = movie.Duration,
            Director = movie.Director,
            Description = movie.Description,
            ImageUrl = movie.ImageUrl,
        };
    }

    public async Task UpdateAsync(MovieFormViewModel model)
    {
        if (!Guid.TryParse(model.Id, out Guid id))
            throw new ArgumentException("Invalid GUID");

        var movie = await _movieRepository.GetByIdAsync(id);

        if (movie == null || movie.IsDeleted)
            throw new ArgumentException("Movie not found");

        if (!DateTime.TryParseExact(model.ReleaseDate, ReleaseDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var releaseDate))
            throw new Exception("Invalid date.");

        movie.Title = model.Title;
        movie.Genre = model.Genre;
        movie.ReleaseDate = releaseDate;
        movie.Duration = model.Duration;
        movie.Director = model.Director;
        movie.Description = model.Description;
        movie.ImageUrl = model.ImageUrl;

        await _movieRepository.UpdateAsync(movie);
    }

    public async Task SoftDeleteAsync(string id)
    {
        if (!Guid.TryParse(id, out Guid guid))
            throw new ArgumentException("Invalid GUID");

        var movie = await _movieRepository.GetByIdAsync(guid);

        if (movie != null && !movie.IsDeleted)
        {
            movie.IsDeleted = true;
            await _movieRepository.UpdateAsync(movie);
        }
    }

    public async Task HardDeleteAsync(string id)
    {
        if (!Guid.TryParse(id, out Guid guid))
            throw new ArgumentException("Invalid GUID");

        var movie = await _movieRepository.GetByIdAsync(guid);

        if (movie != null)
            await _movieRepository.DeleteAsync(movie);
    }
}
