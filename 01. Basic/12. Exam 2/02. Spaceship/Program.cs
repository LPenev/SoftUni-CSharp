using System;

namespace spaceShip
{
    class Program
    {
        static void Main(string[] args)
        {
            // read from console
            double widthShip = double.Parse(Console.ReadLine());
            double lengthShip = double.Parse(Console.ReadLine());
            double heightShip = double.Parse(Console.ReadLine());
            double averageHeightOfAstronauts = double.Parse(Console.ReadLine());

            // calculations
            double volumeOfShip = widthShip * lengthShip * heightShip;
            double volumeOfAustronautsRoom = (averageHeightOfAstronauts + 0.40) * 2 * 2;
            double numberOfAustonauts = Math.Floor(volumeOfShip / volumeOfAustronautsRoom);

            // print result
            if(numberOfAustonauts < 3 ) 
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else if( numberOfAustonauts <= 10 )
            {
                Console.WriteLine($"The spacecraft holds {numberOfAustonauts:f0} astronauts.");
            }
            else if( numberOfAustonauts > 10)
            {
                Console.WriteLine("The spacecraft is too big.");
            }
        }
    }
}