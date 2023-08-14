using System;

namespace TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            int numberOfPeopleInGroup = 0;
            int musala = 0;
            int monblan = 0;
            int klimandgo = 0;
            int k2 = 0;
            int everest = 0;
            int sumPeople = 0;

            // read from conlsole
            int numberOfGroupsOfClimbers = int.Parse(Console.ReadLine());

            // calc
            for (int i = 0; i < numberOfGroupsOfClimbers; i++)
            {
                numberOfPeopleInGroup = int.Parse(Console.ReadLine());
                if(numberOfPeopleInGroup <= 5)
                {
                    musala += numberOfPeopleInGroup;
                }else if(numberOfPeopleInGroup <= 12)
                {
                    monblan += numberOfPeopleInGroup;
                }else if(numberOfPeopleInGroup <= 25)
                {
                    klimandgo += numberOfPeopleInGroup;
                }else if( numberOfPeopleInGroup <= 40)
                {
                    k2 += numberOfPeopleInGroup;
                }
                else { everest += numberOfPeopleInGroup;}
                sumPeople += numberOfPeopleInGroup;
            }

            // calc percents
            double percentMusala = ((double)musala / sumPeople) * 100;
            double percentMonblan = ((double)monblan / sumPeople) * 100;
            double percentKlimandgo = ((double)klimandgo / sumPeople) * 100;
            double percentK2 = ((double)k2 / sumPeople) * 100;
            double percentEverest = ((double)everest / sumPeople) * 100;

            // print result
            Console.WriteLine($"{percentMusala:f2}%");
            Console.WriteLine($"{percentMonblan:f2}%");
            Console.WriteLine($"{percentKlimandgo:f2}%");
            Console.WriteLine($"{percentK2:f2}%");
            Console.WriteLine($"{percentEverest:f2}%");

        }
    }
}