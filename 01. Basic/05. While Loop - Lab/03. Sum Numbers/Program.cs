using System;

namespace sumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // read from console
            int startNumer = int.Parse(Console.ReadLine());
            //int input = int.Parse(Console.ReadLine());
            int sum = 0;
            // while loop
            while(startNumer > sum)
            {
                sum += int.Parse(Console.ReadLine());
            }
            // print result
            Console.WriteLine(sum);
        }
    }
}