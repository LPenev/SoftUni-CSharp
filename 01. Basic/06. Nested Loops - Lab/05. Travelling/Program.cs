using System;
using System.Xml.Linq;

namespace Multiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // variable
            string input;
            string destination = "";
            decimal sum = 0;
            decimal budget = 1;
            bool isEnd = false;

            while (!isEnd)
            {
                if(sum >= budget)
                {
                    Console.WriteLine($"Going to {destination}!");
                    sum = 0;
                }
                // read from console destination und budget
                destination = Console.ReadLine();
                if( destination == "End")
                {
                    isEnd = true;
                    break;
                }

                budget = decimal.Parse(Console.ReadLine());

                while (sum < budget)
                {
                    input = Console.ReadLine();
                    if (input == "End")
                    {
                        isEnd = true;
                        break;
                    }
                    sum += decimal.Parse(input);
                }
            }
        }
    }
}