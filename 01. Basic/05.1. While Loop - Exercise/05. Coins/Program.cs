using System;

namespace coins
{
    class Program
    {
        static void Main(string[] args)
        {
            int coinsCounter = 0;
            decimal money = decimal.Parse(Console.ReadLine());

            while ( money > 0 )
            {
                if( money >= 2 )
                {
                    money -= 2;
                }
                else if( money >= 1 )
                {
                    money -= 1;
                }
                else if( money >= 0.5m )
                {
                    money -= 0.5m;
                }
                else if ( money >= 0.2m )
                {
                    money -= 0.2m;
                }
                else if ( money >= 0.1m )
                {
                    money -= 0.1m;
                }
                else if ( money >= 0.05m )
                {
                    money -= 0.05m;
                }
                else if ( money >= 0.02m )
                {
                    money -= 0.02m;
                }
                else if ( money >= 0.01m )
                {
                    money -= 0.01m;
                }

                coinsCounter++;
            }
            Console.WriteLine(coinsCounter);
        }
    }
}