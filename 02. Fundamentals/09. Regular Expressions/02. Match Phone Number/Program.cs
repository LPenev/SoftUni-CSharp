using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"\+\b359(-| )2\1\d{3}\1\d{4}\b";
            var input = Console.ReadLine();

            var regex = new Regex(pattern);
            MatchCollection phoneNumbers = regex.Matches(input);
            var result = phoneNumbers
                .Select(x => x.Value)
                .ToArray();

            Console.WriteLine(string.Join(", ",result));

            //var phoneMatches = Regex.Matches(input, pattern);

            //var machedPhones = phoneMatches
            //    .Cast<Match>()
            //    .Select(a => a.Value.Trim())
            //    .ToArray();

            //Console.WriteLine(string.Join(", ",machedPhones));
        }
    }
}