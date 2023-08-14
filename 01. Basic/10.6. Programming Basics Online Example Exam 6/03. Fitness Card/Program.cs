using System;

namespace birhdayParty
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            double price = 0;

            // read from console
            double sumWeHave = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();

            // calc
            switch (sport)
            {
                case "Gym":
                    if(gender == "m") { price = 42 ; } 
                    else { price = 35; }
                    break;
                case "Boxing":
                    if (gender == "m") { price = 41; }
                    else { price = 37; }
                    break;
                case "Yoga":
                    if (gender == "m") { price = 45; }
                    else { price = 42; }
                    break;
                case "Zumba":
                    if (gender == "m") { price = 34; }
                    else { price = 31; }
                    break;
                case "Dances":
                    if (gender == "m") { price = 51; }
                    else { price = 53; }
                    break;
                case "Pilates":
                    if (gender == "m") { price = 39; }
                    else { price = 37; }
                    break;
            }

            if(age <= 19) { price *= 0.8; }

            // print result
            if(price > sumWeHave)
            {
                Console.WriteLine($"You don't have enough money! You need ${price - sumWeHave:f2} more.");
            }
            else 
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
        }
    }
}