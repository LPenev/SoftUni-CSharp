namespace _08._Number_sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read from console
            int n = int.Parse(Console.ReadLine());
            int y, numMin = int.MaxValue, numMax = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                y = int.Parse(Console.ReadLine());
                if (y < numMin) numMin = y;
                if (y > numMax) numMax = y;
            }
            // print result
            Console.WriteLine($"Max number: {numMax}");
            Console.WriteLine($"Min number: {numMin}");
        }
    }
}
