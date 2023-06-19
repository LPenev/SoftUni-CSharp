namespace _06._Number_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read from console
            int digit = int.Parse(Console.ReadLine());
            // calc
            if (digit <= 100 && digit >= -100 && digit != 0)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
