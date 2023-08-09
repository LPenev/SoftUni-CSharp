using System;

namespace renovation
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            int sumPaint = 0;
            // read from console
            int wallHeight = int.Parse(Console.ReadLine());
            int wallWidth = int.Parse(Console.ReadLine());
            double areaWindows = int.Parse(Console.ReadLine());

            // calculation
            double area = wallHeight * wallWidth * 4;
            double areaWalls = Math.Ceiling(area * (1 - areaWindows / 100 ));
            
            string input = Console.ReadLine();
            while(input != "Tired!")
            {
                sumPaint += int.Parse(input);
                if(sumPaint >= areaWalls) { break; }
                input = Console.ReadLine();
            }

            // print result
            if(input == "Tired!")
            {
                Console.WriteLine($"{areaWalls-sumPaint} quadratic m left.");
            }
            else if (sumPaint > areaWalls)
            {
                Console.WriteLine($"All walls are painted and you have {sumPaint-areaWalls} l paint left!");
            }else 
            {
                Console.WriteLine("All walls are painted! Great job, Pesho!"); 
            }
        }
    }
}