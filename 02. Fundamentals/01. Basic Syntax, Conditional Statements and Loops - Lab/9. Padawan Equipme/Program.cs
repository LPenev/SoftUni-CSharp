using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {

            // read from console
            float amountOfMoney = float.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double priceSabers = double.Parse(Console.ReadLine());
            float priceRobes = float.Parse(Console.ReadLine());
            float priceBelts = float.Parse(Console.ReadLine());

            // calculations
            double sumSarbes = priceSabers * Math.Ceiling(countOfStudents * 1.1);
            double sumRobes = priceRobes * countOfStudents;

            double freeBelts = Math.Floor((double)countOfStudents / 6);
            double sumBelts = priceBelts * (countOfStudents - freeBelts);
            double sum = sumSarbes + sumRobes + sumBelts;

            if (sum <= amountOfMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {sum:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {sum - amountOfMoney:f2}lv more.");
            }
        }
    }
}