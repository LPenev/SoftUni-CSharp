namespace _07._Working_Hours
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read from console
            int hour = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();
            // calc
            if (day != "Sunday" && hour >= 10 && hour <= 18)
            {
                Console.WriteLine("open");
            }
            else
            {
                Console.WriteLine("closed");
            }
        }
    }
}
