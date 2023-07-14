using System;
using System.Diagnostics;

namespace braceletStand
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            int daysLeft = 5;
            // read from console
            double teresaPocketMoneyPerDay = double.Parse(Console.ReadLine());
            double moneyEarnsPerDay = double.Parse(Console.ReadLine());
            double teresaExpensesForEntirePeriod = double.Parse(Console.ReadLine());
            double priceOfGift = double.Parse(Console.ReadLine());

            // calclations
            double sumSavedMoney = teresaPocketMoneyPerDay * daysLeft;
            double sumEarnsMoney = moneyEarnsPerDay * daysLeft;
            double sumMoney = sumSavedMoney + sumEarnsMoney;
            double netoMoney = sumMoney - teresaExpensesForEntirePeriod;

            // print result
            if(priceOfGift > netoMoney)
            {
                Console.WriteLine($"Insufficient money: {priceOfGift-netoMoney:f2} BGN.");
            }
            else
            {
                Console.WriteLine($"Profit: {netoMoney:f2} BGN, the gift has been purchased.");
            }
        }
    }
}