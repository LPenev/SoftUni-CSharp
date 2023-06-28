namespace _01._Sum_Seconds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input times in Seconds
            int time1 = int.Parse(Console.ReadLine());
            int time2 = int.Parse(Console.ReadLine());
            int time3 = int.Parse(Console.ReadLine());

            // Calc
            int sumTimes = time1 + time2 + time3;
            int hours = sumTimes / 60;
            int minutes = sumTimes % 60;
            // Print result
            Console.WriteLine($"{hours}:{minutes:d2}");
        }
    }
}
