using BookVerse.ViewModels.Book;

namespace BookVerse.Services.Core.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookViewModel>> GetAllBooksAsync(string? userId);
        Task<BookDetailsViewModel?> GetBookDetailsAsync(int? id, string? userId);
        Task<IEnumerable<MyBooksViewModel>?> GetMyBooksViewModelAsync(string userId);
        Task<bool> AddToMyBooksAsync(string userId, int bookId);
        Task<bool> RemoveBookFromMyBooksListAsync(string? userId, int? bookId);
    }
}
