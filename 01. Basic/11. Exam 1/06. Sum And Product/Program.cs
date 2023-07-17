using System;

namespace sumAndProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            bool isFound = false;
            // read from console
            int n = int.Parse(Console.ReadLine());

            // calclations
            for(int a = 1; a <= 9; a++)
            {
                if ( isFound ) break;

                for (int b = 9; b >= a; b--)
                {
                    if ( isFound ) break;

                    for (int c = 0 ; c <= 9; c++)
                    {
                        if ( isFound ) break;

                        for(int d = 9; d >= c; d--)
                        {
                            int sumMultiplication = a * b * c * d;
                            int sumCollecting = a + b + c + d;
                            
                            if(sumMultiplication == sumCollecting && n%10 == 5)
                            {
                                // print result
                                Console.WriteLine($"{a}{b}{c}{d}");
                                isFound = true;
                                break;
                            }

                            if (sumMultiplication / sumCollecting == 3 && n%3 == 0)
                            {
                                // print result
                                Console.WriteLine($"{d}{c}{b}{a}");
                                isFound = true;
                                break;
                            }
                        }
                    }
                }
            }

            // print result
            if( !isFound ) Console.WriteLine("Nothing found");
        }
    }
}