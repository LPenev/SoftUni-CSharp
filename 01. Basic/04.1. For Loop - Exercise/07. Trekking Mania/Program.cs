using System;

namespace TrekkinMania
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            double musala = 0;
            double monblan = 0;
            double kilimandjo = 0;
            double k2 = 0;
            double everest = 0;

            // read from console
            int numberGroups = int.Parse(Console.ReadLine());

            // calc people pro top
            for (int i = 0; i < numberGroups; i++)
            {
                int countPeople = int.Parse(Console.ReadLine());
                if(countPeople <= 5)    musala += countPeople;
                else if(countPeople <= 12)  monblan += countPeople;
                else if (countPeople <= 25) kilimandjo += countPeople;
                else if( countPeople <= 40) k2 += countPeople;
                else everest += countPeople;
            }

            // print result
            double sumPeople = musala + monblan + kilimandjo + k2 + everest;
            Console.WriteLine($"{(musala / sumPeople) * 100:f2}%");
            Console.WriteLine($"{(monblan / sumPeople) * 100:f2}%");
            Console.WriteLine($"{(kilimandjo / sumPeople) * 100:f2}%");
            Console.WriteLine($"{(k2 / sumPeople) * 100:f2}%");
            Console.WriteLine($"{(everest / sumPeople) * 100:f2}%");

        }
    }
}