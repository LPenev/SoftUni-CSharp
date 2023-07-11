using System;

namespace equalSumsEvenOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            int sumOdd = 0, sumEven = 0;
            // read from console
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            // for loop all number between first und second
            for ( int i = first ; i <= second ; i++ )
            {
                string current = i.ToString();

                // for loop all digits of current number
                for ( int j = 0 ; j < current.Length ; j++)
                {
                    int digit = int.Parse( current[j].ToString() );

                    // check current digit is Even or Odd
                    if( j%2 == 0)
                    {
                        sumEven += digit;
                    }
                    else
                    {
                        sumOdd += digit;
                    }
                }

                if ( sumEven == sumOdd)
                {
                    Console.Write(i + " ");
                }

                sumEven = 0;
                sumOdd = 0;
            }
        }
    }
}