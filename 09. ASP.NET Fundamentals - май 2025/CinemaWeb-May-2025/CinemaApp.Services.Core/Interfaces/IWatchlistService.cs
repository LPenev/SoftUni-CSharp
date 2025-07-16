using CinemaApp.Web.ViewModels.Watchlist;

namespace CinemaApp.Services.Core.Interfaces;

public interface IWatchlistService
{
    Task<IEnumerable<WatchlistViewModel>> GetUserWatchlistAsync(string userId);
    Task<bool> IsMoveInWatchlistAsync(string userId, Guid movieId);
    Task AddMovieToWatchlistAsync(string userId, Guid movieId);
    Task RemoveMovieFromWatchlistAsync(string userId, Guid movieId);
}