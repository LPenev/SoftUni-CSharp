namespace _06._Easter_Competition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int numberOfKozunaks = int.Parse(Console.ReadLine());
            string bestBackerName = string.Empty;
            int bestBackerPoints = int.MinValue;


            for (int i = 0; i < numberOfKozunaks; i++)
            {
                string backerName = Console.ReadLine().Trim();
                int backerPoints = 0;
                string input = string.Empty;

                while((input = Console.ReadLine().Trim()) != "Stop")
                {
                    backerPoints += int.Parse(input);
                }

                Console.WriteLine($"{backerName} has {backerPoints} points.");

                if (backerPoints > bestBackerPoints)
                {
                    bestBackerName = backerName;
                    bestBackerPoints = backerPoints;
                    Console.WriteLine($"{bestBackerName} is the new number 1!");
                }
            }

            Console.WriteLine($"{bestBackerName} won competition with {bestBackerPoints} points!");
        }
    }
}
