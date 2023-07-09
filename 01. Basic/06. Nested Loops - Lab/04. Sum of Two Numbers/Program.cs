using System;

namespace demo
{
    class combinations
    {
        static void Main(string[] args)
        {
            // variables
            int counter = 0;
            bool isFound = false;

            // read from console
            // first digit 1..999
            int x1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int magic = int.Parse(Console.ReadLine());

            for ( int a = x1; a <= x2; a++ )
            {
                for ( int b = x1; b <= x2; b++)
                {
                    counter++;
                    if (a + b == magic)
                    {
                        Console.WriteLine($"Combination N:{counter} ({a} + {b} = {magic})");
                        isFound = true;
                        break;
                    }
                }

                if (isFound) break;
            }
            if(!isFound) Console.WriteLine($"{counter} combinations - neither equals {magic}");
        }
    }
}