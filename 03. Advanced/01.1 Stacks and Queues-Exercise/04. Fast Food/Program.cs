namespace _14._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read quantity of Food
            int quantityOfFood = int.Parse(Console.ReadLine());
            // read orders split by whitespace
            int[] ordersArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            // print bigest order
            int bigestOrder = ordersArray.Max();
            Console.WriteLine(bigestOrder);

            // create Stack and add all orders
            Queue<int> orders = new(ordersArray);

            while (orders.Any() && quantityOfFood - orders.Peek() >= 0)
            {
                quantityOfFood -= orders.Peek();
                orders.Dequeue();
            }

            if (orders.Any())
            {
                // print rest of orders
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
            else
            {
                // print message
                Console.WriteLine("Orders complete");
            }
        }
    }
}