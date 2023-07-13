using System;

namespace trainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            double sumGrade = 0;
            double sumAllGrade = 0;
            int counter = 0;
            int numberOfJuri = int.Parse(Console.ReadLine());
            string nameOfPresentation = Console.ReadLine();

            while (nameOfPresentation != "Finish")
            {
                for(int i = 0; i < numberOfJuri; i++)
                {
                    sumGrade += double.Parse(Console.ReadLine());
                    counter++;
                }

                Console.WriteLine($"{nameOfPresentation} - {sumGrade / numberOfJuri:f2}.");
                sumAllGrade += sumGrade;
                sumGrade = 0;

                nameOfPresentation = Console.ReadLine();
            }
            double avGrade = sumAllGrade / counter;
            Console.WriteLine($"Student's final assessment is {avGrade:f2}.");
        }
    }
}