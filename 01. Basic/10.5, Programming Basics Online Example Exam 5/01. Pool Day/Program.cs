using System;

namespace poolDay
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            

            // read from console
            int numberOfPeople = int.Parse(Console.ReadLine());
            double entranceFee = double.Parse(Console.ReadLine());
            double priceOneSunLounger = double.Parse(Console.ReadLine());
            double priceOneUmbrella = double.Parse(Console.ReadLine());

            // calculation
            double numberSunLounger = Math.Ceiling((double)numberOfPeople * 0.75);
            double numberSunUmbrela = Math.Ceiling((double)numberOfPeople / 2);
            double sumMoney = entranceFee * numberOfPeople;
            sumMoney += numberSunLounger * priceOneSunLounger;
            sumMoney += numberSunUmbrela * priceOneUmbrella;
            // print result
            Console.WriteLine($"{sumMoney:f2} lv.");
        }
    }
}