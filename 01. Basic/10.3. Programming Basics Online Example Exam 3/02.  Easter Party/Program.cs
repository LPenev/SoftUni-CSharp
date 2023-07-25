namespace _02.__Easter_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read inputs 
            int numberOfGuests = int.Parse(Console.ReadLine());
            double priceOfEnvelopeForPerson = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            // calcs

            if (numberOfGuests >= 10 && numberOfGuests <= 15)
            {
                priceOfEnvelopeForPerson *= 0.85;
            }
            else if (numberOfGuests <= 20 && numberOfGuests > 10)
            {
                priceOfEnvelopeForPerson *= 0.8;
            }
            else if (numberOfGuests > 20)
            {
                priceOfEnvelopeForPerson *= 0.75;
            }

            double sum = numberOfGuests * priceOfEnvelopeForPerson + budget * 0.1;

            if (sum > budget)
            {
                Console.WriteLine($"No party! {sum - budget:f2} leva needed.");
            }
            else
            {
                Console.WriteLine($"It is party time! {budget - sum:f2} leva left.");
            }
        }
    }
}
