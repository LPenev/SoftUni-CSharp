using System;

namespace sequence2k
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            int nextNumer = 1;
            // read from console
            int numer = int.Parse(Console.ReadLine());

            while (numer >= nextNumer)
            {
                Console.WriteLine(nextNumer);
                nextNumer = nextNumer * 2 + 1;
            }

        }
    }
}