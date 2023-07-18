namespace _02._Godzilla_vs._Kong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read from console
            decimal budgetForFilm = decimal.Parse(Console.ReadLine());
            int numberOfExtras = int.Parse(Console.ReadLine());
            decimal priceForClothingOfExtra = decimal.Parse(Console.ReadLine());

            // calcs
            decimal sumOfDecor = budgetForFilm * 0.1m;
            decimal sumOfClothing = numberOfExtras * priceForClothingOfExtra;
            
            // if number of Extras is more 150, 10% discount of Clothting
            if (numberOfExtras > 150)
            {
                sumOfClothing *= 0.9m;
            }

            decimal sum = budgetForFilm - sumOfDecor - sumOfClothing;

            // print result
            if (sum < 0)
            {
                sum *= -1m;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {sum:f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {sum:f2} leva left.");
            }
        }
    }
}
