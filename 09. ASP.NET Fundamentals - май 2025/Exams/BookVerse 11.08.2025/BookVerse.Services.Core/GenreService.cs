using BookVerse.Data;
using BookVerse.Services.Core.Contracts;
using BookVerse.ViewModels.Book;
using Microsoft.EntityFrameworkCore;

namespace BookVerse.Services.Core;

public class GenreService : IGenreService
{
    private readonly ApplicationDbContext dbContext;

    public GenreService(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<GenreViewModel>> GetGenreAsync()
    {
        IEnumerable<GenreViewModel> allGenres = await this.dbContext
            .Genres
            .AsNoTracking()
            .Select(c => new GenreViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            }).ToArrayAsync();

        return allGenres;
    }

}

