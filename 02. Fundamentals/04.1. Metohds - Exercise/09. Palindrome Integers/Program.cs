using Microsoft.VisualBasic;

namespace _1109._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while(input != "END")
            {
                Console.WriteLine(checkPalindrome(input));

                input = Console.ReadLine();
            }
        }

        static bool checkPalindrome(string input)
        {
            bool result = false;
            if (input[0] == input[input.Length-1])
            {
                result = true;
            }

            return result;
        }
    }
}