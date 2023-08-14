using System;

namespace energyBooster
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            // set 2 packs
            double WatermelonSmall = 56 *2;
            double MangoSmall = 36.66 * 2;
            double PineappleSmall = 42.1 * 2;
            double RaspberrySmall = 20 * 2;
            // set 5 packs
            double WatermelonBig = 28.7 * 5;
            double MangoBig = 19.6 * 5;
            double PineappleBig = 24.8 * 5;
            double RaspberryBig = 15.2 * 5;
            double sum = 0;

            // read from console
            string fruit = Console.ReadLine();
            string sizeSet = Console.ReadLine();
            int numberOrderedSets = int.Parse(Console.ReadLine());

            // calc
            switch (fruit)
            {
                case "Watermelon":
                    if (sizeSet == "small") { sum = numberOrderedSets * WatermelonSmall; } 
                    else { sum = numberOrderedSets * WatermelonBig; }
                    break;
                case "Mango":
                    if (sizeSet == "small") { sum = numberOrderedSets * MangoSmall; } 
                    else { sum = numberOrderedSets * MangoBig; }

                    break;
                case "Pineapple":
                    if (sizeSet == "small") { sum = numberOrderedSets * PineappleSmall; } 
                    else { sum = numberOrderedSets * PineappleBig; }

                    break;
                case "Raspberry":
                    if ( sizeSet == "small") { sum = numberOrderedSets * RaspberrySmall; } 
                    else { sum = numberOrderedSets * RaspberryBig; }
                    break;
            }
            // check for discount
            if ( sum >= 400 && sum <= 1000)
            {
                // discount 15%
                sum *= 0.85;
            }else if ( sum > 1000)
            {
                // discount 50%
                sum *= 0.5;
            }

            // print result
            Console.WriteLine($"{sum:f2} lv.");
        }
    }
}