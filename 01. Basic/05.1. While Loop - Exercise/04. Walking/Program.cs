using System;

namespace walking
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            int stepsNorm = 10000;
            int stepsSum = 0;
            // read steps from console
            string input;

            while( stepsNorm > stepsSum )
            {
                input = Console.ReadLine();
                if ( input == "Going home")
                {
                    stepsSum += int.Parse(Console.ReadLine());
                    break;
                }
                stepsSum += int.Parse(input);
            }

            // print result
            if(stepsNorm > stepsSum)
            {
                Console.WriteLine($"{stepsNorm-stepsSum} more steps to reach goal.");
            }
            else
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{stepsSum-stepsNorm} steps over the goal!");
            }
        }
    }
}