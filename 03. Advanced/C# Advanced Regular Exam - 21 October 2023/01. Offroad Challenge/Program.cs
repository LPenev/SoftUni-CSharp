using System;

namespace _01._Offroad_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> fuel = new(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
            .ToArray());

            Queue<int> consumptionIndexes = new(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> quantities = new(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            bool isNotReached = false;
            int reachedAtitude = 0;

            for (int atitude = 1; 0 < fuel.Count; atitude++)
            {

                int currentFuel = fuel.Pop();
                int currentIndex = consumptionIndexes.Dequeue();
                int currentQuantities = quantities.Dequeue();

                if (currentFuel - currentIndex < currentQuantities)
                {
                    Console.WriteLine($"John did not reach: Altitude {atitude}");
                    isNotReached = true;
                    break;
                }

                Console.WriteLine($"John has reached: Altitude {atitude}");
                reachedAtitude = atitude;
            }

            if (isNotReached)
            {
                Console.WriteLine("John failed to reach the top.");
                Console.Write("Reached altitudes: ");
                for (int count = 1; count <= reachedAtitude; count++)
                {
                    Console.Write($"Altitude {count}");
                    if(count < reachedAtitude)
                    {
                        Console.Write(", ");
                    }
                }
            }
            else
            {
                Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
            }
        }
    }
}
