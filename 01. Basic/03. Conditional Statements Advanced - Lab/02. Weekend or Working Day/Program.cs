﻿namespace _02._Weekend_or_Working_Day
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read day from Cosole
            string day = Console.ReadLine();
            // switch menu
            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    Console.WriteLine("Working day");
                    break;
                case "Saturday":
                case "Sunday":
                    Console.WriteLine("Weekend");
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}
