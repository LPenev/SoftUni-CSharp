using System;

namespace coffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables

            // read from console
            string drink = Console.ReadLine();
            string sugar = Console.ReadLine();
            int numberDrinks = int.Parse(Console.ReadLine());
            double sum = 0;
            // calculation
            switch (drink)
            {
                case "Espresso":
                    if (sugar == "Without") { sum = numberDrinks * 0.90; }
                    else if(sugar == "Normal") { sum = numberDrinks * 1; }
                    else if (sugar == "Extra") { sum = numberDrinks * 1.2; }

                    break;
                case "Cappuccino":
                    if (sugar == "Without") { sum = numberDrinks * 1; }
                    else if (sugar == "Normal") { sum = numberDrinks * 1.2; }
                    else if (sugar == "Extra") { sum = numberDrinks * 1.6; }
                    break;
                case "Tea":
                    if (sugar == "Without") { sum = numberDrinks * 0.5; }
                    else if (sugar == "Normal") { sum = numberDrinks * 0.6; }
                    else if (sugar == "Extra") { sum = numberDrinks * 0.7; }
                    break;
            }

            // discounts
            if(sugar == "Without") { sum *= 0.65; }
            if (drink == "Espresso" && numberDrinks >= 5 ) { sum *= 0.75; }
            if(sum>15) { sum *= 0.8; }

            // print result
            Console.WriteLine($"You bought {numberDrinks} cups of {drink} for {sum:f2} lv.");

        }
    }
}