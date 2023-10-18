using System.Numerics;

namespace _02._Big_Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            FactorialPrint(input);
        }

        static void FactorialPrint(int count)
        {
            BigInteger factirial = 1;
            for (int i = 2; i <= count; i++)
            {
                factirial *= i;
            }
            Console.WriteLine(factirial);
        }
    }
}