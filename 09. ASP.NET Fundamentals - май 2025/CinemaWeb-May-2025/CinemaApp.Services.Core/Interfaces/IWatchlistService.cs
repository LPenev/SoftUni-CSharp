using CinemaApp.Web.ViewModels.Watchlist;

namespace CinemaApp.Services.Core.Interfaces;

public interface IWatchlistService
{
    Task<IEnumerable<WatchlistViewModel>> GetUserWatchlistAsync(string userId);
    Task<bool> IsMoveInWatchlistAsync(string userId, string movieId);
    Task AddMovieToWatchlistAsync(string userId, string movieId);
    Task RemoveMovieFromWatchlistAsync(string userId, string movieId);
}