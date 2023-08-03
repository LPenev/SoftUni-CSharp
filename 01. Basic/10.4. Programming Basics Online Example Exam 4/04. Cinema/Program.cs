using System;

namespace cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacityHall = int.Parse(Console.ReadLine());
            string people = Console.ReadLine();
            int sumPeople = 0;
            double sum = 0;

            while ( people != "Movie time!")
            {
                int currentPeople = int.Parse(people);
                sumPeople += currentPeople;

                // check hall capacity    
                if(capacityHall < sumPeople){ 
                    Console.WriteLine("The cinema is full.");
                    break;
                }

                // sum of Tickets
                sum += currentPeople * 5;
                // discount
                if (currentPeople % 3 == 0)
                {
                    sum -= 5;
                }
                // read from console
                people = Console.ReadLine();
            }
            // print result
            if(capacityHall >= sumPeople)
            {
                int freeseats = capacityHall - sumPeople;
                Console.WriteLine($"There are {freeseats} seats left in the cinema.");
            }
            Console.WriteLine($"Cinema income - {sum} lv.");
        }
    }
}