using System.Security;

namespace _17._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfPumps = int.Parse(Console.ReadLine());
            Queue<(int, int)> routes = new();

            // read from Console und full Queue bis CountOfPumps is 0
            for (int i = 0; i < countOfPumps; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                int amountOfPetrol = input[0];
                int distanceToNextPump = input[1];

                routes.Enqueue((amountOfPetrol, distanceToNextPump));
            }

            int bestRoutCount = 0;
            int totalFuel = 0;

            // check for bestest route
            while (totalFuel == 0)
            { 
                foreach ((int, int) currentPump in routes)
                {
                    totalFuel += currentPump.Item1;
                    int nextPumpDistance = currentPump.Item2;


                    if (totalFuel - nextPumpDistance < 0)
                    {
                        bestRoutCount++;
                        totalFuel = 0;
                        routes.Enqueue(routes.Dequeue());
                        break;
                    }
                    totalFuel -= nextPumpDistance;
                }
            }

            // print result
            Console.WriteLine(bestRoutCount);
        }
    }
}
