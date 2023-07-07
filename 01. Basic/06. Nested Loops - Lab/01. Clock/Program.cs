using System;
using System.Security.Cryptography;

namespace building
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables

            for (int h = 0; h < 24; h++)
            {
                for (int m = 0; m < 60; m++)
                {
                    Console.WriteLine($"{h}:{m}");
                }
            }

        }
    }
}