using System;

namespace changeBureau
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            int bitcoinToBGN = 1168;
            double chinaJoanaToUSD = 0.15; // USD
            double usdToBGN = 1.76; // BGN
            double euroToBGN = 1.95; // BGN
            // read from console
            int bitcoin = int.Parse(Console.ReadLine());
            double chinaJoana = double.Parse(Console.ReadLine());
            double comision = double.Parse(Console.ReadLine());
            // calc
            double sumBGN = bitcoinToBGN * bitcoin;
            sumBGN += (chinaJoana * chinaJoanaToUSD) * usdToBGN;
            double sumEuro = sumBGN / euroToBGN;
            sumEuro -= sumEuro * (comision / 100);

            // print result
            Console.WriteLine($"{sumEuro:f2}");
        }
    }
}