using System;

namespace tenisRanklist
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            string typeTournament;
            int sumPoints = 0;
            double win = 0;
            // read from console
            int countTournament = int.Parse(Console.ReadLine());
            int startNumberPoints = int.Parse(Console.ReadLine());
            sumPoints += startNumberPoints;

            for (int i = 0; i < countTournament; i++)
            {
                typeTournament = Console.ReadLine();
                switch (typeTournament)
                {
                    case "W":
                        sumPoints += 2000;
                        win++;
                        break;
                    case "F":
                        sumPoints += 1200;
                        break;
                    case "SF":
                        sumPoints += 720;
                        break;

                }
            }
            // print results
            Console.WriteLine($"Final points: {sumPoints}");
            Console.WriteLine($"Average points: {(sumPoints-startNumberPoints)/countTournament:f0}");
            Console.WriteLine($"{(win/countTournament)*100:f2}%");
            
        }
    }
}