using BookVerse.Data;
using BookVerse.DataModels;
using BookVerse.Services.Core.Contracts;
using BookVerse.ViewModels.Book;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace BookVerse.Services.Core;

public class BookService : IBookService
{
    private readonly ApplicationDbContext dbContext;
    private readonly UserManager<IdentityUser> userManager;

    public BookService(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException($"Missing dbContext: {nameof(dbContext)}");
        this.userManager = userManager;
    }


    public async Task<IEnumerable<BookViewModel>> GetAllBooksAsync(string? userId)
    {
        bool isUserIdValid = !string.IsNullOrEmpty(userId);

        IEnumerable<BookViewModel> allBooks = await dbContext
            .Books
            .Include(x => x.Genre)
            .Include(x => x.UserBooks)
            .AsNoTracking()
            .Select(x => new BookViewModel()
            {
                Id = x.Id,
                CoverImageUrl = x.CoverImageUrl,
                Title = x.Title,
                Genre = x.Genre.Name,
                SavedCount = x.UserBooks.Count(),
                IsAuthor = isUserIdValid ? x.PublisherId.ToLower() == userId : false,
                IsSaved = isUserIdValid ? x.UserBooks.Any(ur => ur.UserId.ToLower() == userId!.ToLower()) : false,
            }).ToArrayAsync();


        return allBooks;
    }

    public async Task<BookDetailsViewModel?> GetBookDetailsAsync(int? id, string? userId)
    {
        BookDetailsViewModel bookDetailsVM = null;

        if (id.HasValue)
        {
            bool isUserIdValid = userId != null;

            Book? book = await this.dbContext
                .Books
                .Include(x => x.UserBooks)
                .Include(x => x.Genre)
                .Include(x => x.Publisher)
                .SingleOrDefaultAsync(x => x.Id == id.Value);

            if (book != null)
            {
                bookDetailsVM = new BookDetailsViewModel()
                {
                    Id = book.Id,
                    CoverImageUrl = book.CoverImageUrl,
                    Title = book.Title,
                    Description = book.Description,
                    Genre = book.Genre.Name,
                    PublishedOn = book.PublishedOn,
                    Publisher = book.Publisher.UserName,
                    IsAuthor = isUserIdValid ? book.PublisherId.ToLower() == userId!.ToLower() : false,
                    IsSaved = isUserIdValid ? book.UserBooks.Any(ud => ud.UserId.ToLower() == userId.ToLower()) : false,
                };
            }
        }
        return bookDetailsVM;
    }

    public async Task<IEnumerable<MyBooksViewModel>?> GetMyBooksViewModelAsync(string userId)
    {
        IEnumerable<MyBooksViewModel?> myBooks = null;
        IdentityUser? user = await this.userManager.FindByIdAsync(userId);

        if (user != null)
        {
            myBooks = await this.dbContext
                .UserBooks
                .Include(d => d.Book)
                .ThenInclude(d => d.Genre)
                .Where(ud => ud.UserId.ToLower() == userId.ToLower())
                .Select(ud => new MyBooksViewModel()
                {
                    Id = ud.BookId,
                    CoverImageUrl = ud.Book.CoverImageUrl,
                    Title = ud.Book.Title,
                    Genre = ud.Book.Genre.Name,
                }).ToArrayAsync();
        }
        return myBooks;
    }

    public async Task<bool> AddToMyBooksAsync(string userId, int bookId)
    {
        bool operationResult = false;

        IdentityUser? user = await this.userManager.FindByIdAsync(userId);

        Book? myBooks = await this.dbContext
            .Books
            .FindAsync(bookId);

        if (user != null && myBooks != null && myBooks.PublisherId.ToLower() != userId.ToLower())
        {
            UserBook? userBook = await this.dbContext
                .UserBooks
                .SingleOrDefaultAsync(x => x.UserId.ToLower() == userId.ToLower() && x.BookId == bookId);

            if (userBook == null)
            {
                userBook = new UserBook()
                {
                    UserId = userId,
                    BookId = bookId,
                };

                await this.dbContext.UserBooks.AddAsync(userBook);
                await this.dbContext.SaveChangesAsync();
                operationResult = true;
            }
        }

        return operationResult;
    }

    public async Task<bool> RemoveBookFromMyBooksListAsync(string? userId, int? bookId)
    {
        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentException("User id is required.", nameof(userId));
        if (bookId is null || bookId <= 0)
            throw new ArgumentOutOfRangeException(nameof(bookId));

        var link = await dbContext.UserBooks.FindAsync(userId, bookId.Value);
        if (link == null)
            return false;

        dbContext.UserBooks.Remove(link);
        await dbContext.SaveChangesAsync();
        return true;
    }

}
