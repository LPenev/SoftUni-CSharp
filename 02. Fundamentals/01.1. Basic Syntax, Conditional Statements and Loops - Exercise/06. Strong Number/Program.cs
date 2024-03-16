using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int workNumber = number;
            int sum = 0;

            while (workNumber > 0)
            {
                int factoriel = 1;
                int digit = workNumber % 10;
                workNumber /= 10;

                for(int i = 1; i <= digit; i++)
                {
                    factoriel *= i;
                }
                sum += factoriel;
            }

            if (sum == number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}