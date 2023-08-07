using System;

namespace famylyTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            double sumVacantion = 0;
            // read from console
            double budget = double.Parse(Console.ReadLine());
            int numberOfNights = int.Parse(Console.ReadLine());
            double pricePerNights = double.Parse(Console.ReadLine());
            double percentageForAdditionalCosts = double.Parse(Console.ReadLine());

            // calculation
            if( numberOfNights > 7) { pricePerNights *= 0.95; }
            double additionalCosts = budget * (percentageForAdditionalCosts / 100);
            sumVacantion = numberOfNights * pricePerNights + additionalCosts;

            // print result
            if(sumVacantion <= budget)
            {
                Console.WriteLine($"Ivanovi will be left with {budget-sumVacantion:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{sumVacantion-budget:f2} leva needed.");
            }
        }
    }
}