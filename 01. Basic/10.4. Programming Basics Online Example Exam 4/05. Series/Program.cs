using System;

namespace series
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            string nameOfSerial = "";
            double priceOfSerial = 0.0;
            double sum = 0;

            // read rom console
            double budget = double.Parse(Console.ReadLine());
            int numberSerials = int.Parse(Console.ReadLine());

            for(int i = 0; i < numberSerials; i++)
            {
                nameOfSerial = Console.ReadLine();
                priceOfSerial = double.Parse(Console.ReadLine());
                
                switch(nameOfSerial)
                {
                    case "Thrones":
                        // 50% discount
                        sum += priceOfSerial * 0.5;
                        break;
                    case "Lucifer":
                        // 40% discount
                        sum += priceOfSerial * 0.6;
                        break;
                    case "Protector":
                        // 30% discount
                        sum += priceOfSerial * 0.7;
                        break;
                    case "TotalDrama":
                        // 20% discount
                        sum += priceOfSerial * 0.8;
                        break;
                    case "Area":
                        // 10% discount
                        sum += priceOfSerial * 0.9;
                        break;
                    default:
                        sum += priceOfSerial;
                        break;
                }
            }
            // print result
            if (sum <= budget)
            {
                Console.WriteLine($"You bought all the series and left with {budget-sum:f2} lv.");
            }
            else
            {
                Console.WriteLine($"You need {sum-budget:f2} lv. more to buy the series!");
            }
        }
    }
}