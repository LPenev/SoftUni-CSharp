using System;

namespace specialNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int digit = int.Parse(Console.ReadLine());
            bool isSpecial = true;

            for (int i = 1111; i <= 9999; i++)
            {
                int m = i;
                for (int j = 1; j <= 4; j++)
                {
                    int k = m % 10;
                    if(k < 1 || digit%k != 0)
                    {
                        isSpecial = false;
                        break;
                    }
                    m /= 10;
                }

                if(isSpecial) { Console.Write(i + " "); }
                isSpecial = true;
            }
        }
    }
}