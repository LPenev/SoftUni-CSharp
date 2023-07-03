using System;

namespace accountBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            // valriables
            double sum = 0;
            double currentMoney = 0;

            string input = Console.ReadLine();

            while (input != "NoMoreMoney")
            {
                currentMoney = double.Parse(input);
                if(currentMoney < 0 ) 
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                sum += currentMoney;
                Console.WriteLine($"Increase: {currentMoney:f2}");

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}