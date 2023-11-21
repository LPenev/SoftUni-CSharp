using System.Text.RegularExpressions;

namespace _16._Extract_Emails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(^|(?<=\s))(([a-zA-Z0-9]+)([\.\-_]?)([A-Za-z0-9]+)(@)([a-zA-Z]+([\.\-][A-Za-z]+)+))(\b|(?=\s))";
            
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            if (regex.IsMatch(input))
            {
                foreach (Match email in matches)
                {
                    Console.WriteLine(email);
                }
            }
        }
    }
}