using System.Runtime.ConstrainedExecution;

namespace _01._Easter_Bakery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read inputs
            double priceOfFlourPerKilogram = double.Parse(Console.ReadLine());
            double kilogramsOfFlour = double.Parse(Console.ReadLine());
            double kilogramsOfSugar = double.Parse(Console.ReadLine());
            int numberOfEggshells = int.Parse(Console.ReadLine());
            int yeastPackages = int.Parse(Console.ReadLine());

            // calc prices
            double priceOfSugar = priceOfFlourPerKilogram * 0.75;
            double priceOfEggshells = priceOfFlourPerKilogram * 1.1;
            double priceOfYeastPackages = priceOfSugar * 0.2;

            // calc sum

            double sumOfProducts = kilogramsOfFlour * priceOfFlourPerKilogram;
            sumOfProducts += kilogramsOfSugar * priceOfSugar;
            sumOfProducts += numberOfEggshells * priceOfEggshells;
            sumOfProducts += yeastPackages * priceOfYeastPackages;

            // print result
            Console.WriteLine($"{sumOfProducts:f2}");
        }
    }
}
