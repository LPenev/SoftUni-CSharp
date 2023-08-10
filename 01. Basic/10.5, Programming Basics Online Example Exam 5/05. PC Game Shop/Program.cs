using System;
using System.Runtime;

namespace pcGameShop
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            int counterHearthstone = 0;
            int counterFortnite = 0;
            int counterOverwatch = 0;
            int others = 0;
            int i;

            // read from console
            int numberGamesSold = int.Parse(Console.ReadLine());

            // calculation
            for( i = 0; i < numberGamesSold; i++)
            {
                string nameOfGame = Console.ReadLine();
                switch(nameOfGame)
                {
                    case "Hearthstone":
                        counterHearthstone++;
                        break;
                    case "Fornite":
                        counterFortnite++;
                        break;
                    case "Overwatch":
                        counterOverwatch++;
                        break;
                    default:
                        others++;
                        break;
                }

            }

            // print result
            Console.WriteLine($"Hearthstone - {(double)counterHearthstone / i * 100:f2}%");
            Console.WriteLine($"Fornite - {(double)counterFortnite / i * 100:f2}%");
            Console.WriteLine($"Overwatch - {(double)counterOverwatch / i * 100:f2}%");
            Console.WriteLine($"Others - {(double)others / i * 100:f2}%");
        }
    }
}