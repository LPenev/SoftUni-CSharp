using System.Diagnostics;

namespace _01._Oscars_ceremony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal hallRent = decimal.Parse(Console.ReadLine());

            decimal priceOfStatuettes = hallRent * 0.7m;
            decimal priceOfCatering = priceOfStatuettes * 0.85m;
            decimal priceOfSounding = priceOfCatering * 0.5m;

            decimal totalPrice = hallRent + priceOfStatuettes + priceOfCatering + priceOfSounding;

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
