using System.Diagnostics;

namespace _03._Aluminum_Joinery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // inputs 
            int numberOfWindows = int.Parse(Console.ReadLine());
            string typeOfWindowFrames = Console.ReadLine().Trim();
            string methodOfReceipt = Console.ReadLine().Trim();

            // init vars
            double unitPrice = 0;
            double discount = 1;
            double totalOrder = 0;

            // calculation
            if (numberOfWindows < 10)
            {
                Console.WriteLine("Invalid order");
                return;
            }


            switch (typeOfWindowFrames)
            {
                case "90X130":
                    unitPrice = 110;

                    if (numberOfWindows > 30 && numberOfWindows <= 60)
                    {
                        // -5%
                        discount = 0.95;
                    }
                    else if (numberOfWindows > 60)
                    {
                        // -8%
                        discount = 0.92;
                    }

                    break;
                case "100X150":
                    unitPrice = 140;
                    
                    if (numberOfWindows > 40 && numberOfWindows <= 80)
                    {
                        // -6%
                        discount = 0.94;
                    }
                    else if (numberOfWindows > 80)
                    {
                        // -10%
                        discount = 0.90;
                    }

                    break;
                case "130X180":
                    unitPrice = 190;
                    
                    if (numberOfWindows > 20 && numberOfWindows <= 50)
                    {
                        // -7%
                        discount = 0.93;
                    }
                    else if (numberOfWindows > 50)
                    {
                        // -12%
                        discount = 0.88;
                    }

                    break;
                case "200X300":
                    unitPrice = 250;
                    
                    if (numberOfWindows > 25 && numberOfWindows <= 50)
                    {
                        // -9%
                        discount = 0.91;
                    }
                    else if (numberOfWindows > 50)
                    {
                        // -14%
                        discount = 0.86;
                    }

                    break;
            }

            totalOrder = unitPrice * numberOfWindows;
            totalOrder *= discount;

            if (methodOfReceipt == "With delivery")
            {
                totalOrder += 60;
            }

            if(numberOfWindows > 99)
            {
                // -4%
                totalOrder *= 0.96;
            }

            // output
            Console.WriteLine($"{totalOrder:f2} BGN");
        }
    }
}
