using System.Text.RegularExpressions;

namespace _02._Message_Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"!(?<Command>[A-Z][a-z]{1,})!:\[(?<String>[A-Za-z]{8,})\]";
            Regex regex = new Regex(pattern);

            var countOfInput = int.Parse(Console.ReadLine());

            for(int i = 0; i < countOfInput; i++)
            {
                var input = Console.ReadLine();
                Match match = regex.Match(input);
                if(match.Success)
                {
                    var currentString = match.Groups["String"].Value;
                    Console.Write($"{match.Groups["Command"]}:");
                    foreach(char current in currentString)
                    {
                        int number = (int)current;
                        Console.Write($" {number}");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
