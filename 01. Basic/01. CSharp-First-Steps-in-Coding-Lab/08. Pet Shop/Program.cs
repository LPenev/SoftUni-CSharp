namespace _08._Pet_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variable
            int cats, dogs;
            double sum;
            // Read from Console
            dogs = int.Parse(Console.ReadLine());
            cats = int.Parse(Console.ReadLine());
            // Calc
            sum = cats * 4 + dogs * 2.50;
            // Show result
            Console.WriteLine($"{sum} lv.");
        }
    }
}
