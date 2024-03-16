using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if(input == "Start")
                {
                    break;
                }
                
                double current = double.Parse(input);

                if(current == 0.1 || current == 0.2 || current == 0.5 || current == 1 || current ==2)
                {
                    balance += current;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {current}");
                }
            }
            while (true)
            {
                double price = 0;
                string input = Console.ReadLine();
                if(input =="End") { break; }
                
                switch (input)
                {
                    case "Nuts":
                        price = 2;
                        break;
                    case "Water":
                        price = 0.7;
                        break;
                    case "Crisps":
                        price = 1.5;
                        break;
                    case "Soda":
                        price = 0.8;
                        break;
                    case "Coke":
                        price = 1;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        continue;
                }
                if (balance >= price)
                {
                    balance -= price;
                    Console.WriteLine("Purchased {0}", input.ToLower());
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }
            }
            Console.WriteLine("Change: {0:f2}", balance);
        }
    }
}