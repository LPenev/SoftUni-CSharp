﻿namespace BookShop
{
    using BookShop.Models.Enums;
    using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
    using Data;
    using Initializer;
    using System.Globalization;
    using System.Text;

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
            var input = Console.ReadLine();
            result = GetBooksByAuthor(db, input);
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
    }
}
