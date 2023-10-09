using System;

namespace _1106._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PrintsCharacterAtMiddle(input);
        }

        static void PrintsCharacterAtMiddle(string inputedString)
        {
            if (inputedString.Length%2 == 0)
            {
                int startStr = inputedString.Length / 2 - 1;
                Console.WriteLine($"{inputedString[startStr]}{inputedString[startStr + 1]}");
            } else
            {
                int startStr = inputedString.Length / 2;
                Console.WriteLine(inputedString[startStr]);
            }
        }
    }
}