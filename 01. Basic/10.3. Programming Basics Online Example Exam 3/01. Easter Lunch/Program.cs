namespace _01._Easter_Lunch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // init constants 
            const double PriceKozunak = 3.20;
            const double PriceEggsCrustFrom12Eggs = 4.35;
            const double PriceCookiesPerKilogram = 5.40;
            const double PriceDyeForEggsPerEgg = 0.15;

            // read user inputs from console
            int numberOfKuzunaks = int.Parse(Console.ReadLine());
            int numberOfEggshells = int.Parse(Console.ReadLine());
            int kilogramsOfCookies = int.Parse(Console.ReadLine());

            //
            double sum = PriceKozunak * numberOfKuzunaks;
            sum += PriceEggsCrustFrom12Eggs * numberOfEggshells;
            sum += PriceDyeForEggsPerEgg * numberOfEggshells * 12;
            sum += PriceCookiesPerKilogram * kilogramsOfCookies;

            // print result
            Console.WriteLine($"{sum:f2}");
        }
    }
}
