namespace _01._The_Hunting_Games
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daysOfAdventure = int.Parse(Console.ReadLine());
            int countOfPlayers = int.Parse(Console.ReadLine());
            double energyOfGroup = double.Parse(Console.ReadLine());
            double personWater = double.Parse(Console.ReadLine());
            double personFood = double.Parse(Console.ReadLine());

            double totalWater = daysOfAdventure * personWater * countOfPlayers;
            double totalFood = daysOfAdventure * personFood * countOfPlayers;

            int foodDay = 1;
            int waterDay = 1;

            for(int i = 1; i <= daysOfAdventure; i++)
            {
                double lostEnergy = double.Parse(Console.ReadLine());

                energyOfGroup -= lostEnergy;

                if (energyOfGroup <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
                    return;
                }

                if (waterDay == 2)
                {
                    waterDay = 0;
                    energyOfGroup *= 1.05;
                    totalWater *= 0.7;
                }
                
                if( foodDay == 3)
                {
                    foodDay = 0;
                    totalFood -= totalFood / countOfPlayers;
                    energyOfGroup *= 1.1;
                }
                
                waterDay++;
                foodDay++;

            }

            Console.WriteLine($"You are ready for the quest. You will be left with - {energyOfGroup:f2} energy!");
        }
    }
}