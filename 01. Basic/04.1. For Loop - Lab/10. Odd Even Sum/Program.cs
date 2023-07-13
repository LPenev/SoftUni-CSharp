namespace _10._Odd_Even_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read from console
            int n = int.Parse(Console.ReadLine());
            int y = 0;
            double sumOdd = 0;
            double sumEven = 0;

            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0) sumEven += int.Parse(Console.ReadLine());
                else sumOdd += int.Parse(Console.ReadLine());
            }
            if (sumOdd == sumEven) Console.WriteLine("Yes\nSum = " + sumOdd);
            else Console.WriteLine("No\nDiff = " + Math.Abs(sumEven - sumOdd));
        }
    }
}
