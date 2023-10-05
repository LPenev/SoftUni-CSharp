namespace _05._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string selectedProduct = Console.ReadLine();
            int quantityOfProduct = int.Parse(Console.ReadLine());

            double sum = calculateSumOfProducts(selectedProduct, quantityOfProduct);
            Console.WriteLine($"{sum:f2}");
        }

        static double calculateSumOfProducts (string selectedProducts,int quantityOfProducts)
        {
            double priceOfProduct = 0;

            switch (selectedProducts)
            {
                case "coffee":
                    priceOfProduct = 1.5;
                    break;
                case "water":
                    priceOfProduct = 1;
                    break;
                case "coke":
                    priceOfProduct = 1.4;
                    break;
                case "snacks":
                    priceOfProduct = 2;
                    break;
            }
            double result = priceOfProduct * quantityOfProducts;
            return result;
        }
    }
}