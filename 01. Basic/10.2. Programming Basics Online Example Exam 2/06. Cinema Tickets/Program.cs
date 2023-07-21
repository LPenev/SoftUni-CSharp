using System.Runtime.CompilerServices;

namespace _06._Cinema_Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // init vars
            int studentTicket = 0;
            int standartTicket = 0;
            int kidsTicket = 0;

            while (true)
            {
                string nameOfMovie = Console.ReadLine().Trim();
                if (nameOfMovie == "Finish")
                {
                    break;
                }

                int availableSeats = int.Parse(Console.ReadLine());
                int ticketCounter = 0;

                for (int i = 0; i < availableSeats; i++)
                {
                    string input = Console.ReadLine().Trim();
                    if (input == "End")
                    {
                        break;
                    }


                    switch (input)
                    {
                        case "student":
                            studentTicket++;
                            ticketCounter++;
                            break;

                        case "standard":
                            standartTicket++;
                            ticketCounter++;
                            break;

                        case "kid":
                            kidsTicket++;
                            ticketCounter++;
                            break;
                    }
                }

                double avgSeats = ((double)ticketCounter / availableSeats) * 100;

                // print statistic for every Movie
                Console.WriteLine($"{nameOfMovie} - {avgSeats:f2}% full.");
                ticketCounter = 0;
            }

            // print result
            int totalTicket = studentTicket + standartTicket + kidsTicket;
            Console.WriteLine($"Total tickets: {totalTicket}");
            Console.WriteLine($"{((double)studentTicket / totalTicket) * 100:f2}% student tickets.");
            Console.WriteLine($"{((double)standartTicket / totalTicket) * 100:f2}% standard tickets.");
            Console.WriteLine($"{((double)kidsTicket / totalTicket) * 100:f2}% kids tickets.");
        }
    }
}
