using System;
using System.Diagnostics.CodeAnalysis;

namespace sumOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                int Odd = i * 2 - 1;
                Console.WriteLine("{0}",Odd);
                sum += Odd;
            }
            Console.WriteLine("Sum: {0}", sum);
        }
    }
}