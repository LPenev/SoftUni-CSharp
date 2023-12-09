using System;

namespace sortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            double n3 = double.Parse(Console.ReadLine());

            double swap = 0;

            while ( n1 < n2 || n3 > n2 || n2 > n1)
            {
                if (n3 > n1)
                {
                    swap = n1;
                    n1 = n3;
                    n3 = swap;
                }

                if (n2 > n1)
                {
                    swap = n1;
                    n1 = n2;
                    n2 = swap;
                }

                if (n3 > n2)
                {
                    swap = n2;
                    n2 = n3;
                    n3 = swap;
                }
            }
            Console.WriteLine(n1);
            Console.WriteLine(n2);
            Console.WriteLine(n3);
        }
    }
}