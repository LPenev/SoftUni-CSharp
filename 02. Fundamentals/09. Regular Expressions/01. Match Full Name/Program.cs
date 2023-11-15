using System.Text.RegularExpressions;

namespace _01._Match_Full_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"(?<name>\b[A-Z][a-z]+) (?<fname>[A-Z][a-z]+)";

            string input = Console.ReadLine();
            MatchCollection mached = Regex.Matches(input, patern);

            Console.WriteLine(string.Join(" ", mached));

        }
    }
}