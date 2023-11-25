namespace _1._01._Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double totalOrder = 0;
            List<double> orders = new List<double>();

            while (!input.StartsWith("special") && !input.StartsWith("regular"))
            {
                double price = double.Parse(input);
                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    input = Console.ReadLine();
                    continue;
                }

                orders.Add(price);

                input = Console.ReadLine();
            }

            double taxes = orders.Sum() * 0.2;

            if (input == "special")
            {
                totalOrder = (orders.Sum() + taxes) * 0.9;
            }
            else
            {
                totalOrder = orders.Sum() + taxes;
            }
            if (orders.Sum() <= 0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine("Price without taxes: {0:f2}$", orders.Sum());
            Console.WriteLine("Taxes: {0:f2}$", taxes);
            Console.WriteLine("-----------");
            Console.WriteLine("Total price: {0:f2}$", totalOrder);
        }
    }
}