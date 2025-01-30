namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            // Tasks

            // 02. Age Restriction
            //string command = Console.ReadLine();
            //var result = GetBooksByAgeRestriction(db, command);

            // 03. Golden Books
            //var result = GetGoldenBooks(db);

            // 04. Books by price
            var result = GetBooksByPrice(db);


            // Print result
            Console.WriteLine(result);

        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestrinction = Enum.Parse<AgeRestriction>(command, true);

            var resultBooksTitel = context.Books
                .Where(x => x.AgeRestriction == ageRestrinction)
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

        public static string GetGoldenBooks(BookShopContext context)
        {
            var selectedEditionType = Enum.Parse<EditionType>("gold", true);
                        
            var resultTitleGoldenBooksLess5000Copys = context.Books
                .Where(x => x.EditionType == selectedEditionType && x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToArray();

            return String.Join(Environment.NewLine, resultTitleGoldenBooksLess5000Copys);
        }

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
    }
}


