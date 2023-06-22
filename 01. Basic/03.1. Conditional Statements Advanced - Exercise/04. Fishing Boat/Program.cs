namespace _04._Fishing_Boat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // int variables
            double sum = 0;
            bool even = false;
            // read from console
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int countFisher = int.Parse(Console.ReadLine());


            // Calc
            switch (season)
            {
                // Season Spring
                case "Spring":
                    sum = 3000;
                    break;
                // Season Summer and Autumn
                case "Summer":
                case "Autumn":
                    sum = 4200;
                    break;
                // Season Winter
                case "Winter":
                    sum = 2600;
                    break;
            }

            // Calculate discount per fisher
            if (countFisher <= 6)
            {
                sum *= 0.9;
            }
            else if (countFisher >= 7 && countFisher <= 11)
            {
                sum *= 0.85;
            }
            else if (countFisher >= 12)
            {
                sum *= 0.75;
            }

            // Calculate discount per even fisher
            even = (countFisher % 2 == 0);
            if (season != "Autumn" && even)
            {
                sum *= 0.95;
            }

            // Print result
            if (budget >= sum)
            {
                Console.WriteLine($"Yes! You have {budget - sum:f2} leva left.");
            }
            else if (sum > budget)
            {
                Console.WriteLine($"Not enough money! You need {sum - budget:f2} leva.");
            }
        }
    }
}
