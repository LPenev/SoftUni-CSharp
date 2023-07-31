using System;

namespace movieProfit
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfFilm = Console.ReadLine();
            int numberDays = int.Parse(Console.ReadLine());
            int numberTickets = int.Parse(Console.ReadLine());
            double priceOfTicket = double.Parse(Console.ReadLine());
            int procentForCinema = int.Parse(Console.ReadLine());

            double sumIncome = numberDays * numberTickets * priceOfTicket;
            double profit = sumIncome - sumIncome * procentForCinema / 100;

            Console.WriteLine($"The profit from the movie {nameOfFilm} is {profit:f2} lv.");

        }
    }
}