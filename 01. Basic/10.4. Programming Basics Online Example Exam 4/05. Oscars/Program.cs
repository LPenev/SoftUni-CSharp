using System;

namespace oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            string nameOfEvaluators;
            double pointsOfEvaluators = 0;
            double sumOfPoints = 0;
            // read from console
            string nameOfActior = Console.ReadLine();
            double pointsFromAcademy = double.Parse(Console.ReadLine());
            int numberOfEvaluators = int.Parse(Console.ReadLine());
            sumOfPoints += pointsFromAcademy;

            for(int i = 0; i < numberOfEvaluators; i++)
            {
                nameOfEvaluators = Console.ReadLine();
                pointsOfEvaluators = double.Parse(Console.ReadLine());
                sumOfPoints += nameOfEvaluators.Length * pointsOfEvaluators / 2;

               if(sumOfPoints >= 1250.5) { break; }
            }

            if(sumOfPoints >= 1250.5)
            {
                Console.WriteLine($"Congratulations, {nameOfActior} got a nominee for leading role with {sumOfPoints:f1}!");
            }
            else
            {
                Console.WriteLine($"Sorry, {nameOfActior} you need {1250.5-sumOfPoints:f1} more!");
            }
        }
    }
}