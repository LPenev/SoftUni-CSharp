using System;

namespace goldMine
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberLocations = int.Parse(Console.ReadLine());

            for (sbyte i = 0; i < numberLocations; i++)
            {
                double gold = 0;
                double averagePerDayGold = double.Parse(Console.ReadLine());
                int numberDays = int.Parse(Console.ReadLine());
                for (int d = 0; d < numberDays; d++)
                {
                    gold += double.Parse(Console.ReadLine());
                }

                double averageGold = averagePerDayGold * numberDays;

                if (gold >= averageGold)
                {
                    Console.WriteLine($"Good job! Average gold per day: {gold / numberDays:f2}.");
                }
                else
                {
                    Console.WriteLine($"You need {(averageGold - gold) / numberDays:f2} gold.");
                }
            }
        }
    }
}