using System.Text.RegularExpressions;

namespace _01._02._Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"(#|\|)(?<Item>[A-Za-z\s]+)\1(?<ExpDate>\d\d\/\d\d\/\d\d)\1(?<Calories>\d+)\1";
            int caloryProDay = 2000;

            var message = Console.ReadLine();
            
            MatchCollection regexMessage = Regex.Matches(message, pattern);

            int sumCalory = 0;
            
            foreach (Match item in regexMessage)
            {
                sumCalory += int.Parse(item.Groups["Calories"].Value);
            }

            int leftDays = sumCalory / caloryProDay;
            Console.WriteLine($"You have food to last you for: {leftDays} days!");

            foreach (Match item in regexMessage)
            {
                Console.WriteLine($"Item: {item.Groups["Item"]}, Best before: {item.Groups["ExpDate"]}, Nutrition: {item.Groups["Calories"]}");
            }
        }
    }
}
