using System;

namespace catDiet
{
    class Program
    {
        static void Main(string[] args)
        {
            // read from console
            int percentageOfFat = int.Parse(Console.ReadLine());
            int percentageOfProteins = int.Parse(Console.ReadLine());
            int percentageOfCarbohydrates = int.Parse(Console.ReadLine());
            int totalCalories = int.Parse(Console.ReadLine());
            int percentageOfWaterContent = int.Parse(Console.ReadLine());

            // calclations
            double gramFat = totalCalories * ((double)percentageOfFat / 100) / 9;
            double gramProteins = totalCalories * ((double)percentageOfProteins /100) /4;
            double gramCarbohydrates = totalCalories * ((double)percentageOfCarbohydrates /100) /4;

            double weightOfFood = gramFat + gramProteins + gramCarbohydrates;
            double caloriesPerGramOfFood = totalCalories / weightOfFood;
            double percentage = 100 - percentageOfWaterContent;
            double calories = caloriesPerGramOfFood * (percentage / 100);

            // print result
            Console.WriteLine($"{calories:f4}");
        }
    }
}