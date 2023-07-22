using System;
using System.Diagnostics.CodeAnalysis;

namespace roomPainting
{
    class Program
    {
        static void Main(string[] args)
        {
            // read from console
            int numberCansPaint = int.Parse(Console.ReadLine());
            int numberWallpaperRolls = int.Parse(Console.ReadLine());
            double priceOfPairGloves = double.Parse(Console.ReadLine());
            double priceBrush = double.Parse(Console.ReadLine());

            // calculations
            double sumPaint = numberCansPaint * 21.5;
            double sumWallpaperRolls = numberWallpaperRolls * 5.2;
            double sumGloves = Math.Ceiling(numberWallpaperRolls * 0.35) * priceOfPairGloves;
            double sumBursh = Math.Floor(numberCansPaint * 0.48) * priceBrush;
            double sumDelivery = (sumPaint + sumWallpaperRolls + sumGloves + sumBursh) / 15;

            // print result
            Console.WriteLine($"This delivery will cost {sumDelivery:f2} lv.");
        }
    }
}