using System.Text.RegularExpressions;

namespace _13._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"^%(?<name>[A-Z][a-z]+)%[^$%.|]*<(?<product>\w+)>[^$%.|]*\|(?<qnty>\d+)\|[^$%.|]*?(?<price>\d+(\.[0-9]+)?)\$";
            decimal totalSum = 0;

            string input = string.Empty;
            while((input = Console.ReadLine()) != "end of shift")
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string customerName = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    int qnty = int.Parse(match.Groups["qnty"].Value);
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    decimal totalPrice = price * qnty;

                    Console.WriteLine($"{customerName}: {product} - {totalPrice:f2}");
                    totalSum += totalPrice;
                }
            }

            // print result
            Console.WriteLine($"Total income: {totalSum:f2}");
        }
    }
}