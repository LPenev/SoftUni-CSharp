namespace _103._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double[]> orders = new Dictionary<string, double[]>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "buy")
            {
                string[] inputArray = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string productName = inputArray[0];
                double productPrice = double.Parse(inputArray[1]);
                double procuctQuantity = double.Parse(inputArray[2]);

                if (!orders.ContainsKey(productName))
                {
                    orders.Add(productName, new double[2]);
                }
                orders[productName][0] = productPrice;
                orders[productName][1] += procuctQuantity;
            }
            foreach (var product in orders)
            {
                Console.WriteLine($"{product.Key} -> {product.Value[0] * product.Value[1]:f2}");
            }
        }
    }
}