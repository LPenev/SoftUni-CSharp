namespace _07._Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input variables
            double budget = double.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int P = int.Parse(Console.ReadLine());

            // Calc
            double priceVideoCard = N * 250;
            double procesorPrice = M * (priceVideoCard * 0.35);
            double ramPrice = P * (priceVideoCard * 0.10);
            double sum = priceVideoCard + procesorPrice + ramPrice;

            // if VideoCard > Procesors
            if (N > M)
            {
                // discount 15%
                sum *= 0.85;
            }
            if (budget >= sum)
            {
                budget -= sum;
                Console.WriteLine($"You have {budget:f2} leva left!");
            }
            else
            {
                sum -= budget;
                Console.WriteLine($"Not enough money! You need {sum:f2} leva more!");
            }
        }
    }
}
