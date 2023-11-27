using System.Runtime.ConstrainedExecution;

namespace _2._01._SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int employer1StudentsPerHour = int.Parse(Console.ReadLine());
            int employer2StudentsPerHour = int.Parse(Console.ReadLine());
            int employer3StudentsPerHour = int.Parse(Console.ReadLine());

            int studentsCount = int.Parse(Console.ReadLine());
            int workHours = 3;
            int pauseHours = 1;

            int StudentsPerHourProcessed = employer1StudentsPerHour + employer2StudentsPerHour + employer3StudentsPerHour;

            double needHoursToProcessed = (double)studentsCount / StudentsPerHourProcessed;
            double hours = Math.Ceiling(needHoursToProcessed);
           
            if (hours > workHours)
            {
                if (hours % workHours == 0)
                {
                    hours += Math.Floor((hours / workHours - 1) * pauseHours);
                }
                else
                {
                    hours += Math.Floor((hours / workHours) * pauseHours);
                }
            }
            Console.WriteLine("Time needed: {0}h.",hours);
        }
    }
}