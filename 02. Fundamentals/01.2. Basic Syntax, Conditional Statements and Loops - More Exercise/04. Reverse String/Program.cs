using System;

namespace reverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string newString = "";

            for (int i = input.Length-1; i >= 0 ; i--)
            {
                newString += input[i];
            }
            Console.WriteLine(newString);
        }
    }
}