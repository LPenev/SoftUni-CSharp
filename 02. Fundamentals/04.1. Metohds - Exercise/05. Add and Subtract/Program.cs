using System.Data;

namespace _1105._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputA = int.Parse(Console.ReadLine());
            int inputB = int.Parse(Console.ReadLine());
            int inputC = int.Parse(Console.ReadLine());

            int sumAB = SumOfTwo(inputA, inputB);
            int result = SubtractOfTwo(sumAB, inputC);
            Console.WriteLine(result);
        }

        static int SumOfTwo(int valueA, int valueB)
        {
            int result = valueA + valueB;
            return result;
        }

        static int SubtractOfTwo(int valueA, int valueB)
        {
            int result = valueA - valueB;
            return result;
        }
    }
}