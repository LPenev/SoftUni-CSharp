using BookVerse.Services.Core.Contracts;
using BookVerse.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookVerse.Web.Controllers;

public class BookController : BaseController
{

    private readonly IBookService bookService;
    private readonly IGenreService genreService;


    public BookController(IBookService bookService, IGenreService genreService)
    {
        this.bookService = bookService;
        this.genreService = genreService;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            string? userId = this.GetUserId();

            IEnumerable<BookViewModel> allBooks = await
                this.bookService.GetAllBooksAsync(userId);

            return View(allBooks);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return this.RedirectToAction(nameof(Index), "Home");
        }
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        BookDetailsViewModel? bookDetails = null;

        try
        {
            string? userId = this.GetUserId();

            bookDetails = await this.bookService
                .GetBookDetailsAsync(id, userId);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            this.RedirectToAction(nameof(Index), "Home");
        }

        return View(bookDetails);
    }


    [Authorize]
    [HttpGet]
    public async Task<IActionResult> MyBooks()
    {
        try
        {
            string userId = GetUserId()!;
            IEnumerable<MyBooksViewModel>? myBooks =
                await this.bookService.GetMyBooksViewModelAsync(userId);

            if (myBooks == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.View(myBooks);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return this.RedirectToAction(nameof(Index));
        }
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddToMyBooks(int? id) // Add to Favorites
    {
        try
        {
            string userId = GetUserId()!;

            if (id == null)
            {
                this.RedirectToAction(nameof(Index));
            }

            bool myBooksResult = await this.bookService.AddToMyBooksAsync(userId, id.Value);

            if (!myBooksResult)
            {
                this.RedirectToAction(nameof(Index));
            }

            return this.RedirectToAction(nameof(MyBooks));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return this.RedirectToAction(nameof(Index));
        }

    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(int id) // Remove from Favorites
    {
        var userId = this.GetUserId();
        if (string.IsNullOrEmpty(userId))
            return Challenge(); // към Login

        var ok = await this.bookService.RemoveBookFromMyBooksListAsync(userId, id);

        if (!ok)
        {
            TempData["Info"] = "Книгата не е в списъка ти.";
        }

        return RedirectToAction(nameof(MyBooks));
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        try
        {
            BookCreateInputModel inputModel = new BookCreateInputModel()
            {
                Genres = await this.genreService.GetGenreAsync(),
            };

            return View(inputModel);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return this.RedirectToAction(nameof(Index));
        }
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(BookCreateInputModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Genres = await this.genreService.GetGenreAsync();
            return View(model);
        }

        bool addResult = await this.bookService.AddBookAsync(this.GetUserId()!, model);

        if (!addResult)
        {
            ModelState.AddModelError(string.Empty, "Fatal error occurred while adding book");
            model.Genres = await this.genreService.GetGenreAsync();
            return this.View(model);
        }


        return RedirectToAction(nameof(Index));
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        try
        {
            string userId = GetUserId()!;

            BookEditInputModel? editInputModel = await this.bookService.GetBookForEditAsync(userId, id);

            if (editInputModel == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return this.View(editInputModel);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return this.RedirectToAction(nameof(Index));
        }
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Edit(BookEditInputModel model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                model.Genres = await this.genreService.GetGenreAsync();
                return View(model);
            }

            bool addResult = await this.bookService.UpdateBookAsync(this.GetUserId()!, model);

            if (!addResult)
            {
                ModelState.AddModelError(string.Empty, "Fatal error occurred while adding book");
                model.Genres = await this.genreService.GetGenreAsync();
                return this.View(model);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return RedirectToAction(nameof(Index));
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        BookDeleteViewModel? model = null;
        try
        {
            if (id == null)
            {
                this.RedirectToAction(nameof(Index));
            }

            string userId = GetUserId()!;

            model = await this.bookService.GetBookToDelete(userId, id);

            if (model == null)
            {
                this.RedirectToAction(nameof(Index));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return this.RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> ConfirmDelete(int? id)
    {
        try
        {
            if (id == null)
            {
                this.RedirectToAction(nameof(Index));
            }

            string userId = GetUserId()!;

            bool deleteResult = await this.bookService.ConfirmBookDelete(userId, id.Value);

            return this.RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return this.RedirectToAction(nameof(Index));
        }
    }
}

