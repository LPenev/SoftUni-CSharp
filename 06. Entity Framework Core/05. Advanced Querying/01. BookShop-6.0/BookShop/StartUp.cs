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
            string command = Console.ReadLine();
            Console.WriteLine(GetBooksByAgeRestriction(db, command));

            // 03. Golden Books

        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var sb = new StringBuilder();
            var ageRestrinction = Enum.Parse<AgeRestriction>(command, true);

            var resultBooksTitel = context.Books
                .Where(x => x.AgeRestriction == ageRestrinction)
                .Select(x => new { x.Title})
                .OrderBy(x => x.Title);

            foreach (var book in resultBooksTitel) 
            {
                sb.AppendLine(book.Title);
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}


