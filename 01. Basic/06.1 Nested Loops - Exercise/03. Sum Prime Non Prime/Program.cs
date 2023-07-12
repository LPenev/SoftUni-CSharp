using System;

namespace sumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            int sumPrime = 0;
            int sumNonPrime = 0;
            string input = Console.ReadLine();

            //
            while (input != "stop")
            {
                bool isPrime = true;
                int number = int.Parse(input);
                if (number >= 0)
                {
                    if (number < 2)
                    {
                        isPrime = false;
                    }
                    else
                    {
                        double sqrt = Math.Sqrt(number);
                        for (int i = 2; i <= sqrt; i++)
                        {
                            if (number % i == 0)
                            {
                                isPrime = false;
                                break;
                            }
                        }
                    }
                    if (isPrime) { sumPrime += number; }
                    else { sumNonPrime += number; }
                }
                else
                {
                    Console.WriteLine("Number is negative.");
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");
        }
    }
}