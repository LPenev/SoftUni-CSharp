using System;

namespace filmPremiere
{
    class Program
    {
        static void Main(string[] args)
        {
            // read from console
            string nameOfFilm = Console.ReadLine();
            string packet = Console.ReadLine();
            int numberTickets = int.Parse(Console.ReadLine());
            double priceTicket =0;

            // calc
            switch (nameOfFilm)
            {
                case "John Wick":
                    if(packet == "Drink")
                    {
                        priceTicket = 12;
                    }
                    else if(packet == "Popcorn")
                    {
                        priceTicket = 15;
                    }
                    else if(packet == "Menu")
                    {
                        priceTicket = 19;
                    }
                    break;
                case "Star Wars":
                    if (packet == "Drink")
                    {
                        priceTicket = 18;
                    }
                    else if (packet == "Popcorn")
                    {
                        priceTicket = 25;
                    }
                    else if (packet == "Menu")
                    {
                        priceTicket = 30;
                    }

                    if(numberTickets >= 4) { priceTicket *= 0.7; }
                    
                    break;

                case "Jumanji":
                    if (packet == "Drink")
                    {
                        priceTicket = 9;
                    }
                    else if (packet == "Popcorn")
                    {
                        priceTicket = 11;
                    }
                    else if (packet == "Menu")
                    {
                        priceTicket = 14;
                    }

                    if ( numberTickets == 2) { priceTicket *= 0.85; }

                    break;
            }
            double totalSum = priceTicket * numberTickets;
            Console.WriteLine($"Your bill is {totalSum:f2} leva.");
        }
    }
}