using System;

namespace Histograma
{
    class Program
    {
        static void Main(string[] args)
        {
            // read from console
            int n = int.Parse(Console.ReadLine());
            int digit, p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0;

            for(int i = 1; i <= n; i++)
            {
                digit = int.Parse(Console.ReadLine());

                if(digit < 200)
                {
                    p1++;
                }
                else if(digit < 400)
                {
                    p2++;
                }
                else if(digit < 600)
                {
                    p3++;
                }
                else if (digit < 800)
                {
                    p4++;
                }
                else
                {
                    p5++;
                }
            }

            // calc result
            Console.WriteLine($"{(double)p1 / n * 100:f2}%");
            Console.WriteLine($"{(double)p2 / n * 100:f2}%");
            Console.WriteLine($"{(double)p3 / n * 100:f2}%");
            Console.WriteLine($"{(double)p4 / n * 100:f2}%");
            Console.WriteLine($"{(double)p5 / n * 100:f2}%");
        }
    }
}