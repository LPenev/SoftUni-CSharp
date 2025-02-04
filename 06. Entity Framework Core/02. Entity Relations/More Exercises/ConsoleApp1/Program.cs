using System.Globalization;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dateString = "10-12-2015";
            // Output: 10/22/2015 12:00:00 AM
            bool isSuccess6 = DateTime.TryParseExact(dateString, "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime14);
            Console.WriteLine(dateTime14);
        }
    }
}
