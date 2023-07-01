using System;

namespace readText
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            string input;

            // while loop
            while (true)
            {
                // read from console
                input = Console.ReadLine();
                if(input == "Stop")
                {
                    break;
                }
                Console.WriteLine(input);
            }

        }
    }
}