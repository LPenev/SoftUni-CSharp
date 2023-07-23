using System;

namespace giftFromSanta
{
    class Program
    {
        static void Main(string[] args)
        {
            // read from console
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());
            double addressNumber = 0;

            // calculations
            for (int i = m; i >= n; i--)
            {
                if(i%2 == 0)
                {
                    if(i%3 == 0)
                    {
                        if (i == s) break;

                        // print result
                        Console.Write(i + " ");
                    }
                }
            }
        }
    }
}