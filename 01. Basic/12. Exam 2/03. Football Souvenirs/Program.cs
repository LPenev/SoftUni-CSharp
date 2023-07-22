using System;

namespace footballSouvenirs
{
    class Program
    {
        static void Main(string[] args)
        {
            // read from console
            string team = Console.ReadLine();
            string kindOfSouvenirs = Console.ReadLine();
            int numberSouvPurchased = int.Parse(Console.ReadLine());
            double sum = 0;
            bool isInvalid = false;

            // calculations
            switch (team)
            {
                case "Argentina":
                    if (kindOfSouvenirs == "flags") { sum = numberSouvPurchased * 3.25; }
                    else if (kindOfSouvenirs == "caps") { sum = numberSouvPurchased * 7.2; }
                    else if (kindOfSouvenirs == "posters") { sum = numberSouvPurchased * 5.1; }
                    else if (kindOfSouvenirs == "stickers") { sum = numberSouvPurchased * 1.25; }
                    else { Console.WriteLine("Invalid stock!"); isInvalid = true; }
                    break;

                case "Brazil":
                    if(kindOfSouvenirs == "flags") { sum = numberSouvPurchased * 4.2; }
                    else if (kindOfSouvenirs == "caps") { sum = numberSouvPurchased * 8.5; }
                    else if (kindOfSouvenirs == "posters") { sum = numberSouvPurchased * 5.35; }
                    else if (kindOfSouvenirs == "stickers") { sum = numberSouvPurchased * 1.20; }
                    else { Console.WriteLine("Invalid stock!"); isInvalid = true; }
                    break;

                case "Croatia":
                    if(kindOfSouvenirs == "flags") { sum = numberSouvPurchased * 2.75; }
                    else if (kindOfSouvenirs == "caps") { sum = numberSouvPurchased * 6.9; }
                    else if (kindOfSouvenirs == "posters") { sum = numberSouvPurchased * 4.95; }
                    else if (kindOfSouvenirs == "stickers") { sum = numberSouvPurchased * 1.1; }
                    else { Console.WriteLine("Invalid stock!"); isInvalid = true; }
                    break;

                case "Denmark":
                    if(kindOfSouvenirs == "flags") { sum = numberSouvPurchased * 3.1; }
                    else if (kindOfSouvenirs == "caps") { sum = numberSouvPurchased * 6.5; }
                    else if (kindOfSouvenirs == "posters") { sum = numberSouvPurchased * 4.8; }
                    else if (kindOfSouvenirs == "stickers") { sum = numberSouvPurchased * 0.9; }
                    else { Console.WriteLine("Invalid stock!"); isInvalid = true; }
                    break;

                default:
                    Console.WriteLine("Invalid country!");
                    isInvalid = true;
                    break;
            }

            // print result
            if (!isInvalid)
            {
                Console.WriteLine($"Pepi bought {numberSouvPurchased} {kindOfSouvenirs} of {team} for {sum:f2} lv.");
            }

        }
    }
}