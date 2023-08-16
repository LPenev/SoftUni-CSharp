using System;
using System.Data.SqlTypes;

namespace tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            int tournamntWinner = 0;
            int tournamntLosser = 0;
            double sumMoney = 0;

            // read from console
            int numberDayOfTournament = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberDayOfTournament; i++)
            {
                // variables
                double sumDailyMoney = 0;
                int winCounter = 0;
                int lossCounter = 0;

                // read from console
                string input = Console.ReadLine();
                // one day tournament
                while (input != "Finish")
                {
                    string result = Console.ReadLine();

                    if (result == "win")
                    {
                        sumDailyMoney += 20;
                        winCounter++;
                    }
                    else
                    {
                        lossCounter++;
                    }
                    input = Console.ReadLine();
                }
                // check when day winner is, make bonus 10% for daily money 
                if (winCounter > lossCounter) 
                { 
                    sumDailyMoney *= 1.1;
                    tournamntWinner++;
                } else {
                    tournamntLosser++; 
                }
                sumMoney += sumDailyMoney;
            }
            
            if(tournamntWinner > tournamntLosser) 
            {
                sumMoney *= 1.2;
                Console.WriteLine($"You won the tournament! Total raised money: {sumMoney:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {sumMoney:f2}");
            }

        }
    }
}
