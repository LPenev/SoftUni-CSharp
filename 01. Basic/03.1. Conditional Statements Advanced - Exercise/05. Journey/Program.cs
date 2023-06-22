namespace _05._Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read from console
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            // init variables
            string restType = "";
            string destination = "";

            // Calc
            // budget 100 lv in Bulgaria
            if (budget <= 100)
            {
                destination = "Bulgaria";

                if (season == "summer")
                {
                    budget *= 0.3;
                    restType = "Camp";
                }
                else if (season == "winter")
                {
                    budget *= 0.7;
                    restType = "Hotel";
                }

                // budget 1000lv in Balkans            
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";

                if (season == "summer")
                {
                    budget *= 0.4;
                    restType = "Camp";
                }
                else if (season == "winter")
                {
                    budget *= 0.8;
                    restType = "Hotel";
                }
                // budget upper 1000lv in Europe
            }
            else if (budget > 1000)
            {
                destination = "Europe";

                budget *= 0.9;
                restType = "Hotel";

            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{restType} - {budget:f2}");
        }
    }
}
