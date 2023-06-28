using System;

namespace halfSumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            // read from console
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int numMax = int.MinValue;
            int readNum = 0;

            for(int i = 0; i < n; i++)
            {
                readNum = int.Parse(Console.ReadLine());
                sum += readNum;
                if(readNum > numMax) numMax = readNum;
            }
            sum = sum - numMax;
            if (sum == numMax) Console.WriteLine("Yes\nSum = " + sum);
            else Console.WriteLine("No\nDiff = " + Math.Abs(numMax - sum));
        }
    }
}