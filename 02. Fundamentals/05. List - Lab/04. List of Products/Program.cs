namespace _04._List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbersOfLines = int.Parse(Console.ReadLine());

            List<string> listOfProducts = new List<string>();

            for(int i = 0; i < numbersOfLines; i++)
            {
                listOfProducts.Add(Console.ReadLine());
            }

            OrderedProductsByName(listOfProducts);

            PrintProductsWithNumbers(listOfProducts);
        }

        static void PrintProductsWithNumbers(List<string> listOfProducts)
        {
            for(int i = 0;i < listOfProducts.Count;i++)
            {
                Console.WriteLine("{0}.{1}", i + 1, listOfProducts[i]);
            }
        }

        static void OrderedProductsByName(List<string> listOfProducts)
        {
            listOfProducts.Sort();
        }
    }
}