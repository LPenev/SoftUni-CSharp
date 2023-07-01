namespace _04._Personal_Titles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read from console
            double age = double.Parse(Console.ReadLine());
            string gener = Console.ReadLine();

            // calc
            if (age >= 16)
            {
                if (gener == "m")
                {
                    Console.WriteLine("Mr.");
                }
                else
                {
                    Console.WriteLine("Ms.");
                }
            }
            else
            {
                if (gener == "m")
                {
                    Console.WriteLine("Master");
                }
                else
                {
                    Console.WriteLine("Miss");
                }
            }
        }
    }
}
