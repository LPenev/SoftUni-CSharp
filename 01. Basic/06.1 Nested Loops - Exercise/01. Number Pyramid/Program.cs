using System;

namespace numberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            int digit = 0;
            int numPyramid = int.Parse(Console.ReadLine());

            while (numPyramid > digit)
            {
                counter++;
                for(int i = 0; i < counter ; i++)
                {
                    if ( numPyramid == digit )
                    {
                        break;
                    }

                    digit++;
                    Console.Write(digit + " ");
                }
                Console.WriteLine("");
            }
        }
    }
}