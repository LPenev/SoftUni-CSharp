using System;

namespace foodForPets
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            double totalEatenBiscuits = 0;
            double percentFoodEaten = 0;
            double percentFoodEatenByDog = 0;
            double percentFoodEatenByCat = 0;
            double sumFoodEaten = 0;
            double sumFoodEatenByDog = 0;
            double sumFoodEatenByCat = 0;
            double sumBiscuitsDog = 0;
            double sumBiscuitsCat = 0;
            int biscuitDaysCount = 0;

            // read from console
            int numberDays = int.Parse(Console.ReadLine());
            double totalAmountOfFood = double.Parse(Console.ReadLine());
            
            // calc
            for (int i = 0; i < numberDays; i++)
            {
                biscuitDaysCount++;
                // read from console
                int amountOfFoodEatenByDog = int.Parse(Console.ReadLine());
                int amountOfFoodEatenByCat = int.Parse(Console.ReadLine());
                // calc food eaten
                sumFoodEatenByDog += amountOfFoodEatenByDog;
                sumFoodEatenByCat += amountOfFoodEatenByCat;
                sumFoodEaten += amountOfFoodEatenByCat + amountOfFoodEatenByDog;

                if(biscuitDaysCount == 3)
                {
                    // calculate biscuits
                    sumBiscuitsDog += amountOfFoodEatenByDog * 0.1;
                    sumBiscuitsCat += amountOfFoodEatenByCat * 0.1;
                    biscuitDaysCount = 0;
                }

            }
            totalEatenBiscuits = Math.Round(sumBiscuitsDog + sumBiscuitsCat);
            percentFoodEaten = (sumFoodEaten / totalAmountOfFood) * 100;
            percentFoodEatenByDog = (sumFoodEatenByDog / sumFoodEaten) * 100;
            percentFoodEatenByCat = (sumFoodEatenByCat / sumFoodEaten) * 100;

            // print result
            Console.WriteLine($"Total eaten biscuits: {totalEatenBiscuits}gr.");
            Console.WriteLine($"{percentFoodEaten:f2}% of the food has been eaten.");
            Console.WriteLine($"{percentFoodEatenByDog:f2}% eaten from the dog.");
            Console.WriteLine($"{percentFoodEatenByCat:f2}% eaten from the cat.");
        }
    }
}