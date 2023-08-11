using System;

namespace newGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            int winnerPoints = 0;
            string winnerName = "";

            // read from console
            string nameOfPlayer = Console.ReadLine();

            // calculations
            while(nameOfPlayer != "Stop")
            {
                int sumPoints = 0;
                for (int i = 0; i < nameOfPlayer.Length; i++)
                {
                    // read points from console
                    int input = int.Parse(Console.ReadLine());
                    if ((int)nameOfPlayer[i] == input) 
                    { 
                        sumPoints += 10; 
                    } else { 
                        sumPoints += 2; 
                    }
                }
                if(sumPoints >= winnerPoints)
                {
                    winnerPoints = sumPoints;
                    winnerName = nameOfPlayer;
                }
                
                nameOfPlayer = Console.ReadLine();
            }

            // print result
            Console.WriteLine($"The winner is {winnerName} with {winnerPoints} points!");
        }
    }
}