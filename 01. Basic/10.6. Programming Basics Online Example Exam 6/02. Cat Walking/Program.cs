using System;

namespace catWalking
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            int sumTime = 0;
            int brunedCalories = 0;
            // read from console
            int timeTrip = int.Parse(Console.ReadLine());
            int numberTripPerDay = int.Parse(Console.ReadLine());
            int incomenCalorie = int.Parse(Console.ReadLine());

            // calc
            sumTime = numberTripPerDay * timeTrip;
            brunedCalories = sumTime * 5;
            int halfCaloriesForTag = incomenCalorie / 2;

            if (brunedCalories >= halfCaloriesForTag)
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {brunedCalories}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {brunedCalories}.");
            }
        }
    }
}