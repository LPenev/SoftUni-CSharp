namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;
    using System.Runtime.Serialization.Formatters;
    using System.Text;
    using Z.EntityFramework.Plus;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            var result = String.Empty;
            // Tasks

            // 02. Age Restriction
            //string command = Console.ReadLine();
            //result = GetBooksByAgeRestriction(db, command);

            // 03. Golden Books
            //result = GetGoldenBooks(db);

            // 04. Books by price
            //result = GetBooksByPrice(db);

            // 05. Not Released In
            //int inputedYear = int.Parse(Console.ReadLine());
            //result = GetBooksNotReleasedIn(db, inputedYear);

            // 06. Book Titles by Category
            //string input = Console.ReadLine();
            //result = GetBooksByCategory(db, input);

            // 07. Released Before Date
            //string date = Console.ReadLine();
            //result = GetBooksReleasedBefore(db, date);

            // 08. Author Search
            //var input = Console.ReadLine();
            //result = GetAuthorNamesEndingIn(db, input);

            // 09. Book Search
            //var input = Console.ReadLine();
            //result = GetBookTitlesContaining(db, input);

            // 10.	Book Search by Author
            //var input = Console.ReadLine();
            //result = GetBooksByAuthor(db, input);

            // 11. Count Books
            //int lenghtCheck = int.Parse(Console.ReadLine());
            //int countBooks = CountBooks(db, lenghtCheck);
            //result = $"There are {countBooks} books with longer title than {lenghtCheck} symbols";

            // 12. Total Book Copies
            //result = CountCopiesByAuthor(db);

            // 13. Profit by Category
            //result = GetTotalProfitByCategory(db);

            // 14. Most Recent Books
            //result = GetMostRecentBooks(db);

            // 15. Increase Prices
            //IncreasePrices(db);

            // 15. Increase Prices - Version 2 Bulk
            IncreasePricesV2(db);

            // Print result
            Console.WriteLine(result);

        }

        // 02. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var isExcistCommand = Enum.TryParse<AgeRestriction>(command, true, out AgeRestriction ageRestriction);

            if (!isExcistCommand)
            {
                return "Ivalid command";
            }

            var resultBooksTitel = context.Books
                .Where(x => x.AgeRestriction == ageRestriction)
                .OrderBy(x => x.Title)
                .Select(x => new { x.Title})
                .ToArray();

            var sb = new StringBuilder();

            foreach (var book in resultBooksTitel) 
            {
                sb.AppendLine(book.Title);
            }
            
            return sb.ToString().TrimEnd();
        }

        // 03. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var checkResult = Enum.TryParse<EditionType>("Gold", true, out EditionType selectedEditionType);
            
            if (!checkResult)
            {
                return "Invalid Bood Edition";
            }
                        
            var resultTitleGoldenBooksLess5000Copys = context.Books
                .Where(x => x.EditionType == selectedEditionType && x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToArray();

            return String.Join(Environment.NewLine, resultTitleGoldenBooksLess5000Copys);
        }

        // 04. Books by price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var resultBooksByPrices = context.Books
                .Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .Select(x => new { x.Title, x.Price })
                .ToArray();

            var sb = new StringBuilder();

            foreach (var book in resultBooksByPrices) 
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}"); 
            }
            
            return sb.ToString().TrimEnd();
        }

        // 05. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var resultBooksNotReleasedInGivenYear = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToArray();

            return String.Join(Environment.NewLine, resultBooksNotReleasedInGivenYear);
        }

        // 06. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var inputedCategory = input.ToLower()
                .Split()
                .ToArray();

            var resultBooksByCategory = context.Books
                .Where(x => x.BookCategories.Any(x => inputedCategory.Contains(x.Category.Name.ToLower())))
                .OrderBy(x => x.Title)
                .Select(x => x.Title)
                .ToArray();

            return String.Join(Environment.NewLine, resultBooksByCategory);
        }

        // 07. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            if(!DateTime.TryParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var releaseDate))
            {
                return "Invalid date";
            }

            var resultBooksReleasedBefore = context.Books
                .Where(x => x.ReleaseDate < releaseDate)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => new { x.Title, x.EditionType,x.Price})
                .ToArray();

            var sb = new StringBuilder();
            foreach (var book in resultBooksReleasedBefore) 
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 08. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var resultAuthorsNames = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Select(x => $"{x.FirstName} {x.LastName}")
                .ToArray();

            return String.Join(Environment.NewLine, resultAuthorsNames);
        }

        // 09. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var resultBooksTitles = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(x => x.Title)
                .Select(x => x.Title)
                .ToArray();

            return String.Join(Environment.NewLine, resultBooksTitles);
        }

        // 10.	Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var resultBooksTitles = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy (x => x.BookId)
                .Select(x => new { x.Title, AuthorName = $"{x.Author.FirstName} {x.Author.LastName}"})
                .ToArray();

            var sb = new StringBuilder();
            foreach (var book in resultBooksTitles)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorName})");
            }

            return sb.ToString().Trim();
        }

        // 11. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var countBooks = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .Count();

            return countBooks;
        }

        // 12. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var numbersOfBookCopiesByAuthor = context.Authors
                .AsNoTracking()
                .Select(x => new 
                {
                    AuthorName = $"{x.FirstName} {x.LastName}",
                    Copies = x.Books.Sum(x => x.Copies),
                })
                .OrderByDescending(x => x.Copies)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach(var book in numbersOfBookCopiesByAuthor)
            {
                sb.AppendLine($"{book.AuthorName} - {book.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        // 13. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var listCategories = context.Categories
                .AsNoTracking()
                .Select(x => new
                {
                    CategoryName = x.Name,
                    Profit = x.CategoryBooks.Sum( c => c.Book.Price * c.Book.Copies)
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.CategoryName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach(var book in listCategories)
            {
                sb.AppendLine($"{book.CategoryName} {book.Profit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 14. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var MostRecentBooksByCategory = context.Categories
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .Select(x => new 
                {
                    CategoryName = x.Name,
                    Books = x.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Take(3)
                        .Select(b => new 
                        {
                            b.Book.Title,
                            ReleaseYear = b.Book.ReleaseDate.Value.Year
                        })
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach(var category in MostRecentBooksByCategory)
            {
                sb.AppendLine($"--{category.CategoryName}");
                
                foreach(var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseYear})");
                }
            }
            return sb.ToString().TrimEnd();
        }

        // 15. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var upatedBooks = context.Books
                .Where(x => x.ReleaseDate.HasValue && x.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var book in upatedBooks)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        // 15. Increase Prices - Version 2 Bulk
        public static void IncreasePricesV2(BookShopContext context)
        {
            var upatedBooks = context.Books
                .Where(x => x.ReleaseDate.HasValue && x.ReleaseDate.Value.Year < 2010)
                .Update<Book>(book => new Book { Price = book.Price + 5 });
        }

    }
}
