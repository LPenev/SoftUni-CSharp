using System.Text.RegularExpressions;

namespace _12._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var patternName = @"[A-Za-z]+";
            var patternDigits = @"\d";

            var results = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToDictionary(x => x, v => 0);

            string input = string.Empty;
            while((input = Console.ReadLine()) != "end of race")
            {
                MatchCollection name = Regex.Matches(input, patternName);
                var participantName = string.Join(string.Empty, name);

                if (results.ContainsKey(participantName))
                {
                    MatchCollection digits = Regex.Matches(input, patternDigits);
                    results[participantName] += digits.Select(x => int.Parse(x.Value)).Sum();
                }
            }

            var finalResults = results.OrderByDescending(x => x.Value);

            var counter = 1;
            foreach (var current in finalResults)
            {
                string suffix = counter == 1 ? "st" : counter == 2 ? "nd" : "rd";
                Console.WriteLine($"{counter++}{suffix} place: {current.Key}");
                if (counter == 4) { break; }
            }
        }
    }
}