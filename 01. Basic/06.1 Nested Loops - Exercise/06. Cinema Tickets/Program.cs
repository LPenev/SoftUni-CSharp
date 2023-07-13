using System;
using System.Transactions;

namespace cinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            // global variables
            double sumTicketsStudets = 0;
            double sumTicketsStandart = 0;
            double sumTicketsKids = 0;
            
            // read from console name of film
            string filmName = Console.ReadLine();

            while (filmName != "Finish")
            {
                // variables for current loop
                int ticketsStudets = 0;
                int ticketsStandart = 0;
                int ticketsKids = 0;
                // input freeSeats for current film
                int freeSeats = int.Parse(Console.ReadLine());
                for (int i = 0; i < freeSeats; i++)
                {
                    string typeOfTicket = Console.ReadLine();
                    if (typeOfTicket == "End") { break; }

                    // select type of ticket
                    if(typeOfTicket == "student")
                    {
                        ticketsStudets++;
                    }
                    else if(typeOfTicket == "standard")
                    {
                        ticketsStandart++;
                    }else if(typeOfTicket == "kid")
                    {
                        ticketsKids++;
                    }
                }
                // calc sums pro type of ticket
                sumTicketsStudets += ticketsStudets;
                sumTicketsStandart += ticketsStandart;
                sumTicketsKids += ticketsKids;
                // calc procent of full for current film
                double sumTicketCurrent = ticketsStudets + ticketsStandart + ticketsKids;
                double procentFull = (sumTicketCurrent / freeSeats) * 100;
                // print result for current film
                Console.WriteLine($"{filmName} - {procentFull:f2}% full.");
                // input name of film or Finish for end
                filmName = Console.ReadLine();
            }
            // sum all tickets for all movies
            double allTickets = sumTicketsStudets + sumTicketsStandart + sumTicketsKids;
            // print total result
            Console.WriteLine($"Total tickets: {allTickets}");
            Console.WriteLine($"{(sumTicketsStudets / allTickets) * 100:f2}% student tickets.");
            Console.WriteLine($"{(sumTicketsStandart / allTickets) * 100:f2}% standard tickets.");
            Console.WriteLine($"{(sumTicketsKids / allTickets) * 100:f2}% kids tickets.");
        }
    }
}