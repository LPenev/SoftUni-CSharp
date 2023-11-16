using System.Text.RegularExpressions;

namespace _03._Match_Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"\b(?<day>\d{2})([-./])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";
            var input = Console.ReadLine();

            Regex regex = new Regex(pattern);
            MatchCollection result = regex.Matches(input);

            //var result = Regex.Matches(input, pattern);

            foreach (Match date in result)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }   
        }
    }
}