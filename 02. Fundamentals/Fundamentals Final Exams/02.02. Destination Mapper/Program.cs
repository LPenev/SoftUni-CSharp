using System.Text.RegularExpressions;

namespace _02._02._Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var destinations = new List<string>();

            var pattern = @"(=|\/)(?<Destination>[A-Z][A-Za-z]{2,})\1";
            Regex regex = new Regex(pattern);

            var input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            var points = 0;
            foreach (Match match in matches)
            {
                points += match.Groups["Destination"].Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", matches.Select(x => x.Groups["Destination"]))}");
            Console.WriteLine($"Travel Points: {points}");
        }
    }
}
