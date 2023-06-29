namespace _04._Toy_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read from Console
            // price of reise
            double priceReise = double.Parse(Console.ReadLine());
            // count of Puzle       Price 2.60lv
            int puzle = int.Parse(Console.ReadLine());
            // count of Speaking        Toy 3lv
            int speakingToy = int.Parse(Console.ReadLine());
            // count of plush Bear      4.10lv
            int plushBear = int.Parse(Console.ReadLine());
            // count of minion      price 8.20lv
            int minion = int.Parse(Console.ReadLine());
            // count of trucks      Price 2lv
            int trucks = int.Parse(Console.ReadLine());

            // calculate sum
            double sum = puzle * 2.6 + speakingToy * 3 + plushBear * 4.1 + minion * 8.2 + trucks * 2;
            int countToys = puzle + speakingToy + plushBear + minion + trucks;

            // check toys upper 50
            if (countToys >= 50)
            {
                sum -= sum * 0.25;
            }

            // izvajdane naem
            sum -= sum * 0.1;

            // sum - ekskurziata

            // print result
            if (sum < priceReise)
            {
                sum = priceReise - sum;
                Console.WriteLine($"Not enough money! {sum:f2} lv needed.");
            }
            else
            {
                sum = sum - priceReise;
                Console.WriteLine($"Yes! {sum:f2} lv left.");
            }
        }
    }
}
