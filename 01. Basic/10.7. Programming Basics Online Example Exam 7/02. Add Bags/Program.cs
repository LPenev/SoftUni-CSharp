using System.Diagnostics;

namespace _02._Add_Bags
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read inputs 
            double priceOfLuggageOver20kg = double.Parse(Console.ReadLine());
            double kilogramsOfLuggage  = double.Parse(Console.ReadLine());
            int daysUntilTravel = int.Parse(Console.ReadLine());
            int numberOfLuggage = int.Parse(Console.ReadLine());

            // init vars
            double costOfLuggage = 0;

            // calc
            switch (kilogramsOfLuggage)
            {
                case < 10:
                    costOfLuggage = priceOfLuggageOver20kg * 0.2 * numberOfLuggage;
                    break;
                case <= 20:
                    costOfLuggage = priceOfLuggageOver20kg * 0.5 * numberOfLuggage;
                    break;
                case > 20:
                    costOfLuggage = priceOfLuggageOver20kg * numberOfLuggage;
                    break;
            }

            if (daysUntilTravel < 7)
            {
                costOfLuggage *= 1.4;
            }
            else if (daysUntilTravel <= 30)
            {
                costOfLuggage *= 1.15;
            }
            else
            {
                costOfLuggage *= 1.1;
            }

            // output
            Console.WriteLine($" The total price of bags is: {costOfLuggage:f2} lv. ");
        }
    }
}
