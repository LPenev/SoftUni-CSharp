using BookVerse.Services.Core.Contracts;
using BookVerse.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookVerse.Web.Controllers;

public class BookController : BaseController
{

    private readonly IBookService bookService;

    public BookController(IBookService bookService)
    {
        this.bookService = bookService;
    }


    [HttpGet]
    [AllowAnonymous]
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


}

