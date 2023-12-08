using System.Text.RegularExpressions;

namespace _03._02._Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"";
            Regex regex = new Regex(pattern);

            var input = Console.ReadLine();

            MatchCollection matches = regex.Matches(input);

            var word = string.Empty;
            foreach (Match match in matches)
            {
                word = match.Value;
            }
        }
    }
}
