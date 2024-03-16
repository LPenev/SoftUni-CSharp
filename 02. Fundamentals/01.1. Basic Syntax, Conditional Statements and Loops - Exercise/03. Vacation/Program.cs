using System;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // read from console
            int countPeople = int.Parse(Console.ReadLine());
            string TypeGroup = Console.ReadLine();
            string day = Console.ReadLine();

            double price = 0;
            double totalPrice = 0;

            // calculation
            switch (TypeGroup)
            {
                case "Students":
                    if (day == "Friday") { price = 8.45; }
                    else if (day == "Saturday") { price = 9.8; }
                    else { price = 10.46; }

                    totalPrice = price * countPeople;
                    
                    if(countPeople >= 30)
                    {
                        totalPrice *= 0.85;
                    }
                    break;
                case "Business":
                    if(day == "Friday") { price = 10.90; }
                    else if(day == "Saturday") { price = 15.60; }
                    else { price = 16; }
                    
                    totalPrice = price * countPeople;

                    if (countPeople >= 100)
                    {
                        totalPrice -= price * 10;
                    }
                    break;
                case "Regular":
                    if(day == "Friday") { price = 15; }
                    else if(day == "Saturday") { price = 20; }
                    else { price = 22.50; }

                    totalPrice = price * countPeople;
                    
                    if(countPeople >= 10 && countPeople <= 20)
                    {
                        totalPrice *= 0.95;
                    }
                    break;
            }
            // print result
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}