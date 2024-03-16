using System;

namespace gamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            double totalSum = 0;
            while (currentBalance - totalSum > 0)
            {
                //if () { Console.WriteLine("Out of money!"); break; }

                double price = 0;
                string input = Console.ReadLine();
                if(input == "Game Time") { break; }
                switch (input)
                {
                    case "OutFall 4":
                        price = 39.99;
                        break;
                    case "CS: OG":
                        price = 15.99;
                        break;
                    case "Zplinter Zell":
                        price = 19.99;
                        break;
                    case "Honored 2":
                        price = 59.99;
                        break;
                    case "RoverWatch":
                        price = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        price = 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        continue;
                }
                if(currentBalance - totalSum >= price)
                {
                    totalSum += price;
                    Console.WriteLine($"Bought {input}");
                }
                else
                {
                    Console.WriteLine("Too Expensive");
                }

            }
            // print result
            if (currentBalance - totalSum <= 0) 
            {
                Console.WriteLine("Out of money!");
            }
            else
            {
                Console.WriteLine($"Total spent: ${totalSum:f2}. Remaining: ${currentBalance - totalSum:f2}");
            }
        }
    }
}