using System;
using System.Net.WebSockets;
using System.Runtime.InteropServices;

namespace moving
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            string input = "";
            // read from console
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            // calc room volume
            int volume = width * length * height;

            while (volume > 0)
            {
                input = Console.ReadLine();

                if (input == "Done")
                {
                    // print result
                    Console.WriteLine($"{volume} Cubic meters left.");
                    break;
                }
                volume -= int.Parse(input);
            }
            // print result 
            if ( input != "Done" ) Console.WriteLine($"No more free space! You need {Math.Abs(volume)} Cubic meters more.");
        }
    }
}