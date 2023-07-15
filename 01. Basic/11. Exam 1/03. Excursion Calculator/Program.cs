using System;

namespace excursionCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            double sum = 0;
            // read from console
            int numberOfPeople = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            // calclations
            switch (season)
            {
                case "spring":
                    if( numberOfPeople <=5)
                    {
                        sum = numberOfPeople * 50;
                    }
                    else
                    {
                        sum = numberOfPeople * 48;
                    }
                    break;
                case "summer":
                    if (numberOfPeople <= 5)
                    {
                        sum = numberOfPeople * 48.5;
                    }
                    else
                    {
                        sum = numberOfPeople * 45;
                    }
                    // discount
                    sum *= 0.85;
                    break;
                case "autumn":
                    if (numberOfPeople <= 5)
                    {
                        sum = numberOfPeople * 60;
                    }
                    else
                    {
                        sum = numberOfPeople * 49.5;
                    }
                    break;
                case "winter":
                    if (numberOfPeople <= 5)
                    {
                        sum = numberOfPeople * 86;
                    }
                    else
                    {
                        sum = numberOfPeople * 85;
                    }
                    // price increase
                    sum *= 1.08;
                    break;
            }


            // print result
            Console.WriteLine($"{sum:f2} leva.");
        }
    }
}