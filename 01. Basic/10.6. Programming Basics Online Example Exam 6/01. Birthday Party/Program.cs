using System;

namespace birthdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            double renteHall = double.Parse(Console.ReadLine());
            // calc
            double torte = renteHall * 0.2;
            double drinks = torte * 0.55;
            double animaor = renteHall / 3;
            double sum = renteHall + torte + drinks + animaor;

            Console.WriteLine($"{sum:f2}");
        }
    }
}