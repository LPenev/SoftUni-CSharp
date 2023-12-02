namespace _02._Space_Travel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries).ToArray();
            decimal fuel = decimal.Parse(Console.ReadLine());
            decimal ammunition = decimal.Parse(Console.ReadLine());


            for (int i = 0; i < input.Length; i++)
            {
                string[] command = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (command[0])
                {
                    case "Travel":
                        decimal distance = decimal.Parse(command[1]);
                        if ( distance > fuel)
                        {
                            Console.WriteLine("Mission failed.");
                            return;
                        }

                        fuel -= distance;
                        Console.WriteLine($"The spaceship travelled {distance} light-years.");
                        
                        break;

                    case "Enemy":
                        decimal enemyPoints = decimal.Parse(command[1]);

                        if (ammunition >= enemyPoints)
                        {
                            ammunition -= enemyPoints;
                            Console.WriteLine($"An enemy with {enemyPoints} armour is defeated.");
                        }
                        else if(fuel >= enemyPoints * 2)
                        {
                            fuel -= enemyPoints * 2;
                            Console.WriteLine($"An enemy with {enemyPoints} armour is outmaneuvered.");
                        }
                        else
                        {
                            Console.WriteLine("Mission failed.");
                            return;
                        }
                        break;

                    case "Repair":
                        decimal repairPoints = decimal.Parse(command[1]);

                        fuel += repairPoints;
                        ammunition += repairPoints * 2;
                        Console.WriteLine($"Ammunitions added: {repairPoints * 2}.");
                        Console.WriteLine($"Fuel added: {repairPoints}.");
                        break;

                    case "Titan":
                        Console.WriteLine("You have reached Titan, all passengers are safe.");
                        break;
                }
            }
        }
    }
}