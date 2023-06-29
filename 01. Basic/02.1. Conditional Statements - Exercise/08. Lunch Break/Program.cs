namespace _08._Lunch_Break
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Input variables
            string nameSerial = Console.ReadLine();
            int serialDuration = int.Parse(Console.ReadLine());
            double restDuration = int.Parse(Console.ReadLine());

            //Calc
            double launchTime = restDuration / 8;
            double restTime = restDuration / 4;
            double freeTime = restDuration - launchTime - restTime;

            // Show result
            if (freeTime >= serialDuration)
            {
                restTime = Math.Ceiling(freeTime - serialDuration);
                Console.WriteLine($"You have enough time to watch {nameSerial} and left with {restTime} minutes free time.");

            }
            else
            {
                restTime = Math.Ceiling(serialDuration - freeTime);
                Console.WriteLine($"You don't have enough time to watch {nameSerial}, you need {restTime} more minutes.");
            }
        }
    }
}
