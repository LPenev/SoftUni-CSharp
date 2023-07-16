using System;

namespace grandpaStavri
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            double totalAmountOfBrandy = 0;
            double sumOfDegreesForLiterOfBrandy = 0;

            // read from console
            int numberDays = int.Parse(Console.ReadLine());
            // calclations
            for(int i = 0; i < numberDays; i++)
            {
                double amountOfBrandy = double.Parse(Console.ReadLine());
                double degreeOfDrink = double.Parse(Console.ReadLine());
                totalAmountOfBrandy += amountOfBrandy;
                sumOfDegreesForLiterOfBrandy += amountOfBrandy * degreeOfDrink;
            }
            double avgOfDegreesOfBrandy = sumOfDegreesForLiterOfBrandy / totalAmountOfBrandy;

            // print result
            Console.WriteLine($"Liter: {totalAmountOfBrandy:f2}");
            Console.WriteLine($"Degrees: {avgOfDegreesOfBrandy:f2}");
            if(avgOfDegreesOfBrandy < 38)
            {
                Console.WriteLine("Not good, you should baking!");
            }else if (avgOfDegreesOfBrandy <= 42)
            {
                Console.WriteLine("Super!");
            }
            else
            {
                Console.WriteLine("Dilution with distilled water!");
            }
        }
    }
}