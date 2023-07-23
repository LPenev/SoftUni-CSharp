using System;

namespace christmasGifts
{
    class Program
    {
        static void Main(string[] args)
        {
            int kids = 0;
            int adults = 0;
            // read from console
            string input = Console.ReadLine();

            while (input != "Christmas")
            {
                int age = int.Parse(input);
                if(age <= 16)
                {
                    kids++;
                }
                else
                {
                    adults++;
                }

                // read from console
                input = Console.ReadLine();
            }

            Console.WriteLine($"Number of adults: {adults}");
            Console.WriteLine($"Number of kids: {kids}");
            Console.WriteLine($"Money for toys: {kids*5}");
            Console.WriteLine($"Money for sweaters: {adults*15}");
        }
    }
}