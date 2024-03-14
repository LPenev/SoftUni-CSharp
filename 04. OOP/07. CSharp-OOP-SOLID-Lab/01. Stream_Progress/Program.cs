using Models;
using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            Music musicFile = new Music("Iron Maiden", "Fear of the dark", 3, 20);

            StreamProgressInfo streamProgressInfo = new StreamProgressInfo(musicFile);
            Console.WriteLine(streamProgressInfo.CalculateCurrentPercent());
        }
    }
}
