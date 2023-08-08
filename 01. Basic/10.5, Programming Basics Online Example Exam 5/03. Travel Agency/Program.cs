using System;

namespace travelAgency
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables
            double sum = 0;
            bool isBad = false;
            //read from console
            string nameCity = Console.ReadLine();
            string typePacket = Console.ReadLine();
            string vip = Console.ReadLine();
            int daysOfStay = int.Parse(Console.ReadLine());

            //calculation

            if(daysOfStay > 7) { daysOfStay--; }

            switch ( nameCity )
            {
                case "Bansko":
                case "Borovets":
                    if (typePacket == "withEquipment") { 
                        sum = daysOfStay * 100;
                        if (vip == "yes") { sum *= 0.9; }
                    } 
                    else if(typePacket == "noEquipment")
                    { 
                        sum = daysOfStay * 80;
                        if (vip == "yes") { sum *= 0.95; }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        isBad = true;
                    }
                    break;

                case "Varna":
                case "Burgas":
                    if(typePacket == "withBreakfast")
                    {
                        sum = daysOfStay * 130;
                        if (vip == "yes") { sum *= 0.88; }
                    }
                    else if(typePacket == "noBreakfast")
                    {
                        sum = daysOfStay * 100;
                        if (vip == "yes") { sum *= 0.93; }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        isBad = true;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    isBad= true;
                    break;
            }

            //print result
            if (isBad) { }
            else if (daysOfStay < 1) { Console.WriteLine("Days must be positive number!"); }
            else
            {
                Console.WriteLine($"The price is {sum:f2}lv! Have a nice time!");
            }
        }
    }
}