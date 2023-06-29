using System;

namespace CleverLily
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            int toysCounter = 0;
            int sum = 0;
            int birthdayEvenCounter = 0;
            // read from console
            int age = int.Parse(Console.ReadLine());
            double priceWashingMashine = double.Parse(Console.ReadLine());
            int pricePerToy = int.Parse(Console.ReadLine());

            //
            for( int i = 1; i <= age; i++ )
            {
                // if Age is even or odd
                if( i%2 == 0)
                {
                    birthdayEvenCounter++;
                    sum += birthdayEvenCounter * 10 - 1;
                }
                else
                {
                    toysCounter++;
                }
            }
            // calc sum of toys
            sum = sum + ( toysCounter * pricePerToy);

            // print result
            if(sum >= priceWashingMashine)
            {
                Console.WriteLine($"Yes! {sum-priceWashingMashine:f2}");
            }
            else
            {
                Console.WriteLine($"No! {priceWashingMashine-sum:f2}");
            }

        }
    }
}