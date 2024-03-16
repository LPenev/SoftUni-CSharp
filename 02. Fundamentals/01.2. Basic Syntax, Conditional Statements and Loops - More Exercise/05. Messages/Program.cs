using System;

namespace messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int typeCounter = int.Parse(Console.ReadLine());
            int charIndex = 0;
            string message = "";

            for (int i = typeCounter; i > 0; i--)
            {
                string input = Console.ReadLine();

                int lenghtInput = input.Length;
                int digit = int.Parse(input[0].ToString());

                int offset = (digit - 2) * 3;
    
                if (offset == -6)
                {
                    charIndex = 32;
                }
                else
                {
                    if (digit == 8 || digit == 9) { offset++; }

                    charIndex = offset + lenghtInput - 1 + 97;
                }

                message += (char)charIndex;
                //Console.Write((char)charIndex);
            }
            Console.WriteLine(message);
        }
    }
}