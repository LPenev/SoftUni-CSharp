using System;

namespace excursionSale
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            double seaPrice = 680;
            double mountainPrice = 499;
            double sumProfit = 0;
            bool isAllSold = false;

            // read from console
            int numberOfSeaExcursions = int.Parse(Console.ReadLine());
            int numberOfMountainExcursions = int.Parse(Console.ReadLine());

            // calclations
            while (true)
            {
                string packageName = Console.ReadLine();
                if (packageName == "Stop") break;
                
                if(packageName == "sea" && numberOfSeaExcursions !=0)
                {
                    numberOfSeaExcursions--;
                    sumProfit += seaPrice;
                }

                if (packageName == "mountain" && numberOfMountainExcursions != 0)
                {
                    numberOfMountainExcursions--;
                    sumProfit += mountainPrice;
                }
                if (numberOfMountainExcursions == 0 && numberOfSeaExcursions == 0)
                {
                    isAllSold = true;
                    break;
                }
            }

            // print result
            if (isAllSold)
            {
                Console.WriteLine("Good job! Everything is sold.");
            }
            Console.WriteLine($"Profit: {sumProfit} leva.");
        }
    }
}