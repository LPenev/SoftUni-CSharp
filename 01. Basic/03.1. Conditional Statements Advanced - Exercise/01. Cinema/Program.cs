namespace _01._Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read from console
            string type = Console.ReadLine();
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            double income = 0;

            // calc
            if (type == "Premiere")
            {
                income = c * r * 12;
            }
            else if (type == "Normal")
            {
                income = c * r * 7.50;
            }
            else if (type == "Discount")
            {
                income = c * r * 5;
            }
            Console.WriteLine($"{income:f2} leva");
        }
    }
}
