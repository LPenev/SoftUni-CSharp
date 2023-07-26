namespace _03._Easter_Trip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read inputs from console 
            string destination = Console.ReadLine().Trim();
            string dateOfReservation = Console.ReadLine().Trim();
            int numberOfNights = int.Parse(Console.ReadLine());

            // calcs
            double priceOfNight = 0;

            switch (destination)
            {
                case "France":
                    switch (dateOfReservation)
                    {
                        case "21-23":
                            priceOfNight = 30;
                            break;
                        case "24-27":
                            priceOfNight = 35;
                            break;
                        case "28-31":
                            priceOfNight = 40;
                            break;
                    }
                    break;

                case "Italy":
                    switch (dateOfReservation)
                    {
                        case "21-23":
                            priceOfNight = 28;
                            break;
                        case "24-27":
                            priceOfNight = 32;
                            break;
                        case "28-31":
                            priceOfNight = 39;
                            break;
                    }
                    break;

                case "Germany":
                    switch (dateOfReservation)
                    {
                        case "21-23":
                            priceOfNight = 32;
                            break;
                        case "24-27":
                            priceOfNight = 37;
                            break;
                        case "28-31":
                            priceOfNight = 43;
                            break;
                    }
                    break;
            }

            double sum = priceOfNight * numberOfNights;

            // print result
            Console.WriteLine($"Easter trip to {destination} : {sum:f2} leva.");
        }
    }
}
