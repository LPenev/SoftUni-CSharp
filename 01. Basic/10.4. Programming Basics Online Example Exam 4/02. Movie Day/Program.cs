using System;

namespace movieDay
{
    class Program
    {
        static void Main(string[] args)
        {
            int timeForMovies = int.Parse(Console.ReadLine());
            int numberScene = int.Parse(Console.ReadLine());
            int timePerScene = int.Parse(Console.ReadLine());

            double sumTime = timeForMovies * 0.15;
            double sumScene = numberScene * timePerScene;
            double total = sumTime + sumScene;

            if ( total < timeForMovies ) 
            {
                double leftTime = timeForMovies - total;
                Console.WriteLine($"You managed to finish the movie on time! You have {leftTime:f0} minutes left!");
            }
            else
            {
                double leftTime = total - timeForMovies;
                Console.WriteLine($"Time is up! To complete the movie you need {leftTime:f0} minutes.");
            }
        }
    }
}