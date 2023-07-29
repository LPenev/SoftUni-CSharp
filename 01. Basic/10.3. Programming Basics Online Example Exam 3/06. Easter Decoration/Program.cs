namespace _06._Easter_Decoration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // init constants 
            const decimal PriceBasket = 1.5m;
            const decimal PriceWreath = 3.8m;
            const decimal PriceChokolateBunny = 7m;

            // read from Console
            int numberOfClients = int.Parse(Console.ReadLine());

            // init vars
            decimal totalSum = 0;

            for (int i = 1; i <= numberOfClients; i++)
            {
                string input = string.Empty;
                int productCounter = 0;
                decimal currentSum = 0;

                while ((input = Console.ReadLine().Trim()) != "Finish")
                {
                    switch (input)
                    {
                        case "basket":
                            currentSum += PriceBasket;
                            break;
                        case "wreath":
                            currentSum += PriceWreath;
                            break;
                        case "chocolate bunny":
                            currentSum += PriceChokolateBunny;
                            break;
                    }

                    productCounter++;
                }

                if (productCounter % 2 == 0)
                {
                    currentSum *= 0.8m;
                }

                totalSum += currentSum;
                Console.WriteLine($"You purchased {productCounter} items for {currentSum:f2} leva.");
            }

            decimal avgSum = totalSum / numberOfClients;
            Console.WriteLine($"Average bill per client is: {avgSum:f2} leva.");
        }
    }
}
