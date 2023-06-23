namespace _09._Ski_Trip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read from console
            int daysStays = int.Parse(Console.ReadLine());
            string typeOfRooms = Console.ReadLine();
            string vote = Console.ReadLine();
            double sum = 0;
            int priceRoom = 18;
            int priceApartment = 25;
            int pricePresidentApartment = 35;

            // Calculate
            int nights = daysStays - 1;
            switch (typeOfRooms)
            {
                case "room for one person":
                    sum = priceRoom * nights;
                    break;
                case "apartment":
                    if (daysStays < 10)
                    {
                        sum = (priceApartment * nights) * 0.7;
                    }
                    else
                        if (daysStays < 15)
                    {
                        sum = (priceApartment * nights) * 0.65;
                    }
                    else
                    {
                        sum = (priceApartment * nights) * 0.5;

                    }
                    break;
                case "president apartment":
                    if (daysStays < 10)
                    {
                        sum = (pricePresidentApartment * nights) * 0.9;
                    }
                    else if (daysStays < 15)
                    {
                        sum = (pricePresidentApartment * nights) * 0.85;
                    }
                    else
                    {
                        sum = (pricePresidentApartment * nights) * 0.8;
                    }
                    break;
            }
            // vote discount
            // positive vote
            if (vote == "positive")
            {
                sum *= 1.25;
            }
            // negative vote
            else
            {
                sum *= 0.9;
            }
            // print result
            Console.WriteLine($"{sum:f2}");
        }
    }
}
