using System.Text.RegularExpressions;

namespace _13._1._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"^%(?<name>[A-Z][a-z]+)%[^$%.|]*<(?<product>\w+)>[^$%.|]*\|(?<qnty>\d+)\|[^$%.|]*?(?<price>\d+(\.[0-9]+)?)\$";
            var orders = new List<Order>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string customerName = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    int qnty = int.Parse(match.Groups["qnty"].Value);
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    decimal totalPrice = price * qnty;

                    var current = new Order(customerName, product, qnty, totalPrice);
                    orders.Add(current);
                }
            }

            // print result
            foreach (Order order in orders)
            {
                Console.WriteLine($"{order.CustomerName}: {order.Product} - {order.Price:f2}");
            }
            
            decimal totalSum = orders.Select(x => x.Price).Sum();
            Console.WriteLine($"Total income: {totalSum:f2}");
        }
    }

    public class Order
    {
        public Order(string customerName, string product, int qnty, decimal price)
        {
            this.CustomerName = customerName;
            this.Product = product;
            this.Qnty = qnty;
            this.Price = price;
        }

        public string CustomerName { get; }
        public string Product { get; }
        public int Qnty { get; }
        public decimal Price { get; }
    }
}