using System;

namespace multiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int i = 1;
            while (i <= 10)
            {
                Console.WriteLine("{0} X {1} = {2}", number, i, number * i);
                i++;
            }
        }
    }
}