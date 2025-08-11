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
        Task<bool> AddBookAsync(string? userId, BookCreateInputModel model);
        Task<BookEditInputModel> GetBookForEditAsync(string? userId, int? id);
        Task<bool> UpdateBookAsync(string? userId, BookEditInputModel model);
        Task<BookDeleteViewModel> GetBookToDelete(string? userId, int? id);
        Task<bool> ConfirmBookDelete(string? userId, int? recipeId);
    }
}
