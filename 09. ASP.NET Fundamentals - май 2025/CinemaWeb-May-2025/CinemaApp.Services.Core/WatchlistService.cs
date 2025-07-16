using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Watchlist;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Services.Core;

public class WatchlistService : IWatchlistService
{
    private readonly CinemaAppDbContext context;

    public WatchlistService(CinemaAppDbContext context)
    {
        this.context = context;
    }


    public async Task<IEnumerable<WatchlistViewModel>> GetUserWatchlistAsync(string userId)
    {
        var info = context.Watchlists.ToList();
        var infoMovies = context.Movies.ToList();


        return await context.Watchlists
            //.Where(w => w.UserId == userId)
            .Select(w => new WatchlistViewModel
            {
                MovieId = w.Movie.Id.ToString(),
                Title = w.Movie.Title,
                Genre = w.Movie.Genre,
                ReleaseDate = w.Movie.ReleaseDate.ToString("yyyy-MM-dd"),
                ImageUrl = w.Movie.ImageUrl
            }).ToListAsync();
    }

    public async Task<bool> IsMoveInWatchlistAsync(string userId, Guid movieId)
    {
        return await context.Watchlists
            .AnyAsync(w => w.UserId == userId && w.MovieId == movieId);
    }

    public async Task AddMovieToWatchlistAsync(string userId, Guid movieId)
    {
        var addToWatchlist = new Watchlist
        {
            UserId = userId,
            MovieId = movieId,
        };

        context.Watchlists.Add(addToWatchlist);
        await context.SaveChangesAsync();
    }

    public async Task RemoveMovieFromWatchlistAsync(string userId, Guid movieId)
    {
        var userMovie = await context.Watchlists
            .FirstOrDefaultAsync(w => w.UserId == userId && w.MovieId == movieId);
        
        if (userMovie != null)
        {
            context.Watchlists.Remove(userMovie);
            await context.SaveChangesAsync();
        }
    }
}

