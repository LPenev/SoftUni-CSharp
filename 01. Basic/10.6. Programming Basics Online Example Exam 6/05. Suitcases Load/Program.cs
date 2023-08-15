using System;

namespace suitcasesLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            int sumSuitcases = 0;
            int suitcasesCounter = 0;

            // read from console
            double trunkCapacity = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            // calc
            while ( input != "End" )
            {
                // incr. suitcases counter
                suitcasesCounter++;
                // convert input to double
                double suitcaseVolume = double.Parse(input);
                // increase volume of every 3 suitcase with 10%
                if(suitcasesCounter == 3) 
                { 
                    suitcaseVolume *= 1.1;
                    suitcasesCounter = 0; 
                }
                if(trunkCapacity < suitcaseVolume) 
                {
                    Console.WriteLine("No more space!");
                    break;
                }
                trunkCapacity -= suitcaseVolume;
                sumSuitcases++;
                // read from console
                input = Console.ReadLine();
            }

            // print result
            if(input == "End") 
            { 
                Console.WriteLine("Congratulations! All suitcases are loaded!"); 
            }
            
            Console.WriteLine($"Statistic: {sumSuitcases} suitcases loaded.");
        }
    }
}