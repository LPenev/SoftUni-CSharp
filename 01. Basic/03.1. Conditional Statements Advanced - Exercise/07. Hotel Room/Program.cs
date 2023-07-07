namespace _07._Hotel_Room
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read from console
            string month = Console.ReadLine();
            int numberOfNights = int.Parse(Console.ReadLine());

            // init variables
            double sumStudio = 0;
            double sumApartment = 0;

            // calc
            if (month == "May" || month == "October")
            {
                sumStudio = numberOfNights * 50;
                sumApartment = numberOfNights * 65;

                // Studio more 14 nights 30% discount
                if (numberOfNights > 14)
                {
                    sumStudio *= 0.7;
                }
                // Studio more 7 nights 5% discount
                else if (numberOfNights > 7)
                {
                    sumStudio *= 0.95;
                }
            }
            else if (month == "June" || month == "September")
            {
                sumStudio = numberOfNights * 75.2;
                sumApartment = numberOfNights * 68.7;

                // Studio more 14 nights 20% discount
                if (numberOfNights > 14)
                {
                    sumStudio *= 0.8;
                }
            }
            else if (month == "July" || month == "August")
            {
                sumStudio = numberOfNights * 76;
                sumApartment = numberOfNights * 77;

            }

            // Apartment more 14 nights 10% discount
            if (numberOfNights > 14)
            {
                sumApartment *= 0.9;
            }

            // print result
            Console.WriteLine($"Apartment: {sumApartment:f2} lv.");
            Console.WriteLine($"Studio: {sumStudio:f2} lv.");
        }
    }
}
