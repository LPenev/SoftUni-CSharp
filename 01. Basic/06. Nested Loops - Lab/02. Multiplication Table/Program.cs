using System;

namespace travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int d = 1; d <= 10; d++)
            {
                for(int m  = 1; m <= 10; m++)
                {
                    Console.WriteLine($"{d} * {m} = {d*m}");
                }
            }

        }
    }
}