using System.Text.RegularExpressions;

namespace _11._Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^>>(?<furnitureName>[A-Za-z]+)<<(?<price>\d+.\d*)!(?<quantity>\d+)(.*\d*){0,1}$";

            var productsName = new List<string>();
            double totalMoney = 0;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string furnitureName = match.Groups["furnitureName"].Value;
                    double pricePerUnit = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    productsName.Add(furnitureName);
                    totalMoney += pricePerUnit * quantity;
                }
            }

            Console.WriteLine("Bought furniture:");
            foreach (string furnitureName in productsName)
            {
                Console.WriteLine(furnitureName);
            }
            Console.WriteLine($"Total money spend: {totalMoney:f2}");
        }
    }
}