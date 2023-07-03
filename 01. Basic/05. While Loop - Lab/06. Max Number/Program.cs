using System;

namespace maxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            int maxNumber = int.MinValue;
            int inputNumber = 0;
            // read from console
            string input = Console.ReadLine();
            while(input != "Stop")
            {
                inputNumber = int.Parse(input);
                if(inputNumber > maxNumber)
                {
                    maxNumber = inputNumber;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(maxNumber);
        }
    }
}