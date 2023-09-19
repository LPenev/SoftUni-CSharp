using System;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalPrice = 0;
            double price = 0;
            int countOrders = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOrders; i++)
            {
                double capsulePrice = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsuleCount = int.Parse(Console.ReadLine());

                price = days * capsuleCount * capsulePrice;
                totalPrice += price;

                Console.WriteLine($"The price for the coffee is: ${price:f2}");
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}