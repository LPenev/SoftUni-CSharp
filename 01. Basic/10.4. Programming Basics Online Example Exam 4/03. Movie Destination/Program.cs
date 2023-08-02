using System;

namespace movieDestinations
{
    class Program
    {
        static void Main(string[] args)
        {
            // read from console
            double budget = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            int numberDays = int.Parse(Console.ReadLine());
            double pricePerDay = 0;
            double sumMovies = 0;

            switch(destination)
            {
                case "Dubai":
                    if(season == "Winter") { pricePerDay = 45000; }
                    else { pricePerDay = 40000; }
                    sumMovies = (pricePerDay * numberDays) * 0.7;
                    break;
                case "Sofia":
                    if (season == "Winter") { pricePerDay = 17000; }
                    else { pricePerDay = 12500; }
                    sumMovies = (pricePerDay * numberDays) * 1.25;
                    break;
                case "London":
                    if (season == "Winter") { pricePerDay = 24000; }
                    else { pricePerDay = 20250; }
                    sumMovies = pricePerDay * numberDays;
                    break;
            }
            if( budget > sumMovies)
            {
                Console.WriteLine($"The budget for the movie is enough! We have {budget-sumMovies:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"The director needs {sumMovies-budget:f2} leva more!");
            }
        }
    }
}