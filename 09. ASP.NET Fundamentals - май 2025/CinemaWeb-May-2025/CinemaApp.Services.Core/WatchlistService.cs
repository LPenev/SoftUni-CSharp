using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Contracts;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Watchlist;
using Microsoft.EntityFrameworkCore;
using static CinemaApp.GCommon.EntityConstants.Movie;

namespace CinemaApp.Services.Core;

public class WatchlistService : IWatchlistService
{
    private readonly IWatchlistRepository _watchlistRepository;

    public WatchlistService(IWatchlistRepository watchlistRepository)
    {
        _watchlistRepository = watchlistRepository;
    }

    public async Task RemoveMovieFromWatchlistAsync(string userId, string movieId)
    {
        var userMovie = await _watchlistRepository.GetByCompositeKeyAsync(userId, movieId);

        if (userMovie != null)
        {
            await _watchlistRepository.DeleteAsync(userMovie); // Използвай асинхронния метод, той сам прави SaveChangesAsync
        }
    }

    public async Task AddMovieToWatchlistAsync(string userId, string movieId)
    {
        var userMovie = new Watchlist
        {
            UserId = userId,
            MovieId = Guid.Parse(movieId)
        };
        await _watchlistRepository.AddAsync(userMovie); // Не е нужно втори път SaveChangesAsync
    }

    public async Task<bool> IsMoveInWatchlistAsync(string userId, string movieId)
    {
        return await _watchlistRepository.ExistsAsync(userId, movieId.ToString());
    }

    public async Task<IEnumerable<WatchlistViewModel>> GetUserWatchlistAsync(string userId)
    {
        return await _watchlistRepository.GetAllAttached()
            .Where(um => um.UserId == userId)
            .Select(um => new WatchlistViewModel
            {
                MovieId = um.Movie.Id.ToString(),
                Title = um.Movie.Title,
                Genre = um.Movie.Genre,
                ImageUrl = um.Movie.ImageUrl,
                ReleaseDate = um.Movie.ReleaseDate.ToString(ReleaseDateFormat)
            }).ToListAsync();
    }
}


