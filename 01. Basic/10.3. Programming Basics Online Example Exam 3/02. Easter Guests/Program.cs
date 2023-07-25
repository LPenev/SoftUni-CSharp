namespace _02._Easter_Guests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // set constants 
            const decimal PriceOfKozunak = 4;
            const decimal PriceOfEgg = 0.45m;

            // read inputs from console
            int numberOfGuests = int.Parse(Console.ReadLine());
            decimal budget = decimal.Parse(Console.ReadLine());

            // calcs
            decimal neededKozunaks = Math.Ceiling( (decimal)numberOfGuests / 3 );
            int neededOfEggs = numberOfGuests * 2;

            decimal sum = neededKozunaks * PriceOfKozunak;
            sum += neededOfEggs * PriceOfEgg;

            if (budget >= sum)
            {
                Console.WriteLine($"Lyubo bought {neededKozunaks} Easter bread and {neededOfEggs} eggs.");
                Console.WriteLine($"He has {budget-sum:f2} lv. left.");
            }
            else
            {
                Console.WriteLine("Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {sum-budget:f2} lv. more.");
            }
        }
    }
}
