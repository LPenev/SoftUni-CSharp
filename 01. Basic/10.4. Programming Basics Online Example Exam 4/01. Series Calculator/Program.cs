using System;

namespace serieCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameSerial = Console.ReadLine();
            int numberSeasons = int.Parse(Console.ReadLine());
            int numberEpisodes = int.Parse(Console.ReadLine());
            double timeOfEpisode = double.Parse(Console.ReadLine());
            double totalDuration = 0;
            double realTimeOfEpisodesWithAdv = timeOfEpisode * 1.2;

            totalDuration = realTimeOfEpisodesWithAdv * numberEpisodes * numberSeasons + numberSeasons * 10;
            
            Console.WriteLine($"Total time needed to watch the {nameSerial} series is {totalDuration:f0} minutes.");
        }
    }
}