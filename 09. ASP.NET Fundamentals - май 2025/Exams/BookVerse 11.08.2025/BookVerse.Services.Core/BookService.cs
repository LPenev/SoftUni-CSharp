using System.Globalization;
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
    private readonly IGenreService genreService;

    public BookService(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager, IGenreService genreService)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException($"Missing dbContext: {nameof(dbContext)}");
        this.userManager = userManager;
        this.genreService = genreService;
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
    public async Task<bool> AddBookAsync(string? userId, BookCreateInputModel model)
    {
        IdentityUser? user = await this.userManager.FindByIdAsync(userId);
        Genre? genreRef = await this.dbContext.Genres.FindAsync(model.GenreId);
        bool isCreatedOnDateValid = DateTime.TryParseExact(model.PublishedOn,
            "yyyy-mm-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime PublishedOnDate);

        if (user != null && genreRef != null)
        {
            try
            {
                Book newBook = new Book()
                {
                    Title = model.Title,
                    Description = model.Description,
                    CoverImageUrl = model.CoverImageUrl,
                    PublishedOn = PublishedOnDate,
                    PublisherId = userId,
                    Publisher = user,
                    GenreId = model.GenreId,
                };

                await this.dbContext.Books.AddAsync(newBook);
                await this.dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        return false;
    }

    public async Task<BookEditInputModel> GetBookForEditAsync(string? userId, int? id)
    {
        BookEditInputModel? inputModel = null;

        if (id.HasValue && !String.IsNullOrEmpty(userId))
        {
            Book? book = await this.dbContext
                .Books
                .Include(x => x.Genre)
                .Include(x => x.Publisher)
                .SingleOrDefaultAsync(r => r.Id == id && r.PublisherId == userId);

            if (book == null)
            {
                return null;
            }

            var genres = await this.genreService.GetGenreAsync();
            ;

            inputModel = new BookEditInputModel()
            {
                Id = book.Id,
                CoverImageUrl = book.CoverImageUrl,
                Title = book.Title,
                Description = book.Description,
                GenreId = book.GenreId,
                Genres = genres,
                PublishedOn = book.PublishedOn,
            };

            return inputModel;
        }
        return null;
    }

    public async Task<bool> UpdateBookAsync(string? userId, BookEditInputModel model)
    {
        if (userId == null)
        {
            throw new ArgumentNullException(nameof(userId));
        }

        IdentityUser? user = await this.userManager.FindByIdAsync(userId);

        if (userId != user.Id)
        {
            throw new ArgumentNullException(nameof(userId));
        }


        Book updateBook = new Book()
        {
            Id = model.Id,
            Title = model.Title,
            Description = model.Description,
            CoverImageUrl = model.CoverImageUrl, 
            PublisherId = userId,
            Publisher = user,
            GenreId = model.GenreId,
            PublishedOn = model.PublishedOn
        };

        if (updateBook == null)
        {
            throw new ArgumentNullException(nameof(userId));
        }

        this.dbContext.Update(updateBook);
        await this.dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<BookDeleteViewModel> GetBookToDelete(string? userId, int? id)
    {
        BookDeleteViewModel viewModel = null;

        if (id.HasValue)
        {
            bool isUserNameValid = userId != null;

            Book? recipe = await this.dbContext
                .Books
                .Include(x => x.Publisher)
                .SingleOrDefaultAsync(x => x.Id == id && x.PublisherId == userId);

            if (recipe != null)
            {
                viewModel = new BookDeleteViewModel
                {
                    Id = id.Value,
                    Title = recipe.Title,
                    Publisher = recipe.Publisher.UserName!,
                };
            }
        }
        return viewModel;
    }

    public async Task<bool> ConfirmBookDelete(string? userId, int? recipeId)
    {
        bool operationResult = false;

        if (string.IsNullOrWhiteSpace(userId) || recipeId == null)
        {
            return false;
        }

        try
        {
            var favDeletedCount = await this.dbContext
                .UserBooks
                .Where(ur => ur.UserId == userId && ur.BookId == recipeId)
                .ExecuteDeleteAsync();

            var deletedCount = await this.dbContext
                .Books
                .Where(x => x.PublisherId == userId && x.Id == recipeId)
                .ExecuteDeleteAsync();

            operationResult = deletedCount > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            operationResult = false;
        }

        return operationResult;
    }

}
