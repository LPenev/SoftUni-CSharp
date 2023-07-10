using System;

namespace clock
{
    class Program
    {
        static void Main(string[] args)
        {
            // read from console
            int numberOfFloors = int.Parse(Console.ReadLine());
            int numberOfRooms = int.Parse(Console.ReadLine());

            for(int floor = numberOfFloors; floor >= 1; floor--)
            {
                for(int room = 0; room < numberOfRooms ; room++)
                {
                    if ( numberOfFloors == floor )
                    {
                        Console.Write($"L{floor}{room} ");
                    }
                    else if(floor%2 == 0)
                    {
                        Console.Write($"O{floor}{room} ");
                    }
                    else
                    {
                        Console.Write($"A{floor}{room} ");
                    }
                }

                Console.Write("\n");
            }
        }
    }
}