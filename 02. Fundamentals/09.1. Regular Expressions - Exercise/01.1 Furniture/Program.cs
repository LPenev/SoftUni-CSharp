using System.Text.RegularExpressions;

namespace _11._1_Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^>>(?<name>[A-Za-z]+)<<(?<price>\d+.\d*|\d+)!(?<quantity>\d+)(.*\d*){0,1}$";

            var furnitures = new List<Furniture>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    Furniture current = new Furniture(name, price, quantity);
                    furnitures.Add(current);
                }
            }

            Console.WriteLine("Bought furniture:");
            foreach (Furniture current in furnitures)
            {
                Console.WriteLine(current.Name);
            }
            Console.WriteLine($"Total money spend: {furnitures.Select(x=> x.TotalSum).Sum():f2}");
        }
    }

    class Furniture
    {
        public Furniture(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantitiy = quantity;
            TotalSum = TotalPrice();
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantitiy { get; set; }
        public decimal TotalSum { get; set; }

        public decimal TotalPrice()
        {
            return Price * Quantitiy;
        }
    }
}
