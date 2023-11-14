using System.Security;

namespace _108._Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputArray = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
         
            decimal result = 0;
         
            foreach (string current in inputArray)
            {
                decimal currentSum = 0;
                int startIndex = 0;
                int endIndex = current.Length - 1;
                char Letter1 = current[0];
                char Letter2 = current[endIndex];

                decimal number = decimal.Parse(current.Substring(startIndex + 1, endIndex - 1));

                if (char.IsUpper(Letter1))
                {
                    currentSum = number / ((int)Letter1 - 64);
                }
                else
                {
                    currentSum = number * ((int)Letter1 - 96);
                }

                if(char.IsUpper(Letter2))
                {
                    currentSum -= ((int)Letter2 - 64);
                }
                else
                {
                    currentSum += ((int)Letter2 - 96);
                }

                result += currentSum;
            }

            Console.WriteLine($"{result:f2}");
        }
    }
}