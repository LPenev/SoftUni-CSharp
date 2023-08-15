using System;

namespace careOfPuppy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variables
            int gramsPuppyEatAtEachMeal = 0;

            // read from console
            int amountOfPuppyFoodPurchasedKg = int.Parse(Console.ReadLine());
            // convert kg to gr.
            amountOfPuppyFoodPurchasedKg *= 1000;

            string input = Console.ReadLine();

            // calc
            while (input != "Adopted")
            {
                gramsPuppyEatAtEachMeal += int.Parse(input);
                // read from console
                input = Console.ReadLine();
            }

            // print result
            if(amountOfPuppyFoodPurchasedKg >= gramsPuppyEatAtEachMeal)
            {
                Console.WriteLine($"Food is enough! Leftovers: {amountOfPuppyFoodPurchasedKg-gramsPuppyEatAtEachMeal} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {gramsPuppyEatAtEachMeal-amountOfPuppyFoodPurchasedKg} grams more.");
            }

        }
    }
}