namespace _03._Oscars_week_in_cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read from Console
            string nameOfFilm = Console.ReadLine().Trim();
            string typeOfHall = Console.ReadLine().Trim();
            int NumberOfTickets = int.Parse(Console.ReadLine());

            // price of Ticket
            decimal priceOfTicket = 0m;

            switch (nameOfFilm)
            {
                case "A Star Is Born":
                    switch (typeOfHall)
                    {
                        case "normal":
                            priceOfTicket = 7.5m;
                            break;

                        case "luxury":
                            priceOfTicket = 10.5m;
                            break;

                        case "ultra luxury":
                            priceOfTicket = 13.5m;
                            break;
                    }
                    break;

                case "Bohemian Rhapsody":
                    switch (typeOfHall)
                    {
                        case "normal":
                            priceOfTicket = 7.35m;
                            break;

                        case "luxury":
                            priceOfTicket = 9.45m;
                            break;

                        case "ultra luxury":
                            priceOfTicket = 12.75m;
                            break;
                    }
                    break;

                case "Green Book":
                    switch (typeOfHall)
                    {
                        case "normal":
                            priceOfTicket = 8.15m;
                            break;

                        case "luxury":
                            priceOfTicket = 10.25m;
                            break;

                        case "ultra luxury":
                            priceOfTicket = 13.25m;
                            break;
                    }
                    break;

                case "The Favourite":
                    switch (typeOfHall)
                    {
                        case "normal":
                            priceOfTicket = 8.75m;
                            break;

                        case "luxury":
                            priceOfTicket = 11.55m;
                            break;

                        case "ultra luxury":
                            priceOfTicket = 13.95m;
                            break;
                    }
                    break;
            }
            // end price of ticket

            // calculations
            decimal sum = priceOfTicket * NumberOfTickets;

            // print result
            Console.WriteLine($"{nameOfFilm} -> {sum:f2} lv.");
        }
    }
}
