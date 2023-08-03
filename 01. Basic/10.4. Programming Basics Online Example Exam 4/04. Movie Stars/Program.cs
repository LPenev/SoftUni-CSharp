using System;

namespace movieStars
{
    class Program
    {
        static void Main(string[] args)
        {
            double budgetActiors = double.Parse(Console.ReadLine());
            string nameActior = Console.ReadLine();

            while (nameActior != "ACTION")
            {
                if (nameActior.Length <= 15)
                {
                    double priceCurrentActior = double.Parse(Console.ReadLine());
                    budgetActiors -= priceCurrentActior;
                }
                else
                {
                    budgetActiors -= budgetActiors * 0.2;
                }
                if(budgetActiors <=0) { break; }
                nameActior = Console.ReadLine();
            }

            if (budgetActiors > 0)
            {
                Console.WriteLine($"We are left with {budgetActiors:f2} leva.");
            }
            else
            {
                Console.WriteLine($"We need {Math.Abs(budgetActiors):f2} leva for our actors.");
            }
        }
    }
}