using System;

namespace equalSumsEvenOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            // read from console
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            // for loop all number between first und second
            for (int i = first; i <= second; i++)
            {
                string current = i.ToString();
                int sumOdd = int.Parse(current.Substring(0, 1)) + int.Parse(current.Substring(2, 1)) + int.Parse(current.Substring(4, 1));
                int sumEven = int.Parse(current.Substring(1, 1)) + int.Parse(current.Substring(3, 1)) + int.Parse(current.Substring(5, 1));
                if (sumEven == sumOdd) { Console.Write(i + " "); }
            }
        }
    }
}