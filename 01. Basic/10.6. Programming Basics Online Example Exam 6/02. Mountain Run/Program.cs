using System;

namespace mountainRum
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            double sumTimeSecunde = 0;
            // read from console
            double recordTime = double.Parse(Console.ReadLine());
            double PathLenght = double.Parse(Console.ReadLine());
            double timeProMeter = double.Parse(Console.ReadLine());

            // calc
            sumTimeSecunde = PathLenght * timeProMeter;
            sumTimeSecunde += Math.Floor((PathLenght / 50)) * 30;

            if (recordTime > sumTimeSecunde)
            {
                Console.WriteLine($"Yes! The new record is {sumTimeSecunde:f2} seconds.");
            }else
            {
                Console.WriteLine($"No! He was {sumTimeSecunde- recordTime:f2} seconds slower.");
            }
        }
    }
}