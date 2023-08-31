namespace _05._Best_Player
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // init vars
            string bestPlayer = "";
            int bestPlayerGoals = 0;

            string player = "";

            while ((player = Console.ReadLine().Trim()) != "END")
            {
                int goals = int.Parse(Console.ReadLine());

                if(goals > bestPlayerGoals)
                {
                    bestPlayerGoals = goals;
                    bestPlayer = player;
                }

                if(bestPlayerGoals >= 10) break;
            }

            Console.WriteLine($"{bestPlayer} is the best player!");

            if (bestPlayerGoals >= 3)
            {
                Console.WriteLine($"He has scored {bestPlayerGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {bestPlayerGoals} goals.");
            }
            
        }
    }
}
