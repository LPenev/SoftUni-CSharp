using System;

namespace minNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            int minNum = int.MaxValue;
            int inputNum;
            // read string from console
            string input = Console.ReadLine();

            // while loop bis Stop
            while (input != "Stop")
            {
                inputNum = int.Parse(input);
                if (minNum > inputNum)
                {
                    minNum = inputNum;
                }
                input = Console.ReadLine();
            }
            // print result
            Console.WriteLine(minNum);
        }
    }
}