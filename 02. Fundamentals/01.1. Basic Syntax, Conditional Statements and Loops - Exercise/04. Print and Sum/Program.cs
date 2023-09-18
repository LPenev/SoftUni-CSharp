using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // read from console
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int sum = 0;

            // calculation
            for (int i = start; i <= end; i++)
            {
                Console.Write($"{i} ");
                sum += i;
            }
            Console.WriteLine("");
            Console.WriteLine($"Sum: {sum}");
        }
    }
}