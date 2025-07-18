using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Contracts;

namespace CinemaApp.Data.Repository;

public class WatchlistRepository : BaseRepository<Watchlist, object>, IWatchlistRepository
{
    private readonly CinemaAppDbContext context;

    public WatchlistRepository(CinemaAppDbContext dbContext)
        : base(dbContext)
    {
        this.context = dbContext;
    }

    public Watchlist? GetByCompositeKey(string userId, string movieId)
    {
        if (!Guid.TryParse(movieId, out var movieGuid))
        {
            return null; // Ungültige MovieId
        }

        return this.FirstOrDefault(w => w.UserId == userId && w.MovieId == movieGuid);
    }
    
    public async Task<Watchlist?> GetByCompositeKeyAsync(string userId, string movieId)
    {
        if (!Guid.TryParse(movieId, out var movieGuid))
        {
            return null; // Ungültige MovieId
        }

        return await this.FirstOrDefaultAsync(w => w.UserId == userId && w.MovieId == movieGuid);
    }
    
    public bool Exists(string userId, string movieId)
    {
        return this.GetByCompositeKey(userId, movieId) != null;
    }

    public async Task<bool> ExistsAsync(string userId, string movieId)
    {
        return await this.GetByCompositeKeyAsync(userId, movieId) != null;
    }
}
