using System;

namespace oldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            string book = Console.ReadLine();
            string input = Console.ReadLine();

            while ( book != input )
            {
                if( input == "No More Books")
                {
                    book = input;
                    break;
                }
                input = Console.ReadLine();
                i++;
            }
            if( book == "No More Books")
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {i} books.");
            }
            else
            {
                Console.WriteLine($"You checked {i} books and found it.");
            }

        }
    }
}