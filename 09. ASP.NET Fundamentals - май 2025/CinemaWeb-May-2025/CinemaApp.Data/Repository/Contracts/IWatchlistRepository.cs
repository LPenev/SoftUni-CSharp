using CinemaApp.Data.Models;
namespace CinemaApp.Data.Repository.Contracts;

public interface IWatchlistRepository
    : IRepository<Watchlist, object>
{
    Watchlist? GetByCompositeKey(string userId, string movieId);

    Task<Watchlist?> GetByCompositeKeyAsync(string userId, string movieId);

    bool Exists(string userId, string movieId);

    Task<bool> ExistsAsync(string userId, string movieId);
}
