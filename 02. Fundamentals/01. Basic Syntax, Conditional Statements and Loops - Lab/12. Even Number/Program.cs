using System;

namespace evenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n = int.Parse(Console.ReadLine());
                if (Math.Abs(n) % 2 == 0)
                {
                    Console.WriteLine("The number is: {0}",Math.Abs(n));
                    break;
                }
                else
                {
                    Console.WriteLine("Please write an even number.");
                }
            }
        }
    }
}