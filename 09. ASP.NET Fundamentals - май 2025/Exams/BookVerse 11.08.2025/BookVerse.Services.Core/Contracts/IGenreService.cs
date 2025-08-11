using BookVerse.ViewModels.Book;

namespace BookVerse.Services.Core.Contracts;

public interface IGenreService
{
    Task<IEnumerable<GenreViewModel>> GetGenreAsync();
}