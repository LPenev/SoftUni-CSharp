using System;

namespace sumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            int counter =0;
            // read from console
            int input = int.Parse(Console.ReadLine());

            for (int a = 0; a <= input; a++)
            {
                for( int b = 0; b <= input; b++)
                {
                    for (int c = 0; c <= input; c++)
                    {
                        if (a+b+c ==  input)
                        {
                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}