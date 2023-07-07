namespace _08._On_Time_for_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read from console
            int hourExam = int.Parse(Console.ReadLine());
            int minuteExam = int.Parse(Console.ReadLine());
            int hourArrival = int.Parse(Console.ReadLine());
            int minuteArrival = int.Parse(Console.ReadLine());


            // Calc
            int timeCalc = (hourExam * 60 + minuteExam) - (hourArrival * 60 + minuteArrival);
            int hour = (int)Math.Floor(Math.Abs((double)timeCalc / 60));
            int min = (Math.Abs(timeCalc)) % 60;

            // Show result
            // On time
            if (timeCalc == 0)
            {
                Console.WriteLine("On time");
            }
            // On time
            else if (timeCalc > 0)
            {
                if (timeCalc <= 30)
                {
                    Console.WriteLine("On time");
                    Console.WriteLine($"{min} minutes before the start");

                }
                else
                {
                    // Early

                    Console.WriteLine("Early");
                    if (timeCalc >= 60)
                    {
                        if (min < 10)
                        {
                            Console.Write($"{hour}:0{min} hours before the start");
                        }
                        else
                        {
                            Console.Write($"{hour}:{min} hours before the start");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{min} minutes before the start");
                    }
                }
            }
            // Late
            else
            {
                Console.WriteLine("Late");

                if (hour > 0)
                {
                    if (min < 10)
                    {
                        Console.Write($"{hour}:0{min} hours after the start");
                    }
                    else
                    {
                        Console.Write($"{hour}:{min} hours after the start");
                    }
                }
                else
                {
                    Console.WriteLine($"{min} minutes after the start");
                }
            }
        }
    }
}
