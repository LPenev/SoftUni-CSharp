using System;

namespace Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            double points = 0;
            // read from console
            string nameActior = Console.ReadLine();
            double pointAkademy = double.Parse(Console.ReadLine());
            int countEvaluative = int.Parse(Console.ReadLine());
            points += pointAkademy;
            
            for (int i = 0; i < countEvaluative && points < 1250.5; i++)
            {
                string nameEvaluative = Console.ReadLine();
                double pointEvaluative = double.Parse(Console.ReadLine());
                points = points + pointEvaluative * nameEvaluative.Length / 2;
            }
            // print result
            if (points > 1250.5)
            {
                Console.WriteLine($"Congratulations, {nameActior} got a nominee for leading role with {points:f1}!");
            }
            else
            {
                Console.WriteLine($"Sorry, {nameActior} you need {1250.5-points:f1} more!");
            }

        }
    }
}