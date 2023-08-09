using System;
using System.Reflection.Metadata;

namespace club
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            double sumMoneyOrders = 0;
            // read from console
            double clubProfit = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            // calculations
            while ( input != "Party!")
            {
                int numberOfCocktailsForOrder = int.Parse(Console.ReadLine());
                double order = input.Length * numberOfCocktailsForOrder;
                if(order%2 != 0)
                {
                    sumMoneyOrders += order * 0.75;
                }
                else 
                {
                    sumMoneyOrders += order;
                }
                if(sumMoneyOrders >= clubProfit) { break; }
                input = Console.ReadLine();
            }

            // print result
            if( input == "Party!")
            {
                Console.WriteLine($"We need {clubProfit-sumMoneyOrders:f2} leva more.");
            }
            else
            {
                Console.WriteLine("Target acquired.");
            }
            Console.WriteLine($"Club income - {sumMoneyOrders:f2} leva.");
        }
    }
}