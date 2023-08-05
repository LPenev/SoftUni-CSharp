using System;

namespace movieTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            // read from console
            int a1 = int.Parse(Console.ReadLine());
            int a2 = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int n2 = n / 2;
            // 1 symbol
            for (int i = a1;  i < a2; i++)
            {
                if(i%2 != 0) {

                    char ch1 = Convert.ToChar(i);
                    int ch2 = 0; int ch3 = 0; int ch4 = 0;

                    // 2 symbol
                    for (int j = 1; j < n; j++)
                    {
                        ch2 = j;
                        // 3 symbol
                        for (int k = 1; k < n2; k++)
                        {
                            ch3 = k;

                            // 4 symbol
                            ch4 = (int)ch1;
                            int sumCh2to4 = ch2 + ch3 + ch4;
                            if (sumCh2to4 % 2 != 0)
                            {
                                Console.WriteLine($"{ch1}-{ch2}{ch3}{ch4}");
                            }
                        }
                    }

                }
            }

           // Console.WriteLine("{Символ 1}-{Символ 2}{Символ 3}{Символ  4}");
        }
    }
}