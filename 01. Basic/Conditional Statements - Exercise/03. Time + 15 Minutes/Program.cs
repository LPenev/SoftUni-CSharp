namespace _03._Time___15_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // input Hour and Minute
            int hour = int.Parse(Console.ReadLine());
            int minute = int.Parse(Console.ReadLine());
            // Calculate time + 15 min
            minute += 15;
            // Check
            if (minute > 59)
            {
                hour += 1;
                minute = minute - 60;
            }
            if (hour > 23) hour = 0;
            // Print result
            Console.WriteLine($"{hour}:{minute:d2}");
        }
    }
}
