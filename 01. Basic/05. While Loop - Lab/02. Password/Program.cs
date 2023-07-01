using System;

namespace password
{
    class Program
    {
        static void Main(string[] args)
        {
            // read from console
            string userName = Console.ReadLine();
            string password = Console.ReadLine();
            string input = Console.ReadLine();

            // while loop
            while (password != input)
            {
                input = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {userName}!");
        }
    }
}