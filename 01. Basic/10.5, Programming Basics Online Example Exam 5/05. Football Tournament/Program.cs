using System;
using System.Numerics;
using System.Runtime;
using System.Text.RegularExpressions;

namespace footballTournament
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            int counterW = 0;
            int counterD = 0;
            int counterL = 0;
            int sumPoints = 0;

            // read from console
            string footballTeamName = Console.ReadLine();
            int numberOfMatchesPlayed = int.Parse(Console.ReadLine());

            // calculation
            for(int i = 0; i < numberOfMatchesPlayed; i++)
            {
                string resultOfMatchPlayed = Console.ReadLine();
                switch(resultOfMatchPlayed)
                {
                    case "W":
                        counterW++;
                        sumPoints += 3;
                        break;
                    case "D":
                        counterD++;
                        sumPoints += 1;
                        break;
                    case "L":
                        counterL++;
                        break;
                }
            }
            double percentWinGames = (double)counterW / numberOfMatchesPlayed * 100;
            // print result
            if(numberOfMatchesPlayed > 0) 
            {
                Console.WriteLine($"{footballTeamName} has won {sumPoints} points during this season.");
                Console.WriteLine("Total stats:");
                Console.WriteLine($"## W: {counterW}");
                Console.WriteLine($"## D: {counterD}");
                Console.WriteLine($"## L: {counterL}");
                Console.WriteLine($"Win rate: {percentWinGames:f2}%");
            }
            else
            {
                Console.WriteLine($"{footballTeamName} hasn't played any games during this season.");
            }

        }
    }
}