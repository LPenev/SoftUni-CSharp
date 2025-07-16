using CinemaApp.Services.Core;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Watchlist;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers;

public class WatchlistController : BaseController
{
    private readonly IWatchlistService watchlistService;

    public WatchlistController(IWatchlistService watchlistService)
    {
        this.watchlistService = watchlistService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        if (!IsUserAuthenticated())
        {
            return RedirectToAction("Login", "Account");
        }

        string? userId = GetUserId();
        var model = await watchlistService.GetUserWatchlistAsync(userId);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(string movieId)
    {
        if (!IsUserAuthenticated())
        {
            return RedirectToAction("Login", "Account");
        }
        
        var userId = GetUserId();
        bool isMovieInWatchlist = await watchlistService.IsMoveInWatchlistAsync(userId, Guid.Parse(movieId));

        if (!isMovieInWatchlist)
        {
            await watchlistService.AddMovieToWatchlistAsync(userId, Guid.Parse(movieId));
        }

        return RedirectToAction(nameof(Index));

    }

    [HttpPost]
    public IActionResult Remove(Guid movieId)
    {
        if (!IsUserAuthenticated())
        {
            return RedirectToAction("Login", "Account");
        }
        string? userId = GetUserId();
        bool isMovieInWatchlist = watchlistService.IsMoveInWatchlistAsync(userId, movieId).Result;
        
        if (isMovieInWatchlist)
        {
            watchlistService.RemoveMovieFromWatchlistAsync(userId, movieId).Wait();
        }

        return RedirectToAction(nameof(Index));
    }
}
